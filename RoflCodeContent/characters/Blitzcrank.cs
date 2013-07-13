using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoflLib;
using RoflLib.input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RoflLib.io.character;
using RoflLib.input.vibrations;

namespace RoflCodeContent.characters
{
    public class Blitzcrank : Character
    {

        public Blitzcrank(InputDevice inputDevice, Vector2 position, ContentManager content, Color color, int index)
            : base(inputDevice, position, color, index)
        {
            CharacterData characterData = content.Load<CharacterData>("characters/blitzcrank/blitzcrank");
            CopyData(characterData.GetCharacter(content));
            Initialize();
        }
    }
}
