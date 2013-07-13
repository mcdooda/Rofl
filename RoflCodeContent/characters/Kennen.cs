using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using Microsoft.Xna.Framework;
using RoflLib.input;
using Microsoft.Xna.Framework.Content;
using RoflLib.io.character;

namespace RoflCodeContent.characters
{
    public class Kennen : Character
    {

        public Kennen(InputDevice inputDevice, Vector2 position, ContentManager content, Color color, int index)
            : base(inputDevice, position, color, index)
        {
            CharacterData characterData = content.Load<CharacterData>("characters/kennen/kennen");
            CopyData(characterData.GetCharacter(content));
            Initialize();
        }
    }
}
