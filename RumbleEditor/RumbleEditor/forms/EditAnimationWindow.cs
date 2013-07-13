using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RoflLib;

namespace RumbleEditor.forms
{
    public partial class EditAnimationWindow : Form
    {
        private MainWindow mainWindow;

        private string oldName;
        public string OldName
        {
            get { return oldName; }
            set
            {
                oldName = value;
                animationNameTextBox.Text = oldName;
            }
        }

        private Animation.Frame animationFrame;

        public Animation.Frame AnimationFrame
        {
            get { return animationFrame; }
            set
            {
                animationFrame = value;
                freezeDurationNumericUpDown.Value = (decimal)animationFrame.FreezeDuration;
                frameDurationNumericUpDown.Value = (decimal)animationFrame.FrameDuration;
            }
        }

        public EditAnimationWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string newName = animationNameTextBox.Text;
            if (newName != "")
            {
                if (oldName != "" && oldName != newName) // this is not a new attack and the name has been changed
                {
                    mainWindow.RemoveAnimationName(oldName);
                    mainWindow.RumbleEditor.RumbleEditorMode.Character.RemoveFrame(oldName);
                }

                if (oldName == "" || oldName != newName)
                {
                    mainWindow.AddAnimationName(newName);
                    mainWindow.RumbleEditor.RumbleEditorMode.Character.AddFrame(newName, animationFrame);
                    mainWindow.RumbleEditor.RumbleEditorMode.Character.WorldHitPoints = new List<HitPoint>();
                }

                Hide();
                mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = true;
                mainWindow.RumbleEditor.RumbleEditorMode.SetState("physics");
                mainWindow.SetXnaFrameTopMost(true);
                mainWindow.DisableFrameButtons();
            }
            else
                animationNameTextBox.Focus();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (oldName != "")
            {
                mainWindow.RemoveAnimationName(oldName);
                mainWindow.RumbleEditor.RumbleEditorMode.Character.Animation.RemoveFrame(oldName);
            }
            Hide();
            mainWindow.RumbleEditor.RumbleEditorMode.InputEnabled = true;
            mainWindow.RumbleEditor.RumbleEditorMode.SetState("physics");
            mainWindow.SetXnaFrameTopMost(true);
            mainWindow.DisableFrameButtons();
        }

        private void frameDurationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            animationFrame.FrameDuration = (float)frameDurationNumericUpDown.Value;
        }

        private void freezeDurationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            animationFrame.FreezeDuration = (float)freezeDurationNumericUpDown.Value;
        }
    }
}
