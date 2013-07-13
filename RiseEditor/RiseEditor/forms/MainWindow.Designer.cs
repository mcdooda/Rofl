namespace RiseEditor.forms
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.layersTabpage = new System.Windows.Forms.TabPage();
            this.layersListBox = new System.Windows.Forms.CheckedListBox();
            this.layersPanel = new System.Windows.Forms.Panel();
            this.currentLayerOptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.depthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.visibleCheckBox = new System.Windows.Forms.CheckBox();
            this.particlesOptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.removeParticleButton = new System.Windows.Forms.Button();
            this.addParticleButton = new System.Windows.Forms.Button();
            this.elementOptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.addElementButton = new System.Windows.Forms.Button();
            this.elementPropertiesButton = new System.Windows.Forms.Button();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.layerOptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.addLayerButton = new System.Windows.Forms.Button();
            this.removeLayerButton = new System.Windows.Forms.Button();
            this.cameraSettingsTabpage = new System.Windows.Forms.TabPage();
            this.displayParticlesCheckbox = new System.Windows.Forms.CheckBox();
            this.displayOverlayCheckbox = new System.Windows.Forms.CheckBox();
            this.applyShadersCheckbox = new System.Windows.Forms.CheckBox();
            this.displayParticlesOriginCheckbox = new System.Windows.Forms.CheckBox();
            this.resetCameraButton = new System.Windows.Forms.Button();
            this.displayWorldOriginCheckbox = new System.Windows.Forms.CheckBox();
            this.cameraFollowsPointerCheckbox = new System.Windows.Forms.CheckBox();
            this.displayOnlyPlatformsCheckbox = new System.Windows.Forms.CheckBox();
            this.levelBoundsTabpage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.levelBoundsRightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelBoundsBottomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelBoundsTopNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelBoundsLeftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixXnaFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xnaPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.layersTabpage.SuspendLayout();
            this.layersPanel.SuspendLayout();
            this.currentLayerOptionsGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).BeginInit();
            this.particlesOptionsGroupbox.SuspendLayout();
            this.elementOptionsGroupbox.SuspendLayout();
            this.layerOptionsGroupbox.SuspendLayout();
            this.cameraSettingsTabpage.SuspendLayout();
            this.levelBoundsTabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsRightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsBottomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsTopNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsLeftNumericUpDown)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            this.splitContainer.Panel1.Controls.Add(this.menuStrip);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.xnaPanel);
            this.splitContainer.Size = new System.Drawing.Size(884, 585);
            this.splitContainer.SplitterDistance = 345;
            this.splitContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.layersTabpage);
            this.tabControl.Controls.Add(this.cameraSettingsTabpage);
            this.tabControl.Controls.Add(this.levelBoundsTabpage);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(345, 558);
            this.tabControl.TabIndex = 0;
            // 
            // layersTabpage
            // 
            this.layersTabpage.Controls.Add(this.layersListBox);
            this.layersTabpage.Controls.Add(this.layersPanel);
            this.layersTabpage.Location = new System.Drawing.Point(4, 22);
            this.layersTabpage.Name = "layersTabpage";
            this.layersTabpage.Padding = new System.Windows.Forms.Padding(3);
            this.layersTabpage.Size = new System.Drawing.Size(337, 532);
            this.layersTabpage.TabIndex = 1;
            this.layersTabpage.Text = "Layers";
            this.layersTabpage.UseVisualStyleBackColor = true;
            // 
            // layersListBox
            // 
            this.layersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layersListBox.FormattingEnabled = true;
            this.layersListBox.Location = new System.Drawing.Point(0, 0);
            this.layersListBox.Name = "layersListBox";
            this.layersListBox.Size = new System.Drawing.Size(337, 259);
            this.layersListBox.TabIndex = 2;
            this.layersListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.layersListBox_ItemCheck);
            this.layersListBox.SelectedIndexChanged += new System.EventHandler(this.layersListBox_SelectedIndexChanged);
            // 
            // layersPanel
            // 
            this.layersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layersPanel.Controls.Add(this.currentLayerOptionsGroupbox);
            this.layersPanel.Controls.Add(this.particlesOptionsGroupbox);
            this.layersPanel.Controls.Add(this.elementOptionsGroupbox);
            this.layersPanel.Controls.Add(this.layerOptionsGroupbox);
            this.layersPanel.Location = new System.Drawing.Point(0, 262);
            this.layersPanel.Name = "layersPanel";
            this.layersPanel.Size = new System.Drawing.Size(337, 271);
            this.layersPanel.TabIndex = 1;
            // 
            // currentLayerOptionsGroupbox
            // 
            this.currentLayerOptionsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLayerOptionsGroupbox.Controls.Add(this.label1);
            this.currentLayerOptionsGroupbox.Controls.Add(this.depthNumericUpDown);
            this.currentLayerOptionsGroupbox.Controls.Add(this.label2);
            this.currentLayerOptionsGroupbox.Controls.Add(this.visibleCheckBox);
            this.currentLayerOptionsGroupbox.Location = new System.Drawing.Point(6, 4);
            this.currentLayerOptionsGroupbox.Name = "currentLayerOptionsGroupbox";
            this.currentLayerOptionsGroupbox.Size = new System.Drawing.Size(325, 58);
            this.currentLayerOptionsGroupbox.TabIndex = 13;
            this.currentLayerOptionsGroupbox.TabStop = false;
            this.currentLayerOptionsGroupbox.Text = "Layer options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Depth";
            // 
            // depthNumericUpDown
            // 
            this.depthNumericUpDown.DecimalPlaces = 1;
            this.depthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.depthNumericUpDown.Location = new System.Drawing.Point(48, 19);
            this.depthNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.depthNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.depthNumericUpDown.Name = "depthNumericUpDown";
            this.depthNumericUpDown.Size = new System.Drawing.Size(113, 20);
            this.depthNumericUpDown.TabIndex = 3;
            this.depthNumericUpDown.ValueChanged += new System.EventHandler(this.depthNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Visible";
            // 
            // visibleCheckBox
            // 
            this.visibleCheckBox.AutoSize = true;
            this.visibleCheckBox.Checked = true;
            this.visibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visibleCheckBox.Location = new System.Drawing.Point(210, 21);
            this.visibleCheckBox.Name = "visibleCheckBox";
            this.visibleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.visibleCheckBox.TabIndex = 4;
            this.visibleCheckBox.UseVisualStyleBackColor = true;
            this.visibleCheckBox.CheckedChanged += new System.EventHandler(this.visibleCheckBox_CheckedChanged);
            // 
            // particlesOptionsGroupbox
            // 
            this.particlesOptionsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.particlesOptionsGroupbox.Controls.Add(this.removeParticleButton);
            this.particlesOptionsGroupbox.Controls.Add(this.addParticleButton);
            this.particlesOptionsGroupbox.Location = new System.Drawing.Point(6, 135);
            this.particlesOptionsGroupbox.Name = "particlesOptionsGroupbox";
            this.particlesOptionsGroupbox.Size = new System.Drawing.Size(325, 62);
            this.particlesOptionsGroupbox.TabIndex = 12;
            this.particlesOptionsGroupbox.TabStop = false;
            this.particlesOptionsGroupbox.Text = "Particle options";
            // 
            // removeParticleButton
            // 
            this.removeParticleButton.Location = new System.Drawing.Point(111, 20);
            this.removeParticleButton.Name = "removeParticleButton";
            this.removeParticleButton.Size = new System.Drawing.Size(97, 23);
            this.removeParticleButton.TabIndex = 1;
            this.removeParticleButton.Text = "Remove particle";
            this.removeParticleButton.UseVisualStyleBackColor = true;
            this.removeParticleButton.Click += new System.EventHandler(this.removeParticleButton_Click);
            // 
            // addParticleButton
            // 
            this.addParticleButton.Location = new System.Drawing.Point(6, 20);
            this.addParticleButton.Name = "addParticleButton";
            this.addParticleButton.Size = new System.Drawing.Size(98, 23);
            this.addParticleButton.TabIndex = 0;
            this.addParticleButton.Text = "Add particle";
            this.addParticleButton.UseVisualStyleBackColor = true;
            this.addParticleButton.Click += new System.EventHandler(this.addParticleButton_Click);
            // 
            // elementOptionsGroupbox
            // 
            this.elementOptionsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementOptionsGroupbox.Controls.Add(this.addElementButton);
            this.elementOptionsGroupbox.Controls.Add(this.elementPropertiesButton);
            this.elementOptionsGroupbox.Controls.Add(this.removeElementButton);
            this.elementOptionsGroupbox.Location = new System.Drawing.Point(6, 68);
            this.elementOptionsGroupbox.Name = "elementOptionsGroupbox";
            this.elementOptionsGroupbox.Size = new System.Drawing.Size(325, 61);
            this.elementOptionsGroupbox.TabIndex = 10;
            this.elementOptionsGroupbox.TabStop = false;
            this.elementOptionsGroupbox.Text = "Element options";
            // 
            // addElementButton
            // 
            this.addElementButton.Location = new System.Drawing.Point(6, 19);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(98, 23);
            this.addElementButton.TabIndex = 7;
            this.addElementButton.Text = "Add element";
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.addElementButton_Click);
            // 
            // elementPropertiesButton
            // 
            this.elementPropertiesButton.Location = new System.Drawing.Point(214, 19);
            this.elementPropertiesButton.Name = "elementPropertiesButton";
            this.elementPropertiesButton.Size = new System.Drawing.Size(98, 23);
            this.elementPropertiesButton.TabIndex = 9;
            this.elementPropertiesButton.Text = "Properties";
            this.elementPropertiesButton.UseVisualStyleBackColor = true;
            this.elementPropertiesButton.Click += new System.EventHandler(this.elementPropertiesButton_Click);
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(110, 19);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(98, 23);
            this.removeElementButton.TabIndex = 8;
            this.removeElementButton.Text = "Remove element";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.removeElementButton_Click);
            // 
            // layerOptionsGroupbox
            // 
            this.layerOptionsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layerOptionsGroupbox.Controls.Add(this.addLayerButton);
            this.layerOptionsGroupbox.Controls.Add(this.removeLayerButton);
            this.layerOptionsGroupbox.Location = new System.Drawing.Point(6, 203);
            this.layerOptionsGroupbox.Name = "layerOptionsGroupbox";
            this.layerOptionsGroupbox.Size = new System.Drawing.Size(325, 61);
            this.layerOptionsGroupbox.TabIndex = 11;
            this.layerOptionsGroupbox.TabStop = false;
            this.layerOptionsGroupbox.Text = "Layer options";
            // 
            // addLayerButton
            // 
            this.addLayerButton.Location = new System.Drawing.Point(6, 19);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(98, 23);
            this.addLayerButton.TabIndex = 0;
            this.addLayerButton.Text = "Add layer";
            this.addLayerButton.UseVisualStyleBackColor = true;
            this.addLayerButton.Click += new System.EventHandler(this.addLayerButton_Click);
            // 
            // removeLayerButton
            // 
            this.removeLayerButton.Location = new System.Drawing.Point(110, 19);
            this.removeLayerButton.Name = "removeLayerButton";
            this.removeLayerButton.Size = new System.Drawing.Size(98, 23);
            this.removeLayerButton.TabIndex = 1;
            this.removeLayerButton.Text = "Remove layer";
            this.removeLayerButton.UseVisualStyleBackColor = true;
            this.removeLayerButton.Click += new System.EventHandler(this.removeLayerButton_Click);
            // 
            // cameraSettingsTabpage
            // 
            this.cameraSettingsTabpage.Controls.Add(this.displayParticlesCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.displayOverlayCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.applyShadersCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.displayParticlesOriginCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.resetCameraButton);
            this.cameraSettingsTabpage.Controls.Add(this.displayWorldOriginCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.cameraFollowsPointerCheckbox);
            this.cameraSettingsTabpage.Controls.Add(this.displayOnlyPlatformsCheckbox);
            this.cameraSettingsTabpage.Location = new System.Drawing.Point(4, 22);
            this.cameraSettingsTabpage.Name = "cameraSettingsTabpage";
            this.cameraSettingsTabpage.Padding = new System.Windows.Forms.Padding(3);
            this.cameraSettingsTabpage.Size = new System.Drawing.Size(337, 532);
            this.cameraSettingsTabpage.TabIndex = 0;
            this.cameraSettingsTabpage.Text = "Camera settings";
            this.cameraSettingsTabpage.UseVisualStyleBackColor = true;
            // 
            // displayParticlesCheckbox
            // 
            this.displayParticlesCheckbox.AutoSize = true;
            this.displayParticlesCheckbox.Location = new System.Drawing.Point(9, 102);
            this.displayParticlesCheckbox.Name = "displayParticlesCheckbox";
            this.displayParticlesCheckbox.Size = new System.Drawing.Size(100, 17);
            this.displayParticlesCheckbox.TabIndex = 7;
            this.displayParticlesCheckbox.Text = "display particles";
            this.displayParticlesCheckbox.UseVisualStyleBackColor = true;
            // 
            // displayOverlayCheckbox
            // 
            this.displayOverlayCheckbox.AutoSize = true;
            this.displayOverlayCheckbox.Checked = true;
            this.displayOverlayCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayOverlayCheckbox.Location = new System.Drawing.Point(9, 148);
            this.displayOverlayCheckbox.Name = "displayOverlayCheckbox";
            this.displayOverlayCheckbox.Size = new System.Drawing.Size(95, 17);
            this.displayOverlayCheckbox.TabIndex = 6;
            this.displayOverlayCheckbox.Text = "display overlay";
            this.displayOverlayCheckbox.UseVisualStyleBackColor = true;
            // 
            // applyShadersCheckbox
            // 
            this.applyShadersCheckbox.AutoSize = true;
            this.applyShadersCheckbox.Checked = true;
            this.applyShadersCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.applyShadersCheckbox.Location = new System.Drawing.Point(9, 125);
            this.applyShadersCheckbox.Name = "applyShadersCheckbox";
            this.applyShadersCheckbox.Size = new System.Drawing.Size(121, 17);
            this.applyShadersCheckbox.TabIndex = 5;
            this.applyShadersCheckbox.Text = "apply shaders (todo)";
            this.applyShadersCheckbox.UseVisualStyleBackColor = true;
            // 
            // displayParticlesOriginCheckbox
            // 
            this.displayParticlesOriginCheckbox.AutoSize = true;
            this.displayParticlesOriginCheckbox.Checked = true;
            this.displayParticlesOriginCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayParticlesOriginCheckbox.Location = new System.Drawing.Point(9, 78);
            this.displayParticlesOriginCheckbox.Name = "displayParticlesOriginCheckbox";
            this.displayParticlesOriginCheckbox.Size = new System.Drawing.Size(128, 17);
            this.displayParticlesOriginCheckbox.TabIndex = 4;
            this.displayParticlesOriginCheckbox.Text = "display particles origin";
            this.displayParticlesOriginCheckbox.UseVisualStyleBackColor = true;
            // 
            // resetCameraButton
            // 
            this.resetCameraButton.Location = new System.Drawing.Point(9, 171);
            this.resetCameraButton.Name = "resetCameraButton";
            this.resetCameraButton.Size = new System.Drawing.Size(88, 23);
            this.resetCameraButton.TabIndex = 3;
            this.resetCameraButton.Text = "Reset camera";
            this.resetCameraButton.UseVisualStyleBackColor = true;
            this.resetCameraButton.Click += new System.EventHandler(this.resetCameraButton_Click);
            // 
            // displayWorldOriginCheckbox
            // 
            this.displayWorldOriginCheckbox.AutoSize = true;
            this.displayWorldOriginCheckbox.Checked = true;
            this.displayWorldOriginCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayWorldOriginCheckbox.Location = new System.Drawing.Point(9, 55);
            this.displayWorldOriginCheckbox.Name = "displayWorldOriginCheckbox";
            this.displayWorldOriginCheckbox.Size = new System.Drawing.Size(114, 17);
            this.displayWorldOriginCheckbox.TabIndex = 2;
            this.displayWorldOriginCheckbox.Text = "display world origin";
            this.displayWorldOriginCheckbox.UseVisualStyleBackColor = true;
            // 
            // cameraFollowsPointerCheckbox
            // 
            this.cameraFollowsPointerCheckbox.AutoSize = true;
            this.cameraFollowsPointerCheckbox.Location = new System.Drawing.Point(9, 31);
            this.cameraFollowsPointerCheckbox.Name = "cameraFollowsPointerCheckbox";
            this.cameraFollowsPointerCheckbox.Size = new System.Drawing.Size(131, 17);
            this.cameraFollowsPointerCheckbox.TabIndex = 1;
            this.cameraFollowsPointerCheckbox.Text = "camera follows pointer";
            this.cameraFollowsPointerCheckbox.UseVisualStyleBackColor = true;
            this.cameraFollowsPointerCheckbox.CheckedChanged += new System.EventHandler(this.cameraFollowsPointerCheckbox_CheckedChanged);
            // 
            // displayOnlyPlatformsCheckbox
            // 
            this.displayOnlyPlatformsCheckbox.AutoSize = true;
            this.displayOnlyPlatformsCheckbox.Location = new System.Drawing.Point(9, 7);
            this.displayOnlyPlatformsCheckbox.Name = "displayOnlyPlatformsCheckbox";
            this.displayOnlyPlatformsCheckbox.Size = new System.Drawing.Size(125, 17);
            this.displayOnlyPlatformsCheckbox.TabIndex = 0;
            this.displayOnlyPlatformsCheckbox.Text = "display only platforms";
            this.displayOnlyPlatformsCheckbox.UseVisualStyleBackColor = true;
            // 
            // levelBoundsTabpage
            // 
            this.levelBoundsTabpage.Controls.Add(this.button1);
            this.levelBoundsTabpage.Controls.Add(this.label6);
            this.levelBoundsTabpage.Controls.Add(this.label5);
            this.levelBoundsTabpage.Controls.Add(this.label4);
            this.levelBoundsTabpage.Controls.Add(this.levelBoundsRightNumericUpDown);
            this.levelBoundsTabpage.Controls.Add(this.levelBoundsBottomNumericUpDown);
            this.levelBoundsTabpage.Controls.Add(this.levelBoundsTopNumericUpDown);
            this.levelBoundsTabpage.Controls.Add(this.levelBoundsLeftNumericUpDown);
            this.levelBoundsTabpage.Controls.Add(this.label3);
            this.levelBoundsTabpage.Location = new System.Drawing.Point(4, 22);
            this.levelBoundsTabpage.Name = "levelBoundsTabpage";
            this.levelBoundsTabpage.Padding = new System.Windows.Forms.Padding(3);
            this.levelBoundsTabpage.Size = new System.Drawing.Size(337, 532);
            this.levelBoundsTabpage.TabIndex = 2;
            this.levelBoundsTabpage.Text = "Level bounds";
            this.levelBoundsTabpage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reset bounds";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Bottom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Top";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Right";
            // 
            // levelBoundsRightNumericUpDown
            // 
            this.levelBoundsRightNumericUpDown.Location = new System.Drawing.Point(52, 32);
            this.levelBoundsRightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.levelBoundsRightNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.levelBoundsRightNumericUpDown.Name = "levelBoundsRightNumericUpDown";
            this.levelBoundsRightNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.levelBoundsRightNumericUpDown.TabIndex = 4;
            this.levelBoundsRightNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.levelBoundsRightNumericUpDown.ValueChanged += new System.EventHandler(this.levelBoundsRightNumericUpDown_ValueChanged);
            // 
            // levelBoundsBottomNumericUpDown
            // 
            this.levelBoundsBottomNumericUpDown.Location = new System.Drawing.Point(52, 84);
            this.levelBoundsBottomNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.levelBoundsBottomNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.levelBoundsBottomNumericUpDown.Name = "levelBoundsBottomNumericUpDown";
            this.levelBoundsBottomNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.levelBoundsBottomNumericUpDown.TabIndex = 3;
            this.levelBoundsBottomNumericUpDown.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.levelBoundsBottomNumericUpDown.ValueChanged += new System.EventHandler(this.levelBoundsBottomNumericUpDown_ValueChanged);
            // 
            // levelBoundsTopNumericUpDown
            // 
            this.levelBoundsTopNumericUpDown.Location = new System.Drawing.Point(52, 58);
            this.levelBoundsTopNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.levelBoundsTopNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.levelBoundsTopNumericUpDown.Name = "levelBoundsTopNumericUpDown";
            this.levelBoundsTopNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.levelBoundsTopNumericUpDown.TabIndex = 2;
            this.levelBoundsTopNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.levelBoundsTopNumericUpDown.ValueChanged += new System.EventHandler(this.levelBoundsTopNumericUpDown_ValueChanged);
            // 
            // levelBoundsLeftNumericUpDown
            // 
            this.levelBoundsLeftNumericUpDown.Location = new System.Drawing.Point(52, 6);
            this.levelBoundsLeftNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.levelBoundsLeftNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.levelBoundsLeftNumericUpDown.Name = "levelBoundsLeftNumericUpDown";
            this.levelBoundsLeftNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.levelBoundsLeftNumericUpDown.TabIndex = 1;
            this.levelBoundsLeftNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.levelBoundsLeftNumericUpDown.ValueChanged += new System.EventHandler(this.levelBoundsLeftNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Left";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(345, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator2,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
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
            this.xnaPanel.Size = new System.Drawing.Size(535, 585);
            this.xnaPanel.TabIndex = 0;
            this.xnaPanel.SizeChanged += new System.EventHandler(this.xnaPanel_SizeChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 585);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainWindow";
            this.Text = "Rise Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Enter += new System.EventHandler(this.MainWindow_Enter);
            this.Move += new System.EventHandler(this.MainWindow_Move);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.layersTabpage.ResumeLayout(false);
            this.layersPanel.ResumeLayout(false);
            this.currentLayerOptionsGroupbox.ResumeLayout(false);
            this.currentLayerOptionsGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).EndInit();
            this.particlesOptionsGroupbox.ResumeLayout(false);
            this.elementOptionsGroupbox.ResumeLayout(false);
            this.layerOptionsGroupbox.ResumeLayout(false);
            this.cameraSettingsTabpage.ResumeLayout(false);
            this.cameraSettingsTabpage.PerformLayout();
            this.levelBoundsTabpage.ResumeLayout(false);
            this.levelBoundsTabpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsRightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsBottomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsTopNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelBoundsLeftNumericUpDown)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage cameraSettingsTabpage;
        private System.Windows.Forms.Panel xnaPanel;
        private System.Windows.Forms.TabPage layersTabpage;
        private System.Windows.Forms.Panel layersPanel;
        private System.Windows.Forms.Button removeLayerButton;
        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cameraFollowsPointerCheckbox;
        private System.Windows.Forms.CheckBox displayOnlyPlatformsCheckbox;
        private System.Windows.Forms.NumericUpDown depthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox visibleCheckBox;
        private System.Windows.Forms.CheckedListBox layersListBox;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.CheckBox displayWorldOriginCheckbox;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixXnaFrameToolStripMenuItem;
        private System.Windows.Forms.Button resetCameraButton;
        private System.Windows.Forms.Button elementPropertiesButton;
        private System.Windows.Forms.GroupBox layerOptionsGroupbox;
        private System.Windows.Forms.GroupBox elementOptionsGroupbox;
        private System.Windows.Forms.GroupBox particlesOptionsGroupbox;
        private System.Windows.Forms.Button removeParticleButton;
        private System.Windows.Forms.Button addParticleButton;
        private System.Windows.Forms.GroupBox currentLayerOptionsGroupbox;
        private System.Windows.Forms.CheckBox applyShadersCheckbox;
        private System.Windows.Forms.CheckBox displayParticlesOriginCheckbox;
        private System.Windows.Forms.CheckBox displayOverlayCheckbox;
        private System.Windows.Forms.CheckBox displayParticlesCheckbox;
        private System.Windows.Forms.TabPage levelBoundsTabpage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown levelBoundsRightNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelBoundsBottomNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelBoundsTopNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelBoundsLeftNumericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}