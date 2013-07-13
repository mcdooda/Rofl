namespace RiseEditor.forms
{
    partial class PlatformChooser
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
            this.platformsPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.levelDirectoryCombobox.Size = new System.Drawing.Size(1000, 21);
            this.levelDirectoryCombobox.TabIndex = 0;
            this.levelDirectoryCombobox.SelectedIndexChanged += new System.EventHandler(this.levelDirectoryCombobox_SelectedIndexChanged);
            // 
            // platformsPanel
            // 
            this.platformsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.platformsPanel.AutoScroll = true;
            this.platformsPanel.Location = new System.Drawing.Point(13, 41);
            this.platformsPanel.Name = "platformsPanel";
            this.platformsPanel.Size = new System.Drawing.Size(1000, 596);
            this.platformsPanel.TabIndex = 1;
            // 
            // PlatformChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 649);
            this.Controls.Add(this.platformsPanel);
            this.Controls.Add(this.levelDirectoryCombobox);
            this.Name = "PlatformChooser";
            this.Text = "Rise Editor Platform Chooser";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlatformSelector_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox levelDirectoryCombobox;
        private System.Windows.Forms.FlowLayoutPanel platformsPanel;
    }
}