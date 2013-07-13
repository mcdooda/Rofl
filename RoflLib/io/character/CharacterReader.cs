using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace RoflLib.io.character
{
    public class CharacterReader
    {
        private byte[] characterData;
        private ContentManager content;

        public CharacterReader(byte[] characterData, ContentManager content)
        {
            this.characterData = characterData;
            this.content = content;
        }

        public Character Read()
        {
            MemoryStream ms = new MemoryStream(characterData);
            BinaryReader br = new BinaryReader(ms);

            // header
            string header = br.ReadString();
            if (header != "RoflCharacter")
                return null;

            // animation
            string animationTextureName = br.ReadString();
            Texture2D animationTexture = content.Load<Texture2D>(animationTextureName);
            animationTexture.Name = animationTextureName;

            int animationNumLines = br.ReadInt32();
            int animationNumColumns = br.ReadInt32();
            double animationFrameDuration = br.ReadDouble();

            Animation animation = new Animation(animationTexture, animationNumLines, animationNumColumns, animationFrameDuration);
            
            Vector2 animationCenter;
            animationCenter.X = br.ReadSingle();
            animationCenter.Y = br.ReadSingle();
            animation.Center = animationCenter;

            // animations
            int numAnimations = br.ReadInt32();
            for (int i = 0; i < numAnimations; i++)
            {
                string animationName = br.ReadString();

                int animationBeginLine = br.ReadInt32();
                int animationBeginColumn = br.ReadInt32();

                double attackFrameDuration = br.ReadDouble();
                double attackFreezeDuration = br.ReadDouble();

                int animationNumFrames = br.ReadInt32();

                // animation or attack?
                bool isAttack = br.ReadBoolean();

                if (!isAttack)
                {
                    Animation.Frame animationFrame = new Animation.Frame(animationBeginLine, animationBeginColumn, animationNumFrames, attackFrameDuration, attackFreezeDuration);
                    animation.AddFrame(animationName, animationFrame);
                }
                else
                {
                    List<HitPoint> attackHitPoints = new List<HitPoint>();

                    for (int j = 0; j < animationNumFrames; j++)
                    {
                        bool readHitPoint = br.ReadBoolean();
                        if (!readHitPoint)
                            attackHitPoints.Add(null);

                        else
                        {
                            float hitPointSize = br.ReadSingle();
                            Vector2 hitPointPosition;
                            hitPointPosition.X = br.ReadSingle();
                            hitPointPosition.Y = br.ReadSingle();
                            float hitPointDamage = br.ReadSingle();
                            Vector2 hitPointDirection;
                            hitPointDirection.X = br.ReadSingle();
                            hitPointDirection.Y = br.ReadSingle();
                            attackHitPoints.Add(new HitPoint(hitPointSize, hitPointPosition, hitPointDamage, hitPointDirection));
                        }
                    }

                    Attack attack = new Attack(animationBeginLine, animationBeginColumn, attackFrameDuration, attackFreezeDuration, attackHitPoints);
                    animation.AddFrame(animationName, attack);
                }
            }

            // face texture
            string faceTextureName = br.ReadString();

            Texture2D faceTexture = content.Load<Texture2D>(faceTextureName);
            faceTexture.Name = faceTextureName;

            // size
            Vector2 size;
            size.X = br.ReadSingle();
            size.Y = br.ReadSingle();

            // weight
            float weight = br.ReadSingle();

            // jump force
            float jumpForce = br.ReadSingle();

            // running speed
            float runningSpeed = br.ReadSingle();

            // num second jumps
            int numSecondJumps = br.ReadInt32();

            Character character = new Character(animation, faceTexture, size, weight, jumpForce, runningSpeed, numSecondJumps);
            return character;
        }

    }
}
