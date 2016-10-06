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
    public partial class MappingShape
    {
        public override void OnFieldDoubleClick(ShapeField field, DiagramPointEventArgs e)
        {
            string property_Name = this.ModelElement.GetProperties()["Name"].GetValue(this.ModelElement.GetProperties()["Name"]).ToString();
            string property_Description = this.ModelElement.GetProperties()["Description"].GetValue(this.ModelElement.GetProperties()["Description"]).ToString();
            
            MappingProperties mappingProperties = new MappingProperties();
            mappingProperties.NameTextBox = property_Name;
            mappingProperties.DescriptionTextBox = property_Description;

			if (mappingProperties.ShowDialog() == DialogResult.OK)
            {
                this.ModelElement.GetProperties()["Name"].SetValue(this.ModelElement.GetProperties()["Name"], mappingProperties.NameTextBox);
                this.ModelElement.GetProperties()["Description"].SetValue(this.ModelElement.GetProperties()["Description"], mappingProperties.DescriptionTextBox);              
            }
        }
    }
}