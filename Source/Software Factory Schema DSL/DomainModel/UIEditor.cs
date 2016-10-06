using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Security.Permissions;
using Microsoft.VisualStudio.Modeling;

namespace ISpySoft.SFSchemaLanguage.DomainModel
{

    // FxCop rule: must have same security demands as parent class
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"), PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class MappingPropertiesUITypeEditor : System.Drawing.Design.UITypeEditor
    {

        /// <summary>
        /// Overridden to specify that our editor is a modal form
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }


        /// <summary>
        /// Called by VS whenever the user clicks on the ellipsis in the
        /// properties window for a property to which this editor is linked.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(
            System.ComponentModel.ITypeDescriptorContext context,
            IServiceProvider provider,
            object value)
        {
            // Get a reference to the underlying property element
            ElementPropertyDescriptor descriptor = context.PropertyDescriptor as ElementPropertyDescriptor;
            ModelElement underlyingModelElent = descriptor.ModelElement;

            // context.Instance also returns a model element, but this will either
            // be the shape representing the underlying element (if you selected
            // the element via the design surface), or the underlying element
            // itself (if you selected the element via the model explorer)
            ModelElement element = context.Instance as ModelElement;

            //TODO: create and show your form here. If the user has changed
            // the property value via the form, then update the "value"
            // variable.
            
            string property_Name = element.GetProperties()["Name"].GetValue(element.GetProperties()["Name"]).ToString();
            string property_Description = element.GetProperties()["Description"].GetValue(element.GetProperties()["Description"]).ToString();

            MappingProperties mappingProperties = new MappingProperties();
            mappingProperties.NameTextBox = property_Name;
            mappingProperties.DescriptionTextBox = property_Description;

			if (mappingProperties.ShowDialog() == DialogResult.OK)
            {

                element.GetProperties()["Name"].SetValue(element.GetProperties()["Name"], mappingProperties.NameTextBox);
                element.GetProperties()["Description"].SetValue(element.GetProperties()["Description"], mappingProperties.DescriptionTextBox);
            }

            return value;
        }
    }
}










