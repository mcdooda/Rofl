using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RoflLib.utils.math
{
    public class Intersection
    {
        public class IntersectionPoint
        {
            public enum Side2D
            {
                Left,
                Right,
                Bottom,
                Top,
                Unknown
            }

            private Vector2 point;
            public Vector2 Point { get { return point; } }

            private Side2D side;
            public Side2D Side { get { return side; } set { side = value; } }

            private LineSegment lineSegment;
            public LineSegment LineSegment { get { return lineSegment; } set { lineSegment = value; } }

            public IntersectionPoint(Vector2 point)
            {
                this.point = point;
                this.side = Side2D.Unknown;
            }
        }

        private List<IntersectionPoint> intersectionPoints;
        public List<IntersectionPoint> IntersectionPoints { get { return intersectionPoints; } }

        public IntersectionPoint FirstIntersectionPoint { get { return IsEmpty ? null : intersectionPoints[0]; } }
        public bool IsEmpty { get { return intersectionPoints.Count == 0; } }

        private Dictionary<IntersectionPoint.Side2D, List<IntersectionPoint>> pointsBySide;

        public Intersection()
        {
            intersectionPoints = new List<IntersectionPoint>();
            pointsBySide = new Dictionary<IntersectionPoint.Side2D, List<IntersectionPoint>>();
            pointsBySide[IntersectionPoint.Side2D.Left] = new List<IntersectionPoint>();
            pointsBySide[IntersectionPoint.Side2D.Right] = new List<IntersectionPoint>();
            pointsBySide[IntersectionPoint.Side2D.Bottom] = new List<IntersectionPoint>();
            pointsBySide[IntersectionPoint.Side2D.Top] = new List<IntersectionPoint>();
        }

        public void AddPoint(IntersectionPoint intersectionPoint)
        {
            intersectionPoints.Add(intersectionPoint);

            if (intersectionPoint.Side != IntersectionPoint.Side2D.Unknown)
                pointsBySide[intersectionPoint.Side].Add(intersectionPoint);
        }

        public void AddIntersection(Intersection intersection)
        {
            foreach (IntersectionPoint intersectionPoint in intersection.IntersectionPoints)
                AddPoint(intersectionPoint);
        }

        public List<IntersectionPoint> GetPointsBySide(IntersectionPoint.Side2D side)
        {
            return pointsBySide[side];
        }

        public static Intersection PolygonAndLineSegment(Polygon polygon, LineSegment lineSegment)
        {
            Intersection intersection = new Intersection();

            Vertex vertex1 = polygon.Vertices[polygon.Vertices.Count - 1];
            foreach (Vertex vertex2 in polygon.Vertices)
            {
                LineSegment lineSegment2 = new LineSegment(vertex1.Vector2, vertex2.Vector2);

                IntersectionPoint segmentIntersection = TwoLineSegments(lineSegment, lineSegment2).FirstIntersectionPoint;
                if (segmentIntersection != null)
                {
                    segmentIntersection.LineSegment = lineSegment2;
                    intersection.AddPoint(segmentIntersection);
                }
                vertex1 = vertex2;
            }

            return intersection;
        }

        public static Intersection BoxAndPolygon(FloatRectangle box, Polygon polygon)
        {
            Intersection intersection = new Intersection();

            if (FloatRectangle.Intersect(box, polygon.BoundingRectangle))
            {
                Vertex vertex1 = polygon.Vertices[polygon.Vertices.Count - 1];
                foreach (Vertex vertex2 in polygon.Vertices)
                {
                    LineSegment lineSegment = new LineSegment(vertex1.Vector2, vertex2.Vector2);

                    Intersection boxAndLineSegmentIntersection = BoxAndLineSegment(box, lineSegment);
                    intersection.AddIntersection(boxAndLineSegmentIntersection);
                    vertex1 = vertex2;
                }
            }

            return intersection;
        }

        public static Intersection BoxAndLineSegment(FloatRectangle box, LineSegment segment)
        {
            Intersection intersection = new Intersection();

            Vector2 a = new Vector2(box.Left, box.Top);
            Vector2 b = new Vector2(box.Right, box.Top);
            Vector2 c = new Vector2(box.Right, box.Bottom);
            Vector2 d = new Vector2(box.Left, box.Bottom);

            LineSegment top = new LineSegment(a, b);
            LineSegment right = new LineSegment(b, c);
            LineSegment bottom = new LineSegment(c, d);
            LineSegment left = new LineSegment(d, a);

            Intersection int1 = TwoLineSegments(top, segment);
            if (!int1.IsEmpty)
            {
                IntersectionPoint ip = new IntersectionPoint(int1.FirstIntersectionPoint.Point);
                ip.LineSegment = segment;
                ip.Side = IntersectionPoint.Side2D.Top;
                intersection.AddPoint(ip);
            }

            Intersection int2 = TwoLineSegments(right, segment);
            if (!int2.IsEmpty)
            {
                IntersectionPoint ip = new IntersectionPoint(int2.FirstIntersectionPoint.Point);
                ip.LineSegment = segment;
                ip.Side = IntersectionPoint.Side2D.Right;
                intersection.AddPoint(ip);
            }

            Intersection int3 = TwoLineSegments(bottom, segment);
            if (!int3.IsEmpty)
            {
                IntersectionPoint ip = new IntersectionPoint(int3.FirstIntersectionPoint.Point);
                ip.LineSegment = segment;
                ip.Side = IntersectionPoint.Side2D.Bottom;
                intersection.AddPoint(ip);
            }

            Intersection int4 = TwoLineSegments(left, segment);
            if (!int4.IsEmpty)
            {
                IntersectionPoint ip = new IntersectionPoint(int4.FirstIntersectionPoint.Point);
                ip.LineSegment = segment;
                ip.Side = IntersectionPoint.Side2D.Left;
                intersection.AddPoint(ip);
            }

            return intersection;
        }

        public static Intersection TwoLineSegments(LineSegment a, LineSegment b)
        {
            Intersection intersection = new Intersection();
            float d = (b.B.Y - b.A.Y) * (a.B.X - a.A.X) - (b.B.X - b.A.X) * (a.B.Y - a.A.Y);
            if (d != 0)
            {
                float ua = ((b.B.X - b.A.X) * (a.A.Y - b.A.Y) - (b.B.Y - b.A.Y) * (a.A.X - b.A.X)) / d;
                float ub = ((a.B.X - a.A.X) * (a.A.Y - b.A.Y) - (a.B.Y - a.A.Y) * (a.A.X - b.A.X)) / d;

                if (ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1)
                {
                    float x = a.A.X + ua * (a.B.X - a.A.X);
                    float y = a.A.Y + ua * (a.B.Y - a.A.Y);
                    intersection.AddPoint(new IntersectionPoint(new Vector2(x, y)));
                }
            }
            return intersection;
        }

        public static Intersection BoxAndCircle(FloatRectangle box, Circle circle) // returns the center of the circle if there is an intersection (no precision needed)
        {
            Intersection intersection = new Intersection();
            if (box.IsInside(circle.Center))
            {
                intersection.AddPoint(new IntersectionPoint(circle.Center));
            }
            else
            {
                float left = box.Left;
                float right = box.Right;
                float top = box.Top;
                float bottom = box.Bottom;
                float ccX = circle.Center.X;
                float ccY = circle.Center.Y;
                float radius = circle.Radius;

                if (ccX < left) // left
                {
                    if (ccY < top) // top left
                    {
                        float dx = left - ccX;
                        float dy = top - ccY;
                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                        if (dist < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                    else if (ccY > bottom) // bottom left
                    {
                        float dx = left - ccX;
                        float dy = ccY - bottom;
                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                        if (dist < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                    else // left
                    {
                        if (left - ccX < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                }
                else if (ccX > right) // right
                {
                    if (ccY < top) // top right
                    {
                        float dx = ccX - right;
                        float dy = top - ccY;
                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                        if (dist < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                    else if (ccY > bottom) // bottom right
                    {
                        float dx = ccX - right;
                        float dy = ccY - bottom;
                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                        if (dist < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                    else // right
                    {
                        if (ccX - right < radius)
                            intersection.AddPoint(new IntersectionPoint(circle.Center));
                    }
                }
                else if (ccY < top) // top
                {
                    if (top - ccY < radius)
                        intersection.AddPoint(new IntersectionPoint(circle.Center));
                }
                else if (ccY > bottom) // bottom
                {
                    if (ccY - bottom < radius)
                        intersection.AddPoint(new IntersectionPoint(circle.Center));
                }
            }
            return intersection;
        }

    }
}
