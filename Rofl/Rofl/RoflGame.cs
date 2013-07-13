using RoflLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Rofl
{
    public class RoflGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        private GameMode gameMode;
        public GameMode GameMode { get { return gameMode; } }

        private ChooseCharacterMode chooseCharacterMode;
        public ChooseCharacterMode ChooseCharacterMode { get { return chooseCharacterMode; } }

        private AppMode currentMode;
        public AppMode CurrentMode { set { currentMode = value; } }

        public RoflGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
#if false
            DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            graphics.PreferredBackBufferWidth = displayMode.Width;
            graphics.PreferredBackBufferHeight = displayMode.Height;
            graphics.IsFullScreen = true;
#else
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.AllowUserResizing = true;
#endif
        }

        protected override void Initialize()
        {
            gameMode = new GameMode(GraphicsDevice, graphics, Content);
            gameMode.Initialize();

            chooseCharacterMode = new ChooseCharacterMode(GraphicsDevice, graphics, Content);
            chooseCharacterMode.Initialize();

            currentMode = gameMode;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            gameMode.LoadContent();
            chooseCharacterMode.LoadContent();
        }

        protected override void UnloadContent()
        {
            gameMode.UnloadContent();
            chooseCharacterMode.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            currentMode.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentMode.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
