using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib
{
    public abstract class Particle
    {
        protected double popTime;

        protected Texture2D texture;
        public Texture2D Texture { get { return texture; } }

        protected Color color;
        public Color Color { get { return color; } }

        protected Vector2 halfSize;
        public Vector2 HalfSize { get { return halfSize; } }

        protected Vector2 position;
        public Vector2 Position { get { return position; } }

        protected Vector2 speed;

        protected float weight;

        protected float rotation;
        public float Rotation { get { return rotation; } }

        protected float scale;
        public float Scale { get { return scale; } }

        protected ParticleEffect effect;
        public ParticleEffect Effect { get { return effect; } set { effect = value; } }

        protected Random random;

        public Particle(Random random, Texture2D texture, double popTime, Vector2 position)
        {
            this.random = random;
            this.texture = texture;
            this.color = Color.White;
            this.halfSize = new Vector2(texture.Width, texture.Height) / 2;
            this.popTime = popTime;
            this.position = position;
            rotation = 0;
            scale = 1;
            speed = Vector2.Zero;
            weight = 0;
        }

        public virtual bool Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            speed.Y += t * weight;
            position += speed * t;
            return false;
        }

        protected double GetAge(GameTime gameTime)
        {
            return gameTime.TotalGameTime.TotalSeconds - popTime;
        }

        protected bool Lasts(GameTime gameTime, double duration)
        {
            return GetAge(gameTime) > duration;
        }

        protected void SetAlpha(float alpha)
        {
            byte a = (byte)(255 * alpha);
            color.R = a;
            color.G = a;
            color.B = a;
            color.A = a;
        }

        protected void ScaleAlpha(GameTime gameTime, double duration, float from, float to)
        {
            SetAlpha((float)(from + (to - from) * GetAge(gameTime) / duration));
        }

        protected void ScaleScale(GameTime gameTime, double duration, float from, float to)
        {
            scale = (float)(from + (to - from) * GetAge(gameTime) / duration);
        }

        protected void ScaleRotation(GameTime gameTime, double duration, float from, float to)
        {
            rotation = (float)(from + (to - from) * GetAge(gameTime) / duration);
        }

        public virtual void Draw(Renderer renderer)
        {
            //renderer.DrawTexture(texture, position, effect.Layer.Depth);
            renderer.DrawParticle(this);
        }
    }
}
