using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib.input
{
    public class FakeDevice : InputDevice
    {
        public override vibrations.Vibration Vibration { get { return null; } }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override bool IsJumpButtonJustPressed()
        {
            return false;
        }

        public override bool IsResetButtonJustPressed()
        {
            return false;
        }

        public override bool IsCommonAttackButtonJustPressed()
        {
            return false;
        }

        public override bool IsSpecialAttackButtonJustPressed()
        {
            return false;
        }

        public override float GetMoveX()
        {
            return 0;
        }

        public override float GetMoveY()
        {
            return 0;
        }

        public override float GetPreviousMoveX()
        {
            return 0;
        }

        public override float GetPreviousMoveY()
        {
            return 0;
        }

        public override void Vibrate(vibrations.Vibration vibration)
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
