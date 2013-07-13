using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RoflLib.io.level
{
    public class LevelData
    {
        private byte[] data;
        public byte[] Data { get { return data; } }

        public LevelData(byte[] data)
        {
            this.data = data;
        }

        public Level GetLevel(ContentManager content)
        {
            LevelReader levelReader = new LevelReader(data, content);
            return levelReader.Read();
        }
    }
}
