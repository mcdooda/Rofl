using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib
{
    public class HitPoint
    {
        private float size;
        public float Size { get { return size; } set { size = value; } }

        private Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        private float damage;
        public float Damage { get { return damage; } set { damage = value; } }

        private Vector2 direction;
        public Vector2 Direction { get { return direction; } set { direction = value; } }

        private Attack attack;
        public Attack Attack { get { return attack; } set { attack = value; } }

        private double duration;
        public double Duration { get { return duration; } set { duration = value; } }

        private double popTime;
        public double PopTime { get { return popTime; } set { popTime = value; } }

        public Character Attacker { get { return attack.Attacker; } }

        public HitPoint(float size, Vector2 position, float damage, Vector2 direction)
        {
            this.size = size;
            this.position = position;
            this.damage = damage;
            this.direction = direction;
        }

        public HitPoint Clone()
        {
            HitPoint clone = new HitPoint(size, position, damage, direction);
            clone.attack = attack; // not cloned!
            return clone;
        }
    }
}
