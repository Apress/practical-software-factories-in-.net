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
    /// <summary>
    /// Rule to call to programmatically set the position of connected Shapes when
    /// the selected shape is moved.
    /// </summary>
    [RuleOn(typeof(FeatureShape), FireTime = TimeToFire.TopLevelCommit)]
    [RuleOn(typeof(RootFeatureShape), FireTime = TimeToFire.TopLevelCommit)]
    [RuleOn(typeof(FeatureSetShape), FireTime = TimeToFire.TopLevelCommit)]
    public class FeatureShapeAttributeChanged : ChangeRule
    {
        public override void ElementAttributeChanged(ElementAttributeChangedEventArgs e)
        {
            
            // only respond to bounds changes
            if (e.MetaAttribute.Id == NodeShape.AbsoluteBoundsMetaAttributeGuid)
            {
                // get the NodeShape reference to work with.
                NodeShape thisShape = e.ModelElement as NodeShape;
                if (thisShape != null && thisShape.Diagram != null && thisShape != thisShape.Diagram)
                {
                    SelectedShapesCollection selection = thisShape.Diagram.ActiveDiagramView.Selection;
                    // make sure the specified shape is in the selection because we only want
                    // the selected shapes to move their connected shapes (not continously
                    // ripple this effect).
                    if (selection != null && selection.Contains(new DiagramItem(thisShape)) == true)
                    {
                        // calculate the change in bounds position.
                        RectangleD oldBounds = (RectangleD)e.OldValue;
                        RectangleD newBounds = (RectangleD)e.NewValue;
                        double deltaX = newBounds.X - oldBounds.X;
                        double deltaY = newBounds.Y - oldBounds.Y;


                        // find all of the connected shapes.
                        List<Shape> connectedShapes = GetConnectedShapes(thisShape);

                        foreach (Shape shape in connectedShapes)
                        {
                            // make sure the shape isn't in the selection,
                            // because those will be on their own as part of drag-drop.
                            if (selection.Contains(new DiagramItem(shape)) == false)
                            {
                                PointD currentLocation = shape.Location;
                                shape.Location = new PointD(currentLocation.X + deltaX,
                                                                          currentLocation.Y + deltaY);

                            }

                        }

                    }

                }

            }

        }



        /// <summary>
        /// Gets all of the shapes that the specified node shape is connected to
        /// through connectors on the diagram.
        /// </summary>
        /// <param name="nodeShape">Shape to find connections for.</param>
        /// <returns>List of connected shapes.</returns>
        private List<Shape> GetConnectedShapes(NodeShape nodeShape)
        {
            List<Shape> connectedShapes = new List<Shape>();


            // go through the list of connectors for which this shape is the From end.
            foreach (ShapeElement shape in nodeShape.FromRoleLinkShapes)
            {
                Connector connector = shape as Connector;
                if (connector != null && connector.ToShape != null)
                {
                    // add the shape at the other end to the list.
                    connectedShapes.Add(connector.ToShape as Shape);
                    NodeShape ns = connector.ToShape as NodeShape;
                    foreach (Shape s in GetConnectedShapes(ns))
                    {
                        connectedShapes.Add(s);
                    }

                }

            }
            return connectedShapes;
        }

        
    }

    internal static partial class GeneratedMetaModelTypes
    {
        // If you have hand-written rules, you define a
        // partial GeneratedMetaModelTypes and put the types
        // of the rules as internal static fields of the class.
        // For example:
        // internal static Type MyRuleType = typeof(MyRule);
        internal static Type NodeShapeAttributeChangedType = typeof(FeatureShapeAttributeChanged);

    }

}