using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RoflLib;

namespace RoflCodeContent.levels.plaguejungles.particles
{
    class PlagueParticle : Particle
    {
        private float rotationMin;
        private float rotationMax;

        public PlagueParticle(Random random, Texture2D texture, double popTime, Vector2 position)
            : base(random, texture, popTime, position)
        {
            double theta = random.NextDouble() * Math.PI * 2;
            speed = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * (float)(random.NextDouble() + 1) * 200;
            weight = 1000;
            rotationMin = (float)(-random.NextDouble() * 2 * Math.PI);
            rotationMax = (float)(random.NextDouble() * 2 * Math.PI);
            if (random.Next(2) == 0)
            {
                float rotateMin2 = rotationMin;
                rotationMin = rotationMax;
                rotationMax = rotateMin2;
            }
            rotation = rotationMin;
        }

        public override bool Update(GameTime gameTime)
        {
            double duration = 1;
            base.Update(gameTime);
            ScaleAlpha(gameTime, duration, 1, 0);
            ScaleScale(gameTime, duration, 1, 2f);
            ScaleRotation(gameTime, duration, rotationMin, rotationMax);
            return Lasts(gameTime, duration);
        }
    }
}
