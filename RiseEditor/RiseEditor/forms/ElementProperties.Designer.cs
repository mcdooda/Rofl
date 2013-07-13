namespace RiseEditor.forms
{
    partial class ElementProperties
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
            this.additionTexturesGroupbox = new System.Windows.Forms.GroupBox();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.removeTextureButton = new System.Windows.Forms.Button();
            this.addTextureButton = new System.Windows.Forms.Button();
            this.additionalTexturesListbox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeEffectButton = new System.Windows.Forms.Button();
            this.chooseEffectButton = new System.Windows.Forms.Button();
            this.effectTextbox = new System.Windows.Forms.TextBox();
            this.additionTexturesGroupbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // additionTexturesGroupbox
            // 
            this.additionTexturesGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.additionTexturesGroupbox.Controls.Add(this.moveDownButton);
            this.additionTexturesGroupbox.Controls.Add(this.moveUpButton);
            this.additionTexturesGroupbox.Controls.Add(this.removeTextureButton);
            this.additionTexturesGroupbox.Controls.Add(this.addTextureButton);
            this.additionTexturesGroupbox.Controls.Add(this.additionalTexturesListbox);
            this.additionTexturesGroupbox.Location = new System.Drawing.Point(12, 12);
            this.additionTexturesGroupbox.Name = "additionTexturesGroupbox";
            this.additionTexturesGroupbox.Size = new System.Drawing.Size(403, 160);
            this.additionTexturesGroupbox.TabIndex = 3;
            this.additionTexturesGroupbox.TabStop = false;
            this.additionTexturesGroupbox.Text = "Additional textures";
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Location = new System.Drawing.Point(300, 107);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(97, 23);
            this.moveDownButton.TabIndex = 4;
            this.moveDownButton.Text = "Move down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Location = new System.Drawing.Point(300, 78);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(97, 23);
            this.moveUpButton.TabIndex = 3;
            this.moveUpButton.Text = "Move up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // removeTextureButton
            // 
            this.removeTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeTextureButton.Location = new System.Drawing.Point(300, 49);
            this.removeTextureButton.Name = "removeTextureButton";
            this.removeTextureButton.Size = new System.Drawing.Size(97, 23);
            this.removeTextureButton.TabIndex = 2;
            this.removeTextureButton.Text = "Remove texture";
            this.removeTextureButton.UseVisualStyleBackColor = true;
            this.removeTextureButton.Click += new System.EventHandler(this.removeTextureButton_Click);
            // 
            // addTextureButton
            // 
            this.addTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextureButton.Location = new System.Drawing.Point(300, 20);
            this.addTextureButton.Name = "addTextureButton";
            this.addTextureButton.Size = new System.Drawing.Size(97, 23);
            this.addTextureButton.TabIndex = 1;
            this.addTextureButton.Text = "Add texture";
            this.addTextureButton.UseVisualStyleBackColor = true;
            this.addTextureButton.Click += new System.EventHandler(this.addTextureButton_Click);
            // 
            // additionalTexturesListbox
            // 
            this.additionalTexturesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.additionalTexturesListbox.FormattingEnabled = true;
            this.additionalTexturesListbox.Location = new System.Drawing.Point(7, 20);
            this.additionalTexturesListbox.Name = "additionalTexturesListbox";
            this.additionalTexturesListbox.Size = new System.Drawing.Size(287, 121);
            this.additionalTexturesListbox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.removeEffectButton);
            this.groupBox1.Controls.Add(this.chooseEffectButton);
            this.groupBox1.Controls.Add(this.effectTextbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Effect";
            // 
            // removeEffectButton
            // 
            this.removeEffectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeEffectButton.Location = new System.Drawing.Point(300, 49);
            this.removeEffectButton.Name = "removeEffectButton";
            this.removeEffectButton.Size = new System.Drawing.Size(97, 23);
            this.removeEffectButton.TabIndex = 2;
            this.removeEffectButton.Text = "Remove effect";
            this.removeEffectButton.UseVisualStyleBackColor = true;
            this.removeEffectButton.Click += new System.EventHandler(this.removeEffectButton_Click);
            // 
            // chooseEffectButton
            // 
            this.chooseEffectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseEffectButton.Location = new System.Drawing.Point(300, 20);
            this.chooseEffectButton.Name = "chooseEffectButton";
            this.chooseEffectButton.Size = new System.Drawing.Size(97, 23);
            this.chooseEffectButton.TabIndex = 1;
            this.chooseEffectButton.Text = "Choose effect";
            this.chooseEffectButton.UseVisualStyleBackColor = true;
            this.chooseEffectButton.Click += new System.EventHandler(this.chooseEffectButton_Click);
            // 
            // effectTextbox
            // 
            this.effectTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effectTextbox.Enabled = false;
            this.effectTextbox.Location = new System.Drawing.Point(7, 20);
            this.effectTextbox.Name = "effectTextbox";
            this.effectTextbox.Size = new System.Drawing.Size(287, 20);
            this.effectTextbox.TabIndex = 0;
            // 
            // ElementProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.additionTexturesGroupbox);
            this.Name = "ElementProperties";
            this.Text = "Rise Editor Element Properties";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ElementProperties_FormClosed);
            this.additionTexturesGroupbox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox additionTexturesGroupbox;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button removeTextureButton;
        private System.Windows.Forms.Button addTextureButton;
        private System.Windows.Forms.ListBox additionalTexturesListbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removeEffectButton;
        private System.Windows.Forms.Button chooseEffectButton;
        private System.Windows.Forms.TextBox effectTextbox;
    }
}