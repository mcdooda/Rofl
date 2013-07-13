using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RoflLib.input.vibrations;

namespace RoflLib.input
{
    public abstract class InputDevice
    {
        public abstract Vibration Vibration { get; }

        public abstract void Update(GameTime gameTime);

        public abstract bool IsJumpButtonJustPressed();
        public abstract bool IsResetButtonJustPressed();

        public abstract bool IsCommonAttackButtonJustPressed();
        public abstract bool IsSpecialAttackButtonJustPressed();

        public abstract float GetMoveX();
        public abstract float GetMoveY();

        public abstract float GetPreviousMoveX();
        public abstract float GetPreviousMoveY();

        public abstract void Vibrate(Vibration vibration);
        public abstract void StopVibration();

        public abstract bool IsConnected();
    }
}
