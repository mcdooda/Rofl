using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib.utils.math
{
    public class Circle : Shape
    {
        private static int verticesCount = 32;

        private Vector2 center;
        public Vector2 Center { get { return center; } set { center = value; } }

        private float radius;
        public float Radius { get { return radius; } set { radius = value; } }

        public Circle(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        private void ComputeDrawingVertices()
        {
            primitiveList = new VertexPositionColor[verticesCount];
            lineListIndices = new short[verticesCount * 2];

            Vector3 vertexPosition = new Vector3(0, 0, 0);
            for (int i = 0; i < verticesCount; i++)
            {
                vertexPosition.X = center.X + (float)(Math.Cos(Math.PI * 2 * i / verticesCount) * radius);
                vertexPosition.Y = center.Y + (float)(Math.Sin(Math.PI * 2 * i / verticesCount) * radius);
                primitiveList[i] = new VertexPositionColor(vertexPosition, color);
                lineListIndices[i * 2] = (short)(i % verticesCount);
                lineListIndices[i * 2 + 1] = (short)((i + 1) % verticesCount);
            }
        }

        public override void Draw(Renderer renderer)
        {
            ComputeDrawingVertices();

            renderer.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                primitiveList,
                0,               // vertex buffer offset to add to each element of the index buffer
                verticesCount,  // number of vertices in pointList
                lineListIndices, // the index buffer
                0,               // first index element to read
                verticesCount   // number of primitives to draw
            );
        }
    }
}
