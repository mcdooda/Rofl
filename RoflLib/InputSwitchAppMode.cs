using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RoflLib
{
    public abstract class InputSwitchAppMode : AppMode
    {
        private bool inputEnabled;
        public bool InputEnabled { set { inputEnabled = value; } }

        public InputSwitchAppMode(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ContentManager content)
            : base(graphicsDevice, graphics, content)
        {
            inputEnabled = true;
        }

        public new bool IsPressed(Keys key)
        {
            return inputEnabled && base.IsPressed(key);
        }

        public new bool IsJustPressed(Keys key)
        {
            return inputEnabled && base.IsJustPressed(key);
        }

        public new bool IsJustReleased(Keys key)
        {
            return inputEnabled && base.IsJustReleased(key);
        }

        public new bool IsMouseLeftPressed()
        {
            return inputEnabled && base.IsMouseLeftPressed();
        }

        public new bool IsMouseLeftJustPressed()
        {
            return inputEnabled && base.IsMouseLeftJustPressed();
        }

        public new bool IsMouseLeftJustReleased()
        {
            return inputEnabled && base.IsMouseLeftJustReleased();
        }

        public new bool IsMouseRightPressed()
        {
            return inputEnabled && base.IsMouseRightPressed();
        }

        public new bool IsMouseRightJustPressed()
        {
            return inputEnabled && base.IsMouseRightJustPressed();
        }

        public new bool IsMouseRightJustReleased()
        {
            return inputEnabled && base.IsMouseRightJustReleased();
        }

        public new bool IsMouseMiddlePressed()
        {
            return inputEnabled && base.IsMouseMiddlePressed();
        }

        public new bool IsMouseMiddleJustPressed()
        {
            return inputEnabled && base.IsMouseMiddleJustPressed();
        }

        public new bool IsMouseMiddleJustReleased()
        {
            return inputEnabled && base.IsMouseMiddleJustReleased();
        }

        public new bool IsMouseXButton1Pressed()
        {
            return inputEnabled && base.IsMouseXButton1Pressed();
        }

        public new bool IsMouseXButton1JustPressed()
        {
            return inputEnabled && base.IsMouseXButton1JustPressed();
        }

        public new bool IsMouseXButton1JustReleased()
        {
            return inputEnabled && base.IsMouseXButton1JustReleased();
        }

        public new bool IsMouseXButton2Pressed()
        {
            return inputEnabled && base.IsMouseXButton2Pressed();
        }

        public new bool IsMouseXButton2JustPressed()
        {
            return inputEnabled && base.IsMouseXButton2JustPressed();
        }

        public new bool IsMouseXButton2JustReleased()
        {
            return inputEnabled && base.IsMouseXButton2JustReleased();
        }

        public new int GetMouseWheelDelta()
        {
            return inputEnabled ? base.GetMouseWheelDelta() : 0;
        }
    }
}
