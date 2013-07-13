using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib.utils.math
{
    public class Polygon : Shape
    {
        private List<Vertex> vertices;
        public List<Vertex> Vertices { get { return vertices; } }

        private FloatRectangle boundingRectangle;
        public FloatRectangle BoundingRectangle { get { ComputeBoundingRectangle(); return boundingRectangle; } }

        public Polygon(List<Vertex> vertices)
            : base()
        {
            this.vertices = vertices;
            boundingRectangle = null;
        }

        public override bool IsInside(Vector2 point)
        {
            if (!BoundingRectangle.IsInside(point))
                return false;

            bool inside = false;
            float xinters;
            Vertex p1, p2;
            int n = vertices.Count;

            p1 = vertices[0];
            for (int i = 1; i <= n; i++)
            {
                p2 = vertices[i % n];
                if (point.Y > Math.Min(p1.Y, p2.Y))
                {
                    if (point.Y <= Math.Max(p1.Y, p2.Y))
                    {
                        if (point.X <= Math.Max(p1.X, p2.X))
                        {
                            if (p1.Y != p2.Y)
                            {
                                xinters = (point.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                                if (p1.X == p2.X || point.X <= xinters)
                                    inside = !inside;
                            }
                        }
                    }
                }
                p1 = p2;
            }
            return inside;
        }

        public bool Intersects(Polygon polygon)
        {
            return false;
        }

        private void ComputeBoundingRectangle()
        {
            if (boundingRectangle == null)
            {
                Vector2 min = new Vector2(vertices[0].X, vertices[0].Y);
                Vector2 max = new Vector2(vertices[0].X, vertices[0].Y);
                foreach (Vertex vertex in vertices)
                {
                    if (vertex.X < min.X)
                        min.X = vertex.X;

                    if (vertex.Y < min.Y)
                        min.Y = vertex.Y;

                    if (vertex.X > max.X)
                        max.X = vertex.X;

                    if (vertex.Y > max.Y)
                        max.Y = vertex.Y;
                }
                boundingRectangle = new FloatRectangle(min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
        }

        public void ComputeDrawingVertices(Renderer renderer)
        {
            primitiveList = new VertexPositionColor[vertices.Count];
            lineListIndices = new short[vertices.Count * 2];

            Vector2 rendererCenter = renderer.Center;
            float f = renderer.GetPerspective(depth);

            Vector3 vertexPosition = new Vector3(0, 0, -100);
            for (int i = 0; i < vertices.Count; i++)
            {
                vertexPosition.X = vertices[i].X + rendererCenter.X * f;
                vertexPosition.Y = vertices[i].Y + rendererCenter.Y * f;
                primitiveList[i] = new VertexPositionColor(vertexPosition, color);
                lineListIndices[i * 2] = (short)(i % vertices.Count);
                lineListIndices[i * 2 + 1] = (short)((i + 1) % vertices.Count);
            }
        }

        public override void Draw(Renderer renderer)
        {
            ComputeDrawingVertices(renderer);

            renderer.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                primitiveList,
                0,               // vertex buffer offset to add to each element of the index buffer
                vertices.Count,  // number of vertices in pointList
                lineListIndices, // the index buffer
                0,               // first index element to read
                vertices.Count   // number of primitives to draw
            );
        }

        public override void SetOrigin(Vector2 origin)
        {
            Vector2 diff = new Vector2(vertices[0].X - origin.X, vertices[0].Y - origin.Y);
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].X -= diff.X;
                vertices[i].Y -= diff.Y;
            }
            boundingRectangle = null;
        }

        public void RemoveVertex(Vertex vertex)
        {
            if (vertices.Count > 3)
            {
                vertices.Remove(vertex);
                boundingRectangle = null;
            }
        }

        public void AddVertex(int index, Vertex vertex)
        {
            vertices.Insert(index, vertex);
            boundingRectangle = null;
        }

        public int FindInsertIndex(Vector2 position)
        {
            int nearestIndex = 0;
            float nearestDistance = GetDistanceFromEdge(position, 0);

            for (int i = 1; i < vertices.Count; i++)
            {
                float distance = GetDistanceFromEdge(position, i);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestIndex = i;
                }
            }

            return (nearestIndex + 1 + vertices.Count) % vertices.Count;
        }

        private float GetDistanceFromEdge(Vector2 position, int edgeIndex)
        {
            Vertex current = vertices[edgeIndex];
            Vertex next = vertices[(edgeIndex + 1) % vertices.Count];
            return (float)(Vector2.Distance(position, current.Vector2)
                         + Vector2.Distance(position, next.Vector2)
                         - Vector2.Distance(current.Vector2, next.Vector2));
        }

    }
}
