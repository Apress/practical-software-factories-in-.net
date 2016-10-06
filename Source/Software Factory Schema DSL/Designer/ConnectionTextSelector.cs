using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISpySoft.SFSchemaLanguage.Designer
{
    public partial class ConnectionTextSelector : Form
    {
        public enum SelectionState{
            none = 0,
            reads = 1,
            writes = 2
        }
        private SelectionState selected = SelectionState.none;

        
        public ConnectionTextSelector()
        {
            InitializeComponent();
        }

        public SelectionState Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (readsRadioButton.Checked)
            {
                selected = SelectionState.reads;
            }
            else if (writesRadioButton.Checked)
            {
                selected = SelectionState.writes;
            }
            else
                selected = SelectionState.none;

            this.Close();
        }

        private void readsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.OKbutton.Enabled = true;
        }

        private void writesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.OKbutton.Enabled = true;
        }

        
    }
}