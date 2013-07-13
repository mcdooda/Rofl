using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RoflCodeContent.effects.jumpwave
{
    public class JumpWaveEffect : ParticleEffect
    {
        public JumpWaveEffect(ContentManager content)
            : base()
        {
            Register(content);
        }

        public JumpWaveEffect(List<Texture2D> textures, Effect effect, double popTime, Vector2 position)
            : base(textures, effect, popTime, position)
        {
            lastNewParticleTime = 0;

            //Add(new JumpWaveParticle(random, GetRandomTexture(), popTime, position));
        }

        public override bool Update(GameTime gameTime)
        {
            base.Update(gameTime);
            return PeriodicalPop(gameTime, 0.2, 0.07, typeof(JumpWaveParticle));
        }

        public override void Initialize(ContentManager content)
        {
            textures = new List<Texture2D>();
            textures.Add(content.Load<Texture2D>("effects/jumpwave/jumpwave2"));
        }

        public override ParticleEffect New(GameTime gameTime, Vector2 position)
        {
            return new JumpWaveEffect(textures, effect, gameTime.TotalGameTime.TotalSeconds, position);
        }
    }
}
