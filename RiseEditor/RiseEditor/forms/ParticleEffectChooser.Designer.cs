namespace RiseEditor.forms
{
    partial class ParticleEffectChooser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.levelNamespaceCombobox = new System.Windows.Forms.ComboBox();
            this.particleEffectsListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // levelNamespaceCombobox
            // 
            this.levelNamespaceCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelNamespaceCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelNamespaceCombobox.FormattingEnabled = true;
            this.levelNamespaceCombobox.Location = new System.Drawing.Point(13, 13);
            this.levelNamespaceCombobox.Name = "levelNamespaceCombobox";
            this.levelNamespaceCombobox.Size = new System.Drawing.Size(259, 21);
            this.levelNamespaceCombobox.TabIndex = 0;
            this.levelNamespaceCombobox.SelectedIndexChanged += new System.EventHandler(this.levelNamespaceCombobox_SelectedIndexChanged);
            // 
            // particleEffectsListbox
            // 
            this.particleEffectsListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.particleEffectsListbox.FormattingEnabled = true;
            this.particleEffectsListbox.Location = new System.Drawing.Point(13, 41);
            this.particleEffectsListbox.Name = "particleEffectsListbox";
            this.particleEffectsListbox.Size = new System.Drawing.Size(259, 212);
            this.particleEffectsListbox.TabIndex = 1;
            this.particleEffectsListbox.DoubleClick += new System.EventHandler(this.particleEffectsListbox_DoubleClick);
            // 
            // ParticleEffectChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.particleEffectsListbox);
            this.Controls.Add(this.levelNamespaceCombobox);
            this.Name = "ParticleEffectChooser";
            this.Text = "Rise Editor Particle Effect Chooser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParticleEffectChooser_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox levelNamespaceCombobox;
        private System.Windows.Forms.ListBox particleEffectsListbox;

    }
}