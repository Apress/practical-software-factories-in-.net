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
#endregion

namespace ISpySoft.FeatureModelLanguage.Designer
{
	public partial class RelationshipFeatureConnectorConnectionType
	{
        public override bool CanCreateConnection(ShapeElement sourceShapeElement, ShapeElement targetShapeElement, ref string connectionWarning)
		{
			ShapeElement realSource = ConnectorConnectAction.TopLevelShape(sourceShapeElement);
			ShapeElement realTarget = ConnectorConnectAction.TopLevelShape(targetShapeElement);
			ModelElement sourceElement = realSource.ModelElement;
			ModelElement targetElement = realTarget.ModelElement;

            if (realSource == null || realTarget == null) 
                return false;

            else if (realSource == realTarget)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture, 
                                                  "No Self-Connections");
                return false;
            }

            else if (targetElement.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RootFeature))
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                  "Connection to RootFeature not allowed");
                return false;
            }


            else if (targetElement.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.FeatureSet))
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                  "Cannot connect FeatureSet with this Connector");
                return false;
            }
            

            else if (targetElement.GetElementLinks().Count > 2)
            {
                if (NavigationHelper.HasParentShape(targetElement))
                {
                    connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                  "Cannot connect a Shape which has already a parent Shape");
                    return false;
                }
                else
                {
                    return true;
                }     
            }
            
            else
			    return true;
		}
		

	}


    public partial class RelationshipFeatureSetConnectorConnectionType
    {
        public override bool CanCreateConnection(ShapeElement sourceShapeElement, ShapeElement targetShapeElement, ref string connectionWarning)
        {
            if (!base.CanCreateConnection(sourceShapeElement, targetShapeElement, ref connectionWarning))
                return false;

            ShapeElement realSource = ConnectorConnectAction.TopLevelShape(sourceShapeElement);
            ShapeElement realTarget = ConnectorConnectAction.TopLevelShape(targetShapeElement);
            ModelElement sourceElement = realSource.ModelElement;
            ModelElement targetElement = realTarget.ModelElement;

            
            

            if (realSource == null || realTarget == null) return false;

                        
            if (realSource == realTarget)
            {
                connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                  "No Self-Connections");
                return false;
            }

            if (targetElement.GetElementLinks().Count > 2)
            {
                if (NavigationHelper.HasParentShape(targetElement))
                {
                    connectionWarning = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                  "Cannot connect a Shape which has already a parent Shape");
                    return false;
                }
                
            }

            return true;

        } // CanCreateConnection()

    } // partial class

    internal static class NavigationHelper
    {
        /// <summary>
        /// Whether one object is transitively reachable from another via a specific relation. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="goal"></param>
        /// <param name="sourceRole">Source Role of the relation, as played by the source</param>
        /// <param name="targetRole">Target role of the relation, as played by the target</param>
        /// <returns></returns>
        internal static bool HasParentShape(ModelElement targetElement)
        {
            foreach (Object o in targetElement.GetElementLinks())
            {   
                if (o.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet))
                {
                    AbstractFeature roletarget = ((ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet)o).ObjectTransitionTo;
                    if (targetElement == roletarget)
                        return true;
                    
                }
                else if (o.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature))
                {
                    AbstractFeature roletarget = ((ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature)o).TransitionTo;
                    if (targetElement == roletarget)
                       return true;
                }
                
            }
            return false;
        }

    }


}
