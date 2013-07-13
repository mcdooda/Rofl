namespace RumbleEditor.forms
{
    partial class NewCharacterWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.animationFrameDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.animationNumLinesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.animationNumColumnsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseAnimationTextureButton = new System.Windows.Forms.Button();
            this.animationTextureTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chooseFaceTextureButton = new System.Windows.Forms.Button();
            this.faceTextureTextBox = new System.Windows.Forms.TextBox();
            this.createCharacterButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameDurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumLinesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumColumnsNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.animationFrameDurationNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.animationNumLinesNumericUpDown);
            this.groupBox1.Controls.Add(this.animationNumColumnsNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chooseAnimationTextureButton);
            this.groupBox1.Controls.Add(this.animationTextureTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation";
            // 
            // animationFrameDurationNumericUpDown
            // 
            this.animationFrameDurationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationFrameDurationNumericUpDown.DecimalPlaces = 2;
            this.animationFrameDurationNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.animationFrameDurationNumericUpDown.Location = new System.Drawing.Point(96, 99);
            this.animationFrameDurationNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationFrameDurationNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.animationFrameDurationNumericUpDown.Name = "animationFrameDurationNumericUpDown";
            this.animationFrameDurationNumericUpDown.Size = new System.Drawing.Size(146, 20);
            this.animationFrameDurationNumericUpDown.TabIndex = 7;
            this.animationFrameDurationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Frame duration :";
            // 
            // animationNumLinesNumericUpDown
            // 
            this.animationNumLinesNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationNumLinesNumericUpDown.Location = new System.Drawing.Point(96, 47);
            this.animationNumLinesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationNumLinesNumericUpDown.Name = "animationNumLinesNumericUpDown";
            this.animationNumLinesNumericUpDown.Size = new System.Drawing.Size(146, 20);
            this.animationNumLinesNumericUpDown.TabIndex = 5;
            this.animationNumLinesNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // animationNumColumnsNumericUpDown
            // 
            this.animationNumColumnsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationNumColumnsNumericUpDown.Location = new System.Drawing.Point(96, 73);
            this.animationNumColumnsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationNumColumnsNumericUpDown.Name = "animationNumColumnsNumericUpDown";
            this.animationNumColumnsNumericUpDown.Size = new System.Drawing.Size(146, 20);
            this.animationNumColumnsNumericUpDown.TabIndex = 4;
            this.animationNumColumnsNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columns :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lines :";
            // 
            // chooseAnimationTextureButton
            // 
            this.chooseAnimationTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseAnimationTextureButton.Location = new System.Drawing.Point(145, 19);
            this.chooseAnimationTextureButton.Name = "chooseAnimationTextureButton";
            this.chooseAnimationTextureButton.Size = new System.Drawing.Size(97, 23);
            this.chooseAnimationTextureButton.TabIndex = 1;
            this.chooseAnimationTextureButton.Text = "Choose texture";
            this.chooseAnimationTextureButton.UseVisualStyleBackColor = true;
            this.chooseAnimationTextureButton.Click += new System.EventHandler(this.chooseAnimationTextureButton_Click);
            // 
            // animationTextureTextBox
            // 
            this.animationTextureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTextureTextBox.Location = new System.Drawing.Point(6, 21);
            this.animationTextureTextBox.Name = "animationTextureTextBox";
            this.animationTextureTextBox.Size = new System.Drawing.Size(133, 20);
            this.animationTextureTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chooseFaceTextureButton);
            this.groupBox2.Controls.Add(this.faceTextureTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Face";
            // 
            // chooseFaceTextureButton
            // 
            this.chooseFaceTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseFaceTextureButton.Location = new System.Drawing.Point(145, 17);
            this.chooseFaceTextureButton.Name = "chooseFaceTextureButton";
            this.chooseFaceTextureButton.Size = new System.Drawing.Size(97, 23);
            this.chooseFaceTextureButton.TabIndex = 6;
            this.chooseFaceTextureButton.Text = "Choose texture";
            this.chooseFaceTextureButton.UseVisualStyleBackColor = true;
            this.chooseFaceTextureButton.Click += new System.EventHandler(this.chooseFaceTextureButton_Click);
            // 
            // faceTextureTextBox
            // 
            this.faceTextureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.faceTextureTextBox.Location = new System.Drawing.Point(6, 19);
            this.faceTextureTextBox.Name = "faceTextureTextBox";
            this.faceTextureTextBox.Size = new System.Drawing.Size(133, 20);
            this.faceTextureTextBox.TabIndex = 6;
            // 
            // createCharacterButton
            // 
            this.createCharacterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createCharacterButton.Location = new System.Drawing.Point(158, 221);
            this.createCharacterButton.Name = "createCharacterButton";
            this.createCharacterButton.Size = new System.Drawing.Size(102, 23);
            this.createCharacterButton.TabIndex = 2;
            this.createCharacterButton.Text = "Create character";
            this.createCharacterButton.UseVisualStyleBackColor = true;
            this.createCharacterButton.Click += new System.EventHandler(this.createCharacterButton_Click);
            // 
            // NewCharacterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 257);
            this.Controls.Add(this.createCharacterButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewCharacterWindow";
            this.Text = "Rumble Editor new character";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameDurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumLinesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumColumnsNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox animationTextureTextBox;
        private System.Windows.Forms.Button chooseAnimationTextureButton;
        private System.Windows.Forms.NumericUpDown animationNumLinesNumericUpDown;
        private System.Windows.Forms.NumericUpDown animationNumColumnsNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button chooseFaceTextureButton;
        private System.Windows.Forms.TextBox faceTextureTextBox;
        private System.Windows.Forms.NumericUpDown animationFrameDurationNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createCharacterButton;
    }
}