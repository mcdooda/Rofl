using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RiseEditor.forms;

namespace RumbleEditor.forms
{
    public partial class NewCharacterWindow : Form
    {
        private MainWindow mainWindow;
        private SpriteChooser spriteChooser;
        private FaceTextureChooser faceTextureChooser;

        public NewCharacterWindow(MainWindow mainWindow, SpriteChooser spriteChooser, FaceTextureChooser faceTextureChooser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.spriteChooser = spriteChooser;
            this.faceTextureChooser = faceTextureChooser;
        }

        private void createCharacterButton_Click(object sender, EventArgs e)
        {
            mainWindow.RumbleEditor.RumbleEditorMode.NewCharacter(
                animationTextureTextBox.Text,
                (int)animationNumLinesNumericUpDown.Value,
                (int)animationNumColumnsNumericUpDown.Value,
                (double)animationFrameDurationNumericUpDown.Value,
                faceTextureTextBox.Text
            );
            mainWindow.SetXnaFrameTopMost(true);
            Hide();
        }

        private void chooseAnimationTextureButton_Click(object sender, EventArgs e)
        {
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = false;
            spriteChooser.Show();
        }

        public void SetAnimationTexture(string animationTexture)
        {
            animationTextureTextBox.Text = animationTexture;
        }

        public void SetFaceTexture(string faceTexture)
        {
            faceTextureTextBox.Text = faceTexture;
        }

        private void chooseFaceTextureButton_Click(object sender, EventArgs e)
        {
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = false;
            faceTextureChooser.Show();
        }
    }
}
