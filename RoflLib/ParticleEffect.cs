using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RoflLib
{
    public abstract class ParticleEffect
    {
        protected double popTime;
        protected double lastNewParticleTime;

        protected List<Particle> particles;

        protected Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        protected LevelLayer layer;
        public LevelLayer Layer { get { return layer; } set { layer = value; } }

        protected static Random random;
        public static Random Random { get { return random; } set { random = value; } }

        protected List<Texture2D> textures;
        public List<Texture2D> Textures { set { textures = value; } }

        protected Effect effect;
        public Effect Effect { set { effect = value; } }

        private static Dictionary<string, ParticleEffect> particleEffects;
        public static Dictionary<string, ParticleEffect> ParticleEffects { get { return particleEffects; } set { particleEffects = value; } }

        public string Name { get { return GetType().FullName; } }

        abstract public void Initialize(ContentManager content);
        abstract public ParticleEffect New(GameTime gameTime, Vector2 position);

        public ParticleEffect(List<Texture2D> textures, Effect effect, double popTime, Vector2 position)
        {
            particles = new List<Particle>();
            this.textures = textures;
            this.effect = effect;
            this.popTime = popTime;
            this.lastNewParticleTime = 0;
            this.position = position;
        }

        public ParticleEffect() // factory constructor
        {

        }

        public void Register(ContentManager content)
        {
            Initialize(content);
            particleEffects[Name] = this;
        }

        public static ParticleEffect Get(string name)
        {
            return particleEffects[name];
        }

        public void Add(Particle particle)
        {
            particles.Add(particle);
            particle.Effect = this;
        }

        public void Remove(Particle particle)
        {
            particles.Remove(particle);
        }

        public virtual bool Update(GameTime gameTime)
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                if (particles[i].Update(gameTime))
                    particles.RemoveAt(i);
            }
            return false;
        }

        protected bool Lasts(GameTime gameTime, double duration)
        {
            return gameTime.TotalGameTime.TotalSeconds - popTime > duration;
        }

        protected bool LastsAndWaitParticles(GameTime gameTime, double duration, ref bool keepSpawning)
        {
            keepSpawning = gameTime.TotalGameTime.TotalSeconds - popTime <= duration;
            return Lasts(gameTime, duration) && particles.Count == 0;
        }

        protected bool WaitParticles()
        {
            return particles.Count == 0;
        }

        private static Type[] particleConstructorTypes = new Type[] { typeof(Random), typeof(Texture2D), typeof(double), typeof(Vector2) };

        protected bool PeriodicalPop(GameTime gameTime, double duration, double period, Type particleType)
        {
            bool keepSpawning = true;
            bool remove = LastsAndWaitParticles(gameTime, duration, ref keepSpawning);

            if (keepSpawning && gameTime.TotalGameTime.TotalSeconds - lastNewParticleTime > period)
            {
                lastNewParticleTime = gameTime.TotalGameTime.TotalSeconds;
                Particle particle = (Particle)particleType.GetConstructor(particleConstructorTypes).Invoke(new object[] { random, GetRandomTexture(), gameTime.TotalGameTime.TotalSeconds, position });
                Add(particle);
            }

            return remove;
        }

        protected bool InfinitePeriodicalPop(GameTime gameTime, double particleDuration, double period, Type particleType)
        {
            if (gameTime.TotalGameTime.TotalSeconds - lastNewParticleTime > period)
            {
                lastNewParticleTime = gameTime.TotalGameTime.TotalSeconds;
                Particle particle = (Particle)particleType.GetConstructor(particleConstructorTypes).Invoke(new object[] { random, GetRandomTexture(), gameTime.TotalGameTime.TotalSeconds, position });
                Add(particle);
            }
            return false;
        }

        protected Texture2D GetRandomTexture()
        {
            return textures[random.Next(textures.Count)];
        }

        public void Draw(Renderer renderer)
        {
            if (particles.Count > 0)
            {
                if (effect != null)
                {
                    renderer.BeginTextures(effect, null);

                    foreach (Particle particle in particles)
                        particle.Draw(renderer);

                    renderer.BeginTextures();
                }
                else
                {
                    foreach (Particle particle in particles)
                        particle.Draw(renderer);
                }
            }
        }
    }
}
