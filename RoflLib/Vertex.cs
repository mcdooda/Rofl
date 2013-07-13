using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib
{
    public class Vertex
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2 Vector2 { get { return new Vector2(X, Y); } }

        public Vertex(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vertex(Vector2 vector2)
        {
            X = vector2.X;
            Y = vector2.Y;
        }
    }
}
