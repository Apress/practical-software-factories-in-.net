using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling.Validation;
using System.Collections;


namespace ISpySoft.SFSchemaLanguage.DomainModel
{
    [ValidationState(ValidationState.Enabled)]

    public partial class Mapping
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]


        private void ValidateMappingConnectors(ValidationContext context)
        {
                                
                Hashtable hashtable = new Hashtable();

                foreach (object o in this.GetElementLinks())
                {
                    if (o.GetType() == typeof(SchemaModelItemHasSchemaModelItem))
                    {
                        if (!hashtable.Contains((ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget))
                        {
                            hashtable.Add((ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget, ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)));
                        }
                        else
                        {
                            if (hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget].ToString() == "reads" && ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "writes")
                                hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget] = "readswrites";
                            if (hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget].ToString() == "writes" && ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "writes")
                                hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget] = "twicewrites";
                            if (hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget].ToString() == "writes" && ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "reads")
                                hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget] = "readswrites";
                            if (hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget].ToString() == "reads" && ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "reads")
                                hashtable[(ViewPoint)((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget] = "twicereads";
                        }
                    }
                }

                
                if (hashtable.Count <= 1)
                {
                    context.LogError("Mapping Error: Needs at least 1 Input & 1 Output", "MappingError", this);
                }

                if (hashtable.Count == 2)
                {
                    foreach (DictionaryEntry d in hashtable)
                    {
                        if (d.Value.ToString() == "twicewrites" || d.Value.ToString() == "twicereads")
                        {
                            context.LogError("Mapping Error: Values of property 'Description' of two connections to the same ViewPoint mustn't be the same", "MappingError", this);
                        }
                    }
                    
                }

            

        }

    }



    [ValidationState(ValidationState.Enabled)]

    public partial class Artifact
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]


        private void ValidateTextDecorationOfConnector(ValidationContext context)
        {

            if ((ArtifactType)this.GetProperties()["Type"].GetValue(this.GetProperties()["Type"]) == ArtifactType.Asset)
            {
                bool flag = false;

                foreach (object o in this.GetElementLinks())
                {
                    if (o.GetType() == typeof(SchemaModelItemHasSchemaModelItem))
                    {
                        if (((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "uses")
                            flag = true;
                    }
                }

                if (flag == false)
                {
                    context.LogError("Asset Error: Needs at least 1 Input with 'uses'", "AssetError", this);
                }

            }




            if ((ArtifactType)this.GetProperties()["Type"].GetValue(this.GetProperties()["Type"]) == ArtifactType.Tool)
            {
                bool flag = false;

                foreach (object o in this.GetElementLinks())
                {
                    if (o.GetType() == typeof(SchemaModelItemHasSchemaModelItem))
                    {
                        if (((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "uses")
                            flag = true;
                    }
                }

                
                if (flag == false)
                {
                    context.LogError("Tool Error: Needs at least 1 Input with 'uses'", "ToolError", this);
                }

            }



            if ((ArtifactType)this.GetProperties()["Type"].GetValue(this.GetProperties()["Type"]) == ArtifactType.WorkProduct)
            {
                bool flag = false;

                if (this.GetElementLinks().Count != 0)
                {

                    foreach (object o in this.GetElementLinks())
                    {
                        if (o.GetType() == typeof(SchemaModelItemHasSchemaModelItem))
                        {
                            if (((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o)).ToString() == "writes")
                                flag = true;
                        }
                    }

                    if (flag == false)
                    {
                        context.LogError("WorkProduct Error: Needs at least 1 Input with 'writes'", "WorkProductError", this);
                    }
                }
                else
                    context.LogError("WorkProduct Error: Needs at least 1 Input", "WorkProductError", this);

            }

        }


    }


   


    [ValidationState(ValidationState.Enabled)]

    public partial class Activity
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]


        private void ValidateActivity(ValidationContext context)
        {
            bool hasworkproduct = false;

            if (this.GetElementLinks().Count != 0)
            {

                foreach (object o in this.GetElementLinks())
                {
                    if (o.GetType() == typeof(SchemaModelItemHasSchemaModelItem))
                    {
                        string description = ((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].GetValue(((SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"]).ToString();

                        if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget) as Artifact != null)
                        {
                            string type = ((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget.GetProperties()["Type"].GetValue(((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget.GetProperties()["Type"]).ToString();

                            if (description == "writes" && type == "WorkProduct")
                            {
                                hasworkproduct = true;
                            }
                        }
                    }
                }

                if (hasworkproduct == false)
                {
                    context.LogError("Activity Error: Activity needs at least one WorkProduct as output", "ActivityError", this);
                }
            }
            else
            {
                context.LogError("Activity Error: Activity is not used within diagram", "ActivityError", this);
            }

        }


    }




}