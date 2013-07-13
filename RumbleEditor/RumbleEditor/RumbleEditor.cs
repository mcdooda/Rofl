using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RumbleEditor.forms;

namespace RumbleEditor
{
    public class RumbleEditor : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        RumbleEditorMode rumbleEditorMode;
        MainWindow mainWindow;

        public RumbleEditorMode RumbleEditorMode { get { return rumbleEditorMode; } }

        public RumbleEditor()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            {
                System.Windows.Forms.Form xnaFrame = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(Window.Handle);
                xnaFrame.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }

        public void UpdateWindow(int x, int y, int width, int height)
        {
            rumbleEditorMode.UpdateWindow(width, height);
        }

        protected override void Initialize()
        {
            rumbleEditorMode = new RumbleEditorMode(GraphicsDevice, graphics, Content);
            rumbleEditorMode.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            mainWindow = new MainWindow(this);
            rumbleEditorMode.MainWindow = mainWindow;
            mainWindow.Show();
            rumbleEditorMode.LoadContent();
        }

        protected override void UnloadContent()
        {
            rumbleEditorMode.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            rumbleEditorMode.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            rumbleEditorMode.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
