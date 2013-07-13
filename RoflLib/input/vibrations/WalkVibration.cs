using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RoflLib.input.vibrations
{
    public class WalkVibration : Vibration
    {
        public WalkVibration(GameTime gameTime)
            : base(gameTime, 0, 0, 0)
        {

        }

        public override bool IsFinished(GameTime gameTime)
        {
            return false;
        }

        public override void Vibrate(GameTime gameTime)
        {
            GamePad.SetVibration(playerIndex, 0, 0.2f);
        }
    }
}
