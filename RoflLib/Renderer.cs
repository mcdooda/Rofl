using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RoflLib.utils.math;

namespace RoflLib
{
    public class Renderer
    {
        private GraphicsDevice graphicsDevice;
        public GraphicsDevice GraphicsDevice { get { return graphicsDevice; } }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BasicEffect basicEffect;

        private Vector2 topLeft;
        public Vector2 TopLeft { get { return topLeft; } }

        private Vector2 bottomRight;
        public Vector2 BottomRight { get { return bottomRight; } }

        private Dictionary<string, Texture2D> utilityTextures;
        public Dictionary<string, Texture2D> UtilityTextures { get { return utilityTextures; } }

        public int Width { get { return graphicsDevice.Viewport.Width; } }
        public int Height { get { return graphicsDevice.Viewport.Height; } }

        private Effect currentEffect;
        private bool spriteBatchBegun;
        private Texture2D[] currentTextures;

        private float zoom;
        public float Zoom
        {
            get { return zoom; }

            set
            {
                float z = value;
                if (z < 0.1f)
                    z = 0.1f;

                if (z != zoom)
                {
                    zoom = z;
                    topLeft.X = -Width / 2 / zoom + center.X;
                    topLeft.Y = -Height / 2 / zoom + center.Y;
                    bottomRight.X = topLeft.X + Width / zoom;
                    bottomRight.Y = topLeft.Y + Height / zoom;
                    InitializeTransform();
                }
            }
        }

        private Vector2 center;
        public Vector2 Center
        {
            get { return center; }

            set
            {
                if (value.X != center.X || value.Y != center.Y)
                {
                    center = value;
                    topLeft.X = -Width / 2 / zoom + value.X;
                    topLeft.Y = -Height / 2 / zoom + value.Y;
                    bottomRight.X = topLeft.X + Width / zoom;
                    bottomRight.Y = topLeft.Y + Height / zoom;
                    InitializeTransform();
                }
            }
        }

        public Renderer(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            this.spriteBatch = new SpriteBatch(graphicsDevice);
            this.utilityTextures = new Dictionary<string, Texture2D>();
            this.zoom = 1;
            InitializeEffect();
            center = Vector2.One;
            Center = Vector2.Zero;
            currentEffect = null;
            spriteBatchBegun = false;
            currentTextures = null;
        }

        public void Update(int width, int height)
        {
            if (graphics.PreferredBackBufferWidth != width || graphics.PreferredBackBufferHeight != height)
            {
                graphics.PreferredBackBufferWidth = width;
                graphics.PreferredBackBufferHeight = height;
                graphics.ApplyChanges();
                center.X = 1; // enforces re-computing center
                Center = Vector2.Zero;
            }
        }

        private void InitializeTransform()
        {
            basicEffect.View = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 1.0f), Vector3.Zero, Vector3.Up);
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(
                topLeft.X,
                bottomRight.X,
                bottomRight.Y,
                topLeft.Y,
                1.0f,
                1000.0f
            );
        }

        private void InitializeEffect()
        {
            basicEffect = new BasicEffect(graphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.World = Matrix.Identity;
        }

        public void BeginTextures()
        {
            if (!spriteBatchBegun)
            {
                spriteBatch.Begin();
                spriteBatchBegun = true;
                currentEffect = null;
                currentTextures = null;
            }
            else if (currentEffect != null)
            {
                spriteBatch.End();
                spriteBatch.Begin();
                currentEffect = null;
                currentTextures = null;
            }
        }

        public void BeginTextures(Effect effect, Texture2D[] textures)
        {
            if (!spriteBatchBegun)
            {
                int i = 1;
                foreach (Texture2D texture in textures)
                {
                    graphicsDevice.Textures[i] = texture;
                    i++;
                }
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, effect);
                spriteBatchBegun = true;
                currentEffect = effect;
                currentTextures = textures;
            }
            else if (currentEffect != effect || currentTextures != textures)
            {
                spriteBatch.End();
                if (textures != null)
                {
                    int i = 1;
                    foreach (Texture2D texture in textures)
                    {
                        graphicsDevice.Textures[i] = texture;
                        i++;
                    }
                }
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, effect);
                currentEffect = effect;
                currentTextures = textures;
            }
        }

        public void EndTextures()
        {
            spriteBatch.End();
            spriteBatchBegun = false;
            currentEffect = null;
            currentTextures = null;
        }

        public void DrawTexture(Texture2D texture, Vector2 textureCenter, float depth = 0)
        {
            spriteBatch.Draw(
                texture,
                (-topLeft + textureCenter + center * (1 - (float)Math.Pow(2, depth))) * zoom - new Vector2(texture.Width, texture.Height) / 2,
                Color.White
            );
        }

        public void DrawInterfaceTexture(Texture2D texture, Vector2 textureCenter)
        {
            spriteBatch.Draw(texture, textureCenter - new Vector2(texture.Width, texture.Height) / 2, Color.White);
        }

        public void DrawInterfaceTexture(Texture2D texture, Vector2 textureCenter, Color color)
        {
            spriteBatch.Draw(texture, textureCenter - new Vector2(texture.Width, texture.Height) / 2, color);
        }

        public void DrawInterfaceTexture(Texture2D texture, Vector2 textureCenter, Color color, float scale)
        {
            spriteBatch.Draw(texture, textureCenter, null, color, 0, new Vector2(texture.Width, texture.Height) / 2, scale, SpriteEffects.None, 0);
        }

        public void DrawStringFromRight(SpriteFont spriteFont, string text, Vector2 position, Color color, float scale)
        {
            Vector2 size = spriteFont.MeasureString(text);
            size.X *= scale;
            size.Y = 0;
            spriteBatch.DrawString(spriteFont, text, position - size, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public void DrawAnimation(Animation animation)
        {
            Vector2 position = (-topLeft + animation.Position + center * (1 - (float)Math.Pow(2, animation.Depth))) * zoom;
            spriteBatch.Draw(animation.Texture, position, animation.SourceRectangle, animation.Color, animation.Rotation, animation.Center, animation.Scale * zoom, animation.SpriteEffects, 0);
        }

        public void DrawElement(LevelElement element)
        {
            Vector2 position = new Vector2(
                (-topLeft.X + element.Center.X + center.X * (1 - (float)Math.Pow(2, element.Layer.Depth))),
                (-topLeft.Y + element.Center.Y + center.Y * (1 - (float)Math.Pow(2, element.Layer.Depth)))
                //(-topLeft.Y + element.Center.Y)
            ) * zoom;
            spriteBatch.Draw(
                element.Texture,
                position,
                null,
                Color.White,
                0,
                element.HalfSize,
                zoom,
                SpriteEffects.None,
                0
            );
        }

        public void DrawParticle(Particle particle)
        {
            float depth = particle.Effect.Layer.Depth;
            Vector2 position = new Vector2(
                (-topLeft.X + particle.Position.X + center.X * (1 - (float)Math.Pow(2, depth))),
                (-topLeft.Y + particle.Position.Y + center.Y * (1 - (float)Math.Pow(2, depth)))
                //(-topLeft.Y + element.Center.Y)
            ) * zoom;
            spriteBatch.Draw(
                particle.Texture,
                position,
                null,
                particle.Color,
                particle.Rotation,
                particle.HalfSize,
                zoom * particle.Scale,
                SpriteEffects.None,
                0
            );
        }

        public void DrawShape(Shape shape)
        {
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                shape.Draw(this);
            }
        }

        public void AddUtilityTexture(ContentManager content, string name)
        {
            utilityTextures[name] = content.Load<Texture2D>(name);
        }

        public Vector2 GetCameraRelative(Vector2 position)
        {
            return position / zoom + topLeft;
        }

        public Vector2 GetCameraRelative(Vector2 position, float depth)
        {
            return position / zoom + topLeft - center * (1 - (float)Math.Pow(2, depth));
        }

        public void Clear(Color color)
        {
            graphicsDevice.Clear(color);
        }
    }
}
