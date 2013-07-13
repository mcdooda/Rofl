using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflLib.utils.math
{
    public class Shape
    {
        protected VertexPositionColor[] primitiveList;
        public VertexPositionColor[] PrimitiveList { get { return primitiveList; } }

        protected short[] lineListIndices;
        public short[] LineListIndices { get { return lineListIndices; } }

        protected Color color;
        public Color Color { get { return color; } set { color = value; } }

        protected float depth;
        public float Depth { get { return depth; } set { depth = value; } }

        public Shape()
        {
            color = Color.Black;
            depth = 0;
        }

        public virtual void Draw(Renderer renderer)
        {

        }

        public virtual bool IsInside(Vector2 point)
        {
            return false;
        }

        public virtual void SetOrigin(Vector2 origin)
        {
            throw new NotImplementedException();
        }
    }
}
