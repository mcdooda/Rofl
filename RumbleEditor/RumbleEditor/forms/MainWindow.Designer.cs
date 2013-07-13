namespace RumbleEditor.forms
{
    partial class MainWindow
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.removeHitPointButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playAnimationButton = new System.Windows.Forms.Button();
            this.addAnimationButton = new System.Windows.Forms.Button();
            this.editAnimationButton = new System.Windows.Forms.Button();
            this.animationsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.secondaryJumpsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.runningSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jumpForceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.weightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chooseFaceTextureButton = new System.Windows.Forms.Button();
            this.faceTextureTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.animationFrameDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.animationNumLinesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.animationNumColumnsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chooseAnimationTextureButton = new System.Windows.Forms.Button();
            this.animationTextureTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixXnaFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xnaPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondaryJumpsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumpForceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameDurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumLinesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumColumnsNumericUpDown)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.menuStrip);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.xnaPanel);
            this.splitContainer.Size = new System.Drawing.Size(751, 649);
            this.splitContainer.SplitterDistance = 273;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 621);
            this.panel1.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.nextFrameButton);
            this.groupBox5.Controls.Add(this.removeHitPointButton);
            this.groupBox5.Location = new System.Drawing.Point(4, 452);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(264, 61);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Frame";
            // 
            // nextFrameButton
            // 
            this.nextFrameButton.Enabled = false;
            this.nextFrameButton.Location = new System.Drawing.Point(6, 19);
            this.nextFrameButton.Name = "nextFrameButton";
            this.nextFrameButton.Size = new System.Drawing.Size(97, 23);
            this.nextFrameButton.TabIndex = 5;
            this.nextFrameButton.Text = "Next frame";
            this.nextFrameButton.UseVisualStyleBackColor = true;
            this.nextFrameButton.Click += new System.EventHandler(this.nextFrameButton_Click);
            // 
            // removeHitPointButton
            // 
            this.removeHitPointButton.Enabled = false;
            this.removeHitPointButton.Location = new System.Drawing.Point(109, 19);
            this.removeHitPointButton.Name = "removeHitPointButton";
            this.removeHitPointButton.Size = new System.Drawing.Size(97, 23);
            this.removeHitPointButton.TabIndex = 4;
            this.removeHitPointButton.Text = "Remove hit point";
            this.removeHitPointButton.UseVisualStyleBackColor = true;
            this.removeHitPointButton.Click += new System.EventHandler(this.removeHitPointButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.playAnimationButton);
            this.groupBox1.Controls.Add(this.addAnimationButton);
            this.groupBox1.Controls.Add(this.editAnimationButton);
            this.groupBox1.Controls.Add(this.animationsComboBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animations";
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playAnimationButton.Enabled = false;
            this.playAnimationButton.Location = new System.Drawing.Point(58, 49);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(97, 23);
            this.playAnimationButton.TabIndex = 3;
            this.playAnimationButton.Text = "Play";
            this.playAnimationButton.UseVisualStyleBackColor = true;
            this.playAnimationButton.Click += new System.EventHandler(this.playAnimationButton_Click);
            // 
            // addAnimationButton
            // 
            this.addAnimationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addAnimationButton.Enabled = false;
            this.addAnimationButton.Location = new System.Drawing.Point(161, 49);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(97, 23);
            this.addAnimationButton.TabIndex = 2;
            this.addAnimationButton.Text = "Add";
            this.addAnimationButton.UseVisualStyleBackColor = true;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // editAnimationButton
            // 
            this.editAnimationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editAnimationButton.Enabled = false;
            this.editAnimationButton.Location = new System.Drawing.Point(161, 20);
            this.editAnimationButton.Name = "editAnimationButton";
            this.editAnimationButton.Size = new System.Drawing.Size(97, 23);
            this.editAnimationButton.TabIndex = 1;
            this.editAnimationButton.Text = "Edit";
            this.editAnimationButton.UseVisualStyleBackColor = true;
            this.editAnimationButton.Click += new System.EventHandler(this.editAnimationButton_Click);
            // 
            // animationsComboBox
            // 
            this.animationsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationsComboBox.Enabled = false;
            this.animationsComboBox.FormattingEnabled = true;
            this.animationsComboBox.Location = new System.Drawing.Point(6, 22);
            this.animationsComboBox.Name = "animationsComboBox";
            this.animationsComboBox.Size = new System.Drawing.Size(149, 21);
            this.animationsComboBox.Sorted = true;
            this.animationsComboBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.secondaryJumpsNumericUpDown);
            this.groupBox4.Controls.Add(this.runningSpeedNumericUpDown);
            this.groupBox4.Controls.Add(this.jumpForceNumericUpDown);
            this.groupBox4.Controls.Add(this.weightNumericUpDown);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(4, 212);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 136);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Physics";
            // 
            // secondaryJumpsNumericUpDown
            // 
            this.secondaryJumpsNumericUpDown.Location = new System.Drawing.Point(103, 97);
            this.secondaryJumpsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.secondaryJumpsNumericUpDown.Name = "secondaryJumpsNumericUpDown";
            this.secondaryJumpsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.secondaryJumpsNumericUpDown.TabIndex = 9;
            this.secondaryJumpsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondaryJumpsNumericUpDown.ValueChanged += new System.EventHandler(this.secondaryJumpsNumericUpDown_ValueChanged);
            // 
            // runningSpeedNumericUpDown
            // 
            this.runningSpeedNumericUpDown.Location = new System.Drawing.Point(103, 71);
            this.runningSpeedNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.runningSpeedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.runningSpeedNumericUpDown.Name = "runningSpeedNumericUpDown";
            this.runningSpeedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.runningSpeedNumericUpDown.TabIndex = 8;
            this.runningSpeedNumericUpDown.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.runningSpeedNumericUpDown.ValueChanged += new System.EventHandler(this.runningSpeedNumericUpDown_ValueChanged);
            // 
            // jumpForceNumericUpDown
            // 
            this.jumpForceNumericUpDown.Location = new System.Drawing.Point(103, 45);
            this.jumpForceNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.jumpForceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.jumpForceNumericUpDown.Name = "jumpForceNumericUpDown";
            this.jumpForceNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.jumpForceNumericUpDown.TabIndex = 7;
            this.jumpForceNumericUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.jumpForceNumericUpDown.ValueChanged += new System.EventHandler(this.jumpForceNumericUpDown_ValueChanged);
            // 
            // weightNumericUpDown
            // 
            this.weightNumericUpDown.Location = new System.Drawing.Point(103, 19);
            this.weightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.weightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightNumericUpDown.Name = "weightNumericUpDown";
            this.weightNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.weightNumericUpDown.TabIndex = 5;
            this.weightNumericUpDown.Value = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.weightNumericUpDown.ValueChanged += new System.EventHandler(this.weightNumericUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Secondary jumps:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Running speed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Jump force:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Weight:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chooseFaceTextureButton);
            this.groupBox3.Controls.Add(this.faceTextureTextBox);
            this.groupBox3.Location = new System.Drawing.Point(4, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Face";
            // 
            // chooseFaceTextureButton
            // 
            this.chooseFaceTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseFaceTextureButton.Enabled = false;
            this.chooseFaceTextureButton.Location = new System.Drawing.Point(161, 17);
            this.chooseFaceTextureButton.Name = "chooseFaceTextureButton";
            this.chooseFaceTextureButton.Size = new System.Drawing.Size(97, 23);
            this.chooseFaceTextureButton.TabIndex = 6;
            this.chooseFaceTextureButton.Text = "Choose texture";
            this.chooseFaceTextureButton.UseVisualStyleBackColor = true;
            // 
            // faceTextureTextBox
            // 
            this.faceTextureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.faceTextureTextBox.Enabled = false;
            this.faceTextureTextBox.Location = new System.Drawing.Point(6, 19);
            this.faceTextureTextBox.Name = "faceTextureTextBox";
            this.faceTextureTextBox.Size = new System.Drawing.Size(149, 20);
            this.faceTextureTextBox.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.animationFrameDurationNumericUpDown);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.animationNumLinesNumericUpDown);
            this.groupBox2.Controls.Add(this.animationNumColumnsNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chooseAnimationTextureButton);
            this.groupBox2.Controls.Add(this.animationTextureTextBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // animationFrameDurationNumericUpDown
            // 
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
            this.animationFrameDurationNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.animationFrameDurationNumericUpDown.TabIndex = 7;
            this.animationFrameDurationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.animationFrameDurationNumericUpDown.ValueChanged += new System.EventHandler(this.animationFrameDurationNumericUpDown_ValueChanged);
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
            this.animationNumLinesNumericUpDown.Enabled = false;
            this.animationNumLinesNumericUpDown.Location = new System.Drawing.Point(96, 47);
            this.animationNumLinesNumericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.animationNumLinesNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.animationNumLinesNumericUpDown.Name = "animationNumLinesNumericUpDown";
            this.animationNumLinesNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.animationNumLinesNumericUpDown.TabIndex = 5;
            this.animationNumLinesNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.animationNumLinesNumericUpDown.ValueChanged += new System.EventHandler(this.animationNumLinesNumericUpDown_ValueChanged);
            // 
            // animationNumColumnsNumericUpDown
            // 
            this.animationNumColumnsNumericUpDown.Enabled = false;
            this.animationNumColumnsNumericUpDown.Location = new System.Drawing.Point(96, 73);
            this.animationNumColumnsNumericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.animationNumColumnsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationNumColumnsNumericUpDown.Name = "animationNumColumnsNumericUpDown";
            this.animationNumColumnsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.animationNumColumnsNumericUpDown.TabIndex = 4;
            this.animationNumColumnsNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.animationNumColumnsNumericUpDown.ValueChanged += new System.EventHandler(this.animationNumColumnsNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Columns :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Lines :";
            // 
            // chooseAnimationTextureButton
            // 
            this.chooseAnimationTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseAnimationTextureButton.Enabled = false;
            this.chooseAnimationTextureButton.Location = new System.Drawing.Point(161, 19);
            this.chooseAnimationTextureButton.Name = "chooseAnimationTextureButton";
            this.chooseAnimationTextureButton.Size = new System.Drawing.Size(97, 23);
            this.chooseAnimationTextureButton.TabIndex = 1;
            this.chooseAnimationTextureButton.Text = "Choose texture";
            this.chooseAnimationTextureButton.UseVisualStyleBackColor = true;
            // 
            // animationTextureTextBox
            // 
            this.animationTextureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTextureTextBox.Enabled = false;
            this.animationTextureTextBox.Location = new System.Drawing.Point(6, 21);
            this.animationTextureTextBox.Name = "animationTextureTextBox";
            this.animationTextureTextBox.Size = new System.Drawing.Size(149, 20);
            this.animationTextureTextBox.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(273, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixXnaFrameToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fixXnaFrameToolStripMenuItem
            // 
            this.fixXnaFrameToolStripMenuItem.Name = "fixXnaFrameToolStripMenuItem";
            this.fixXnaFrameToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.fixXnaFrameToolStripMenuItem.Text = "Fix Xna Frame";
            this.fixXnaFrameToolStripMenuItem.Click += new System.EventHandler(this.fixXnaFrameToolStripMenuItem_Click);
            // 
            // xnaPanel
            // 
            this.xnaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xnaPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.xnaPanel.Location = new System.Drawing.Point(0, 0);
            this.xnaPanel.Name = "xnaPanel";
            this.xnaPanel.Size = new System.Drawing.Size(474, 649);
            this.xnaPanel.TabIndex = 0;
            this.xnaPanel.SizeChanged += new System.EventHandler(this.xnaPanel_SizeChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 649);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainWindow";
            this.Text = "Rumble Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Enter += new System.EventHandler(this.MainWindow_Enter);
            this.Move += new System.EventHandler(this.MainWindow_Move);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondaryJumpsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumpForceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameDurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumLinesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationNumColumnsNumericUpDown)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel xnaPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixXnaFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown animationFrameDurationNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown animationNumLinesNumericUpDown;
        private System.Windows.Forms.NumericUpDown animationNumColumnsNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button chooseAnimationTextureButton;
        private System.Windows.Forms.TextBox animationTextureTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button chooseFaceTextureButton;
        private System.Windows.Forms.TextBox faceTextureTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown secondaryJumpsNumericUpDown;
        private System.Windows.Forms.NumericUpDown runningSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown jumpForceNumericUpDown;
        private System.Windows.Forms.NumericUpDown weightNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button editAnimationButton;
        private System.Windows.Forms.ComboBox animationsComboBox;
        private System.Windows.Forms.Button addAnimationButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button nextFrameButton;
        private System.Windows.Forms.Button removeHitPointButton;
        private System.Windows.Forms.Button playAnimationButton;
    }
}