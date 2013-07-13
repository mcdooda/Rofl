using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Im = System.Drawing.Image;

namespace RiseEditor.forms
{
    public class SpritePictureBox : PictureBox
    {
        public SpritePictureBox(ContentManager content, string name)
        {
            float factor = 0.5f;

            Texture2D texture = content.Load<Texture2D>(name);
            MemoryStream mem = new MemoryStream();
            texture.SaveAsPng(mem, (int)(texture.Width * factor), (int)(texture.Height * factor));

            Name = name;
            Size = new System.Drawing.Size((int)(texture.Width * factor), (int)(texture.Height * factor));
            Image = Im.FromStream(mem);
        }
    }
}
