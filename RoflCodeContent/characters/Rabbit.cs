using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using RoflLib.input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoflLib.io.character;

namespace RoflCodeContent.characters
{
    public class Rabbit : Character
    {

        public Rabbit(InputDevice inputDevice, Vector2 position, ContentManager content, Color color, int index)
            : base(inputDevice, position, color, index)
        {
            CharacterData characterData = content.Load<CharacterData>("characters/test/rabbit");
            CopyData(characterData.GetCharacter(content));
            Initialize();
        }

    }
}
