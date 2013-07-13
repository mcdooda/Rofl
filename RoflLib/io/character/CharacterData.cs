using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RoflLib.io.character
{
    public class CharacterData
    {
        private byte[] data;
        public byte[] Data { get { return data; } }

        public CharacterData(byte[] data)
        {
            this.data = data;
        }

        public Character GetCharacter(ContentManager content)
        {
            CharacterReader characterReader = new CharacterReader(data, content);
            return characterReader.Read();
        }
    }
}
