using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using RoflLib;

namespace RoflCodeContent.levels.plaguejungles.particles
{
    public class PlagueEffect : ParticleEffect
    {
        public PlagueEffect(ContentManager content)
            : base()
        {
            Register(content);
        }

        public PlagueEffect(List<Texture2D> textures, Effect effect, double popTime, Vector2 position)
            : base(textures, effect, popTime, position)
        {
            lastNewParticleTime = 0;
        }

        public override bool Update(GameTime gameTime)
        {
            base.Update(gameTime);
            return InfinitePeriodicalPop(gameTime, 10, 0.02, typeof(PlagueParticle));
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
            return new PlagueEffect(textures, effect, gameTime.TotalGameTime.TotalSeconds, position);
        }
    }
}
