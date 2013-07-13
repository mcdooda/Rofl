using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiseEditor.forms
{
    public class AddTextureChooser : PlatformChooser
    {

        public AddTextureChooser(MainWindow mainWindow)
            : base(mainWindow)
        {
            Text = "Rise Editor Additional Texture Chooser";
        }

        public override void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            PlatformPictureBox platformPictureBox = (PlatformPictureBox)sender;
            mainWindow.ElementPropertiesAddTexture(platformPictureBox.Name);
        }

    }
}
