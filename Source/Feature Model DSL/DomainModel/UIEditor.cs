using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Security.Permissions;
using Microsoft.VisualStudio.Modeling;
using ISpySoft.FeatureModelLanguage.DomainModel;

namespace ISpySoft.FeatureModelLanguage.DomainModel
{

    // FxCop rule: must have same security demands as parent class
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"), PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class FeaturePropertiesUITypeEditor : System.Drawing.Design.UITypeEditor
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
            string property_Name = element.GetProperties()["Name"].GetValue(element.GetProperties()["Name"]).ToString();
            FeatureKind property_Kind = (FeatureKind)element.GetProperties()["Kind"].GetValue(element.GetProperties()["Kind"]);
            string property_Condition = element.GetProperties()["Condition"].GetValue(element.GetProperties()["Condition"]).ToString();
            string property_Constraint = element.GetProperties()["Constraint"].GetValue(element.GetProperties()["Constraint"]).ToString();
            string property_Requirements = element.GetProperties()["Requirements"].GetValue(element.GetProperties()["Requirements"]).ToString();

            FeatureProperties featureProperties = new FeatureProperties();
            featureProperties.NameTextBox.Text = property_Name;
            featureProperties.ConditionTextBox.Text = property_Condition;
            featureProperties.ConstraintTextBox.Text = property_Constraint;
            featureProperties.RequirementsTextBox.Text = property_Requirements;
            featureProperties.KindComboBox.Text = property_Kind.ToString();

			if (featureProperties.ShowDialog() == DialogResult.OK)
            {

                element.GetProperties()["Name"].SetValue(element.GetProperties()["Name"], featureProperties.NameTextBox.Text);
                switch (featureProperties.KindComboBox.Text)
                {
                    case "Mandatory":
                        element.GetProperties()["Kind"].SetValue(element.GetProperties()["Kind"], FeatureKind.Mandatory);
                        break;
                    case "Optional":
                        element.GetProperties()["Kind"].SetValue(element.GetProperties()["Kind"], FeatureKind.Optional);
                        break;
                    case "FeatureSetFeature":
                        element.GetProperties()["Kind"].SetValue(element.GetProperties()["Kind"], FeatureKind.FeatureSetFeature);
                        break;
                     
                }
                element.GetProperties()["Condition"].SetValue(element.GetProperties()["Condition"], featureProperties.ConditionTextBox.Text);
                element.GetProperties()["Constraint"].SetValue(element.GetProperties()["Constraint"], featureProperties.ConstraintTextBox.Text);
                element.GetProperties()["Requirements"].SetValue(element.GetProperties()["Requirements"], featureProperties.RequirementsTextBox.Text);
            }

            return value;
        }

    }



    // FxCop rule: must have same security demands as parent class
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"), PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class RootFeaturePropertiesUITypeEditor : System.Drawing.Design.UITypeEditor
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
            string property_Name = element.GetProperties()["Name"].GetValue(element.GetProperties()["Name"]).ToString();
            string property_Condition = element.GetProperties()["Condition"].GetValue(element.GetProperties()["Condition"]).ToString();
            string property_Constraint = element.GetProperties()["Constraint"].GetValue(element.GetProperties()["Constraint"]).ToString();
            string property_Requirements = element.GetProperties()["Requirements"].GetValue(element.GetProperties()["Requirements"]).ToString();

            RootFeatureProperties rootFeatureProperties = new RootFeatureProperties();
            rootFeatureProperties.NameTextBox.Text = property_Name;
            rootFeatureProperties.ConditionTextBox.Text = property_Condition;
            rootFeatureProperties.ConstraintTextBox.Text = property_Constraint;
            rootFeatureProperties.RequirementsTextBox.Text = property_Requirements;

			if (rootFeatureProperties.ShowDialog() == DialogResult.OK)
            {
                element.GetProperties()["Name"].SetValue(element.GetProperties()["Name"], rootFeatureProperties.NameTextBox.Text);
                element.GetProperties()["Condition"].SetValue(element.GetProperties()["Condition"], rootFeatureProperties.ConditionTextBox.Text);
                element.GetProperties()["Constraint"].SetValue(element.GetProperties()["Constraint"], rootFeatureProperties.ConstraintTextBox.Text);
                element.GetProperties()["Requirements"].SetValue(element.GetProperties()["Requirements"], rootFeatureProperties.RequirementsTextBox.Text);
            }

            return value;
        }

    }




}