// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2004-2005, SIL International. All Rights Reserved.   
// <copyright from='2004' to='2005' company='SIL International'>
//		Copyright (c) 2004-2005, SIL International. All Rights Reserved.   
//    
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright> 
#endregion
// 
// File: TriStateTreeView.cs
// Responsibility: Eberhard Beilharz/Tim Steenwyk
// 
// <remarks>
// </remarks>
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FeatureModelConfigurationLib;

namespace FeatureModelConfigurator
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	/// A tree view with tri-state check boxes
	/// </summary>
	/// <remarks>
	/// REVIEW: If we want to have icons in addition to the check boxes, we probably have to 
	/// set the icons for the check boxes in a different way. The windows tree view control
	/// can have a separate image list for states.
	/// </remarks>
	/// ----------------------------------------------------------------------------------------
	public class TriStateTreeView : TreeView
	{
		private FeatureModel featureModel;
		//private TextBox statusTextBox;
		private RootFeatureType rootFeature;
		private System.Windows.Forms.ImageList m_TriStateImages;
		private System.ComponentModel.IContainer components;
		/// <summary>
		/// The check state
		/// </summary>
		/// <remarks>The states corresponds to image index</remarks>
		public enum CheckState
		{
			/// <summary>greyed out</summary>
			QuestionMark = 7,
			/// <summary>Unchecked</summary>
			Unchecked = 5,
			/// <summary>Checked</summary>
			Checked = 6,
            /// <summary>Greyed</summary>
            Greyed = 8,
			/// <summary>FeatureSet</summary>
			FeatureSet = 3,
		}

		#region Redefined Win-API structs and methods
		/// <summary></summary>
		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct TV_HITTESTINFO
		{
			/// <summary>Client coordinates of the point to test.</summary>
			public Point pt;
			/// <summary>Variable that receives information about the results of a hit test.</summary>
			public TVHit flags;
			/// <summary>Handle to the item that occupies the point.</summary>
			public IntPtr hItem;
		}

		/// <summary>Hit tests for tree view</summary>
		[Flags]
		public enum TVHit
		{
			/// <summary>In the client area, but below the last item.</summary>
			NoWhere = 0x0001,
			/// <summary>On the bitmap associated with an item.</summary>
			OnItemIcon = 0x0002,
			/// <summary>On the label (string) associated with an item.</summary>
			OnItemLabel = 0x0004,
			/// <summary>In the indentation associated with an item.</summary>
			OnItemIndent = 0x0008,
			/// <summary>On the button associated with an item.</summary>
			OnItemButton = 0x0010,
			/// <summary>In the area to the right of an item. </summary>
			OnItemRight = 0x0020,
			/// <summary>On the state icon for a tree-view item that is in a user-defined state.</summary>
			OnItemStateIcon = 0x0040,
			/// <summary>On the bitmap or label associated with an item. </summary>
			OnItem = (OnItemIcon | OnItemLabel | OnItemStateIcon),
			/// <summary>Above the client area. </summary>
			Above = 0x0100,
			/// <summary>Below the client area.</summary>
			Below = 0x0200,
			/// <summary>To the right of the client area.</summary>
			ToRight = 0x0400,
			/// <summary>To the left of the client area.</summary>
			ToLeft = 0x0800
		}

		/// <summary></summary>
		public enum TreeViewMessages
		{
			/// <summary></summary>
			TV_FIRST            = 0x1100,      // TreeView messages
			/// <summary></summary>
			TVM_HITTEST         = (TV_FIRST + 17),
		}

		/// <summary></summary>
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, TreeViewMessages msg, int wParam, ref TV_HITTESTINFO lParam);
		#endregion

		#region Constructor and destructor
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="TriStateTreeView"/> class.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public TriStateTreeView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			ImageList = m_TriStateImages;
			ImageIndex = (int)CheckState.Unchecked;
			SelectedImageIndex = (int)CheckState.Unchecked;

		}

		/// -----------------------------------------------------------------------------------
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged 
		/// resources; <c>false</c> to release only unmanaged resources. 
		/// </param>
		/// -----------------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// -----------------------------------------------------------------------------------
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		/// -----------------------------------------------------------------------------------
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriStateTreeView));
            this.m_TriStateImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // m_TriStateImages
            // 
            this.m_TriStateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_TriStateImages.ImageStream")));
            this.m_TriStateImages.TransparentColor = System.Drawing.Color.Transparent;
            this.m_TriStateImages.Images.SetKeyName(0, "");
            this.m_TriStateImages.Images.SetKeyName(1, "");
            this.m_TriStateImages.Images.SetKeyName(2, "");
            this.m_TriStateImages.Images.SetKeyName(3, "FeatureSet.ico");
            this.m_TriStateImages.Images.SetKeyName(4, "Unspecified.ico");
            this.m_TriStateImages.Images.SetKeyName(5, "CheckboxUnchecked.ico");
            this.m_TriStateImages.Images.SetKeyName(6, "Checkbox.ico");
            this.m_TriStateImages.Images.SetKeyName(7, "CheckboxQuestionmark.ico");
            this.m_TriStateImages.Images.SetKeyName(8, "CheckboxGreyed.ico");
            // 
            // TriStateTreeView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

		}
		#endregion

		#region Hide no longer appropriate properties from Designer
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ------------------------------------------------------------------------------------
		[Browsable(false)]
		public new bool CheckBoxes
		{
			get { return base.CheckBoxes; }
			set { base.CheckBoxes = value; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ------------------------------------------------------------------------------------
		[Browsable(false)]
		public new int ImageIndex
		{
			get { return base.ImageIndex; }
			set { base.ImageIndex = value; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ------------------------------------------------------------------------------------
		[Browsable(false)]
		public new ImageList ImageList
		{
			get { return base.ImageList; }
			set { base.ImageList = value; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// ------------------------------------------------------------------------------------
		[Browsable(false)]
		public new int SelectedImageIndex
		{
			get { return base.SelectedImageIndex; }
			set { base.SelectedImageIndex = value; }
		}
		#endregion

		#region Overrides
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Called when the user clicks on an item
		/// </summary>
		/// <param name="e"></param>
		/// ------------------------------------------------------------------------------------
		protected override void OnClick(EventArgs e)
		{

			base.OnClick (e);

			TV_HITTESTINFO hitTestInfo = new TV_HITTESTINFO();
			hitTestInfo.pt = PointToClient(Control.MousePosition);

			SendMessage(Handle, TreeViewMessages.TVM_HITTEST,
				0, ref hitTestInfo);
			if ((hitTestInfo.flags & TVHit.OnItemIcon) == TVHit.OnItemIcon)
			{
				TreeNode node = GetNodeAt(hitTestInfo.pt);

				if (node != null && rootFeature.Items != null && CheckIfNodeIsChangeable(node))
				{
					foreach (object o in this.rootFeature.Items)
					{
						string fullpathname = rootFeature.name;
						if (o.GetType() == typeof(FeatureType))
						{
							fullpathname = string.Format("{0}\\{1}", fullpathname, ((FeatureType)o).name);
							if (fullpathname == node.FullPath)
							{
								if (node.ImageIndex == (int)CheckState.Unchecked)
									((FeatureType)o).configuration = ConfigType.Unspecified;
								else if (node.ImageIndex == (int)CheckState.Checked)
								{
									((FeatureType)o).configuration = ConfigType.Excluded;
									UnSelectChildNodesInObjectModelRecursive((FeatureType)o);
									UnSelectChildNodesInTreeViewRecursive(node);
								}
								else if (node.ImageIndex == (int)CheckState.QuestionMark)
									((FeatureType)o).configuration = ConfigType.Included;
								else
									((FeatureType)o).configuration = ConfigType.Excluded;
								break;
							}
							else
							{
                                if (((FeatureType)o).Items != null)
                                {
                                    if (((FeatureType)o).Items.Length > 0)
                                    {
                                        GetSubFeaturesOfObjectModelRecursive(o, fullpathname, node);
                                    }
                                }
							}
						}
						else if (o.GetType() == typeof(FeatureSetType))
						{
							fullpathname = string.Format("{0}\\FeatureSet [{1}...{2}]", fullpathname, ((FeatureSetType)o).min, ((FeatureSetType)o).max);
							if (((FeatureSetType)o).Feature.Length > 0)
							{
								GetSubFeaturesOfObjectModelRecursive(o, fullpathname, node);
							}
						}
					}
					ChangeNodeState(node);
				}
				
			}
			ArrayList errorArray = featureModel.CheckConfiguredModel();
			string[] array = (string[])errorArray.ToArray(typeof(string));
			//this.statusTextBox.Lines = array;
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Toggle item if user presses Enter key
		/// </summary>
		/// <param name="e"></param>
		/// ------------------------------------------------------------------------------------
		//protected override void OnKeyDown(KeyEventArgs e)
		//{
		//    base.OnKeyDown (e);

		//    if (e.KeyCode == Keys.Enter)
		//        ChangeNodeState(SelectedNode);
		//}
		#endregion

		#region Private methods

		private void UnSelectAlternativeFeatureSetFeaturesInTreeView(TreeNode node)
		{
			TreeNode parentnode = node.Parent;

			foreach (TreeNode subnode in parentnode.Nodes)
			{
				if (!subnode.Equals(node))
				{
					subnode.ImageIndex = (int)CheckState.Unchecked;
				}
			}
		}


		private void UnSelectChildNodesInObjectModelRecursive(FeatureType feature)
		{
			if (feature.Items != null)
			{
				foreach (object subobj in feature.Items)
				{
					if (subobj.GetType() == typeof(FeatureType))
					{
						if (((FeatureType)subobj).kind != KindType.Mandatory)
						{
							((FeatureType)subobj).configuration = ConfigType.Excluded;
							UnSelectChildNodesInObjectModelRecursive((FeatureType)subobj);
						}
					}

					else if (subobj.GetType() == typeof(FeatureSetType))
					{
						UnSelectChildNodesInObjectModelRecursive((FeatureSetType)subobj);
					}
				}
			}
		}


		private void UnSelectChildNodesInObjectModelRecursive(FeatureSetType featureSet)
		{
			if (featureSet.Feature != null)
			{
				foreach (object subobj in featureSet.Feature)
				{
					if (subobj.GetType() == typeof(FeatureType))
					{
						if (((FeatureType)subobj).kind != KindType.Mandatory)
						{
							((FeatureType)subobj).configuration = ConfigType.Excluded;
							UnSelectChildNodesInObjectModelRecursive((FeatureType)subobj);
						}
					}

					else if (subobj.GetType() == typeof(FeatureSetType))
					{
						UnSelectChildNodesInObjectModelRecursive((FeatureSetType)subobj);
					}
				}
			}
		}


		private void UnSelectChildNodesInTreeViewRecursive(TreeNode node)
		{
			if (node.Nodes.Count != 0)
			{
				foreach (TreeNode subnode in node.Nodes)
				{
					if (subnode.ImageIndex != (int)CheckState.FeatureSet)
					{
						if (CheckIfNodeIsChangeable(subnode))
						{
							subnode.ImageIndex = (int)CheckState.Unchecked;
							UnSelectChildNodesInTreeViewRecursive(subnode);
						}
					}
					else
						UnSelectChildNodesInTreeViewRecursive(subnode);
				}
			}
			
		}
		
		
		private void GetSubFeaturesOfObjectModelRecursive(object o, string fullPathName, TreeNode node)
		{
			if (o.GetType() == typeof(FeatureType))
			{
				if (((FeatureType)o).Items != null)
				{
					foreach (object subobj in ((FeatureType)o).Items)
					{
						string fpn = fullPathName;
						if (subobj.GetType() == typeof(FeatureType))
						{
							fpn = string.Format("{0}\\{1}", fpn, ((FeatureType)subobj).name);
							if (fpn == node.FullPath)
							{
								if (node.ImageIndex == (int)CheckState.Unchecked)
									((FeatureType)subobj).configuration = ConfigType.Unspecified;
								else if (node.ImageIndex == (int)CheckState.Checked)
								{
									((FeatureType)subobj).configuration = ConfigType.Excluded;
									UnSelectChildNodesInObjectModelRecursive((FeatureType)subobj);
									UnSelectChildNodesInTreeViewRecursive(node);
								}
								else if (node.ImageIndex == (int)CheckState.QuestionMark)
									((FeatureType)subobj).configuration = ConfigType.Included;
								else
									((FeatureType)subobj).configuration = ConfigType.Excluded;
								break;
							}
							else
								GetSubFeaturesOfObjectModelRecursive(subobj, fpn, node);
						}
						else if (subobj.GetType() == typeof(FeatureSetType))
						{
							fpn = string.Format("{0}\\FeatureSet [{1}...{2}]", fpn, ((FeatureSetType)subobj).min, ((FeatureSetType)subobj).max);
							if (fpn == node.FullPath)
								break;
							else
								GetSubFeaturesOfObjectModelRecursive(subobj, fpn, node);
						}
					}
				}
			}

			else if (o.GetType() == typeof(FeatureSetType))
			{
				if (((FeatureSetType)o).Feature != null)
				{
					foreach (object subobj in ((FeatureSetType)o).Feature)
					{
						string fpn = fullPathName;
						fpn = string.Format("{0}\\{1}", fpn, ((FeatureType)subobj).name);
						if (fpn == node.FullPath)
						{
							if (node.ImageIndex == (int)CheckState.Unchecked)
								((FeatureType)subobj).configuration = ConfigType.Unspecified;
							else if (node.ImageIndex == (int)CheckState.Checked)
								((FeatureType)subobj).configuration = ConfigType.Excluded;
							else if (node.ImageIndex == (int)CheckState.QuestionMark)
							{
								((FeatureType)subobj).configuration = ConfigType.Included;
								if (((FeatureSetType)o).min.Trim().Equals("1") && ((FeatureSetType)o).max.Trim().Equals("1"))
								{
									UnSelectAlternativeFeatureSetFeaturesInTreeView(node);
									foreach (object so in ((FeatureSetType)o).Feature)
									{
										string fn = fullPathName;
										fn = string.Format("{0}\\{1}", fn, ((FeatureType)so).name);
										if (fn != node.FullPath)
										{
											((FeatureType)so).configuration = ConfigType.Excluded;
										}
									}
								}
							}
							else
								((FeatureType)o).configuration = ConfigType.Excluded;
							break;
						}
						else
							GetSubFeaturesOfObjectModelRecursive(subobj, fpn, node);
					}
				}
			}

		}

		

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Checks if node state could be changed
		/// </summary>
		/// <param name="node"></param>
		/// <param name="state"></param>
		/// ------------------------------------------------------------------------------------
		private bool CheckIfNodeIsChangeable(TreeNode node)
		{
			if (node.NodeFont == null)
				return false;
			else
				return true;
		}
		
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Checks or unchecks node
		/// </summary>
		/// <param name="node"></param>
		/// <param name="state"></param>
		/// ------------------------------------------------------------------------------------
		private void SetNodeCheckState(TreeNode node, CheckState state)
		{
			InternalSetChecked(node, state);
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Handles changing the state of a node
		/// </summary>
		/// <param name="node"></param>
		/// ------------------------------------------------------------------------------------
		protected void ChangeNodeState(TreeNode node)
		{
			BeginUpdate();
			CheckState newState;
			if (node.ImageIndex == (int)CheckState.Unchecked)
				newState = CheckState.QuestionMark;
			else if (node.ImageIndex == (int)CheckState.Checked)
				newState = CheckState.Unchecked;
			else if (node.ImageIndex == (int)CheckState.QuestionMark)
				newState = CheckState.Checked;
			else
				newState = CheckState.Unchecked;
			SetNodeCheckState(node, newState);
			EndUpdate();
		}

		
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Sets the checked state of a node, but doesn't deal with children or parents
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="state">The new checked state</param>
		/// <returns><c>true</c> if checked state was set to the requested state, otherwise
		/// <c>false</c>.</returns>
		/// ------------------------------------------------------------------------------------
		private bool InternalSetChecked(TreeNode node, CheckState state)
		{
			TreeViewCancelEventArgs args = 
				new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown);
			OnBeforeCheck(args);
			if (args.Cancel)
				return false;

			node.ImageIndex = (int)state;
			node.SelectedImageIndex = (int)state;

			OnAfterCheck(new TreeViewEventArgs(node, TreeViewAction.Unknown));
			return true;
		}

		///// ------------------------------------------------------------------------------------
		///// <summary>
		///// Build a list of all of the tag data for checked items in the tree.
		///// </summary>
		///// <param name="node"></param>
		///// <param name="list"></param>
		///// ------------------------------------------------------------------------------------
		//private void BuildTagDataList(TreeNode node, ArrayList list)
		//{
		//    if (GetChecked(node) == CheckState.Checked && node.Tag != null)
		//        list.Add(node.Tag);

		//    foreach (TreeNode child in node.Nodes)
		//        BuildTagDataList(child, list);
		//}

		///// ------------------------------------------------------------------------------------
		///// <summary>
		///// Look through the tree nodes to find the node that has given tag data and check it.
		///// </summary>
		///// <param name="node"></param>
		///// <param name="tag"></param>
		///// <param name="state"></param>
		///// ------------------------------------------------------------------------------------
		//private void FindAndCheckNode(TreeNode node, object tag, CheckState state)
		//{
		//    if (node.Tag != null && node.Tag.Equals(tag))
		//    {
		//        SetChecked(node, state);
		//        return;
		//    }

		//    foreach (TreeNode child in node.Nodes)
		//        FindAndCheckNode(child, tag, state);
		//}
		#endregion

		#region Public methods


		//public void InitializeStatusTextBox(ref TextBox _statusTextBox)
		//{
		//    this.statusTextBox = _statusTextBox;
		//}

		public void InitializeFeatureModel(ref FeatureModel _featureModel)
		{
			this.featureModel = _featureModel;
		}

		public void InitializeRootFeature(ref RootFeatureType _rootFeature)
		{
			this.rootFeature = _rootFeature;
		}

		
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the checked state of a node
		/// </summary>
		/// <param name="node">Node</param>
		/// <returns>The checked state</returns>
		/// ------------------------------------------------------------------------------------
		//public CheckState GetChecked(TreeNode node)
		//{
		//    if (node.ImageIndex < 0)
		//        return CheckState.Unchecked;
		//    else
		//        return (CheckState)node.ImageIndex;
		//}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Sets the checked state of a node
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="state">The new checked state</param>
		/// ------------------------------------------------------------------------------------
		public void SetChecked(TreeNode node, CheckState state)
		{
			if (!InternalSetChecked(node, state))
				return;
			SetNodeCheckState(node, state);
		}

		///// ------------------------------------------------------------------------------------
		///// <summary>
		///// Find a node in the tree that matches the given tag data and set its checked state
		///// </summary>
		///// <param name="tag"></param>
		///// <param name="state"></param>
		///// ------------------------------------------------------------------------------------
		//public void CheckNodeByTag(object tag, CheckState state)
		//{
		//    if (tag == null)
		//        return;
		//    foreach (TreeNode node in Nodes)
		//        FindAndCheckNode(node, tag, state);
		//}

		///// ------------------------------------------------------------------------------------
		///// <summary>
		///// Return a list of the tag data for all of the checked items in the tree
		///// </summary>
		///// <returns></returns>
		///// ------------------------------------------------------------------------------------
		//public ArrayList GetCheckedTagData()
		//{
		//    ArrayList list = new ArrayList();

		//    foreach (TreeNode node in Nodes)
		//        BuildTagDataList(node, list);
		//    return list;
		//}
		#endregion
	}
}
