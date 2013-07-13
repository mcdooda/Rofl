using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RoflLib.io.character
{
    public class CharacterDataReader : ContentTypeReader<CharacterData>
    {
        protected override CharacterData Read(ContentReader input, CharacterData existingInstance)
        {
            return new CharacterData(input.ReadBytes((int)input.BaseStream.Length));
        }
    }
}
