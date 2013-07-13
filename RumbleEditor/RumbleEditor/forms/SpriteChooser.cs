using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RumbleEditor.forms;

namespace RiseEditor.forms
{
    public partial class SpriteChooser : Form
    {
        protected MainWindow mainWindow;
        protected NewCharacterWindow newCharacterWindow;
        public NewCharacterWindow NewCharacterWindow { set { newCharacterWindow = value; } }

        public SpriteChooser(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void FillCombobox(List<string> levelDirectories)
        {
            foreach (string levelDirectory in levelDirectories)
                levelDirectoryCombobox.Items.Add(levelDirectory);

            levelDirectoryCombobox.SelectedIndex = 0;
        }

        private void LoadLevelImages(string directory)
        {
            platformsPanel.Controls.Clear();

            ContentManager content = mainWindow.RumbleEditor.RumbleEditorMode.Content;

            string path = "characters/" + directory + "/images/";
            DirectoryInfo levelImagesDir = new DirectoryInfo(content.RootDirectory + "/" + path);

            FileInfo[] files = levelImagesDir.GetFiles();

            foreach (FileInfo file in files)
            {
                string name = path + Path.GetFileNameWithoutExtension(file.Name);
                SpritePictureBox pictureBox = new SpritePictureBox(content, name);
                pictureBox.DoubleClick += new EventHandler(pictureBox_DoubleClick);
                platformsPanel.Controls.Add(pictureBox);
            }
        }

        public virtual void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            SpritePictureBox spritePictureBox = (SpritePictureBox)sender;
            newCharacterWindow.SetAnimationTexture(spritePictureBox.Name);
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = true;
        }

        private void levelDirectoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directory = (string)levelDirectoryCombobox.SelectedItem;
            LoadLevelImages(directory);
        }

        private void PlatformSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = true;
        }
    }
}
