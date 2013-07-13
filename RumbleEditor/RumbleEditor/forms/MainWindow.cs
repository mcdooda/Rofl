using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RoflLib.io.character;
using RoflLib;
using RiseEditor.forms;

namespace RumbleEditor.forms
{
    public partial class MainWindow : Form
    {
        private RumbleEditor rumbleEditor;
        public RumbleEditor RumbleEditor { get { return rumbleEditor; } }

        public bool HasFocus { get { return ContainsFocus; } set { if (value) Focus(); } }

        private NewCharacterWindow newCharacterWindow;

        private EditAnimationWindow editAnimationWindow;
        public EditAnimationWindow EditAnimationWindow { get { return editAnimationWindow; } }

        private SpriteChooser spriteChooser;
        private FaceTextureChooser faceTextureChooser;

        public MainWindow(RumbleEditor rumbleEditor)
        {
            InitializeComponent();
            this.rumbleEditor = rumbleEditor;
            SetXnaFrameTopMost(true);

            List<string> charactersDirectories = rumbleEditor.RumbleEditorMode.GetCharactersDirectories();

            spriteChooser = new SpriteChooser(this);
            spriteChooser.FillCombobox(charactersDirectories);

            faceTextureChooser = new FaceTextureChooser(this);
            faceTextureChooser.FillCombobox(charactersDirectories);

            newCharacterWindow = new NewCharacterWindow(this, spriteChooser, faceTextureChooser);

            spriteChooser.NewCharacterWindow = newCharacterWindow;
            faceTextureChooser.NewCharacterWindow = newCharacterWindow;

            editAnimationWindow = new EditAnimationWindow(this);
        }

        public System.Windows.Forms.Control GetXnaFrame()
        {
            return (System.Windows.Forms.Control)System.Windows.Forms.Form.FromHandle(rumbleEditor.Window.Handle);
        }

        public void SetXnaFrameTopMost(bool topMost)
        {
            ((System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(rumbleEditor.Window.Handle)).TopMost = topMost;
        }

        public void UpdateXnaFrame()
        {
            System.Windows.Forms.Control xnaFrame = GetXnaFrame();
            if (xnaFrame != null)
            {
                xnaFrame.Hide();
                rumbleEditor.UpdateWindow(0, 0, xnaPanel.Width, xnaPanel.Height);
                xnaFrame.Location = xnaPanel.PointToScreen(new System.Drawing.Point(0, 0));
                xnaFrame.Width = xnaPanel.Width;
                xnaFrame.Height = xnaPanel.Height;
                xnaFrame.Show();
                xnaFrame.BringToFront();
            }
        }

        public void NewCharacter(string animationTextureName, int animationNumLines, int animationNumColumns, double animationFrameDuration, string faceTextureName)
        {
            rumbleEditor.RumbleEditorMode.NewCharacter(
                animationTextureName,
                animationNumLines,
                animationNumColumns,
                animationFrameDuration,
                faceTextureName
            );

            animationTextureTextBox.Text = animationTextureName;
            animationNumLinesNumericUpDown.Value = animationNumLines;
            animationNumColumnsNumericUpDown.Value = animationNumColumns;
            animationFrameDurationNumericUpDown.Value = (decimal)animationFrameDuration;
            faceTextureTextBox.Text = faceTextureName;

            SetXnaFrameTopMost(true);
        }

        public void AddAnimationName(string animationName)
        {
            animationsComboBox.Items.Add(animationName);
        }

        public void RemoveAnimationName(string animationName)
        {
            animationsComboBox.Items.Remove(animationName);
        }

        private void fixXnaFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetXnaFrameTopMost(false);
            SetXnaFrameTopMost(true);
        }

        private void xnaPanel_SizeChanged(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void MainWindow_Enter(object sender, EventArgs e)
        {
            UpdateXnaFrame();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            rumbleEditor.Exit();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rumbleEditor.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetXnaFrameTopMost(false);
            newCharacterWindow.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/characters";
            openFileDialog.Filter = "Character files (*.chr)|*.chr";
            openFileDialog.FilterIndex = 1;

            SetXnaFrameTopMost(false);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CharacterData characterData = new CharacterData(File.ReadAllBytes(openFileDialog.FileName));
                rumbleEditor.RumbleEditorMode.OpenCharacter(characterData);

                Character character = rumbleEditor.RumbleEditorMode.Character;
                animationNumLinesNumericUpDown.Value = character.Animation.NumLines;
                animationNumColumnsNumericUpDown.Value = character.Animation.NumColumns;
                animationFrameDurationNumericUpDown.Value = (decimal)character.Animation.FrameDuration;
                weightNumericUpDown.Value = (decimal)character.Weight;
                jumpForceNumericUpDown.Value = (decimal)character.JumpForce;
                runningSpeedNumericUpDown.Value = (decimal)character.RunningSpeed;
                secondaryJumpsNumericUpDown.Value = character.NumSecondJumps;
                animationsComboBox.Items.Clear();
                foreach (KeyValuePair<string, Animation.Frame> frame in character.Animation.Frames)
                    animationsComboBox.Items.Add(frame.Key);
            }
            SetXnaFrameTopMost(true);
            EnableAnimationButtons();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/rofl/characters";
            saveFileDialog.Filter = "Character files (*.chr)|*.chr";
            saveFileDialog.FilterIndex = 1;

            SetXnaFrameTopMost(false);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rumbleEditor.RumbleEditorMode.Saved = true;
                FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                rumbleEditor.RumbleEditorMode.SaveCharacter(fileInfo.Name);
            }
            SetXnaFrameTopMost(true);
        }

        private void weightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetCharacterWeight((float)weightNumericUpDown.Value);
        }

        private void jumpForceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetCharacterJumpForce((float)jumpForceNumericUpDown.Value);
        }

        private void runningSpeedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetCharacterRunningSpeed((float)runningSpeedNumericUpDown.Value);
        }

        private void secondaryJumpsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetCharacterSecondaryJumps((int)secondaryJumpsNumericUpDown.Value);
        }

        private void animationNumLinesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetAnimationNumLines((int)animationNumLinesNumericUpDown.Value);
        }

        private void animationNumColumnsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetAnimationNumColumns((int)animationNumColumnsNumericUpDown.Value);
        }

        private void animationFrameDurationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetAnimationFrameDuration((double)animationFrameDurationNumericUpDown.Value);
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.SetState("attackSprite");
        }

        private void editAnimationButton_Click(object sender, EventArgs e)
        {
            string animationName = (string)animationsComboBox.SelectedItem;
            if (animationName != null)
            {
                rumbleEditor.RumbleEditorMode.InputEnabled = false;
                SetXnaFrameTopMost(false);
                editAnimationWindow.AnimationFrame = rumbleEditor.RumbleEditorMode.Character.Animation.Frames[animationName];
                editAnimationWindow.OldName = animationName;
                editAnimationWindow.ShowDialog();
            }
        }

        public void EnableFrameButtons()
        {
            nextFrameButton.Enabled = true;
            removeHitPointButton.Enabled = true;
        }

        public void DisableFrameButtons()
        {
            nextFrameButton.Enabled = false;
            removeHitPointButton.Enabled = false;
        }

        public void EnableAnimationButtons()
        {
            animationsComboBox.Enabled = true;
            editAnimationButton.Enabled = true;
            addAnimationButton.Enabled = true;
            //playAnimationButton.Enabled = true;
        }

        private void nextFrameButton_Click(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.AttackHitNextFrame();
        }

        private void playAnimationButton_Click(object sender, EventArgs e)
        {
            string animationName = (string)animationsComboBox.SelectedItem;
            if (animationName != null)
            {
                rumbleEditor.RumbleEditorMode.PlayFrame(animationName);
            }
        }

        private void removeHitPointButton_Click(object sender, EventArgs e)
        {
            rumbleEditor.RumbleEditorMode.RemoveHitPoint();
        }
    }
}
