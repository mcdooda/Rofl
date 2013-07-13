using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RoflLib.input.vibrations
{
    public class Vibration
    {
        public enum VibrationType
        {
            Hard = 1,
            Soft = 2
        }

        protected PlayerIndex playerIndex;
        public PlayerIndex PlayerIndex { set { playerIndex = value; } }

        private double beginTime;
        protected double duration;
        protected float strength;
        protected VibrationType vibrationType;

        public Vibration(GameTime gameTime, double duration, float strength, VibrationType vibrationType)
        {
            beginTime = gameTime.TotalGameTime.TotalSeconds;
            this.duration = duration;
            this.strength = strength;
            this.vibrationType = vibrationType;
        }

        public virtual bool IsFinished(GameTime gameTime)
        {
            return GetAge(gameTime) > duration;
        }

        public void Stop()
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }

        public virtual void Vibrate(GameTime gameTime)
        {
            float leftStrength = 0;
            float rightStrength = 0;

            if ((vibrationType & VibrationType.Hard) == VibrationType.Hard)
                rightStrength = strength;
            
            if ((vibrationType & VibrationType.Soft) == VibrationType.Soft)
                leftStrength = strength;

            GamePad.SetVibration(playerIndex, leftStrength, rightStrength);
        }

        protected double GetAge(GameTime gameTime)
        {
            return gameTime.TotalGameTime.TotalSeconds - beginTime;
        }

    }
}
