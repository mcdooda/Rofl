using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiseEditor.forms;

namespace RumbleEditor.forms
{
    public class FaceTextureChooser : SpriteChooser
    {

        public FaceTextureChooser(MainWindow mainWindow)
            : base(mainWindow)
        {
            Text = "Rumble Editor Face Texture Chooser";
        }

        public override void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            SpritePictureBox spritePictureBox = (SpritePictureBox)sender;
            newCharacterWindow.SetFaceTexture(spritePictureBox.Name);
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = true;
        }
    }
}
