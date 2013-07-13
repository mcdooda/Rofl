using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RoflLib.utils.math;
using RoflLib.io.level;

namespace RoflLib
{
    public class Level
    {
        private List<LevelLayer> layers;
        public List<LevelLayer> Layers { get { return layers; } }

        private LevelLayer platformsLayer;
        public LevelLayer PlatformsLayer { get { return platformsLayer; } }

        private FloatRectangle bounds;
        public FloatRectangle Bounds { get { return bounds; } set { bounds = value; bounds.Color = Color.Green; } }

        private List<Effect> timedEffects;

        private LevelLayerDepthComparer layerDepthComparer;

        public Level()
        {
            layers = new List<LevelLayer>();
            layerDepthComparer = new LevelLayerDepthComparer();
            timedEffects = new List<Effect>();
            bounds = new FloatRectangle(-1000, -1000, 2000, 1700);
            bounds.Color = Color.Green;
        }

        public void AddLayer(LevelLayer layer, bool sort)
        {
            layers.Add(layer);

            if (layer.Depth == 0)
                platformsLayer = layer;

            if (sort)
                SortLayers();
        }

        public void AddLayer(LevelLayer layer)
        {
            AddLayer(layer, true);
        }

        public void RemoveLayer(LevelLayer layer)
        {
            layers.Remove(layer);
        }

        public void SortLayers()
        {
            layers.Sort(layerDepthComparer);
        }

        public void DrawWithCharacters(Renderer renderer, List<Character> characters)
        {
            int i = 0;
            for (; layers[i] != platformsLayer; i++)
                layers[i].Draw(renderer);

            //TODO: fix characters depth
            platformsLayer.Draw(renderer);

            foreach (Character character in characters)
                character.Draw(renderer);

            for (i++; i < layers.Count; i++)
                layers[i].Draw(renderer);
        }

        public void Draw(Renderer renderer)
        {
            foreach (LevelLayer layer in layers)
                layer.Draw(renderer);
        }

        public void DrawWithoutEffects(Renderer renderer)
        {
            foreach (LevelLayer layer in layers)
                layer.DrawWithoutEffects(renderer);
        }

        public LevelData GetLevelData()
        {
            LevelWriter levelWriter = new LevelWriter(this);
            return new LevelData(levelWriter.Write());
        }

        public void AddTimedEffect(Effect timedEffect)
        {
            if (timedEffects.IndexOf(timedEffect) == -1)
                timedEffects.Add(timedEffect);
        }

        public void UpdateEffects(GameTime gameTime)
        {
            foreach (LevelLayer layer in layers)
                layer.UpdateEffects(gameTime);

            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            foreach (Effect timedEffect in timedEffects)
                timedEffect.Parameters["time"].SetValue(time);
        }
    }
}
