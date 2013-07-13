using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflCodeContent.effects.dust
{
    public class DustEffect : ParticleEffect
    {
        public DustEffect(ContentManager content)
            : base()
        {
            Register(content);
        }

        public DustEffect(List<Texture2D> textures, Effect effect, double popTime, Vector2 position)
            : base(textures, effect, popTime, position)
        {
            lastNewParticleTime = 0;

            Add(new DustParticle(random, GetRandomTexture(), popTime, position, -1));
            Add(new DustParticle(random, GetRandomTexture(), popTime, position, 1));
        }

        public override bool Update(GameTime gameTime)
        {
            base.Update(gameTime);
            return WaitParticles();
        }

        public override void Initialize(ContentManager content)
        {
            textures = new List<Texture2D>();
            textures.Add(content.Load<Texture2D>("effects/dust/dust"));
        }

        public override ParticleEffect New(GameTime gameTime, Vector2 position)
        {
            return new DustEffect(textures, effect, gameTime.TotalGameTime.TotalSeconds, position);
        }
    }
}
