using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace RiseEditor.forms
{
    public partial class EffectChooser : Form
    {
        private MainWindow mainWindow;

        public EffectChooser(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void effectsListbox_DoubleClick(object sender, EventArgs e)
        {
            if (effectsListbox.SelectedItem != null)
            {
                mainWindow.ElementPropertiesSetEffect((string)effectsListbox.SelectedItem);
                Hide();
            }
        }

        public void FillCombobox(List<string> levelDirectories)
        {
            foreach (string levelDirectory in levelDirectories)
                levelDirectoryCombobox.Items.Add(levelDirectory);

            levelDirectoryCombobox.SelectedIndex = 0;
        }

        private void LoadLevelEffects(string directory)
        {
            effectsListbox.Items.Clear();
            ContentManager content = mainWindow.RiseEditor.RiseEditorMode.Content;

            string path = "levels/" + directory + "/effects/";
            DirectoryInfo levelEffectsDir = new DirectoryInfo(content.RootDirectory + "/" + path);

            try
            {
                FileInfo[] files = levelEffectsDir.GetFiles();

                foreach (FileInfo file in files)
                    effectsListbox.Items.Add(path + Path.GetFileNameWithoutExtension(file.Name));
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void levelDirectoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directory = (string)levelDirectoryCombobox.SelectedItem;
            LoadLevelEffects(directory);
        }
    }
}
