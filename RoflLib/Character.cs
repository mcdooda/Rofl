using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RoflLib.utils;
using RoflLib.utils.math;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using RoflLib.input;
using RoflLib.input.vibrations;

namespace RoflLib
{
    public class Character
    {
        public enum Direction1D
        {
            Left = -1,
            Right = 1
        }

        protected int index;
        public int Index { get { return index; } set { index = value; } }

        protected InputDevice inputDevice;
        public InputDevice InputDevice { set { inputDevice = value; } }

        protected Direction1D direction;
        public Direction1D Direction { get { return direction; } set { direction = value; } }

        protected Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        protected Animation animation;
        public Animation Animation { get { return animation; } }

        protected float animationCenterX;
        public float AnimationCenterX { get { return animationCenterX; } }

        public Vector2 AnimationCenter
        {
            get
            {
                return animation.Center;
            }

            set
            {
                if (direction == Direction1D.Left)
                    value.X = animation.FrameWidth - value.X;

                animation.Center = value;
                animationCenterX = value.X;
            }
        }

        protected Texture2D faceTexture;
        public Texture2D FaceTexture { get { return faceTexture; } }

        protected Color color;
        public Color Color { set { color = value; } }

        protected Vector2 size;
        public Vector2 Size { get { return size; } }
        public float Width { get { return size.X; } set { size.X = value; boundingRectangle.Width = value; } }
        public float Height { get { return size.Y; } set { size.Y = value; boundingRectangle.Height = value; } }

        protected float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        protected float jumpForce;
        public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }

        protected Vector2 speed;
        public Vector2 Speed { get { return speed; } set { speed = value; } }

        protected float runningSpeed;
        public float RunningSpeed { get { return runningSpeed; } set { runningSpeed = value; } }

        protected bool onTheFloor;
        public bool OnTheFloor { get { return onTheFloor; } set { onTheFloor = value; } }

        protected LineSegment currentFloor;

        protected bool dead;
        public bool Dead { get { return dead; } }

        protected float damage;
        public float Damage { get { return damage; } }

        protected float displayedDamage;

        protected int numLives;
        public int NumLives { get { return numLives; } set { numLives = value; } }

        protected int numSecondJumps;
        public int NumSecondJumps { get { return numSecondJumps; } set { numSecondJumps = value; } }

        protected int remainingSecondJumps;

        protected FloatRectangle boundingRectangle;
        public FloatRectangle BoundingRectangle { get { return boundingRectangle; } }

        public Attack CurrentAttack { get { return animation.CurrentFrame is Attack ? (Attack)animation.CurrentFrame : null; } }
        public HitPoint CurrentAttackHitPoint { get { return animation.CurrentFrame is Attack ? ((Attack)animation.CurrentFrame).CurrentHitPoint : null; } }

        protected Intersection levelIntersection;

        protected bool frozen;
        public bool Frozen { get { return frozen; } }

        protected double freezeTime;
        protected double freezeDuration;

        public float Left
        {
            get { return position.X - Width / 2; }
            set { position.X = value + Width / 2; }
        }
        public float Right
        {
            get { return position.X + Width / 2; }
            set { position.X = value - Width / 2; }
        }
        public float Top
        {
            get { return position.Y - Height; }
            set { position.Y = value + Height; }
        }
        public float Bottom
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public float CenterX
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public float CenterY
        {
            get { return position.Y - Height / 2; }
            set { position.Y = value + Height / 2; }
        }
        public Vector2 Center
        {
            get { return new Vector2(CenterX, CenterY); }
            set { CenterX = value.X; CenterY = value.Y; }
        }

        public List<HitPoint> WorldHitPoints
        {
            set
            {
                foreach (KeyValuePair<string, Animation.Frame> attack in animation.Frames)
                    if (attack.Value is Attack)
                        ((Attack)attack.Value).WorldHitPoints = value;
            }
        }

        // fake editor character
        public Character(InputDevice inputDevice, Vector2 position, Color color, int index)
        {
            this.index = index;
            this.color = color;
            this.inputDevice = inputDevice;
            this.position = position;
            direction = Direction1D.Right;
            frozen = false;
            speed = Vector2.Zero;
            onTheFloor = false;
            levelIntersection = new Intersection();
            dead = false;
            displayedDamage = 0;
            damage = 0;
            remainingSecondJumps = 0;
        }

        // real character
        public Character(Animation animation, Texture2D faceTexture, Vector2 size, float weight, float jumpForce, float runningSpeed, int numSecondJumps)
        {
            this.animation = animation;
            this.faceTexture = faceTexture;
            this.size = size;
            this.weight = weight;
            this.jumpForce = jumpForce;
            this.runningSpeed = runningSpeed;
            this.numSecondJumps = numSecondJumps;

            inputDevice = new FakeDevice();
            onTheFloor = false;
            levelIntersection = new Intersection();
            dead = false;
            displayedDamage = 0;
            damage = 0;
            remainingSecondJumps = 0;
            color = Color.White;

            Initialize();
        }

        public void CopyData(Character character)
        {
            animation = character.animation; // no need to copy, "character" will not be used anymore
            faceTexture = character.faceTexture;
            size = character.size;
            weight = character.weight;
            jumpForce = character.jumpForce;
            runningSpeed = character.runningSpeed;
            numSecondJumps = character.numSecondJumps;

            Initialize();
        }

        protected void Initialize()
        {
            direction = Direction1D.Right;
            animationCenterX = animation.Center.X;
            animation.Position = position;
            animation.CurrentLine = 1;
            animation.Color = color;
            boundingRectangle = new FloatRectangle(0, 0, Width, Height);

            foreach (KeyValuePair<string, Animation.Frame> attack in animation.Frames)
                if (attack.Value is Attack)
                    ((Attack)attack.Value).Attacker = this;
        }

        public void Update(GameTime gameTime, Level level)
        {
            inputDevice.Update(gameTime);

            if (dead)
            {
                if (inputDevice.IsResetButtonJustPressed())
                    Respawn();

                else
                    return;
            }

            UpdateInput(gameTime, level);

            UpdatePhysics(gameTime, level);

            UpdateAnimation(gameTime);

            if ((!onTheFloor || speed.X == 0) && inputDevice.Vibration is WalkVibration)
                inputDevice.StopVibration();

            UpdateDisplayedDamage(gameTime);
        }

        private void UpdateInput(GameTime gameTime, Level level)
        {
            // floor attacks
            if (onTheFloor)
            {
                // common attack
                if (inputDevice.IsCommonAttackButtonJustPressed())
                {
                    if (speed.X == 0)
                        TriggerCommonAttack(gameTime);

                    else
                        TriggerCommonSideAttack(gameTime);
                }
            }

            if (inputDevice.IsJumpButtonJustPressed() || inputDevice.GetMoveY() > 0.3 && inputDevice.GetPreviousMoveY() <= 0.3)
                Jump(gameTime, level);

            float moveX = inputDevice.GetMoveX();

            if (!frozen && Math.Abs(moveX) > 0.3)
            {
                if (onTheFloor && inputDevice.Vibration == null)
                    inputDevice.Vibrate(new WalkVibration(gameTime));

                speed.X = moveX * runningSpeed;

                if (onTheFloor)
                {
                    if (moveX < 0)
                        direction = Direction1D.Left;

                    else
                        direction = Direction1D.Right;
                }
            }
            else if (onTheFloor)
            {
                speed.X = 0;
            }
        }

        public void UpdatePhysics(GameTime gameTime, Level level)
        {
            Fall(gameTime);

            UpdateFreeze(gameTime);

            double time = gameTime.ElapsedGameTime.TotalSeconds;

            position += speed * (float)time;

            UpdateBoundingRectangle();
            CollideWithPlatforms(gameTime, level);
            UpdateBoundingRectangle();
        }

        private void UpdateDisplayedDamage(GameTime gameTime)
        {
            if (displayedDamage < damage)
            {
                displayedDamage += (float)gameTime.ElapsedGameTime.TotalSeconds * 20;
                if (displayedDamage > damage)
                    displayedDamage = damage;
            }
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            animation.FlipX(direction == Direction1D.Left);

            if (direction == Direction1D.Right)
            {
                animation.CenterX = animationCenterX;
            }
            else
            {
                animation.CenterX = animation.FrameWidth - animationCenterX;
            }

            if (onTheFloor)
            {
                if (!(animation.CurrentFrame is Attack))
                {
                    if (speed.X != 0)
                        animation.LoopFrame("Run", gameTime);

                    else
                        animation.LoopFrame("Idle", gameTime);
                }
            }
            else
            {
                if (speed.Y > 0)
                    animation.LoopFrame("Fall", gameTime);
            }

            animation.Position = position;
            animation.Update(gameTime);
        }

        public void Draw(Renderer renderer)
        {
            if (!dead)
            {
                animation.Draw(renderer);
                
                Texture2D intersectionTexture = renderer.UtilityTextures["intersection"];
                Vector2 intersectionTextureHalfSize = new Vector2(intersectionTexture.Width, intersectionTexture.Height) / 2;
                foreach (Intersection.IntersectionPoint ip in levelIntersection.IntersectionPoints)
                    renderer.DrawTexture(intersectionTexture, ip.Point);
            }
        }

        public void DrawDamage(Renderer renderer, SpriteFont spriteFont)
        {
            float scale = (float)renderer.Height / 1080; // ratio 1:1 on 1080p
            Vector2 position = new Vector2((index * 250 + 125) * scale, renderer.Height - 125 * scale);
            renderer.DrawInterfaceTexture(faceTexture, position, color, scale);

            string damagePercentage = Math.Round(displayedDamage) + "%";
            renderer.DrawStringFromRight(spriteFont, damagePercentage, position + new Vector2(117, 17) * scale, Color.Black, scale);

            float f = Math.Max(1 - displayedDamage / 100, 0);
            Color damageColor = new Color(0.66f + f / 3, f, f);
            renderer.DrawStringFromRight(spriteFont, damagePercentage, position + new Vector2(120, 20) * scale, damageColor, scale);
        }

        private void UpdateBoundingRectangle()
        {
            boundingRectangle.Left = Left;
            boundingRectangle.Top = Top;
        }

        public void Jump(GameTime gameTime, Level level)
        {
            if (!frozen)
            {
                if (onTheFloor)
                {
                    speed.Y = -jumpForce;
                    speed.X = 0;
                    onTheFloor = false;
                    remainingSecondJumps = numSecondJumps;
                    inputDevice.StopVibration();
                    animation.PlayFrame("Jump", gameTime);
                }
                else if (remainingSecondJumps > 0)
                {
                    remainingSecondJumps--;
                    speed.Y = -jumpForce;
                    ParticleEffect particleEffect = ParticleEffect.Get("RoflCodeContent.effects.jumpwave.JumpWaveEffect");
                    level.PlatformsLayer.AddEffect(particleEffect.New(gameTime, position));
                    animation.PlayFrame("Jump", gameTime);
                }
            }
        }

        private void Fall(GameTime gameTime)
        {
            if (!onTheFloor)
                speed.Y += (float)(weight * gameTime.ElapsedGameTime.TotalSeconds);
        }

        private void CollideWithPlatforms(GameTime gameTime, Level level)
        {
            levelIntersection = new Intersection();

            // avoids dirty glitches while walking on a downward slope
            if (onTheFloor && position.X >= Math.Min(currentFloor.A.X, currentFloor.B.X) && position.X <= Math.Max(currentFloor.A.X, currentFloor.B.X))
                position.Y = currentFloor.A.Y + (position.X - currentFloor.A.X) * ((currentFloor.A.Y - currentFloor.B.Y) / (currentFloor.A.X - currentFloor.B.X)) + 1;

            bool floorCollision = false;

            foreach (LevelElement element in level.PlatformsLayer.Elements)
            {
                bool fc = CollideWithPlatform(element);
                floorCollision = floorCollision || fc;
            }

            if (onTheFloor && !floorCollision)
                remainingSecondJumps = numSecondJumps;

            else if (!onTheFloor && floorCollision)
            {
                ParticleEffect particleEffect = ParticleEffect.Get("RoflCodeContent.effects.dust.DustEffect");
                level.PlatformsLayer.AddEffect(particleEffect.New(gameTime, position));

                inputDevice.Vibrate(new Vibration(gameTime, 0.08, 0.7f, Vibration.VibrationType.Soft));
                speed = Vector2.Zero;
            }

            onTheFloor = floorCollision;
        }

        private bool CollideWithPlatform(LevelElement element)
        {
            bool floorCollision = false;
            Polygon elementPolygon = element.Polygon;

            if (FloatRectangle.Intersect(boundingRectangle, elementPolygon.BoundingRectangle))
            {
                //float headY = (Bottom + Top * 3) / 4;
                float beltY = (Bottom + Top) / 2;
                //float feetY = (Bottom * 3 + Top) / 4;

                LineSegment verticalLineSegment = new LineSegment(new Vector2(CenterX, Bottom), new Vector2(CenterX, Top));
                //LineSegment headLineSegment = new LineSegment(new Vector2(Left, headY), new Vector2(Right, headY));
                LineSegment beltLineSegment = new LineSegment(new Vector2(Left, beltY), new Vector2(Right, beltY));
                //LineSegment feetLineSegment = new LineSegment(new Vector2(Left, feetY), new Vector2(Right, feetY));

                Intersection sideIntersection = new Intersection();
                //sideIntersection.AddIntersection(Intersection.PolygonAndLineSegment(elementPolygon, headLineSegment));
                sideIntersection.AddIntersection(Intersection.PolygonAndLineSegment(elementPolygon, beltLineSegment));
                //sideIntersection.AddIntersection(Intersection.PolygonAndLineSegment(elementPolygon, feetLineSegment));

                if (!sideIntersection.IsEmpty)
                {
                    foreach (Intersection.IntersectionPoint ip in sideIntersection.IntersectionPoints)
                    {
                        float pX = ip.Point.X;
                        if (pX < position.X)
                        {
                            if (pX > Left)
                            {
                                Left = pX;

                                if (speed.X < 0)
                                    speed.X = 0;
                            }
                        }
                        else if (pX < Right)
                        {
                            Right = pX;

                            if (speed.X > 0)
                                speed.X = 0;
                        }
                    }
                }

                Intersection verticalIntersection = Intersection.PolygonAndLineSegment(elementPolygon, verticalLineSegment);
                if (!verticalIntersection.IsEmpty)
                {
                    float newFeetY = float.PositiveInfinity;
                    float newHeadY = float.NegativeInfinity;

                    foreach (Intersection.IntersectionPoint ip in verticalIntersection.IntersectionPoints)
                    {
                        float pY = ip.Point.Y;
                        if (pY < CenterY)
                        {
                            if (pY >= newHeadY)
                                newHeadY = pY;
                        }
                        else if (pY <= newFeetY)
                        {
                            if (currentFloor != ip.LineSegment)
                            {
                                float d = ip.LineSegment.Derivative;

                                if (-1.5 <= d && d <= 1.5)
                                    currentFloor = ip.LineSegment;
                            }

                            newFeetY = pY;
                        }
                    }

                    if (newFeetY < float.PositiveInfinity)
                    {
                        floorCollision = true;
                        Bottom = newFeetY;
                        speed.Y = 0;
                    }

                    if (newHeadY > float.NegativeInfinity)
                    {
                        Top = newHeadY;
                        speed.Y *= -0.5f;
                    }
                }

                levelIntersection.AddIntersection(sideIntersection);
                levelIntersection.AddIntersection(verticalIntersection);
            }

            return floorCollision;
        }

        public void Respawn()
        {
            position.X = 0;
            position.Y = -100;
            speed = Vector2.Zero;
            dead = false;
            damage = 0;
            displayedDamage = 0;
            numLives--;
        }

        protected void VibrateAttack(string name, GameTime gameTime)
        {
            inputDevice.Vibrate(new AttackVibration(gameTime, animation.GetSubFrameDuration(name)));
        }

        protected void PlayAttack(string name, GameTime gameTime, bool vibrate)
        {
            if (!(animation.CurrentFrame is Attack))
            {
                PlayFrame(name, gameTime);
                if (vibrate)
                    VibrateAttack(name, gameTime);
            }
        }

        protected virtual void TriggerCommonAttack(GameTime gameTime)
        {
            PlayAttack("CommonAttack", gameTime, true);
        }

        protected virtual void TriggerCommonSideAttack(GameTime gameTime)
        {
            PlayAttack("CommonSideAttack", gameTime, true);
        }

        public void AddFrame(string name, Animation.Frame frame)
        {
            if (frame is Attack)
                ((Attack)frame).Attacker = this;

            animation.AddFrame(name, frame);
        }

        public void RemoveFrame(string name)
        {
            animation.RemoveFrame(name);
        }

        public void PlayFrame(string name, GameTime gameTime)
        {
            double freezeDuration = animation.PlayFrame(name, gameTime);
            if (freezeDuration > 0)
                Freeze(gameTime, freezeDuration);
        }

        protected void Freeze(GameTime gameTime, double duration)
        {
            double time = gameTime.TotalGameTime.TotalSeconds;
            if (!frozen || duration > time - freezeTime)
            {
                frozen = true;
                freezeTime = time;
                freezeDuration = duration;
            }
        }

        private void UpdateFreeze(GameTime gameTime)
        {
            if (frozen)
            {
                double time = gameTime.TotalGameTime.TotalSeconds;
                if (time > freezeTime + freezeDuration)
                    frozen = false;
            }
        }

        public void DealDamage(float amount)
        {
            this.damage += amount;
        }

        public void Kill(GameTime gameTime)
        {
            if (!dead)
            {
                dead = true;
                inputDevice.Vibrate(new DeathVibration(gameTime));
            }
        }
    }
}
