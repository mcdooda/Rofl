using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib
{
    public class Attack : Animation.Frame
    {
        private Character attacker;
        public Character Attacker { get { return attacker; } set { attacker = value; } }

        private List<HitPoint> hitPoints;
        public List<HitPoint> HitPoints { get { return hitPoints; } }

        public HitPoint CurrentHitPoint { get { return hitPoints[numFrameUpdates]; } }

        private List<HitPoint> worldHitPoints;
        public List<HitPoint> WorldHitPoints { set { worldHitPoints = value; } }

        public Attack(int beginLine, int beginColumn, double frameDuration, double freezeDuration, List<HitPoint> hitPoints)
            : base(beginLine, beginColumn, hitPoints.Count, frameDuration, freezeDuration)
        {
            this.hitPoints = hitPoints;
            foreach (HitPoint hitPoint in hitPoints)
            {
                if (hitPoint != null)
                    hitPoint.Attack = this;
            }
        }

        protected override void FrameChanged(GameTime gameTime, Animation animation)
        {
            if (numFrameUpdates < hitPoints.Count && hitPoints[numFrameUpdates] != null)
            {
                HitPoint currentHitPoint = hitPoints[numFrameUpdates].Clone();
                currentHitPoint.Position = new Vector2(attacker.Position.X + currentHitPoint.Position.X * (int)attacker.Direction, attacker.Position.Y + currentHitPoint.Position.Y);
                currentHitPoint.Direction = new Vector2(currentHitPoint.Direction.X * (int)attacker.Direction, currentHitPoint.Direction.Y);
                currentHitPoint.PopTime = gameTime.TotalGameTime.TotalSeconds;
                currentHitPoint.Duration = frameDuration;
                worldHitPoints.Add(currentHitPoint);
            }
        }

    }
}
