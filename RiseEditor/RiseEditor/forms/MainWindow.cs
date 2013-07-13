using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using RoflLib;
using RoflLib.utils.math;
using System.IO;
using RoflLib.io.level;

namespace RiseEditor.forms
{
    public partial class MainWindow : Form
    {
        private RiseEditor riseEditor;
        public RiseEditor RiseEditor { get { return riseEditor; } }

        public bool HasFocus { get { return ContainsFocus; } set { if (value) Focus(); } }

        private PlatformChooser platformsChooser;
        private AddTextureChooser addTextureChooser;
        private ElementProperties elementProperties;
        private EffectChooser effectChooser;
        private ParticleEffectChooser particleEffectChooser;

        public string SelectedTabName { get { return tabControl.SelectedTab.Text; } }

        public MainWindow(RiseEditor riseEditor)
        {
            InitializeComponent();
            this.riseEditor = riseEditor;
            SetXnaFrameTopMost(true);

            List<string> levelsDirectories = riseEditor.RiseEditorMode.GetLevelsDirectories();

            platformsChooser = new PlatformChooser(this);
            platformsChooser.FillCombobox(levelsDirectories);

            addTextureChooser = new AddTextureChooser(this);
            addTextureChooser.FillCombobox(levelsDirectories);

            elementProperties = new ElementProperties(this);

            effectChooser = new EffectChooser(this);
            effectChooser.FillCombobox(levelsDirectories);

            particleEffectChooser = new ParticleEffectChooser(this);
            particleEffectChooser.FillCombobox(levelsDirectories);
        }

        public System.Windows.Forms.Control GetXnaFrame()
        {
            return (System.Windows.Forms.Control)System.Windows.Forms.Form.FromHandle(riseEditor.Window.Handle);
        }

        private void SetXnaFrameTopMost(bool topMost)
        {
            ((System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(riseEditor.Window.Handle)).TopMost = topMost;
        }

        public void UpdateXnaFrame()
        {
            System.Windows.Forms.Control xnaFrame = GetXnaFrame();
            if (xnaFrame != null)
            {
                xnaFrame.Hide();
                riseEditor.UpdateWindow(0, 0, xnaPanel.Width, xnaPanel.Height);
                xnaFrame.Location = xnaPanel.PointToScreen(new System.Drawing.Point(0, 0));
                xnaFrame.Width = xnaPanel.Width;
                xnaFrame.Height = xnaPanel.Height;
                xnaFrame.Show();
                xnaFrame.BringToFront();
            }
        }

        public bool DisplayOnlyPlatforms()
        {
            return displayOnlyPlatformsCheckbox.Checked;
        }

        public bool CameraFollowsPointer()
        {
            return cameraFollowsPointerCheckbox.Checked;
        }

        public bool DisplayWorldOrigin()
        {
            return displayWorldOriginCheckbox.Checked;
        }

        public bool DisplayParticlesOrigin()
        {
            return displayParticlesOriginCheckbox.Checked;
        }

        public bool DisplayParticles()
        {
            return displayParticlesCheckbox.Checked;
        }

        public bool ApplyShaders()
        {
            return applyShadersCheckbox.Checked;
        }

        public bool DisplayOverlay()
        {
            return displayOverlayCheckbox.Checked;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            riseEditor.Exit();
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void xnaPanel_SizeChanged(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void MainWindow_Enter(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void cameraFollowsPointerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!cameraFollowsPointerCheckbox.Checked)
                riseEditor.RiseEditorMode.Renderer.Center = Vector2.Zero;
        }

        private void depthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (riseEditor.RiseEditorMode.CurrentLayer != riseEditor.RiseEditorMode.Level.PlatformsLayer)
                riseEditor.RiseEditorMode.CurrentLayer.Depth = (float)depthNumericUpDown.Value;

            else
                depthNumericUpDown.Value = 0;

            LevelLayer currentLayer = riseEditor.RiseEditorMode.CurrentLayer;
            currentLayerOptionsGroupbox.Text = "Layer options: " + currentLayer.GetName();

            // TODO: call only when necessary
            UpdateLayersNodes();
        }


        public void UpdateLayersNodes()
        {
            List<LevelLayer> layers = riseEditor.RiseEditorMode.Level.Layers;
            layers.Sort(new LevelLayerDepthComparer());
            object[] items = new object[layers.Count];
            int i = 0;

            foreach (LevelLayer layer in layers)
            {
                items[i] = layer.GetName();
                i++;
            }

            layersListBox.Items.Clear();
            layersListBox.Items.AddRange(items);

            i = 0;
            foreach (LevelLayer layer in layers)
            {
                layersListBox.SetItemChecked(i, layer.Visible);
                i++;
            }
        }

        private void layersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LevelLayer> layers = riseEditor.RiseEditorMode.Level.Layers;
            riseEditor.RiseEditorMode.CurrentLayer = layers[layersListBox.SelectedIndex];
            UpdateCurrentLayerPanel();
        }

        public void UpdateCurrentLayerPanel()
        {
            LevelLayer currentLayer = riseEditor.RiseEditorMode.CurrentLayer;
            LevelLayer platformsLayer = riseEditor.RiseEditorMode.Level.PlatformsLayer;
            currentLayerOptionsGroupbox.Text = "Layer options: " + currentLayer.GetName();
            depthNumericUpDown.Value = (decimal)currentLayer.Depth;
            visibleCheckBox.Checked = currentLayer.Visible;

            if (currentLayer == platformsLayer)
            {
                depthNumericUpDown.Enabled = false;
                removeLayerButton.Enabled = false;
            }
            else
            {
                depthNumericUpDown.Enabled = true;
                removeLayerButton.Enabled = true;
            }
        }

        public void SelectPlatformsLayer()
        {
            for (int i = 0; i < layersListBox.Items.Count; i++)
            {
                if (layersListBox.Items[i].ToString().Contains("platforms"))
                {
                    layersListBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public void OpenElementProperties(LevelElement element)
        {
            elementProperties.SetElement(element);
            riseEditor.RiseEditorMode.InputEnabled = false;
            elementProperties.ShowDialog();
        }

        public void ElementPropertiesAddTexture(string name)
        {
            elementProperties.AddTexture(name);
            elementProperties.UpdateAdditionalTextures();
        }

        public void ElementPropertiesSetEffect(string name)
        {
            elementProperties.SetEffect(name);
        }

        public void OpenAddTextureChooser()
        {
            addTextureChooser.ShowDialog();
        }

        public void OpenEffectChooser()
        {
            effectChooser.ShowDialog();
        }

        private void addParticleButton_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.InputEnabled = false;
            particleEffectChooser.ShowDialog();
        }

        private void layersListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<LevelLayer> layers = riseEditor.RiseEditorMode.Level.Layers;
            layers[e.Index].Visible = e.NewValue == CheckState.Checked;
        }

        private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<LevelLayer> layers = riseEditor.RiseEditorMode.Level.Layers;
            LevelLayer currentLayer = riseEditor.RiseEditorMode.CurrentLayer;
            currentLayer.Visible = visibleCheckBox.Checked;
            layersListBox.SetItemChecked(layers.IndexOf(currentLayer), visibleCheckBox.Checked);
        }

        private void addElementButton_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.InputEnabled = false;
            platformsChooser.ShowDialog();
        }

        private void removeElementButton_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.ToggleRemovingElementAction();
        }

        private void removeLayerButton_Click(object sender, EventArgs e)
        {
            LevelLayer currentLayer = riseEditor.RiseEditorMode.CurrentLayer;
            riseEditor.RiseEditorMode.Level.RemoveLayer(currentLayer);
            riseEditor.RiseEditorMode.CurrentLayer = riseEditor.RiseEditorMode.Level.PlatformsLayer;
            UpdateLayersNodes();
            UpdateCurrentLayerPanel();
        }

        private void addLayerButton_Click(object sender, EventArgs e)
        {
            float maxDepth = 0;
            foreach (LevelLayer layer in riseEditor.RiseEditorMode.Level.Layers)
            {
                if (layer.Depth > maxDepth)
                    maxDepth = layer.Depth;
            }

            float depth = maxDepth + 1;
            if (depth > 10)
                depth = 10;

            LevelLayer newLayer = new LevelLayer(depth);
            riseEditor.RiseEditorMode.Level.AddLayer(newLayer);
            riseEditor.RiseEditorMode.CurrentLayer = newLayer;
            UpdateLayersNodes();
            UpdateCurrentLayerPanel();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.NewLevel();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/levels";
            saveFileDialog.Filter = "Level files (*.lvl)|*.lvl";
            saveFileDialog.FilterIndex = 1;

            SetXnaFrameTopMost(false);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                riseEditor.RiseEditorMode.Saved = true;
                FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                riseEditor.RiseEditorMode.SaveLevel(fileInfo.Name);
            }
            SetXnaFrameTopMost(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/levels";
            openFileDialog.Filter = "Level files (*.lvl)|*.lvl";
            openFileDialog.FilterIndex = 1;

            SetXnaFrameTopMost(false);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LevelData levelData = new LevelData(File.ReadAllBytes(openFileDialog.FileName));
                riseEditor.RiseEditorMode.OpenLevel(levelData);
            }
            SetXnaFrameTopMost(true);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            riseEditor.Exit();
        }

        private void fixXnaFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetXnaFrameTopMost(false);
            SetXnaFrameTopMost(true);
        }

        private void resetCameraButton_Click(object sender, EventArgs e)
        {
            Renderer renderer = riseEditor.RiseEditorMode.Renderer;
            renderer.Center = Vector2.Zero;
            renderer.Zoom = 1;
            cameraFollowsPointerCheckbox.Checked = false;
        }

        private void elementPropertiesButton_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.ToggleElementPropertiesAction();
        }

        private void removeParticleButton_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.ToggleRemovingParticleEffectAction();
        }

        private void levelBoundsLeftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FloatRectangle levelBounds = riseEditor.RiseEditorMode.Level.Bounds;
            float left = levelBounds.Left;
            levelBounds.Left = (float)levelBoundsLeftNumericUpDown.Value;
            levelBounds.Width += left - levelBounds.Left;
        }

        private void levelBoundsRightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FloatRectangle levelBounds = riseEditor.RiseEditorMode.Level.Bounds;
            levelBounds.Width += (float)levelBoundsRightNumericUpDown.Value - levelBounds.Right;
        }

        private void levelBoundsTopNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FloatRectangle levelBounds = riseEditor.RiseEditorMode.Level.Bounds;
            float top = levelBounds.Top;
            levelBounds.Top = (float)levelBoundsTopNumericUpDown.Value;
            levelBounds.Height += top - levelBounds.Top;
        }

        private void levelBoundsBottomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FloatRectangle levelBounds = riseEditor.RiseEditorMode.Level.Bounds;
            levelBounds.Height += (float)levelBoundsBottomNumericUpDown.Value - levelBounds.Bottom;
        }

        public void UpdateLevelBounds()
        {
            FloatRectangle levelBounds = riseEditor.RiseEditorMode.Level.Bounds;
            levelBoundsLeftNumericUpDown.Value = (decimal)levelBounds.Left;
            levelBoundsRightNumericUpDown.Value = (decimal)levelBounds.Right;
            levelBoundsTopNumericUpDown.Value = (decimal)levelBounds.Top;
            levelBoundsBottomNumericUpDown.Value = (decimal)levelBounds.Bottom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            riseEditor.RiseEditorMode.Level.Bounds = new FloatRectangle(-1000, -1000, 2000, 1700);
            UpdateLevelBounds();
        }

    }
}
