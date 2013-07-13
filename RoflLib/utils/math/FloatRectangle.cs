using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RoflLib.utils.math
{
    public class FloatRectangle : Shape
    {
        private Vertex position;
        private Vertex size;

        public Vertex Position { get { return position; } }
        public Vertex Size { get { return size; } }

        public float Left { get { return position.X; } set { position.X = value; } }
        public float Right { get { return position.X + size.X; } set { position.X = value - size.X; } }
        public float Top { get { return position.Y; } set { position.Y = value; } }
        public float Bottom { get { return position.Y + size.Y; } set { position.Y = value - size.Y; } }

        public float Width { get { return size.X; } set { size.X = value; } }
        public float Height { get { return size.Y; } set { size.Y = value; } }

        public FloatRectangle(float x, float y, float width, float height)
            : base()
        {
            position = new Vertex(x, y);
            size = new Vertex(width, height);
        }

        private void ComputeDrawingVertices(Renderer renderer)
        {
            Polygon polygon = ToPolygon();
            polygon.ComputeDrawingVertices(renderer);
            primitiveList = polygon.PrimitiveList;
            lineListIndices = polygon.LineListIndices;
        }

        public override void Draw(Renderer renderer)
        {
            ComputeDrawingVertices(renderer);
            renderer.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                primitiveList,
                0,               // vertex buffer offset to add to each element of the index buffer
                4,               // number of vertices in pointList
                lineListIndices, // the index buffer
                0,               // first index element to read
                4                // number of primitives to draw
            );
        }

        public override bool IsInside(Vector2 point)
        {
            return point.X >= Left && point.X <= Right
                && point.Y >= Top && point.Y <= Bottom;
        }

        public Polygon ToPolygon()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(Left, Top));
            vertices.Add(new Vertex(Right, Top));
            vertices.Add(new Vertex(Right, Bottom));
            vertices.Add(new Vertex(Left, Bottom));
            Polygon polygon = new Polygon(vertices);
            polygon.Color = color;
            return polygon;
        }

        public override void SetOrigin(Vector2 origin)
        {
            position.X = origin.X;
            position.Y = origin.Y;
        }

        public static bool Intersect(FloatRectangle a, FloatRectangle b)
        {
            return !(b.Left > a.Right || b.Right < a.Left || b.Top > a.Bottom || b.Bottom < a.Top);
        }

        public static FloatRectangle IntersectRectangle(FloatRectangle a, FloatRectangle b)
        {
            float interLeft = Math.Max(a.Left, b.Left);
            float interTop = Math.Max(a.Top, b.Top);
            float interRight = Math.Min(a.Right, b.Right);
            float interBottom = Math.Min(a.Bottom, b.Bottom);

            if (interLeft < interRight && interTop < interBottom)
                return new FloatRectangle(interLeft, interTop, interRight - interLeft, interBottom - interTop);

            else
                return null;
        }
    }
}
