namespace ISpySoft.SFSchemaLanguage.Designer
{
    partial class ConnectionTextSelector
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.writesRadioButton = new System.Windows.Forms.RadioButton();
            this.readsRadioButton = new System.Windows.Forms.RadioButton();
            this.OKbutton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.writesRadioButton);
            this.groupBox.Controls.Add(this.readsRadioButton);
            this.groupBox.Controls.Add(this.OKbutton);
            this.groupBox.Location = new System.Drawing.Point(13, 13);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(267, 126);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Please select one";
            // 
            // writesRadioButton
            // 
            this.writesRadioButton.AutoSize = true;
            this.writesRadioButton.Location = new System.Drawing.Point(103, 51);
            this.writesRadioButton.Name = "writesRadioButton";
            this.writesRadioButton.Size = new System.Drawing.Size(52, 17);
            this.writesRadioButton.TabIndex = 2;
            this.writesRadioButton.Text = "writes";
            this.writesRadioButton.UseVisualStyleBackColor = true;
            this.writesRadioButton.CheckedChanged += new System.EventHandler(this.writesRadioButton_CheckedChanged);
            // 
            // readsRadioButton
            // 
            this.readsRadioButton.AutoSize = true;
            this.readsRadioButton.Location = new System.Drawing.Point(103, 28);
            this.readsRadioButton.Name = "readsRadioButton";
            this.readsRadioButton.Size = new System.Drawing.Size(51, 17);
            this.readsRadioButton.TabIndex = 1;
            this.readsRadioButton.TabStop = true;
            this.readsRadioButton.Text = "reads";
            this.readsRadioButton.UseVisualStyleBackColor = true;
            this.readsRadioButton.CheckedChanged += new System.EventHandler(this.readsRadioButton_CheckedChanged);
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OKbutton.Enabled = false;
            this.OKbutton.Location = new System.Drawing.Point(93, 82);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // ConnectionTextSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 151);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectionTextSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionTextSelector";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.RadioButton writesRadioButton;
        private System.Windows.Forms.RadioButton readsRadioButton;
    }
}