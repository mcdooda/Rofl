using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RoflLib.input.vibrations
{
    public class DeathVibration : Vibration
    {

        public DeathVibration(GameTime gameTime)
            : base(gameTime, 0.7, 1f, VibrationType.Soft | VibrationType.Hard)
        {

        }

        public override void Vibrate(GameTime gameTime)
        {
            float force = 1f - ((float)GetAge(gameTime) / 2f);
            GamePad.SetVibration(playerIndex, force, 1);
        }

    }
}
