#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ISpySoft.FeatureModelLanguage.DomainModel;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Utilities;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Windows.Forms;
#endregion

namespace ISpySoft.FeatureModelLanguage.Designer
{
    public partial class RootFeatureShape
    {
        public override void OnFieldDoubleClick(ShapeField field, DiagramPointEventArgs e)
        {
            string property_Name = this.ModelElement.GetProperties()["Name"].GetValue(this.ModelElement.GetProperties()["Name"]).ToString();
            string property_Condition = this.ModelElement.GetProperties()["Condition"].GetValue(this.ModelElement.GetProperties()["Condition"]).ToString();
            string property_Constraint = this.ModelElement.GetProperties()["Constraint"].GetValue(this.ModelElement.GetProperties()["Constraint"]).ToString();
            string property_Requirements = this.ModelElement.GetProperties()["Requirements"].GetValue(this.ModelElement.GetProperties()["Requirements"]).ToString();

            RootFeatureProperties rootFeatureProperties = new RootFeatureProperties();


            rootFeatureProperties.NameTextBox.Text = property_Name;
            rootFeatureProperties.ConditionTextBox.Text = property_Condition;
            rootFeatureProperties.ConstraintTextBox.Text = property_Constraint;
            rootFeatureProperties.RequirementsTextBox.Text = property_Requirements;


            if (rootFeatureProperties.DialogResult == DialogResult.OK)
            {

                this.ModelElement.GetProperties()["Name"].SetValue(this.ModelElement.GetProperties()["Name"], rootFeatureProperties.NameTextBox.Text);
                this.ModelElement.GetProperties()["Condition"].SetValue(this.ModelElement.GetProperties()["Condition"], rootFeatureProperties.ConditionTextBox.Text);
                this.ModelElement.GetProperties()["Constraint"].SetValue(this.ModelElement.GetProperties()["Constraint"], rootFeatureProperties.ConstraintTextBox.Text);
                this.ModelElement.GetProperties()["Requirements"].SetValue(this.ModelElement.GetProperties()["Requirements"], rootFeatureProperties.RequirementsTextBox.Text);
            }

        }
    }
}