using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RoflLib.io.level
{
    public class LevelDataReader : ContentTypeReader<LevelData>
    {
        protected override LevelData Read(ContentReader input, LevelData existingInstance)
        {
            return new LevelData(input.ReadBytes((int)input.BaseStream.Length));
        }
    }
}
