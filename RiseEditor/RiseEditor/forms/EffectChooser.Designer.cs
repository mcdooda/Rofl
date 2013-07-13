namespace RiseEditor.forms
{
    partial class EffectChooser
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
            this.levelDirectoryCombobox = new System.Windows.Forms.ComboBox();
            this.effectsListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // levelDirectoryCombobox
            // 
            this.levelDirectoryCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelDirectoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelDirectoryCombobox.FormattingEnabled = true;
            this.levelDirectoryCombobox.Location = new System.Drawing.Point(13, 13);
            this.levelDirectoryCombobox.Name = "levelDirectoryCombobox";
            this.levelDirectoryCombobox.Size = new System.Drawing.Size(259, 21);
            this.levelDirectoryCombobox.TabIndex = 0;
            this.levelDirectoryCombobox.SelectedIndexChanged += new System.EventHandler(this.levelDirectoryCombobox_SelectedIndexChanged);
            // 
            // effectsListbox
            // 
            this.effectsListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effectsListbox.FormattingEnabled = true;
            this.effectsListbox.Location = new System.Drawing.Point(13, 41);
            this.effectsListbox.Name = "effectsListbox";
            this.effectsListbox.Size = new System.Drawing.Size(259, 212);
            this.effectsListbox.TabIndex = 1;
            this.effectsListbox.DoubleClick += new System.EventHandler(this.effectsListbox_DoubleClick);
            // 
            // EffectChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.effectsListbox);
            this.Controls.Add(this.levelDirectoryCombobox);
            this.Name = "EffectChooser";
            this.Text = "Rise Editor Effect Chooser";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox levelDirectoryCombobox;
        private System.Windows.Forms.ListBox effectsListbox;
    }
}