namespace ISpySoft.FeatureModelLanguage.DomainModel
{
    partial class FeatureProperties
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
			this.kindComboBox = new System.Windows.Forms.ComboBox();
			this.MyCancelButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.requirementsTextBox = new System.Windows.Forms.TextBox();
			this.requirementsLabel = new System.Windows.Forms.Label();
			this.constraintTextBox = new System.Windows.Forms.TextBox();
			this.constraintLabel = new System.Windows.Forms.Label();
			this.conditionTextBox = new System.Windows.Forms.TextBox();
			this.conditionLabel = new System.Windows.Forms.Label();
			this.kindLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// kindComboBox
			// 
			this.kindComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kindComboBox.FormattingEnabled = true;
			this.kindComboBox.Items.AddRange(new object[] {
            "Mandatory",
            "Optional",
            "FeatureSetFeature"});
			this.kindComboBox.Location = new System.Drawing.Point(84, 38);
			this.kindComboBox.Name = "kindComboBox";
			this.kindComboBox.Size = new System.Drawing.Size(325, 21);
			this.kindComboBox.TabIndex = 3;
			// 
			// MyCancelButton
			// 
			this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.MyCancelButton.Location = new System.Drawing.Point(334, 380);
			this.MyCancelButton.Name = "MyCancelButton";
			this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
			this.MyCancelButton.TabIndex = 11;
			this.MyCancelButton.Text = "Cancel";
			this.MyCancelButton.UseVisualStyleBackColor = true;
			this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKButton.Location = new System.Drawing.Point(253, 380);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 10;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// requirementsTextBox
			// 
			this.requirementsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.requirementsTextBox.Location = new System.Drawing.Point(12, 136);
			this.requirementsTextBox.Multiline = true;
			this.requirementsTextBox.Name = "requirementsTextBox";
			this.requirementsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.requirementsTextBox.Size = new System.Drawing.Size(397, 238);
			this.requirementsTextBox.TabIndex = 9;
			// 
			// requirementsLabel
			// 
			this.requirementsLabel.AutoSize = true;
			this.requirementsLabel.Location = new System.Drawing.Point(12, 120);
			this.requirementsLabel.Name = "requirementsLabel";
			this.requirementsLabel.Size = new System.Drawing.Size(75, 13);
			this.requirementsLabel.TabIndex = 8;
			this.requirementsLabel.Text = "Requirements:";
			// 
			// constraintTextBox
			// 
			this.constraintTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.constraintTextBox.Location = new System.Drawing.Point(84, 91);
			this.constraintTextBox.Name = "constraintTextBox";
			this.constraintTextBox.Size = new System.Drawing.Size(325, 20);
			this.constraintTextBox.TabIndex = 7;
			// 
			// constraintLabel
			// 
			this.constraintLabel.AutoSize = true;
			this.constraintLabel.Location = new System.Drawing.Point(12, 94);
			this.constraintLabel.Name = "constraintLabel";
			this.constraintLabel.Size = new System.Drawing.Size(57, 13);
			this.constraintLabel.TabIndex = 6;
			this.constraintLabel.Text = "Constraint:";
			// 
			// conditionTextBox
			// 
			this.conditionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.conditionTextBox.Location = new System.Drawing.Point(84, 65);
			this.conditionTextBox.Name = "conditionTextBox";
			this.conditionTextBox.Size = new System.Drawing.Size(325, 20);
			this.conditionTextBox.TabIndex = 5;
			// 
			// conditionLabel
			// 
			this.conditionLabel.AutoSize = true;
			this.conditionLabel.Location = new System.Drawing.Point(12, 68);
			this.conditionLabel.Name = "conditionLabel";
			this.conditionLabel.Size = new System.Drawing.Size(54, 13);
			this.conditionLabel.TabIndex = 4;
			this.conditionLabel.Text = "Condition:";
			// 
			// kindLabel
			// 
			this.kindLabel.AutoSize = true;
			this.kindLabel.Location = new System.Drawing.Point(12, 41);
			this.kindLabel.Name = "kindLabel";
			this.kindLabel.Size = new System.Drawing.Size(31, 13);
			this.kindLabel.TabIndex = 2;
			this.kindLabel.Text = "Kind:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Location = new System.Drawing.Point(84, 12);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(325, 20);
			this.nameTextBox.TabIndex = 1;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(12, 15);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name:";
			// 
			// FeatureProperties
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.MyCancelButton;
			this.ClientSize = new System.Drawing.Size(421, 415);
			this.Controls.Add(this.kindComboBox);
			this.Controls.Add(this.MyCancelButton);
			this.Controls.Add(this.requirementsTextBox);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.requirementsLabel);
			this.Controls.Add(this.kindLabel);
			this.Controls.Add(this.constraintTextBox);
			this.Controls.Add(this.conditionLabel);
			this.Controls.Add(this.constraintLabel);
			this.Controls.Add(this.conditionTextBox);
			this.Name = "FeatureProperties";
			this.Text = "Feature Properties";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox constraintTextBox;
        private System.Windows.Forms.Label constraintLabel;
        private System.Windows.Forms.TextBox conditionTextBox;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Label kindLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox requirementsTextBox;
        private System.Windows.Forms.Label requirementsLabel;
        private System.Windows.Forms.ComboBox kindComboBox;

        
        public System.Windows.Forms.TextBox ConstraintTextBox
        {
            get
            {
                return constraintTextBox;
            }
            set
            {
                constraintTextBox = value;
            }

        }

        public System.Windows.Forms.TextBox ConditionTextBox
        {
            get
            {
                return conditionTextBox;
            }
            set
            {
                conditionTextBox = value;
            }

        }

        public System.Windows.Forms.TextBox NameTextBox
        {
            get
            {
                return nameTextBox;
            }
            set
            {
                nameTextBox = value;
            }

        }

        public System.Windows.Forms.TextBox RequirementsTextBox
        {
            get
            {
                return requirementsTextBox;
            }
            set
            {
                requirementsTextBox = value;
            }

        }

        public System.Windows.Forms.ComboBox KindComboBox
        {
            get
            {
                return kindComboBox;
            }
            set
            {
                kindComboBox = value;
            }

        }

    }
}