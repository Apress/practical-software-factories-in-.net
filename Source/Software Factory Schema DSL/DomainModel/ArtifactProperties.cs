using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISpySoft.SFSchemaLanguage.DomainModel
{
    public partial class ArtifactProperties : Form
    {
        public ArtifactProperties()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
            this.Close();
        }

		public string NameTextBox
		{
			get { return nameTextBox.Text; }
			set { nameTextBox.Text = value; }
		}

		public string DescriptionTextBox
		{
			get { return descriptionTextBox.Text; }
			set { descriptionTextBox.Text = value; }
		}

		public string TypeComboBox
		{
			get { return typeComboBox.Text; }
			set { typeComboBox.Text = value; }
		}
    }
}