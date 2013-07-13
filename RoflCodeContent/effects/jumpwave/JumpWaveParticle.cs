using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflCodeContent.effects.jumpwave
{
    public class JumpWaveParticle : Particle
    {
        public JumpWaveParticle(Random random, Texture2D texture, double popTime, Vector2 position)
            : base(random, texture, popTime, position)
        {
            speed = Vector2.Zero;
            weight = 0;
            scale = 0.5f;
            SetAlpha(0.5f);
        }

        public override bool Update(GameTime gameTime)
        {
            double duration = 0.1;
            base.Update(gameTime);
            ScaleAlpha(gameTime, duration, 0.5f, 0);
            ScaleScale(gameTime, duration, 0.5f, 1);
            return Lasts(gameTime, duration);
        }
    }
}
