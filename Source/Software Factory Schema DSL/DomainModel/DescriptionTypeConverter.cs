using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace ISpySoft.SFSchemaLanguage.DomainModel
{
    class ConnnectionDescriptionTypeConverter : StringConverter
    {
        private bool selected = false;
        SchemaModelItemHasSchemaModelItem connection;
        
        
        /// <summary>
        /// Indicates that we support drop-down editing for this property.
        /// </summary>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            // BUG: the value of context.Instance should always be the entity itself, since the
            // domain property is defined on the Entity class. However, currently it is shape, if
            // you select it on the design surface. Code below works around this.
            
            
            PresentationElement pe = context.Instance as PresentationElement;
            if (pe != null)
            {
                //entity = pe.ModelElement as Entity;
                connection = pe.ModelElement as SchemaModelItemHasSchemaModelItem;
                if (connection != null)
                {
                    selected = true;
                    return true;
                }
                else
                    selected = false;
                    return false;
            }
            else
            {
                connection = context.Instance as SchemaModelItemHasSchemaModelItem;
                if (connection != null)
                {
                    selected = true;
                    return true;
                }
                else
                    selected = false;
                return false;
            }

            //return connection != null ? true : false;
        }


        /// <summary>
        /// Return the actual collection of values we support
        /// </summary>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (selected == true)
            {
                SchemaModelItem targetitem = connection.SchemaModelItemTarget;
                SchemaModelItem sourceitem = connection.SchemaModelItemSource;

                if (targetitem.GetType() == typeof(Activity))
                {
                    return new StandardValuesCollection(new string[] { "filters" });
                }

                else if (targetitem.GetType() == typeof(Artifact) && sourceitem.GetType() == typeof(Activity))
                {
                    switch (((ArtifactType)((Artifact)targetitem).GetProperties()["Type"].GetValue(((Artifact)targetitem).GetProperties()["Type"])))
                    {
                        case ArtifactType.Asset:
                            return new StandardValuesCollection(new string[] { "uses" });
                            
                        case ArtifactType.Tool:
                            return new StandardValuesCollection(new string[] { "uses" });
                            
                        case ArtifactType.WorkProduct:
                            return new StandardValuesCollection(new string[] { "reads", "writes" });
                            
                    }
                    
                }

                else if (targetitem.GetType() == typeof(Artifact) && sourceitem.GetType() == typeof(ViewPoint))
                {
                    return new StandardValuesCollection(new string[] { "filters" });
                }


                else if (targetitem.GetType() == typeof(ViewPoint))
                {
                    return new StandardValuesCollection(new string[] { "reads", "writes" });
                }
                else
                {
                    return null;
                }
            }
            return null;

          }
    }
}