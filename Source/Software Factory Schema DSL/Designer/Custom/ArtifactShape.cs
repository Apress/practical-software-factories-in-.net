#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ISpySoft.SFSchemaLanguage.DomainModel;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Utilities;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Windows.Forms;
#endregion

namespace ISpySoft.SFSchemaLanguage.Designer
{
    public partial class ArtifactShape
    {
        public override void OnFieldDoubleClick(ShapeField field, DiagramPointEventArgs e)
        {
            string property_Name = this.ModelElement.GetProperties()["Name"].GetValue(this.ModelElement.GetProperties()["Name"]).ToString();
			string property_Description = this.ModelElement.GetProperties()["Description"].GetValue(this.ModelElement.GetProperties()["Description"]).ToString();
			ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType property_Type = (ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType)this.ModelElement.GetProperties()["Type"].GetValue(this.ModelElement.GetProperties()["Type"]);

            ArtifactProperties artifactProperties = new ArtifactProperties();

            artifactProperties.NameTextBox = property_Name;
			artifactProperties.DescriptionTextBox = property_Description;
			artifactProperties.TypeComboBox = property_Type.ToString();

			if (artifactProperties.ShowDialog() == DialogResult.OK)
            {
                this.ModelElement.GetProperties()["Name"].SetValue(this.ModelElement.GetProperties()["Name"], artifactProperties.NameTextBox);
				this.ModelElement.GetProperties()["Description"].SetValue(this.ModelElement.GetProperties()["Description"], artifactProperties.DescriptionTextBox);
				switch (artifactProperties.TypeComboBox)
                {
                    case "Asset":
                        this.ModelElement.GetProperties()["Type"].SetValue(this.ModelElement.GetProperties()["Type"], ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType.Asset);
                        break;
                    case "Tool":
                        this.ModelElement.GetProperties()["Type"].SetValue(this.ModelElement.GetProperties()["Type"], ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType.Tool);
                        break;
                    case "WorkProduct":
                        this.ModelElement.GetProperties()["Type"].SetValue(this.ModelElement.GetProperties()["Type"], ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType.WorkProduct);
                        break;

                }
            }
        }

    }

}