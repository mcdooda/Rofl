using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using RoflCodeContent.levels.test.particles;

namespace RiseEditor.forms
{
    public partial class ParticleEffectChooser : Form
    {
        private MainWindow mainWindow;

        public ParticleEffectChooser(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void FillCombobox(List<string> levelNamespaces)
        {
            foreach (string levelNamespace in levelNamespaces)
                levelNamespaceCombobox.Items.Add(levelNamespace);

            levelNamespaceCombobox.SelectedIndex = 0;
        }

        private void LoadLevelParticleEffects(string ns)
        {
            particleEffectsListbox.Items.Clear();

            Assembly asm = Assembly.GetAssembly(typeof(TestEffect));
            Type[] types = asm.GetExportedTypes();
            string prefix = "RoflCodeContent.levels." + ns + ".particles.";
            foreach (Type t in types)
            {
                if (t.FullName.IndexOf(prefix) == 0)
                    particleEffectsListbox.Items.Add(t.Name);
            }
        }

        private void levelNamespaceCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ns = (string)levelNamespaceCombobox.SelectedItem;
            LoadLevelParticleEffects(ns);
        }

        private void ParticleEffectChooser_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindow.RiseEditor.RiseEditorMode.InputEnabled = true;
        }

        private void particleEffectsListbox_DoubleClick(object sender, EventArgs e)
        {
            if (particleEffectsListbox.SelectedItem != null)
            {
                string particleEffectName = (string)particleEffectsListbox.SelectedItem;
                string ns = (string)levelNamespaceCombobox.SelectedItem;
                string prefix = "RoflCodeContent.levels." + ns + ".particles.";
                string fullName = prefix + particleEffectName;
                mainWindow.RiseEditor.RiseEditorMode.SetParticleEffect(fullName);
                Hide();
                mainWindow.RiseEditor.RiseEditorMode.InputEnabled = true;
            }
        }
    }
}
