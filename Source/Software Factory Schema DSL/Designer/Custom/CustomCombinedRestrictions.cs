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
#endregion

namespace ISpySoft.SFSchemaLanguage.Designer
{
    public partial class SchemaModelItemHasSchemaModelItemConnectorConnectionType
    {
        public override bool CanCreateConnection(ShapeElement sourceShape, ShapeElement targetShape, ref string connectionWarning)
        {
            if (sourceShape is IDecorator)
                sourceShape = ConnectorConnectAction.TopLevelShape(sourceShape);

            if (targetShape is IDecorator)
                targetShape = ConnectorConnectAction.TopLevelShape(targetShape);
          
            if ((sourceShape.ModelElement as Activity) != null && (targetShape.ModelElement as ViewPoint) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as Activity) != null && (targetShape.ModelElement as Activity) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as Activity) != null && (targetShape.ModelElement as Mapping) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null && (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null && (targetShape.ModelElement as Activity) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null && (targetShape.ModelElement as Mapping) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null && (targetShape.ModelElement as ViewPoint) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as Mapping) != null && (targetShape.ModelElement as Mapping) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as Mapping) != null && (targetShape.ModelElement as Activity) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as Mapping) != null && (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ViewPoint) != null && (targetShape.ModelElement as ViewPoint) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }
            else if ((sourceShape.ModelElement as ViewPoint) != null && (targetShape.ModelElement as Mapping) != null)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Connection not allowed");
                return false;
            }

            else
                if (ConnectionValidator.MaxNumbersOfConnectionsReached(sourceShape, targetShape) == true)
                {
                    connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, "Maximum number of connections reached");
                    return false;
                }
                else
                    return true;

        }


        /// <summary>
        /// Creates a relationship between SchemaModelItemSource and SchemaModelItemTarget
        /// </summary>
        /// <param name="source">SchemaModelItemSource to start the relationship at</param>
        /// <param name="target">SchemaModelItemTarget to end the relationship at</param>
        public override void CreateConnection(Shape sourceShape, Shape targetShape)
        {
            if (sourceShape == null)
            {
                throw new ArgumentNullException("sourceShape");
            }

            if (targetShape == null)
            {
                throw new ArgumentNullException("targetShape");
            }

            if (sourceShape != null && targetShape != null)
            {
                ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItem sourceElement = sourceShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItem;
                ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItem targetElement = targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItem;

                // Make MEL relationship - PEL relationship will be handled by ViewFixup mechanism
                if (sourceElement != null && targetElement != null)
                {


                    targetElement.SchemaModelItemSource.Add(sourceElement);

                    foreach (object o in targetElement.GetElementLinks())
                    {
                        if (o.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {
                            if (((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                GetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"]).ToString().Equals(""))
                            {
                                if ((targetElement as Activity) != null)
                                {
                                    ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                        SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "filters");
                                }
                                else if ((targetElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null)
                                {

                                    if (((ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType)((ISpySoft.SFSchemaLanguage.DomainModel.Artifact)targetElement).GetProperties()["Type"].
                                        GetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Type"])) == ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType.Asset)
                                    {
                                        if ((sourceElement as ViewPoint) != null)
                                        {
                                            ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                            SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "filters");
                                        }
                                        else
                                        {
                                            ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "uses");
                                        }
                                    }
                                    else if (((ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType)((ISpySoft.SFSchemaLanguage.DomainModel.Artifact)targetElement).GetProperties()["Type"].
                                        GetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Type"])) == ISpySoft.SFSchemaLanguage.DomainModel.ArtifactType.Tool)
                                    {
                                        if ((sourceElement as ViewPoint) != null)
                                        {
                                            ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                            SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "filters");
                                        }
                                        else
                                        {
                                            ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                            SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "uses");
                                        }
                                        
                                    }
                                    else
                                    {
                                        if ((sourceElement as ISpySoft.SFSchemaLanguage.DomainModel.ViewPoint) != null)
                                        {
                                            ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                    SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "filters");
                                        }

                                        else
                                        {
                                            ConnectionTextSelector selector = new ConnectionTextSelector();
                                            selector.ShowDialog();
                                            ConnectionTextSelector.SelectionState state = selector.Selected;

                                            if (state == ConnectionTextSelector.SelectionState.reads)
                                            {
                                                ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                        SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "reads");
                                            }
                                            // writes
                                            else if (state == ConnectionTextSelector.SelectionState.writes)
                                            {
                                                ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                        SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "writes");
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                                // Viewpoint
                                else
                                {
                                    ConnectionTextSelector selector = new ConnectionTextSelector();
                                    selector.ShowDialog();
                                    ConnectionTextSelector.SelectionState state = selector.Selected;

                                    if (state == ConnectionTextSelector.SelectionState.reads)
                                    {
                                        ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "reads");
                                    }
                                    // writes
                                    else if (state == ConnectionTextSelector.SelectionState.writes)
                                    {
                                        ((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"].
                                                SetValue(((ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem)o).GetProperties()["Description"], "writes");
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }

                }
            }
        }	
                       
    }

    




    public static class ConnectionValidator
    {
        
        
        
        public static bool MaxNumbersOfConnectionsReached(ShapeElement sourceShape, ShapeElement targetShape)
        {
            if ((sourceShape.ModelElement as ViewPoint) != null && (targetShape.ModelElement as Activity) != null)
            {

                if ((targetShape.ModelElement as Activity).GetElementLinks().Count != 0)
                {
                    foreach (object o in (targetShape.ModelElement as Activity).GetElementLinks())
                    {
                        if (o.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {

                            if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as ViewPoint) != null)
                            {
                                if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as ViewPoint) == sourceShape.ModelElement as ViewPoint)
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    return false;
                }
                return false;
            }


            else if ((sourceShape.ModelElement as ViewPoint) != null && (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null)
            {
                if ((targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact).GetElementLinks().Count != 0)
                {
                    foreach (object o in (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact).GetElementLinks())
                    {
                        if (o.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {

                            if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as ViewPoint) != null)
                            {
                                if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as ViewPoint) == sourceShape.ModelElement as ViewPoint)
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    return false;
                }
                return false;
            }


            else if ((sourceShape.ModelElement as Activity) != null && (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact) != null)
            {
                if ((targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact).GetElementLinks().Count != 0)
                {
                    foreach (object o in (targetShape.ModelElement as ISpySoft.SFSchemaLanguage.DomainModel.Artifact).GetElementLinks())
                    {
                        if (o.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {

                            if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as Activity) != null)
                            {
                                if ((((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemSource as Activity) == sourceShape.ModelElement as Activity)
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    return false;
                }
                return false;
            }


            else if ((sourceShape.ModelElement as Mapping) != null && (targetShape.ModelElement as ViewPoint) != null)
            {
                bool tooManyTargetsFlag = false;
                bool tooManyConnectionsFlag = false;
                int connections = 0;
                System.Collections.ArrayList connectedTargetShapes = new System.Collections.ArrayList();
                connectedTargetShapes.Add(targetShape.ModelElement as SchemaModelItem);

                if ((sourceShape.ModelElement as Mapping).GetElementLinks().Count != 0)
                {
                    foreach (object o in (sourceShape.ModelElement as Mapping).GetElementLinks())
                    {
                        if (o.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {

                            if (!connectedTargetShapes.Contains(((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget))
                            {
                                connectedTargetShapes.Add(((SchemaModelItemHasSchemaModelItem)o).SchemaModelItemTarget);
                                if (connectedTargetShapes.Count > 2)
                                {
                                    tooManyTargetsFlag = true;
                                }
                            }

                        }
                    }
                    
                }

                if ((targetShape.ModelElement as ViewPoint).GetElementLinks().Count != 0)
                {
                    foreach (object obj in (targetShape.ModelElement as ViewPoint).GetElementLinks())
                    {
                        if (obj.GetType() == typeof(ISpySoft.SFSchemaLanguage.DomainModel.SchemaModelItemHasSchemaModelItem))
                        {

                            if ((((SchemaModelItemHasSchemaModelItem)obj).SchemaModelItemSource as Mapping) != null)
                            {
                                if ((((SchemaModelItemHasSchemaModelItem)obj).SchemaModelItemSource as Mapping) == sourceShape.ModelElement as Mapping)
                                {
                                    connections++;

                                    if (connections > 1)
                                        tooManyConnectionsFlag = true;
                                }

                            }
                        }
                    }
                    
                }

                
                if (tooManyTargetsFlag == true && tooManyConnectionsFlag == false)
                    return true;
                if (tooManyTargetsFlag == true && tooManyConnectionsFlag == true)
                    return true;
                if (tooManyTargetsFlag == false && tooManyConnectionsFlag == true)
                    return true;
                else
                    return false;
                               
            }

            else
                return false;

        }
    }
}