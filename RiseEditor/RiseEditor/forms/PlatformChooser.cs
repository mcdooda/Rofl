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

namespace RiseEditor.forms
{
    public partial class PlatformChooser : Form
    {
        protected MainWindow mainWindow;

        public PlatformChooser(MainWindow mainWindow)
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

            ContentManager content = mainWindow.RiseEditor.RiseEditorMode.Content;

            string path = "levels/" + directory + "/images/";
            DirectoryInfo levelImagesDir = new DirectoryInfo(content.RootDirectory + "/" + path);

            FileInfo[] files = levelImagesDir.GetFiles();

            foreach (FileInfo file in files)
            {
                string name = path + Path.GetFileNameWithoutExtension(file.Name);
                PlatformPictureBox pictureBox = new PlatformPictureBox(content, name);
                pictureBox.DoubleClick += new EventHandler(pictureBox_DoubleClick);
                platformsPanel.Controls.Add(pictureBox);
            }
        }

        public virtual void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            PlatformPictureBox platformPictureBox = (PlatformPictureBox)sender;
            mainWindow.RiseEditor.RiseEditorMode.AddElement(platformPictureBox.Name);
            mainWindow.RiseEditor.RiseEditorMode.InputEnabled = true;
        }

        private void levelDirectoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directory = (string)levelDirectoryCombobox.SelectedItem;
            LoadLevelImages(directory);
        }

        private void PlatformSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindow.RiseEditor.RiseEditorMode.InputEnabled = true;
        }
    }
}
