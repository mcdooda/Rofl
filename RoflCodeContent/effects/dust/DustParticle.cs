using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflCodeContent.effects.dust
{
    public class DustParticle : Particle
    {
        public DustParticle(Random random, Texture2D texture, double popTime, Vector2 position, int direction)
            : base(random, texture, popTime, position)
        {
            speed = new Vector2(direction * 200, 0);
            weight = 0;
            scale = 0.2f;
        }

        public override bool Update(GameTime gameTime)
        {
            double duration = 0.2;
            base.Update(gameTime);
            ScaleAlpha(gameTime, duration, 1, 0);
            ScaleScale(gameTime, duration, 0.2f, 1);
            return Lasts(gameTime, duration);
        }
    }
}
