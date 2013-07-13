using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoflLib.input.vibrations;

namespace RoflLib.input
{
    public class GamePadDevice : InputDevice
    {
        public override Vibration Vibration { get { return vibration; } }

        private PlayerIndex playerIndex;
        private GamePadState currentGamePadState;
        private GamePadState previousGamePadState;
        private Vibration vibration;

        public GamePadDevice(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
            currentGamePadState = GamePad.GetState(playerIndex);
            previousGamePadState = currentGamePadState;
        }

        public override void Update(GameTime gameTime)
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(playerIndex);

            if (vibration != null)
            {
                bool remove = vibration.IsFinished(gameTime);

                if (remove)
                {
                    vibration.Stop();
                    vibration = null;
                }
                else
                    vibration.Vibrate(gameTime);
            }
        }

        public override bool IsJumpButtonJustPressed()
        {
            return previousGamePadState.IsButtonUp(Buttons.B) && currentGamePadState.IsButtonDown(Buttons.B) || previousGamePadState.IsButtonUp(Buttons.Y) && currentGamePadState.IsButtonDown(Buttons.Y);
        }

        public override bool IsResetButtonJustPressed()
        {
            return previousGamePadState.IsButtonUp(Buttons.LeftShoulder) && currentGamePadState.IsButtonDown(Buttons.LeftShoulder);
        }

        public override bool IsCommonAttackButtonJustPressed()
        {
            return previousGamePadState.IsButtonUp(Buttons.A) && currentGamePadState.IsButtonDown(Buttons.A);
        }

        public override bool IsSpecialAttackButtonJustPressed()
        {
            return previousGamePadState.IsButtonUp(Buttons.B) && currentGamePadState.IsButtonDown(Buttons.B);
        }

        public override float GetMoveX()
        {
            return currentGamePadState.ThumbSticks.Left.X;
        }

        public override float GetMoveY()
        {
            return currentGamePadState.ThumbSticks.Left.Y;
        }

        public override float GetPreviousMoveX()
        {
            return previousGamePadState.ThumbSticks.Left.X;
        }

        public override float GetPreviousMoveY()
        {
            return previousGamePadState.ThumbSticks.Left.Y;
        }

        public override void Vibrate(Vibration vibration)
        {
            this.vibration = vibration;
        }

        public override void StopVibration()
        {
            if (vibration != null)
                vibration.Stop();

            vibration = null;
        }

        public override bool IsConnected()
        {
            return GamePad.GetState(playerIndex).IsConnected;
        }
    }
}
