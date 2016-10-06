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
	/// Connection Points - encourage shapes of this class to accept connectors only at center of sides.
	/// </summary>
	public partial class FeatureShape
	{
		/// <summary>
		/// Called on every connector creation.
		/// </summary>
		public override bool HasConnectionPoints
		{
			get
			{
				return true;
			}
		}

        



		/// <summary>
		/// Called on every connector creation.
		/// Should only define connection points once.
		/// </summary>
		/// <param name="link"></param>
		public override void CreateConnectionPoint(LinkShape link)
		{
			if (this.ConnectionPoints == null || this.ConnectionPoints.Count == 0)
			{
				// Contrary to appearances, connection points aren't specific to link type.
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Bottom),
					link);
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Top),
					link);
				
			}
		}
	}


	public partial class FeatureSetShape
	{
		/// <summary>
		/// Called on every connector creation.
		/// </summary>
		public override bool HasConnectionPoints
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Called on every connector creation.
		/// Should only define connection points once.
		/// </summary>
		/// <param name="link"></param>
		public override void CreateConnectionPoint(LinkShape link)
		{
			if (this.ConnectionPoints == null || this.ConnectionPoints.Count == 0)
			{
				// Contrary to appearances, connection points aren't specific to link type.
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Bottom),
					link);
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Top),
					link);
				
			}
		}
	}


	public partial class RootFeatureShape
	{
		/// <summary>
		/// Called on every connector creation.
		/// </summary>
		public override bool HasConnectionPoints
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Called on every connector creation.
		/// Should only define connection points once.
		/// </summary>
		/// <param name="link"></param>
		public override void CreateConnectionPoint(LinkShape link)
		{
			if (this.ConnectionPoints == null || this.ConnectionPoints.Count == 0)
			{
				// Contrary to appearances, connection points aren't specific to link type.
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Bottom),
					link);
				this.CreateConnectionPoint(
					new PointD(AbsoluteBoundingBox.Center.X, AbsoluteBoundingBox.Top),
					link);
				
			}
		}
	}

}
