using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Rofl
{
    public class ChooseCharacterMode : AppMode
    {
        public ChooseCharacterMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
            : base(graphicsDevice, graphics, content)
        {

        }

        public override void Initialize()
        {
            base.Initialize();


        }

        public override void LoadContent()
        {

            base.LoadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }

        public override void Draw(GameTime gameTime)
        {
            renderer.Clear(Color.Black);
            renderer.BeginTextures();



            renderer.EndTextures();
        }

    }
}
