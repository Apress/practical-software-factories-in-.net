using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISpySoft.FeatureModelLanguage.DomainModel
{
    public partial class RootFeatureProperties : Form
    {
        public RootFeatureProperties()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
			Close();
		}

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
			Close();
		}
    }
}