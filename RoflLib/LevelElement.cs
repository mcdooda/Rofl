using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RoflLib.utils.math;

namespace RoflLib
{
    public class LevelElement
    {
        private Polygon polygon;
        public Polygon Polygon
        {
            get { return polygon; }
            set { polygon = value; }
        }

        private Vector2 center;
        public Vector2 Center { get { return center; } set { center = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } }

        private Texture2D[] additionalTextures;
        public Texture2D[] AdditionalTextures { get { return additionalTextures; } set { additionalTextures = value; } }

        private Vector2 halfSize;
        public Vector2 HalfSize { get { return halfSize; } }

        private LevelLayer layer;
        public LevelLayer Layer { get { return layer; } set { layer = value; } }

        private Effect effect;
        public Effect Effect { get { return effect; } set { effect = value; } }

        public LevelElement(Texture2D texture, Texture2D[] additionalTextures, Effect effect, Vector2 center)
        {
            this.texture = texture;
            this.additionalTextures = additionalTextures;
            this.effect = effect;
            this.center = center;
            halfSize = new Vector2(texture.Width / 2, texture.Height / 2);

            FloatRectangle rectangle = new FloatRectangle(center.X - halfSize.X, center.Y - halfSize.Y, texture.Width, texture.Height);
            this.polygon = rectangle.ToPolygon();
            polygon.Color = Color.Blue;
        }

        public void Draw(Renderer renderer)
        {
            if (effect != null)
            {
                renderer.BeginTextures(effect, additionalTextures);
                renderer.DrawElement(this);
                renderer.BeginTextures();
            }
            else
                renderer.DrawElement(this);
        }

        public void DrawEditor(Renderer renderer)
        {
            renderer.DrawShape(polygon);
        }

        public bool IsInside(Vector2 point)
        {
            return polygon.IsInside(point);
        }

        public Vertex GetPolygonOrigin()
        {
            return polygon.Vertices[0];
        }

        public void SetPosition(Vector2 position)
        {
            float relativeCenterX = GetPolygonOrigin().X - center.X;
            float relativeCenterY = GetPolygonOrigin().Y - center.Y;
            polygon.SetOrigin(position);
            center.X = GetPolygonOrigin().X - relativeCenterX;
            center.Y = GetPolygonOrigin().Y - relativeCenterY;
        }

        public Vertex AddPolygonVertex(Vector2 position)
        {
            int newIndex = polygon.FindInsertIndex(position);
            polygon.AddVertex(newIndex, new Vertex(position));
            polygon.Color = Color.Blue;
            return polygon.Vertices[newIndex];
        }
    }
}
