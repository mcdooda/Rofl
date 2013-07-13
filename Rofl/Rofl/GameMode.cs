using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using RoflCodeContent.levels.test.particles;
using RoflLib.utils.math;
using RoflLib.input;
using RoflCodeContent.characters;
using RoflLib.io.level;

namespace Rofl
{
    public class GameMode : AppMode
    {
        private List<Character> characters;
        private List<HitPoint> hitPoints;

        private SpriteFont damageSpriteFont;

        private Vector2 cameraCenter;
        private float cameraZoom;
        
        public GameMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
            : base(graphicsDevice, graphics, content)
        {
            characters = new List<Character>();
            hitPoints = new List<HitPoint>();
        }

        public override void Initialize()
        {
            base.Initialize();
            cameraCenter = Vector2.Zero;
            cameraZoom = 1;
        }

        public override void LoadContent()
        {
            LoadParticleEffects();
            LoadCharacters();
            LoadFonts();
            LoadLevel();
            base.LoadContent();
            renderer.AddUtilityTexture(content, "redsquare");
            renderer.AddUtilityTexture(content, "intersection");
        }

        private void LoadLevel()
        {
            LevelData levelData = content.Load<LevelData>("levels/test/level");
            level = levelData.GetLevel(content);
        }

        private void LoadParticleEffects()
        {
            ParticleEffect.Random = random;
            ParticleEffect.ParticleEffects = new Dictionary<string, ParticleEffect>();

            // level particles
            new RoflCodeContent.levels.test.particles.TestEffect(content);
            new RoflCodeContent.levels.plaguejungles.particles.PlagueEffect(content);

            // other particles
            new RoflCodeContent.effects.dust.DustEffect(content);
            new RoflCodeContent.effects.jumpwave.JumpWaveEffect(content);
        }

        private void LoadCharacters()
        {
            Color[] colors = new Color[] {
                Color.White,
                Color.YellowGreen,
                Color.PaleVioletRed,
                Color.DeepSkyBlue
            };

            InputDevice[] devices = new InputDevice[] {
                new KeyboardDevice(),
                new GamePadDevice(PlayerIndex.One),
                new GamePadDevice(PlayerIndex.Two),
                new GamePadDevice(PlayerIndex.Three),
                new GamePadDevice(PlayerIndex.Four)
            };

            int index = 0;
            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i].IsConnected())
                {
                    Character character = new Kennen(devices[i], new Vector2(-300 + i * 200, -100), content, colors[index], index);
                    character.WorldHitPoints = hitPoints;
                    characters.Add(character);
                    index++;
                }
            }

            for (float x = level.Bounds.Left; x < level.Bounds.Right; x += 200)
            {
                Character character = new Rabbit(new FakeResetDevice(), new Vector2(x, -100), content, new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()), index);
                character.WorldHitPoints = hitPoints;
                characters.Add(character);
                index++;
            }
        }

        private void LoadFonts()
        {
            damageSpriteFont = content.Load<SpriteFont>("fonts/damage");
        }

        public override void Update(GameTime gameTime)
        {
            level.UpdateEffects(gameTime);

            float cameraLeft = float.PositiveInfinity;
            float cameraRight = float.NegativeInfinity;
            float cameraTop = float.PositiveInfinity;
            float cameraBottom = float.NegativeInfinity;

            FloatRectangle levelBounds = level.Bounds;

            SeparateCharacters(gameTime); // called before character.Update to ensure that characters do not intersect with the level
            UpdateHitPoints(gameTime);

            int numDead = 0;
            foreach (Character character in characters)
            {
                character.Update(gameTime, level);

                if (!FloatRectangle.Intersect(levelBounds, character.BoundingRectangle))
                    character.Kill(gameTime);
                
                if (!character.Dead)
                {
                    if (character.Left < cameraLeft)
                        cameraLeft = character.Left;

                    if (character.Right > cameraRight)
                        cameraRight = character.Right;

                    if (character.Top < cameraTop)
                        cameraTop = character.Top;

                    if (character.Bottom > cameraBottom)
                        cameraBottom = character.Bottom;
                }
                else
                    numDead++;
            }

            if (numDead < characters.Count)
            {
                float margin = 200;
                cameraLeft -= margin;
                cameraRight += margin;
                cameraTop -= margin;
                cameraBottom += margin;

                if (cameraLeft < levelBounds.Left)
                    cameraLeft = levelBounds.Left;

                if (cameraRight > levelBounds.Right)
                    cameraRight = levelBounds.Right;

                if (cameraTop < levelBounds.Top)
                    cameraTop = levelBounds.Top;

                if (cameraBottom > levelBounds.Bottom)
                    cameraBottom = levelBounds.Bottom;

                Vector2 cameraDirection = new Vector2((cameraLeft + cameraRight) / 2, (cameraTop + cameraBottom) / 2);

                float zoomDirection = Math.Min(renderer.Width / (cameraRight - cameraLeft), renderer.Height / (cameraBottom - cameraTop));
                if (zoomDirection > 1.2f)
                    zoomDirection = 1.2f;

                Vector2 cameraMove = cameraDirection - cameraCenter;
                float moveDistanceSquared = cameraMove.LengthSquared();
                if (moveDistanceSquared != 0)
                {
                    cameraMove.Normalize();
                    cameraMove *= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (cameraMove.LengthSquared() > moveDistanceSquared)
                    {
                        cameraMove.Normalize();
                        cameraMove *= (float)Math.Sqrt(moveDistanceSquared);
                    }

                    cameraCenter += cameraMove;
                }

                float zoomMove = zoomDirection - cameraZoom;
                float zoomDistance = zoomMove;
                if (zoomDistance != 0)
                {
                    zoomMove = Math.Sign(zoomMove) * (float)gameTime.ElapsedGameTime.TotalSeconds / 2;

                    if (Math.Abs(zoomMove) > Math.Abs(zoomDistance))
                        zoomMove = zoomDistance;

                    cameraZoom += zoomMove;
                }
            }

            renderer.Center = cameraCenter;
            renderer.Zoom = cameraZoom;
        }

        private void SeparateCharacters(GameTime gameTime)
        {
            // two separations per character!
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Character character1 in characters)
            {
                if (!character1.Dead)
                {
                    foreach (Character character2 in characters)
                    {
                        if (!character2.Dead && character1.Index < character2.Index)
                        {
                            FloatRectangle overlappingRectangle = FloatRectangle.IntersectRectangle(character1.BoundingRectangle, character2.BoundingRectangle);
                            if (overlappingRectangle != null)
                            {
                                float speed = 0.012f;
                                float character1MoveX = (float)(overlappingRectangle.Width * character2.Weight / character1.Weight * elapsedTime * speed * character1.RunningSpeed);
                                float character2MoveX = (float)(overlappingRectangle.Width * character1.Weight / character2.Weight * elapsedTime * speed * character2.RunningSpeed);
                                if (character1.CenterX < character2.CenterX)
                                {
                                    character1.CenterX -= character1MoveX;
                                    character2.CenterX += character2MoveX;
                                }
                                else
                                {
                                    character1.CenterX += character1MoveX;
                                    character2.CenterX -= character2MoveX;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateHitPoints(GameTime gameTime)
        {
            double time = gameTime.TotalGameTime.TotalSeconds;
            for (int i = hitPoints.Count - 1; i >= 0; i--)
            {
                bool remove = false;
                HitPoint hitPoint = hitPoints[i];
                if (hitPoint.PopTime + hitPoint.Duration < time)
                {
                    remove = true;
                }
                else
                {
                    Circle hitPointCircle = new Circle(hitPoint.Position, hitPoint.Size);
                    foreach (Character character in characters)
                    {
                        if (hitPoint.Attacker != character)
                        {
                            if (!Intersection.BoxAndCircle(character.BoundingRectangle, hitPointCircle).IsEmpty)
                            {
                                character.DealDamage(10);
                                character.OnTheFloor = false;
                                character.Speed += hitPoint.Direction * 2 * (float)Math.Pow(2, character.Damage / 100);
                                remove = true;
                            }
                        }
                    }
                }

                if (remove)
                    hitPoints.RemoveAt(i);
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            renderer.BeginTextures();

            level.DrawWithCharacters(renderer, characters);

            //Texture2D levelCenterTexture = renderer.UtilityTextures["redsquare"];
            //renderer.DrawTexture(levelCenterTexture, Vector2.Zero, 0);

            foreach (Character character in characters)
                character.DrawDamage(renderer, damageSpriteFont);

            renderer.EndTextures();

            foreach (HitPoint hitPoint in hitPoints)
            {
                Circle circle = new Circle(hitPoint.Position, hitPoint.Size);
                circle.Color = Color.Red;
                renderer.DrawShape(circle);

                LineSegment line = new LineSegment(hitPoint.Position, hitPoint.Position + hitPoint.Direction);
                line.Color = Color.Red;
                renderer.DrawShape(line);
            }
        }

    }
}
