using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoflLib;
using RoflLib.input;
using RoflLib.io.character;
using RoflLib.io.level;
using RoflLib.utils.math;
using RumbleEditor.forms;

namespace RumbleEditor
{
    public class RumbleEditorMode : InputSwitchAppMode
    {
        private MainWindow mainWindow;
        public MainWindow MainWindow { set { mainWindow = value; } }

        private Character character;
        public Character Character { get { return character; } }

        private List<Character> characters;

        private SpriteFont damageSpriteFont;

        private GameTime lastUpdateTime;

        private Vector2 dragMousePosition;
        private Vector2 dragAnimationCenter;
        private bool dragging;

        private Vector2 resizeMousePosition;
        private bool resizingEstBound;
        private bool resizingWestBound;
        private bool resizingNorthBound;

        private bool saved;
        public bool Saved { get { return saved; } set { saved = value; } }

        private delegate void DrawEditor(GameTime gameTime);
        private Dictionary<string, DrawEditor> drawEditor;
        private DrawEditor currentDrawEditor;

        private delegate void UpdateEditor(GameTime gameTime);
        private Dictionary<string, UpdateEditor> updateEditor;
        private UpdateEditor currentUpdateEditor;

        private int attackLine;   // cursor y
        private int attackColumn; // cursor x
        private int attackBeginLine;
        private int attackBeginColumn;
        private int attackEndLine;
        private int attackEndColumn;
        private int attackHitLine;
        private int attackHitColumn;
        private List<HitPoint> attackHitPoints;
        private bool attackHitPointDone;
        private HitPoint attackHitPoint;
        private LineSegment attackHitPointLineSegment;
        private Circle attackHitPointCircle;

        public RumbleEditorMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
            : base(graphicsDevice, graphics, content)
        {
            characters = new List<Character>();
        }

        public override void Initialize()
        {
            dragging = false;
        }

        public override void LoadContent()
        {
            LoadParticleEffects();
            LoadFonts();
            LoadLevel();
            LoadEditorStates();
            base.LoadContent();
            mainWindow.UpdateXnaFrame();
            renderer.AddUtilityTexture(content, "characterfeetposition");
            renderer.AddUtilityTexture(content, "intersection");
            renderer.AddUtilityTexture(content, "redsquare");
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

        private void LoadFonts()
        {
            damageSpriteFont = content.Load<SpriteFont>("fonts/damage");
        }

        private void LoadLevel()
        {
            LevelData levelData = content.Load<LevelData>("levels/rumbleeditor/level");
            level = levelData.GetLevel(content);
        }

        private void LoadEditorStates()
        {
            drawEditor = new Dictionary<string, DrawEditor>();
            updateEditor = new Dictionary<string, UpdateEditor>();

            AddState("physics", DrawPhysics, UpdatePhysics);
            AddState("attackSprite", DrawAttackSprite, UpdateAttackSprite);
            AddState("attackHit", DrawAttackHit, UpdateAttackHit);

            SetState("physics");
        }

        private void AddState(string name, DrawEditor drawEditor, UpdateEditor updateEditor)
        {
            this.drawEditor[name] = drawEditor;
            this.updateEditor[name] = updateEditor;
        }

        public void SetState(string name)
        {
            currentDrawEditor = drawEditor[name];
            currentUpdateEditor = updateEditor[name];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            lastUpdateTime = gameTime;

            Vector2 mouse = GetMousePosition();
            if (IsMouseInside())
            {
                mainWindow.GetXnaFrame().Focus();
                mainWindow.HasFocus = false;
            }
            else if (!mainWindow.HasFocus)
            {
                mainWindow.HasFocus = true;
            }

            currentUpdateEditor(gameTime);
        }

        private void UpdatePhysics(GameTime gameTime)
        {
            if (character != null)
            {
                Vector2 mouse = GetMouseCameraRelativePosition();

                if (IsMouseLeftJustPressed() && IsMouseInside())
                {
                    int margin = 20;
                    if (Math.Abs(character.Top - mouse.Y) < margin && character.Left - margin < mouse.X && mouse.X < character.Right + margin)
                    {
                        resizingNorthBound = true;
                        resizeMousePosition = mouse;
                    }

                    if (character.Top - margin < mouse.Y && mouse.Y < character.Bottom + margin)
                    {
                        if (Math.Abs(character.Left - mouse.X) < margin)
                        {
                            resizingWestBound = true;
                            resizeMousePosition = mouse;
                        }
                        else if (Math.Abs(character.Right - mouse.X) < margin)
                        {
                            resizingEstBound = true;
                            resizeMousePosition = mouse;
                        }
                    }

                    if (resizingNorthBound)
                    {
                        if (resizingEstBound)
                            SetCursor(Cursors.SizeNESW);

                        else if (resizingWestBound)
                            SetCursor(Cursors.SizeNWSE);

                        else
                            SetCursor(Cursors.SizeNS);
                    }
                    else if (resizingEstBound || resizingWestBound)
                    {
                        SetCursor(Cursors.SizeWE);
                    }
                    else
                    {
                        SetCursor(Cursors.SizeAll);
                        dragging = true;
                        dragMousePosition = mouse;
                        dragAnimationCenter = character.Animation.Center;
                    }
                }
                else if (!IsMouseLeftPressed())
                {
                    SetCursor(Cursors.Default);
                    dragging = false;
                    resizingEstBound = false;
                    resizingWestBound = false;
                    resizingNorthBound = false;
                }
                else if (dragging)
                {
                    character.AnimationCenter = dragAnimationCenter - GetMouseCameraRelativePosition() + dragMousePosition;
                }

                if (resizingNorthBound)
                {
                    character.Height = character.Bottom - mouse.Y;
                    character.Top = mouse.Y;
                }

                if (resizingEstBound)
                {
                    character.Width = (mouse.X - character.CenterX) * 2;
                    character.Right = mouse.X;
                }
                else if (resizingWestBound)
                {
                    character.Width = (character.CenterX - mouse.X) * 2;
                    character.Left = mouse.X;
                }
            

                level.UpdateEffects(gameTime);

                character.Update(gameTime, level);

                if (!FloatRectangle.Intersect(level.Bounds, character.BoundingRectangle))
                    character.Kill(gameTime);
            }
        }

        private void UpdateAttackSprite(GameTime gameTime)
        {
            if (IsMouseInside())
            {
                Vector2 mouse = GetMousePosition();

                attackLine = (int)Math.Floor((mouse.Y - renderer.Height / 2f + character.Animation.Texture.Height / 2f / 4f) / (float)character.Animation.FrameHeight * 4);
                attackColumn = (int)Math.Floor((mouse.X - renderer.Width / 2f + character.Animation.Texture.Width / 2f / 4f) / (float)character.Animation.FrameWidth * 4);

                if (attackLine >= 0 && attackLine < character.Animation.NumLines
                    && attackColumn >= 0 && attackColumn < character.Animation.NumColumns)
                {
                    if (IsMouseLeftJustPressed())
                    {
                        attackBeginLine = attackLine;
                        attackBeginColumn = attackColumn;
                    }
                    else if (IsMouseLeftJustReleased() && (attackLine > attackBeginLine || (attackLine == attackBeginLine && attackColumn >= attackBeginColumn)))
                    {
                        attackEndLine = attackLine;
                        attackEndColumn = attackColumn;
                        attackHitLine = attackBeginLine;
                        attackHitColumn = attackBeginColumn;
                        SetState("attackHit");
                        mainWindow.EnableFrameButtons();
                        attackHitPoints = new List<HitPoint>();
                        RemoveHitPoint();
                    }
                }
            }
        }

        private void UpdateAttackHit(GameTime gameTime)
        {
            character.Animation.Position = Vector2.Zero;
            character.Animation.FlipX(false);
            character.Animation.CurrentLine = attackHitLine;
            character.Animation.CurrentColumn = attackHitColumn;
            character.Animation.UpdateSourceRectangle();

            if (IsMouseInside() && !attackHitPointDone)
            {
                Vector2 mouse = GetMouseCameraRelativePosition();

                if (IsMouseLeftJustPressed())
                {
                    if (attackHitPointCircle == null)
                    {
                        attackHitPoint = new HitPoint(10, mouse, 1, Vector2.Zero);
                        attackHitPointLineSegment = new LineSegment(mouse, mouse);
                        attackHitPointLineSegment.Depth = 10;
                    }
                    else
                        attackHitPointDone = true;
                }
                else if (IsMouseLeftJustReleased())
                {
                    if (attackHitPointCircle == null)
                    {
                        attackHitPoint.Direction = mouse - attackHitPoint.Position;
                        attackHitPointCircle = new Circle(attackHitPoint.Position, 0);
                        attackHitPointCircle.Color = Color.Blue;
                    }
                }
                else if (IsMouseLeftPressed())
                {
                    if (attackHitPointCircle == null)
                        attackHitPointLineSegment.B = mouse;
                }
                else if (attackHitPointCircle != null)
                {
                    float dx = attackHitPoint.Position.X - mouse.X;
                    float dy = attackHitPoint.Position.Y - mouse.Y;
                    attackHitPointCircle.Radius = (float)Math.Sqrt(dx * dx + dy * dy);
                    attackHitPoint.Size = attackHitPointCircle.Radius;
                }
            }
        }

        public void AttackHitNextFrame()
        {
            attackHitPoints.Add(attackHitPoint);
            RemoveHitPoint();
            if (attackHitLine == attackEndLine && attackHitColumn == attackEndColumn)
            {
                // register animation or attack
                int numHitPoints = 0;
                foreach (HitPoint hitPoint in attackHitPoints)
                {
                    if (hitPoint != null)
                        numHitPoints++;
                }

                Animation.Frame animationFrame = null;
                if (numHitPoints > 0)
                {
                    animationFrame = new Attack(attackBeginLine, attackBeginColumn, 1f / attackHitPoints.Count, 1, attackHitPoints);
                }
                else
                {
                    animationFrame = new Animation.Frame(attackBeginLine, attackBeginColumn, attackHitPoints.Count, 1f / attackHitPoints.Count, 0);
                }

                InputEnabled = false;
                mainWindow.SetXnaFrameTopMost(false);
                mainWindow.EditAnimationWindow.AnimationFrame = animationFrame;
                mainWindow.EditAnimationWindow.OldName = "";
                mainWindow.EditAnimationWindow.ShowDialog();
            }
            else
            {
                attackHitColumn++;
                if (attackHitColumn >= character.Animation.NumColumns)
                {
                    attackHitColumn = 0;
                    attackHitLine++;
                }
            }
        }

        public void RemoveHitPoint()
        {
            attackHitPointDone = false;
            attackHitPointLineSegment = null;
            attackHitPointCircle = null;
            attackHitPoint = null;
        }

        public override void Draw(GameTime gameTime)
        {
            renderer.BeginTextures();

            currentDrawEditor(gameTime);

            renderer.EndTextures();
        }

        private void DrawPhysics(GameTime gameTime)
        {
            level.DrawWithCharacters(renderer, characters);

            if (character != null)
            {
                character.DrawDamage(renderer, damageSpriteFont);

                Texture2D characterFeetPositionTexture = renderer.UtilityTextures["characterfeetposition"];
                renderer.DrawTexture(characterFeetPositionTexture, character.Position);

                renderer.EndTextures();
                renderer.DrawShape(character.BoundingRectangle);
                renderer.BeginTextures();
            }
        }

        private void DrawAttackSprite(GameTime gameTime)
        {
            renderer.DrawInterfaceTexture(character.Animation.Texture, new Vector2(renderer.Width, renderer.Height) / 2, Color.White, 0.25f);

            if (IsMouseLeftPressed())
            {
                if (attackLine >= 0 && attackLine < character.Animation.NumLines
                    && attackColumn >= 0 && attackColumn < character.Animation.NumColumns
                    && (attackLine > attackBeginLine || (attackLine == attackBeginLine && attackColumn >= attackBeginColumn)))
                {
                    int l = attackBeginLine;
                    int c = attackBeginColumn;
                    while (l < attackLine || (l == attackLine && c <= attackColumn))
                    {
                        FloatRectangle rect = new FloatRectangle(c * character.Animation.FrameWidth / 4 - character.Animation.Texture.Width / 4 / 2, l * character.Animation.FrameHeight / 4 - character.Animation.Texture.Height / 4 / 2,
                            character.Animation.FrameWidth / 4, character.Animation.FrameHeight / 4);
                        rect.Color = Color.Blue;
                        renderer.DrawShape(rect);
                        c++;
                        if (c >= character.Animation.NumColumns)
                        {
                            c = 0;
                            l++;
                        }
                    }
                }
            }
            else
            {
                if (attackLine >= 0 && attackLine < character.Animation.NumLines
                    && attackColumn >= 0 && attackColumn < character.Animation.NumColumns)
                {
                    FloatRectangle rect = new FloatRectangle(attackColumn * character.Animation.FrameWidth / 4 - character.Animation.Texture.Width / 4 / 2, attackLine * character.Animation.FrameHeight / 4 - character.Animation.Texture.Height / 4 / 2,
                        character.Animation.FrameWidth / 4, character.Animation.FrameHeight / 4);
                    rect.Color = Color.Blue;
                    renderer.DrawShape(rect);
                }
            }
        }

        private void DrawAttackHit(GameTime gameTime)
        {
            character.Animation.Draw(renderer);
            renderer.EndTextures();

            if (attackHitPointLineSegment != null)
                renderer.DrawShape(attackHitPointLineSegment);

            if (attackHitPointCircle != null)
                renderer.DrawShape(attackHitPointCircle);

            HitPoint lastHitPoint = null;
            foreach (HitPoint hitPoint in attackHitPoints)
            {
                if (hitPoint != null)
                {
                    LineSegment directionLine = new LineSegment(hitPoint.Position, hitPoint.Position + hitPoint.Direction);
                    directionLine.Color = Color.Red;
                    renderer.DrawShape(directionLine);

                    Circle sizeCircle = new Circle(hitPoint.Position, hitPoint.Size);
                    sizeCircle.Color = Color.Red;
                    renderer.DrawShape(sizeCircle);

                    if (lastHitPoint != null)
                    {
                        LineSegment line = new LineSegment(lastHitPoint.Position, hitPoint.Position);
                        line.Color = Color.Red;
                        renderer.DrawShape(line);
                    }
                    lastHitPoint = hitPoint;
                }
            }

            renderer.BeginTextures();

            renderer.DrawTexture(renderer.UtilityTextures["redsquare"], Vector2.Zero);
        }

        public void NewCharacter(string animationTextureName, int animationNumLines, int animationNumColumns, double animationFrameDuration, string faceTextureName)
        {
            Texture2D animationTexture = content.Load<Texture2D>(animationTextureName);
            animationTexture.Name = animationTextureName;
            Animation animation = new Animation(animationTexture, animationNumLines, animationNumColumns, animationFrameDuration);
            animation.Reset(lastUpdateTime);
            animation.Center = new Vector2(animation.FrameWidth / 2, animation.FrameHeight);

            Texture2D faceTexture = content.Load<Texture2D>(faceTextureName);
            faceTexture.Name = faceTextureName;

            Vector2 size = new Vector2(animation.FrameWidth, animation.FrameHeight);

            float weight = 2500;
            float jumpForce = 1200;
            float runningSpeed = 800;
            int numSecondJumps = 1;

            character = new Character(animation, faceTexture, size, weight, jumpForce, runningSpeed, numSecondJumps);
            character.WorldHitPoints = new List<HitPoint>();

            GamePadDevice gamePad1 = new GamePadDevice(PlayerIndex.One);

            if (gamePad1.IsConnected())
                character.InputDevice = gamePad1;

            else
                character.InputDevice = new KeyboardDevice();

            characters.Clear();
            characters.Add(character);
            ResetAnimation();
        }

        public void OpenCharacter(CharacterData characterData)
        {
            character = characterData.GetCharacter(content);
            character.WorldHitPoints = new List<HitPoint>();

            GamePadDevice gamePad1 = new GamePadDevice(PlayerIndex.One);

            if (gamePad1.IsConnected())
                character.InputDevice = gamePad1;

            else
                character.InputDevice = new KeyboardDevice();

            characters.Clear();
            characters.Add(character);
            ResetAnimation();
        }

        public void SaveCharacter(string name)
        {
            string charactersDir = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/characters";

            if (!Directory.Exists(charactersDir))
                Directory.CreateDirectory(charactersDir);

            string file = charactersDir + "/" + name;
            CharacterWriter characterWriter = new CharacterWriter(character);
            File.WriteAllBytes(file, characterWriter.Write());
        }

        public void AnimationSetLine(int line)
        {
            if (character != null)
                character.Animation.CurrentLine = line;
        }

        public void AnimationSetColumn(int column)
        {
            if (character != null)
                character.Animation.CurrentColumn = column;
        }

        public void ResetAnimation()
        {
            character.Animation.Reset(lastUpdateTime);
        }

        public void SetCharacterWeight(float weight)
        {
            if (character != null)
                character.Weight = weight;
        }

        public void SetCharacterJumpForce(float jumpForce)
        {
            if (character != null)
                character.JumpForce = jumpForce;
        }

        public void SetCharacterRunningSpeed(float runningSpeed)
        {
            if (character != null)
                character.RunningSpeed = runningSpeed;
        }

        public void SetCharacterSecondaryJumps(int secondaryJumps)
        {
            if (character != null)
                character.NumSecondJumps = secondaryJumps;
        }

        public void SetAnimationNumLines(int numLines)
        {
            if (character != null)
                character.Animation.NumLines = numLines;
        }

        public void SetAnimationNumColumns(int numColumns)
        {
            if (character != null)
                character.Animation.NumColumns = numColumns;
        }

        public void SetAnimationFrameDuration(double frameDuration)
        {
            if (character != null)
                character.Animation.FrameDuration = frameDuration;
        }

        private void SetCursor(Cursor cursor)
        {
            mainWindow.GetXnaFrame().Cursor = cursor;
        }

        public List<string> GetCharactersDirectories()
        {
            List<string> charactersDirectories = new List<string>();

            DirectoryInfo charactersDir = new DirectoryInfo(content.RootDirectory + "/characters");

            DirectoryInfo[] dirs = charactersDir.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
                charactersDirectories.Add(dir.Name);

            return charactersDirectories;
        }

        public void PlayFrame(string name)
        {
            if (character != null)
                character.PlayFrame(name, lastUpdateTime);
        }

        public void RemoveFrame(string name)
        {
            if (character != null)
                character.Animation.RemoveFrame(name);
        }
    }
}
