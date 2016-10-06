using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;

namespace FeatureModelConfigurator
{
	public partial class WindowsForm : Form
	{
		private TriStateTreeView triStateTreeView;
		private FeatureModel featureModel;
		
		public WindowsForm()
		{
			InitializeComponent();
			
			// TriStateTreeView
			triStateTreeView = new TriStateTreeView();
			this.triStateTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.triStateTreeView.Location = new System.Drawing.Point(5, 19);
			this.triStateTreeView.Name = "triStateTreeView";
			this.triStateTreeView.Size = new System.Drawing.Size(890, 390);
			this.triStateTreeView.TabIndex = 0;
			this.triStateTreeView.Visible = false;

			// Add TriStateTreeView to GroupBox
			this.featureModelGroupBox.Controls.Add(triStateTreeView);

			
		}

		private void loadModelFromXmlFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.toolStripStatusLabel.Text = "Ready";
			
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Feature Configuration Files (*.featureconfig)|*.featureconfig|All Files (*.*)|*.*";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckFileExists = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				//this.statusTextBox.Text = "";

                FeatureModelConfigurator.Properties.Settings settings = new FeatureModelConfigurator.Properties.Settings();
                string path = Application.StartupPath;

                FeatureModel oldFeatureModel = featureModel;
				featureModel = new FeatureModel(openFileDialog.FileName);

                try
                {
                    featureModel.ValidateXmlFile(string.Concat(path, "\\", settings.xmlschemapath));

                    if (featureModel.Validity)
                    {
                        this.triStateTreeView.InitializeFeatureModel(ref featureModel);
                        //this.triStateTreeView.InitializeStatusTextBox(ref this.statusTextBox);

                        // Set Text of Gpoupbox with model filename
                        this.featureModelGroupBox.Text = openFileDialog.FileName;

                        featureModel.CreateTreeViewFromXmlFile(this.triStateTreeView);
                        this.triStateTreeView.Visible = true;

                        //
                        this.toolStripStatusLabel.Text = string.Format("Model from '{0}' successfully loaded", openFileDialog.FileName);

                        //
                        this.saveModelToXmlFileToolStripMenuItem.Enabled = true;

                        
                        this.toolStripButtonReset.Enabled = true;
                        this.toolStripButtonSave.Enabled = true;
						this.toolStripButtonSaveAs.Enabled = true;
						this.toolStripButtonClose.Enabled = true;
                        this.variabilityFMCheckBox.Enabled = true;

                        //
                        ArrayList errorArray = featureModel.CheckConfiguredModel();
                        string[] array = (string[])errorArray.ToArray(typeof(string));
                        //this.statusTextBox.Lines = array;
                    }

                    else
                    {
                        //this.statusTextBox.Text = string.Format("XML-File '{0}' is not valid!", featureModel.FileName);
                        this.toolStripStatusLabel.Text = "Loading failed";
                        featureModel = oldFeatureModel;
                    }
                }
                catch (Exception exception)
                {
                    System.Windows.Forms.MessageBox.Show(exception.Message, "Feature Model Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}


		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ArrayList errorArray = featureModel.CheckConfiguredModel();
			string[] array = (string[])errorArray.ToArray(typeof(string));
			//this.statusTextBox.Lines = array;

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Feature Configuration Files (*.featureconfig)|*.featureconfig|All Files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.OverwritePrompt = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				featureModel.SaveModel(saveFileDialog.FileName);
			}
		}


		private void saveModelToXmlFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ArrayList errorArray = featureModel.CheckConfiguredModel();
			string[] array = (string[])errorArray.ToArray(typeof(string));
			//this.statusTextBox.Lines = array;

			featureModel.SaveModel();
		}

		
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void toolStripButtonReset_Click(object sender, EventArgs e)
        {
            triStateTreeView.Nodes.Clear();
            triStateTreeView.Visible = false;
            
            this.saveModelToXmlFileToolStripMenuItem.Enabled = false;
            //this.statusTextBox.Text = "";

            FeatureModelConfigurator.Properties.Settings settings = new FeatureModelConfigurator.Properties.Settings();
            string path = Application.StartupPath;

            try
            {
                featureModel.ValidateXmlFile(string.Concat(path, "\\", settings.xmlschemapath));

                if (featureModel.Validity)
                {
                    featureModel.CreateTreeViewFromXmlFile(this.triStateTreeView);
                    this.triStateTreeView.Visible = true;

                    //
                    this.toolStripStatusLabel.Text = "Model reset";

                    //
                    this.saveModelToXmlFileToolStripMenuItem.Enabled = true;

                    
                }

                else
                {
                    this.toolStripStatusLabel.Text = "Model reset failed";
                }
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show(exception.Message, "Feature Reset Model Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            ArrayList errorArray = featureModel.CheckConfiguredModel();
            string[] array = (string[])errorArray.ToArray(typeof(string));
            //this.statusTextBox.Lines = array;

            featureModel.SaveModel();
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            triStateTreeView.Nodes.Clear();
            triStateTreeView.Visible = false;
            
            this.saveModelToXmlFileToolStripMenuItem.Enabled = false;
            this.toolStripStatusLabel.Text = "Ready";
            this.featureModelGroupBox.Text = "Feature Model";
            //this.statusTextBox.Text = "";

            this.toolStripButtonClose.Enabled = false;
            this.toolStripButtonReset.Enabled = false;
            this.toolStripButtonSave.Enabled = false;
			this.toolStripButtonSaveAs.Enabled = false;
            this.variabilityFMCheckBox.CheckState = CheckState.Unchecked;
            this.variabilityFMCheckBox.Enabled = false;
            
        }

        private void variabilityFMCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (variabilityFMCheckBox.CheckState == CheckState.Checked)
            {
                featureModel.ShowOnlyVariabilityFeatures(this.triStateTreeView, featureModel);
            }
            else
            {
                featureModel.ShowAllFeatures(this.triStateTreeView, featureModel);
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
			loadModelFromXmlFileToolStripMenuItem_Click(sender, e);
        }
	}
}