namespace FeatureModelConfigurator
{
	partial class WindowsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadModelFromXmlFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveModelToXmlFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.variabilityFMCheckBox = new System.Windows.Forms.CheckBox();
			this.featureModelGroupBox = new System.Windows.Forms.GroupBox();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 610);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(916, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
			this.toolStripStatusLabel.Text = "Ready";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(916, 24);
			this.menuStrip.TabIndex = 4;
			this.menuStrip.Text = "menuStrip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadModelFromXmlFileToolStripMenuItem,
            this.saveModelToXmlFileToolStripMenuItem,
            this.toolStripButtonSaveAs,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadModelFromXmlFileToolStripMenuItem
			// 
			this.loadModelFromXmlFileToolStripMenuItem.Name = "loadModelFromXmlFileToolStripMenuItem";
			this.loadModelFromXmlFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.loadModelFromXmlFileToolStripMenuItem.Text = "Load Model";
			this.loadModelFromXmlFileToolStripMenuItem.Click += new System.EventHandler(this.loadModelFromXmlFileToolStripMenuItem_Click);
			// 
			// saveModelToXmlFileToolStripMenuItem
			// 
			this.saveModelToXmlFileToolStripMenuItem.Enabled = false;
			this.saveModelToXmlFileToolStripMenuItem.Name = "saveModelToXmlFileToolStripMenuItem";
			this.saveModelToXmlFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.saveModelToXmlFileToolStripMenuItem.Text = "Save Model";
			this.saveModelToXmlFileToolStripMenuItem.Click += new System.EventHandler(this.saveModelToXmlFileToolStripMenuItem_Click);
			// 
			// toolStripButtonSaveAs
			// 
			this.toolStripButtonSaveAs.Enabled = false;
			this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
			this.toolStripButtonSaveAs.Size = new System.Drawing.Size(167, 22);
			this.toolStripButtonSaveAs.Text = "Save Model As...";
			this.toolStripButtonSaveAs.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonReset,
            this.toolStripSeparator4,
            this.toolStripButtonClose});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(916, 25);
			this.toolStrip.TabIndex = 3;
			this.toolStrip.Text = "toolStrip";
			// 
			// toolStripButtonLoad
			// 
			this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
			this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonLoad.Name = "toolStripButtonLoad";
			this.toolStripButtonLoad.Size = new System.Drawing.Size(81, 22);
			this.toolStripButtonLoad.Text = "Load Model";
			this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
			// 
			// toolStripButtonSave
			// 
			this.toolStripButtonSave.Enabled = false;
			this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
			this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSave.Name = "toolStripButtonSave";
			this.toolStripButtonSave.Size = new System.Drawing.Size(82, 22);
			this.toolStripButtonSave.Text = "Save Model";
			this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonReset
			// 
			this.toolStripButtonReset.Enabled = false;
			this.toolStripButtonReset.ForeColor = System.Drawing.SystemColors.ControlText;
			this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
			this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonReset.Name = "toolStripButtonReset";
			this.toolStripButtonReset.Size = new System.Drawing.Size(86, 22);
			this.toolStripButtonReset.Text = "Reset Model";
			this.toolStripButtonReset.Click += new System.EventHandler(this.toolStripButtonReset_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonClose
			// 
			this.toolStripButtonClose.Enabled = false;
			this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
			this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClose.Name = "toolStripButtonClose";
			this.toolStripButtonClose.Size = new System.Drawing.Size(84, 22);
			this.toolStripButtonClose.Text = "Close Model";
			this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripClose_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.variabilityFMCheckBox);
			this.panel2.Controls.Add(this.featureModelGroupBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 49);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(916, 561);
			this.panel2.TabIndex = 7;
			// 
			// variabilityFMCheckBox
			// 
			this.variabilityFMCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.variabilityFMCheckBox.AutoSize = true;
			this.variabilityFMCheckBox.Enabled = false;
			this.variabilityFMCheckBox.Location = new System.Drawing.Point(6, 534);
			this.variabilityFMCheckBox.Name = "variabilityFMCheckBox";
			this.variabilityFMCheckBox.Size = new System.Drawing.Size(166, 17);
			this.variabilityFMCheckBox.TabIndex = 1;
			this.variabilityFMCheckBox.Text = "Show only Variability Features";
			this.variabilityFMCheckBox.UseVisualStyleBackColor = true;
			this.variabilityFMCheckBox.CheckedChanged += new System.EventHandler(this.variabilityFMCheckBox_CheckedChanged);
			// 
			// featureModelGroupBox
			// 
			this.featureModelGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.featureModelGroupBox.Location = new System.Drawing.Point(6, 3);
			this.featureModelGroupBox.Name = "featureModelGroupBox";
			this.featureModelGroupBox.Size = new System.Drawing.Size(900, 527);
			this.featureModelGroupBox.TabIndex = 0;
			this.featureModelGroupBox.TabStop = false;
			this.featureModelGroupBox.Text = "Feature Model";
			// 
			// WindowsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(916, 632);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "WindowsForm";
			this.Text = "FeatureModel Configurator 0.5";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadModelFromXmlFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveModelToXmlFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox featureModelGroupBox;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox variabilityFMCheckBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
		private System.Windows.Forms.ToolStripMenuItem toolStripButtonSaveAs;
	}
}

