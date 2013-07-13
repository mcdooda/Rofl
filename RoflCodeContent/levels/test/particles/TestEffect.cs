using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RoflCodeContent.levels.test.particles
{
    public class TestEffect : ParticleEffect
    {
        public TestEffect(ContentManager content)
            : base()
        {
            Register(content);
        }

        public TestEffect(List<Texture2D> textures, Effect effect, double popTime, Vector2 position)
            : base(textures, effect, popTime, position)
        {
            lastNewParticleTime = 0;
        }

        public override bool Update(GameTime gameTime)
        {
            base.Update(gameTime);
            return PeriodicalPop(gameTime, 10, 0.02, typeof(TestParticle));
        }

        public override void Initialize(ContentManager content)
        {
            textures = new List<Texture2D>();
            textures.Add(content.Load<Texture2D>("redsquare"));
            textures.Add(content.Load<Texture2D>("bluesquare"));

            effect = content.Load<Effect>("levels/test/effects/testeffect");
        }

        public override ParticleEffect New(GameTime gameTime, Vector2 position)
        {
            return new TestEffect(textures, effect, gameTime.TotalGameTime.TotalSeconds, position);
        }
    }
}
