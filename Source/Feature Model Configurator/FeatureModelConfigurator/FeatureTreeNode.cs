using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FeatureModelConfigurationLib;

namespace FeatureModelConfigurator
{
	public class FeatureTreeNode : TreeNode 
	{
		private RootFeatureType rootFeature;
		private FeatureType feature;
		
		public void InitializeRootFeature(ref RootFeatureType rf)
		{
			this.rootFeature = rf;
		}

		public void InitializeFeature(ref FeatureType f)
		{
			this.feature = f;
		}
		
		public RootFeatureType RootFeature
		{
			get { return rootFeature; }
		}
		
		public FeatureType Feature
		{
			get { return feature; }
		}

	}


}
