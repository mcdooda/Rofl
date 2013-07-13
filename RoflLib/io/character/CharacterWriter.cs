using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RoflLib.io.character
{
    public class CharacterWriter
    {
        private Character character;

        public CharacterWriter(Character character)
        {
            this.character = character;
        }

        public byte[] Write()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);

            // header
            bw.Write("RoflCharacter");

            // animation
            bw.Write(character.Animation.Texture.Name);
            bw.Write(character.Animation.NumLines);
            bw.Write(character.Animation.NumColumns);
            bw.Write(character.Animation.FrameDuration);
            bw.Write(character.AnimationCenterX);
            bw.Write(character.AnimationCenter.Y);

            // animations
            bw.Write(character.Animation.Frames.Count);
            foreach (KeyValuePair<string, Animation.Frame> frame in character.Animation.Frames)
            {
                string animationName = frame.Key;
                Animation.Frame animation = frame.Value;

                bw.Write(animationName);

                bw.Write(animation.BeginLine);
                bw.Write(animation.BeginColumn);

                bw.Write(animation.FrameDuration);
                bw.Write(animation.FreezeDuration);

                bw.Write(animation.NumFrames);

                if (!(animation is Attack))
                {
                    bw.Write(false);
                }
                else
                {
                    bw.Write(true);
                    Attack attack = (Attack)animation;
                    foreach (HitPoint hitPoint in attack.HitPoints)
                    {
                        if (hitPoint == null)
                            bw.Write(false);

                        else
                        {
                            bw.Write(true);
                            bw.Write(hitPoint.Size);
                            bw.Write(hitPoint.Position.X);
                            bw.Write(hitPoint.Position.Y);
                            bw.Write(hitPoint.Damage);
                            bw.Write(hitPoint.Direction.X);
                            bw.Write(hitPoint.Direction.Y);
                        }
                    }
                }
            }

            // face texture
            bw.Write(character.FaceTexture.Name);

            // size
            bw.Write(character.Size.X);
            bw.Write(character.Size.Y);

            // weight
            bw.Write(character.Weight);

            // jump force
            bw.Write(character.JumpForce);

            // running speed
            bw.Write(character.RunningSpeed);

            // num second jumps
            bw.Write(character.NumSecondJumps);

            ms.Position = 0;

            int streamLength = (int)ms.Length;
            byte[] characterData = new byte[streamLength];
            ms.Read(characterData, 0, streamLength);
            bw.Close();

            return characterData;
        }
    }
}
