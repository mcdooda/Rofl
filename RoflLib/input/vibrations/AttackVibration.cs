using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RoflLib.input.vibrations
{
    public class AttackVibration : Vibration
    {

        public AttackVibration(GameTime gameTime, double duration)
            : base(gameTime, duration, 0, 0)
        {

        }

        public override void Vibrate(GameTime gameTime)
        {
            float age = (float)GetAge(gameTime);
            float leftStrength = 0;
            float rightStrength = 0;

            if (duration - age > 0.2)
                rightStrength = (float)(age / duration / 2);

            else
            {
                rightStrength = 1f;
                leftStrength = 1f;
            }

            GamePad.SetVibration(playerIndex, leftStrength, rightStrength);
        }

    }
}
