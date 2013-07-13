using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using RoflLib.input.vibrations;

namespace RoflLib.input
{
    public class KeyboardDevice : InputDevice
    {
        public override Vibration Vibration { get { return null; } }

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public KeyboardDevice()
        {
            currentKeyboardState = Keyboard.GetState();
            previousKeyboardState = currentKeyboardState;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public override bool IsJumpButtonJustPressed()
        {
            return previousKeyboardState.IsKeyUp(Keys.Space) && currentKeyboardState.IsKeyDown(Keys.Space) || previousKeyboardState.IsKeyUp(Keys.Z) && previousKeyboardState.IsKeyDown(Keys.Z);
        }

        public override bool IsResetButtonJustPressed()
        {
            return previousKeyboardState.IsKeyUp(Keys.R) && currentKeyboardState.IsKeyDown(Keys.R);
        }

        public override bool IsCommonAttackButtonJustPressed()
        {
            return previousKeyboardState.IsKeyUp(Keys.N) && currentKeyboardState.IsKeyDown(Keys.N);
        }

        public override bool IsSpecialAttackButtonJustPressed()
        {
            return previousKeyboardState.IsKeyUp(Keys.B) && currentKeyboardState.IsKeyDown(Keys.B);
        }

        public override float GetMoveX()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Q) && currentKeyboardState.IsKeyUp(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Left) && currentKeyboardState.IsKeyUp(Keys.Right))
                return -1;

            else if (currentKeyboardState.IsKeyDown(Keys.D) && currentKeyboardState.IsKeyUp(Keys.Q) || currentKeyboardState.IsKeyDown(Keys.Right) && currentKeyboardState.IsKeyUp(Keys.Left))
                return 1;

            else
                return 0;
        }

        public override float GetMoveY()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Z) && currentKeyboardState.IsKeyUp(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Up) && currentKeyboardState.IsKeyUp(Keys.Down))
                return 1;

            else if (currentKeyboardState.IsKeyDown(Keys.S) && currentKeyboardState.IsKeyUp(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.Down) && currentKeyboardState.IsKeyUp(Keys.Up))
                return -1;

            else
                return 0;
        }

        public override float GetPreviousMoveX()
        {
            if (previousKeyboardState.IsKeyDown(Keys.Q) && previousKeyboardState.IsKeyUp(Keys.D) || previousKeyboardState.IsKeyDown(Keys.Left) && previousKeyboardState.IsKeyUp(Keys.Right))
                return -1;

            else if (previousKeyboardState.IsKeyDown(Keys.D) && previousKeyboardState.IsKeyUp(Keys.Q) || previousKeyboardState.IsKeyDown(Keys.Right) && previousKeyboardState.IsKeyUp(Keys.Left))
                return 1;

            else
                return 0;
        }

        public override float GetPreviousMoveY()
        {
            if (previousKeyboardState.IsKeyDown(Keys.Z) && previousKeyboardState.IsKeyUp(Keys.S) || previousKeyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Down))
                return 1;

            else if (previousKeyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.Z) || previousKeyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Up))
                return -1;

            else
                return 0;
        }

        public override void Vibrate(Vibration vibration)
        {
            
        }

        public override void StopVibration()
        {
            
        }

        public override bool IsConnected()
        {
            return true;
        }
    }
}
