using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RoflLib
{
    public abstract class AppMode
    {
        protected GraphicsDeviceManager graphics;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager content;
        public ContentManager Content { get { return content; } }

        protected KeyboardState previousKeyboardState;
        protected KeyboardState currentKeyboardState;

        protected MouseState previousMouseState;
        protected MouseState currentMouseState;

        protected Level level;
        public Level Level { get { return level; } }

        protected Renderer renderer;

        protected Random random;

        public Renderer Renderer { get { return renderer; } }

        abstract public void Draw(GameTime gameTime);

        public AppMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            this.content = content;

            this.random = new Random();

            currentKeyboardState = Keyboard.GetState();
            previousKeyboardState = currentKeyboardState;

            currentMouseState = Mouse.GetState();
            previousMouseState = currentMouseState;
        }

        public virtual void Initialize()
        {
            level = new Level();
        }

        public virtual void LoadContent()
        {
            renderer = new Renderer(graphicsDevice, graphics);
        }

        public virtual void UnloadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool IsPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public bool IsJustPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        public bool IsJustReleased(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
        }

        public bool IsMouseLeftPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsMouseLeftJustPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsMouseLeftJustReleased()
        {
            return currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsMouseRightPressed()
        {
            return currentMouseState.RightButton == ButtonState.Pressed;
        }

        public bool IsMouseRightJustPressed()
        {
            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }

        public bool IsMouseRightJustReleased()
        {
            return currentMouseState.RightButton == ButtonState.Released && previousMouseState.RightButton == ButtonState.Pressed;
        }

        public bool IsMouseMiddlePressed()
        {
            return currentMouseState.MiddleButton == ButtonState.Pressed;
        }

        public bool IsMouseMiddleJustPressed()
        {
            return currentMouseState.MiddleButton == ButtonState.Pressed && previousMouseState.MiddleButton == ButtonState.Released;
        }

        public bool IsMouseMiddleJustReleased()
        {
            return currentMouseState.MiddleButton == ButtonState.Released && previousMouseState.MiddleButton == ButtonState.Pressed;
        }

        public bool IsMouseXButton1Pressed()
        {
            return currentMouseState.XButton1 == ButtonState.Pressed;
        }

        public bool IsMouseXButton1JustPressed()
        {
            return currentMouseState.XButton1 == ButtonState.Pressed && previousMouseState.XButton1 == ButtonState.Released;
        }

        public bool IsMouseXButton1JustReleased()
        {
            return currentMouseState.XButton1 == ButtonState.Released && previousMouseState.XButton1 == ButtonState.Pressed;
        }

        public bool IsMouseXButton2Pressed()
        {
            return currentMouseState.XButton2 == ButtonState.Pressed;
        }

        public bool IsMouseXButton2JustPressed()
        {
            return currentMouseState.XButton2 == ButtonState.Pressed && previousMouseState.XButton2 == ButtonState.Released;
        }

        public bool IsMouseXButton2JustReleased()
        {
            return currentMouseState.XButton2 == ButtonState.Released && previousMouseState.XButton2 == ButtonState.Pressed;
        }

        public int GetMouseWheelDelta()
        {
            return currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue;
        }

        public bool IsMouseInside()
        {
            Vector2 mouse = GetMousePosition();
            return mouse.X >= 0 && mouse.X < renderer.Width && mouse.Y >= 0 && mouse.Y < renderer.Height;
        }

        public Vector2 GetMousePosition()
        {
            return new Vector2(currentMouseState.X, currentMouseState.Y);
        }

        public Vector2 GetMouseCameraRelativePosition()
        {
            return renderer.GetCameraRelative(GetMousePosition());
        }

        public Vector2 GetMouseCameraRelativePositionDepth(float depth)
        {
            return renderer.GetCameraRelative(GetMousePosition(), depth);
        }

        public void UpdateWindow(int width, int height)
        {
            if (renderer != null)
                renderer.Update(width, height);
        }

    }
}
