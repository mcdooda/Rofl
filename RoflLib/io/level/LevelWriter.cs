using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib.io.level
{
    public class LevelWriter
    {
        private Level level;

        private List<string> textureNames;
        private Dictionary<string, int> textureIds;

        private List<string> effectNames;
        private Dictionary<string, int> effectIds;

        private List<string> particleEffectNames;
        private Dictionary<string, int> particleEffectIds;

        public LevelWriter(Level level)
        {
            this.level = level;
        }

        public byte[] Write()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);

            FillResourceIds();

            // header
            bw.Write("RoflLevel");

            // write bounds
            bw.Write(level.Bounds.Left);
            bw.Write(level.Bounds.Top);
            bw.Write(level.Bounds.Width);
            bw.Write(level.Bounds.Height);

            // write textures
            bw.Write(textureNames.Count);
            foreach (string textureName in textureNames)
                bw.Write(textureName);

            // write effects
            bw.Write(effectNames.Count);
            foreach (string effectName in effectNames)
                bw.Write(effectName);

            // write particle effects
            bw.Write(particleEffectNames.Count);
            foreach (string particleEffectName in particleEffectNames)
                bw.Write(particleEffectName);

            // write layers
            bw.Write(level.Layers.Count);
            foreach (LevelLayer layer in level.Layers)
            {
                // write each element
                bw.Write(layer.Depth);
                bw.Write(layer.Elements.Count);
                foreach (LevelElement element in layer.Elements)
                {
                    bw.Write(textureIds[element.Texture.Name]);
                    bw.Write(element.Center.X);
                    bw.Write(element.Center.Y);

                    if (element.Effect != null)
                    {
                        bw.Write(true);
                        bw.Write(effectIds[element.Effect.Name]);
                    }
                    else
                        bw.Write(false);

                    if (element.AdditionalTextures != null && element.AdditionalTextures.Length > 0)
                    {
                        bw.Write(element.AdditionalTextures.Length);

                        foreach (Texture2D texture in element.AdditionalTextures)
                            bw.Write(textureIds[texture.Name]);
                    }
                    else
                        bw.Write(0);

                    if (layer.Depth == 0) // write element hitbox
                    {
                        bw.Write(element.Polygon.Vertices.Count);
                        foreach (Vertex vertex in element.Polygon.Vertices)
                        {
                            bw.Write(vertex.X);
                            bw.Write(vertex.Y);
                        }
                    }
                }

                // write each particle effect
                bw.Write(layer.ParticleEffects.Count);
                foreach (ParticleEffect particleEffect in layer.ParticleEffects)
                {
                    bw.Write(particleEffectIds[particleEffect.Name]);
                    bw.Write(particleEffect.Position.X);
                    bw.Write(particleEffect.Position.Y);
                }
            }

            ms.Position = 0;

            int streamLength = (int)ms.Length;
            byte[] levelData = new byte[streamLength];
            ms.Read(levelData, 0, streamLength);
            bw.Close();

            return levelData;
        }

        private void FillResourceIds()
        {
            textureNames = new List<string>();
            effectNames = new List<string>();
            particleEffectNames = new List<string>();

            foreach (LevelLayer layer in level.Layers)
            {
                foreach (LevelElement element in layer.Elements)
                {
                    string textureName = element.Texture.Name;
                    if (textureNames.IndexOf(textureName) == -1)
                        textureNames.Add(textureName);

                    if (element.Effect != null && particleEffectNames.IndexOf(element.Effect.Name) == -1)
                        effectNames.Add(element.Effect.Name);

                    if (element.AdditionalTextures != null)
                    {
                        foreach (Texture2D texture in element.AdditionalTextures)
                        {
                            if (textureNames.IndexOf(texture.Name) == -1)
                                textureNames.Add(texture.Name);
                        }
                    }
                }
                foreach (ParticleEffect effect in layer.ParticleEffects)
                {
                    string particleEffectName = effect.Name;
                    if (particleEffectNames.IndexOf(particleEffectName) == -1)
                        particleEffectNames.Add(particleEffectName);
                }
            }

            textureIds = new Dictionary<string, int>();
            int id = 0;
            foreach (string textureName in textureNames)
            {
                textureIds[textureName] = id;
                id++;
            }

            effectIds = new Dictionary<string, int>();
            id = 0;
            foreach (string effectName in effectNames)
            {
                effectIds[effectName] = id;
                id++;
            }

            particleEffectIds = new Dictionary<string, int>();
            id = 0;
            foreach (string particleEffectName in particleEffectNames)
            {
                particleEffectIds[particleEffectName] = id;
                id++;
            }
        }

    }
}
