using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.IO;
using RoflLib.utils.math;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflLib.io.level
{
    public class LevelReader
    {
        private byte[] levelData;
        private ContentManager content;

        public LevelReader(byte[] levelData, ContentManager content)
        {
            this.levelData = levelData;
            this.content = content;
        }

        public Level Read()
        {
            Level level = new Level();

            MemoryStream ms = new MemoryStream(levelData);
            BinaryReader br = new BinaryReader(ms);

            // header
            string header = br.ReadString();
            if (header != "RoflLevel")
                return null;

            // bounds
            float left = br.ReadSingle();
            float top = br.ReadSingle();
            float width = br.ReadSingle();
            float height = br.ReadSingle();
            level.Bounds = new FloatRectangle(left, top, width, height);

            // read textures
            int numTextures = br.ReadInt32();
            Texture2D[] textures = new Texture2D[numTextures];
            for (int i = 0; i < numTextures; i++)
            {
                string textureName = br.ReadString();
                textures[i] = content.Load<Texture2D>(textureName);
                textures[i].Name = textureName;
            }

            // read effects
            int numEffects = br.ReadInt32();
            Effect[] effects = new Effect[numEffects];
            for (int i = 0; i < numEffects; i++)
            {
                string effectName = br.ReadString();
                effects[i] = content.Load<Effect>(effectName);
                effects[i].Name = effectName;

                if (effects[i].Parameters["time"] != null)
                    level.AddTimedEffect(effects[i]);
            }

            // read particle effects
            int numParticleEffects = br.ReadInt32();
            ParticleEffect[] particleEffects = new ParticleEffect[numParticleEffects];
            for (int i = 0; i < numParticleEffects; i++)
            {
                string particleEffectName = br.ReadString();
                particleEffects[i] = ParticleEffect.Get(particleEffectName);
            }

            // read layers
            int numLayers = br.ReadInt32();
            for (int i = 0; i < numLayers; i++)
            {
                float depth = br.ReadSingle();
                LevelLayer layer = new LevelLayer(depth);

                // read each element
                int numElements = br.ReadInt32();
                for (int j = 0; j < numElements; j++)
                {
                    int textureId = br.ReadInt32();
                    Texture2D texture = textures[textureId];
                    float x = br.ReadSingle();
                    float y = br.ReadSingle();
                    Vector2 center = new Vector2(x, y);

                    bool hasEffect = br.ReadBoolean();
                    Effect effect = null;
                    if (hasEffect)
                    {
                        int effectId = br.ReadInt32();
                        effect = effects[effectId];
                    }

                    Texture2D[] additionalTextures = null;
                    int numAdditionalTextures = br.ReadInt32();
                    if (numAdditionalTextures > 0)
                    {
                        additionalTextures = new Texture2D[numAdditionalTextures];
                        for (int k = 0; k < numAdditionalTextures; k++)
                        {
                            int additionalTextureId = br.ReadInt32();
                            additionalTextures[k] = textures[additionalTextureId];
                        }
                    }

                    LevelElement element = new LevelElement(texture, additionalTextures, effect, center);
                    if (depth == 0) // read element hitbox
                    {
                        int numVertices = br.ReadInt32();
                        List<Vertex> vertices = new List<Vertex>();
                        for (int k = 0; k < numVertices; k++)
                        {
                            float vertexX = br.ReadSingle();
                            float vertexY = br.ReadSingle();
                            Vertex vertex = new Vertex(vertexX, vertexY);
                            vertices.Add(vertex);
                        }
                        element.Polygon = new Polygon(vertices);
                        element.Polygon.Color = Color.Blue;
                    }
                    layer.AddElement(element);
                }

                // read each particle effect
                int numLayerEffects = br.ReadInt32();
                for (int j = 0; j < numLayerEffects; j++)
                {
                    int effectId = br.ReadInt32();
                    float x = br.ReadSingle();
                    float y = br.ReadSingle();
                    // TODO: add particle effect to layer
                    layer.AddEffect(particleEffects[effectId].New(null, new Vector2(x, y)));
                }

                level.AddLayer(layer, false);
            }
            level.SortLayers();

            return level;
        }
    }
}
