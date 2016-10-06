using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling;
using System.Diagnostics;
using Microsoft.VisualStudio.Modeling.Utilities;
using System.Drawing;
using Microsoft.VisualStudio.Modeling.Diagrams;


namespace ISpySoft.FeatureModelLanguage.Designer
{
	/// <summary>
	/// ClassShape in the Class Diagram template.
	/// </summary>
	public partial class FeatureSetShape
	{
		/// <summary>
		/// Gets called whenever a shape is inserted into the diagram.
		/// This is a good time to setup visuals, because all shapes,
		/// decorators, compartments, shapefields, etc. have been created.
		/// </summary>
		public override void OnShapeInserted()
		{
			base.OnShapeInserted();

			// Define the font change to make.
			// In this case, make all decorators show bold, italic,
			// and bigger sized text.
			FontSettings fs = new FontSettings();
			//fs.Bold = true;
			fs.Name = "Arial";

			foreach (ShapeDecorator decorator in this.Decorators)
			{
				// Only do this for all of the text decorators in this shape.
				TextShapeDecorator shapeDec = decorator as TextShapeDecorator;
				if (shapeDec != null)
				{
					shapeDec.StyleSet.OverrideFont(DiagramFonts.ShapeText, fs);
				}
			}

			// make the compartment item text bold.
			FontSettings fsBold = new FontSettings();
			//fsBold.Bold = true;
			fsBold.Name = "Arial";

			foreach (ShapeElement shape in this.NestedChildShapes)
			{
				// Only do this for all of the compartments in this shape.
				Compartment compartment = shape as Compartment;
				if (compartment != null)
				{
					compartment.StyleSet.OverrideFont(DiagramFonts.ShapeTitle, fsBold);
					//compartment.StyleSet.OverrideFont(DiagramFonts.ShapeText, fsBold);
				}
			}
		}
	}
}

