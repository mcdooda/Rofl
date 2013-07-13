using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib.utils.math
{
    public class LineSegment : Shape
    {
        public Vector2 A { get; set; }
        public Vector2 B { get; set; }

        public float Derivative
        {
            get
            {
                float dx = B.X - A.X;

                if (dx == 0)
                    return float.PositiveInfinity;

                else
                {
                    return (B.Y - A.Y) / dx;
                }
            }
        }

        public LineSegment(Vector2 a, Vector2 b)
        {
            A = a;
            B = b;
            color = Color.Blue;
        }

        public override void Draw(Renderer renderer)
        {
            primitiveList = new VertexPositionColor[2];
            primitiveList[0] = new VertexPositionColor(new Vector3(A, 0), color);
            primitiveList[1] = new VertexPositionColor(new Vector3(B, 0), color);

            lineListIndices = new short[2];
            lineListIndices[0] = 0;
            lineListIndices[1] = 1;

            renderer.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                primitiveList,
                0,               // vertex buffer offset to add to each element of the index buffer
                2,               // number of vertices in pointList
                lineListIndices, // the index buffer
                0,               // first index element to read
                1                // number of primitives to draw
            );
        }
    }
}
