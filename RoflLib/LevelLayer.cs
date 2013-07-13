using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib
{
    public class LevelLayer
    {
        private float depth;
        public float Depth
        {
            get
            {
                return depth;
            }

            set
            {
                depth = value;
                foreach (LevelElement element in elements)
                    element.Polygon.Depth = value;
            }
        }

        private List<LevelElement> elements;
        public List<LevelElement> Elements { get { return elements; } }

        private List<ParticleEffect> effects;
        public List<ParticleEffect> ParticleEffects { get { return effects; } }

        private bool visible;
        public bool Visible { get { return visible; } set { visible = value; } }

        public LevelLayer(float depth)
        {
            this.depth = depth;
            this.elements = new List<LevelElement>();
            this.effects = new List<ParticleEffect>();
            this.visible = true;
        }

        public string GetName()
        {
            string name = "layer " + depth;

            List<string> info = new List<string>();

            if (depth == 0)
                info.Add("platforms");

            if (elements.Count == 0)
                info.Add("empty");

            if (info.Count > 0)
                name += " (" + string.Join(",", info) + ")";

            return name;
        }

        public void AddElement(LevelElement element)
        {
            elements.Add(element);
            element.Layer = this;
            element.Polygon.Depth = depth;
        }

        public void RemoveElement(LevelElement selectedElement)
        {
            elements.Remove(selectedElement);
        }

        public void AddEffect(ParticleEffect effect)
        {
            effects.Add(effect);
            effect.Layer = this;
        }

        public void RemoveEffect(ParticleEffect effect)
        {
            effects.Remove(effect);
        }

        public void UpdateEffects(GameTime gameTime)
        {
            for (int i = effects.Count - 1; i >= 0; i--)
            {
                if (effects[i].Update(gameTime))
                    effects.RemoveAt(i);
            }
        }

        public void DrawEffects(Renderer renderer)
        {
            foreach (ParticleEffect effect in effects)
                effect.Draw(renderer);
        }

        public void Draw(Renderer renderer)
        {
            if (visible)
            {
                foreach (LevelElement element in elements)
                    element.Draw(renderer);

                DrawEffects(renderer);
            }
        }

        public void DrawWithoutEffects(Renderer renderer)
        {
            if (visible)
            {
                foreach (LevelElement element in elements)
                    element.Draw(renderer);
            }
        }

        public void DrawEditor(Renderer renderer)
        {
            if (visible)
            {
                foreach (LevelElement element in elements)
                    element.DrawEditor(renderer);
            }
        }
    }
}
