

/***************************************************************************
         Copyright (c) Microsoft Corporation. All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind; 
    it is not recommended for use in a production environment.
***************************************************************************/

/*
 * For detailed explanation of the special features this file creates, see the accompanying document
 * "Customizing features in Microsoft Tools for Domain Specific Languages"
 * 
 * THE TECHNIQUES DEMONSTRATED HERE WILL CHANGE IN FUTURE VERSIONS OF THE PRODUCT.
 *  
 * To generate your own version of this solution, do not copy this solution.
 * Instead, create a new solution using an appropriate Domain Specific Language template, and then
 * copy across the Custom*.* files.
 */

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
	/// Make CommentLink links straight and diagonal.
	/// Other parts of definition are in Designer.dsldm.cs and Connectors.cs.
	/// </summary>
	public partial class RelationshipFeatureConnector
	{
		[CLSCompliant(false)]
		protected override Microsoft.VisualStudio.Modeling.Diagrams.GraphObject.VGRoutingStyle DefaultRoutingStyle
		{
			get { return Microsoft.VisualStudio.Modeling.Diagrams.GraphObject.VGRoutingStyle.VGRouteStraight; }
		}
	}


	public partial class RelationshipFeatureSetConnector
	{
		[CLSCompliant(false)]
		protected override Microsoft.VisualStudio.Modeling.Diagrams.GraphObject.VGRoutingStyle DefaultRoutingStyle
		{
			get { return Microsoft.VisualStudio.Modeling.Diagrams.GraphObject.VGRoutingStyle.VGRouteStraight; }
		}
	}

}
