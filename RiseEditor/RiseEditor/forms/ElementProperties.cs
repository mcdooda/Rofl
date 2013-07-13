using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RoflLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RiseEditor.forms
{
    public partial class ElementProperties : Form
    {
        private MainWindow mainWindow;
        private LevelElement element;

        public ElementProperties(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void SetElement(LevelElement element)
        {
            this.element = element;

            additionalTexturesListbox.Items.Clear();
            if (element.AdditionalTextures != null)
            {
                foreach (Texture2D additionalTexture in element.AdditionalTextures)
                    additionalTexturesListbox.Items.Add(additionalTexture.Name);
            }

            effectTextbox.Clear();
            if (element.Effect != null)
                effectTextbox.Text = element.Effect.Name;
        }

        public void AddTexture(string name)
        {
            additionalTexturesListbox.Items.Add(name);
        }

        public void SetEffect(string name)
        {
            effectTextbox.Text = name;
            ContentManager content = mainWindow.RiseEditor.RiseEditorMode.Content;
            Effect effect = content.Load<Effect>(name);
            effect.Name = name;
            element.Effect = effect;

            Level level = mainWindow.RiseEditor.RiseEditorMode.Level;
            if (effect.Parameters["time"] != null)
                level.AddTimedEffect(effect);
        }

        private void ElementProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindow.RiseEditor.RiseEditorMode.InputEnabled = true;
        }

        private void addTextureButton_Click(object sender, EventArgs e)
        {
            mainWindow.OpenAddTextureChooser();
        }

        private void removeTextureButton_Click(object sender, EventArgs e)
        {
            int index = additionalTexturesListbox.SelectedIndex;
            if (index != -1)
            {
                additionalTexturesListbox.Items.RemoveAt(additionalTexturesListbox.SelectedIndex);

                if (additionalTexturesListbox.Items.Count > 0)
                {
                    if (index < additionalTexturesListbox.Items.Count)
                        additionalTexturesListbox.SelectedIndex = index;

                    else if (index == additionalTexturesListbox.Items.Count)
                        additionalTexturesListbox.SelectedIndex = index - 1;

                }

                UpdateAdditionalTextures();
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = additionalTexturesListbox.SelectedIndex;
            if (index != -1)
            {
                if (index > 0)
                {
                    string selectedValue = (string)additionalTexturesListbox.Items[index];
                    additionalTexturesListbox.Items[index] = additionalTexturesListbox.Items[index - 1];
                    additionalTexturesListbox.Items[index - 1] = selectedValue;
                    additionalTexturesListbox.SelectedIndex = index - 1;
                    UpdateAdditionalTextures();
                }
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = additionalTexturesListbox.SelectedIndex;
            if (index != -1)
            {
                if (index < additionalTexturesListbox.Items.Count - 1)
                {
                    string selectedValue = (string)additionalTexturesListbox.Items[index];
                    additionalTexturesListbox.Items[index] = additionalTexturesListbox.Items[index + 1];
                    additionalTexturesListbox.Items[index + 1] = selectedValue;
                    additionalTexturesListbox.SelectedIndex = index + 1;
                    UpdateAdditionalTextures();
                }
            }
        }

        private void chooseEffectButton_Click(object sender, EventArgs e)
        {
            mainWindow.OpenEffectChooser();
        }

        public void UpdateAdditionalTextures()
        {
            ContentManager content = mainWindow.RiseEditor.RiseEditorMode.Content;

            Texture2D[] additionalTextures = new Texture2D[additionalTexturesListbox.Items.Count];
            for (int i = 0; i < additionalTextures.Length; i++)
            {
                string textureName = (string)additionalTexturesListbox.Items[i];
                additionalTextures[i] = content.Load<Texture2D>(textureName);
                additionalTextures[i].Name = textureName;
            }

            element.AdditionalTextures = additionalTextures;
        }

        private void removeEffectButton_Click(object sender, EventArgs e)
        {
            effectTextbox.Text = "";
            element.Effect = null;
        }
    }
}
