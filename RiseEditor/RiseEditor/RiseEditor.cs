using RoflLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RiseEditor.forms;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RiseEditor
{
    public class RiseEditor : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        RiseEditorMode riseEditorMode;
        MainWindow mainWindow;

        public RiseEditorMode RiseEditorMode { get { return riseEditorMode; } }

        public RiseEditor()
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
            riseEditorMode.UpdateWindow(width, height);
        }

        protected override void Initialize()
        {
            riseEditorMode = new RiseEditorMode(GraphicsDevice, graphics, Content);
            riseEditorMode.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            mainWindow = new MainWindow(this);
            riseEditorMode.MainWindow = mainWindow;
            mainWindow.Show();
            riseEditorMode.LoadContent();
        }

        protected override void UnloadContent()
        {
            riseEditorMode.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            riseEditorMode.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            riseEditorMode.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
