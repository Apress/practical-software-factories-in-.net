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
    public partial class FeatureShape
    {
        public override void OnFieldDoubleClick(ShapeField field, DiagramPointEventArgs e)
        {
            string property_Name = this.ModelElement.GetProperties()["Name"].GetValue(this.ModelElement.GetProperties()["Name"]).ToString();
            FeatureKind property_Kind = (FeatureKind)this.ModelElement.GetProperties()["Kind"].GetValue(this.ModelElement.GetProperties()["Kind"]);
            string property_Condition = this.ModelElement.GetProperties()["Condition"].GetValue(this.ModelElement.GetProperties()["Condition"]).ToString();
            string property_Constraint = this.ModelElement.GetProperties()["Constraint"].GetValue(this.ModelElement.GetProperties()["Constraint"]).ToString();
            string property_Requirements = this.ModelElement.GetProperties()["Requirements"].GetValue(this.ModelElement.GetProperties()["Requirements"]).ToString();

            FeatureProperties featureProperties = new FeatureProperties();


            featureProperties.NameTextBox.Text = property_Name;
            featureProperties.ConditionTextBox.Text = property_Condition;
            featureProperties.ConstraintTextBox.Text = property_Constraint;
            featureProperties.RequirementsTextBox.Text = property_Requirements;
            featureProperties.KindComboBox.Text = property_Kind.ToString();

			if (featureProperties.ShowDialog() == DialogResult.OK)
            {

                this.ModelElement.GetProperties()["Name"].SetValue(this.ModelElement.GetProperties()["Name"], featureProperties.NameTextBox.Text);
                switch (featureProperties.KindComboBox.Text)
                {
                    case "Mandatory":
                        this.ModelElement.GetProperties()["Kind"].SetValue(this.ModelElement.GetProperties()["Kind"], FeatureKind.Mandatory);
                        break;
                    case "Optional":
                        this.ModelElement.GetProperties()["Kind"].SetValue(this.ModelElement.GetProperties()["Kind"], FeatureKind.Optional);
                        break;
                    case "FeatureSetFeature":
                        this.ModelElement.GetProperties()["Kind"].SetValue(this.ModelElement.GetProperties()["Kind"], FeatureKind.FeatureSetFeature);
                        break;

                }
                this.ModelElement.GetProperties()["Condition"].SetValue(this.ModelElement.GetProperties()["Condition"], featureProperties.ConditionTextBox.Text);
                this.ModelElement.GetProperties()["Constraint"].SetValue(this.ModelElement.GetProperties()["Constraint"], featureProperties.ConstraintTextBox.Text);
                this.ModelElement.GetProperties()["Requirements"].SetValue(this.ModelElement.GetProperties()["Requirements"], featureProperties.RequirementsTextBox.Text);
            }
            
        }
    }
}