using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RoflLib
{
    public class Animation
    {
        public class Frame
        {
            protected double frameDuration;
            public double FrameDuration { get { return frameDuration; } set { frameDuration = value; } }

            protected double lastFrameUpdate;
            protected int numFrameUpdates;

            protected double freezeDuration;
            public double FreezeDuration { get { return freezeDuration; } set { freezeDuration = value; } }

            protected int beginLine;
            public int BeginLine { get { return beginLine; } }

            protected int beginColumn;
            public int BeginColumn { get { return beginColumn; } }

            protected int numFrames;
            public int NumFrames { get { return numFrames; } }

            public double Duration { get { return numFrames * frameDuration; } }

            public Frame(int beginLine, int beginColumn, int numFrames, double frameDuration, double freezeDuration)
            {
                this.beginLine = beginLine;
                this.beginColumn = beginColumn;
                this.numFrames = numFrames;
                this.frameDuration = frameDuration;
                this.freezeDuration = freezeDuration;
            }

            public void Reset(GameTime gameTime, Animation animation)
            {
                numFrameUpdates = 0;
                lastFrameUpdate = gameTime.TotalGameTime.TotalSeconds;
                animation.currentColumn = beginColumn;
                animation.currentLine = beginLine;
                animation.UpdateSourceRectangle();
                FrameChanged(gameTime, animation); // first frame
            }

            public bool Update(GameTime gameTime, Animation animation)
            {
                double totalSeconds = gameTime.TotalGameTime.TotalSeconds;
                if (totalSeconds - lastFrameUpdate > frameDuration)
                {
                    numFrameUpdates++;
                    if (numFrameUpdates == numFrames)
                    {
                        return true; // end of the frame
                    }

                    animation.currentColumn++;
                    if (animation.currentColumn == animation.NumColumns)
                    {
                        animation.currentColumn = 0;
                        animation.currentLine++;
                    }

                    animation.UpdateSourceRectangle();

                    lastFrameUpdate = totalSeconds * 2 - lastFrameUpdate - frameDuration;

                    FrameChanged(gameTime, animation); // updates new frame (used for attack hits)
                }
                return false; // keep frame running
            }

            protected virtual void FrameChanged(GameTime gameTime, Animation animation)
            {

            }
        }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } }

        private Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        private float depth;
        public float Depth { get { return depth; } set { depth = value; } }

        private float rotation;
        public float Rotation { get { return rotation; } set { rotation = value; } }

        private float scale;
        public float Scale { get { return scale; } set { scale = value; } }

        private Vector2 center;
        public Vector2 Center { get { return center; } set { center = value; } }

        public float CenterX { get { return center.X; } set { center.X = value; } }
        public float CenterY { get { return center.Y; } set { center.Y = value; } }

        private Color color;
        public Color Color { get { return color; } set { color = value; } }

        private SpriteEffects spriteEffects;
        public SpriteEffects SpriteEffects { get { return spriteEffects; } }

        private Rectangle sourceRectangle;
        public Rectangle SourceRectangle { get { return sourceRectangle; } }

        private int numLines;
        public int NumLines { get { return numLines; } set { numLines = value; frameHeight = texture.Height / numLines; sourceRectangle.Height = frameHeight; } }

        private int numColumns;
        public int NumColumns { get { return numColumns; } set { numColumns = value; frameWidth = texture.Width / numColumns; sourceRectangle.Width = frameWidth; } }

        private int frameWidth;
        public int FrameWidth { get { return frameWidth; } }

        private int frameHeight;
        public int FrameHeight { get { return frameHeight; } }

        private int currentLine;
        public int CurrentLine
        {
            set
            {
                currentLine = value;
                UpdateSourceRectangle();
            }
        }

        private int currentColumn;
        public int CurrentColumn
        {
            set
            {
                currentColumn = value;
                UpdateSourceRectangle();
            }
        }

        private double frameDuration;
        public double FrameDuration { get { return frameDuration; } set { frameDuration = value; } }

        private Dictionary<string, Frame> frames;
        public Dictionary<string, Frame> Frames { get { return frames; } }

        private Frame currentFrame;
        public Frame CurrentFrame { get { return currentFrame; } }

        private Frame lastPlayedFrame;

        private Frame loopingFrame;

        public Animation(Texture2D texture, int numLines, int numColumns, double frameDuration)
        {
            this.texture = texture;
            this.numLines = numLines;
            this.numColumns = numColumns;
            this.frameDuration = frameDuration;
            frameWidth = texture.Width / numColumns;
            frameHeight = texture.Height / numLines;
            currentLine = 0;
            currentColumn = 0;
            sourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);

            position = new Vector2(0, 0);
            depth = 0;
            rotation = 0;
            scale = 1;
            center = new Vector2(0, 0);
            color = Color.White;
            spriteEffects = SpriteEffects.None;

            frames = new Dictionary<string, Frame>();
        }

        public void Reset(GameTime gameTime)
        {
            currentLine = 0;
            currentColumn = 0;
        }

        public void Update(GameTime gameTime)
        {
            double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

            if (currentFrame != null)
            {
                bool removeFrame = currentFrame.Update(gameTime, this);
                if (removeFrame)
                {
                    if (currentFrame == loopingFrame)
                        currentFrame.Reset(gameTime, this);

                    else
                        currentFrame = null;
                }
            }
        }

        public void UpdateSourceRectangle()
        {
            sourceRectangle.X = currentColumn * frameWidth;
            sourceRectangle.Y = currentLine * frameHeight;
        }

        public void FlipX(bool flipX)
        {
            if (flipX)
                spriteEffects |= SpriteEffects.FlipHorizontally;

            else
                spriteEffects &= ~SpriteEffects.FlipHorizontally;
        }

        public void FlipY(bool flipY)
        {
            if (flipY)
                spriteEffects |= SpriteEffects.FlipVertically;

            else
                spriteEffects &= ~SpriteEffects.FlipVertically;
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawAnimation(this);
        }

        public void AddFrame(string name, Frame frame)
        {
            frames[name] = frame;
        }

        public void RemoveFrame(string name)
        {
            frames.Remove(name);
        }

        public bool IsCurrentFrame(string name)
        {
            if (!frames.ContainsKey(name))
                return false;

            else
                return frames[name] == currentFrame;
        }

        public bool IsLastPlayedFrame(string name)
        {
            if (!frames.ContainsKey(name))
                return false;

            else
                return frames[name] == lastPlayedFrame;
        }

        public double PlayFrame(string name, GameTime gameTime)
        {
            if (frames.ContainsKey(name))
            {
                loopingFrame = null;
                Frame frame = frames[name];
                currentFrame = frame;
                lastPlayedFrame = currentFrame;
                frame.Reset(gameTime, this);
                return frame.FreezeDuration;
            }
            else
                return 0;
        }

        public void LoopFrame(string name, GameTime gameTime)
        {
            if (frames.ContainsKey(name))
            {
                loopingFrame = frames[name];
                if (loopingFrame != currentFrame)
                    PlayFrame(name, gameTime);
            }
        }

        public double GetSubFrameDuration(string name)
        {
            if (frames.ContainsKey(name))
            {
                return frames[name].Duration;
            }
            else
                return 0;
        }

    }
}
