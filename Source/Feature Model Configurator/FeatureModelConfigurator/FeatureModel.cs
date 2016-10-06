using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections;
using FeatureModelConfigurationLib;

namespace FeatureModelConfigurator
{
	public class FeatureModel
	{
		private string fileName;
		private bool valid;
		private RootFeatureType rootFeature;

		public FeatureModel(string _fileName)
		{
			fileName = _fileName;
			valid = true;
			rootFeature = null;
		}


		public RootFeatureType RootFeature
		{
			get { return rootFeature; }
		}

		public bool Validity
		{
			get { return valid; }
		}

		public string FileName
		{
			get { return fileName; }
		}
	

		public void ValidateXmlFile(string xsdfilename)
		{
			this.valid = true;
			XmlReaderSettings settings = new XmlReaderSettings();
            try
            {
                StreamReader streamreader = new StreamReader(fileName);
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add("", xsdfilename);
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                XmlReader reader = XmlReader.Create(new XmlTextReader(streamreader), settings);
                while (reader.Read()) ;
                streamreader.Close();
            }
            catch (Exception exception)
            {
                throw (exception);
            }
			
		}


		// event is called when validation of file fails
		private void ValidationCallBack(object sender, ValidationEventArgs e)
		{
			this.valid = false;
		}


        // create TristateTreeView from XML file
        public void CreateTreeViewFromXmlFile(TriStateTreeView treeView)
		{
            
            FeatureModelConfiguration fmc = new FeatureModelConfiguration(this.fileName);
            rootFeature = fmc.GetFeatureModelConfigurationModel();


			// Clear TriStateTreeView
			treeView.Nodes.Clear();

			//
			treeView.BeginUpdate();
						
			treeView.InitializeRootFeature(ref rootFeature);
			FeatureTreeNode rn = new FeatureTreeNode();
			rn.Text = rootFeature.name;
			rn.InitializeRootFeature(ref rootFeature);
			//treeView.SetChecked(rn, TriStateTreeView.CheckState.Checked);
            treeView.SetChecked(rn, TriStateTreeView.CheckState.Greyed);
            treeView.Nodes.Add(rn);
			

			foreach (object o in rootFeature.Items)
			{
				if (o.GetType() == typeof(FeatureType))
				{
					FeatureType ft = (FeatureType)o;
					FeatureTreeNode subRootNode = new FeatureTreeNode();
					subRootNode.Text = ft.name;
					subRootNode.InitializeFeature(ref ft);
					
					if (ft.kind == KindType.Optional || ft.kind == KindType.FeatureSetFeature)
							subRootNode.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

					switch (ft.configuration)
					{
						case ConfigType.Included:
                            if (ft.kind == KindType.Mandatory)
                            {
                                //treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Greyed);
                            }
                            else
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
							break;
						case ConfigType.Excluded:
							treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Unchecked);
							break;
						case ConfigType.Unspecified:
							treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.QuestionMark);
							break;
					}

					rn.Nodes.Add(subRootNode);
					CreateTreeNode(subRootNode, ft, treeView);
				}

				else if (o.GetType() == typeof(FeatureSetType))
				{
					FeatureSetType fst = (FeatureSetType)o;
					FeatureTreeNode subRootNode = new FeatureTreeNode();
					subRootNode.Text = string.Format("FeatureSet [{0}...{1}]", fst.min, fst.max);
					treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.FeatureSet);
					rn.Nodes.Add(subRootNode);
					CreateTreeNode(subRootNode, fst, treeView);
				}
			}

			treeView.ExpandAll();
			treeView.EndUpdate();
		}


		// recursive method
		private void CreateTreeNode(FeatureTreeNode parentNode, FeatureType feature, TriStateTreeView treeView)
		{
			if (feature.Items != null)
			{
				foreach (object o in feature.Items)
				{
					if (o.GetType() == typeof(FeatureType))
					{
						FeatureTreeNode node = new FeatureTreeNode();
						node.Text = ((FeatureType)o).name;

						if (((FeatureType)o).kind == KindType.Optional || ((FeatureType)o).kind == KindType.FeatureSetFeature)
							node.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

						switch (((FeatureType)o).configuration)
						{
							case ConfigType.Included:
                                if (((FeatureType)o).kind == KindType.Mandatory)
                                {
                                    //treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.Greyed);
                                }
                                else
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                break;
							case ConfigType.Unspecified:
								treeView.SetChecked(node, TriStateTreeView.CheckState.QuestionMark);
								break;
							case ConfigType.Excluded:
								treeView.SetChecked(node, TriStateTreeView.CheckState.Unchecked);
								break;
						}

						parentNode.Nodes.Add(node);
						CreateTreeNode(node, ((FeatureType)o), treeView);
					}
					else
					{
						FeatureTreeNode node = new FeatureTreeNode();
						treeView.SetChecked(node, TriStateTreeView.CheckState.FeatureSet);
						node.Text = string.Format("FeatureSet [{0}...{1}]", ((FeatureSetType)o).min, ((FeatureSetType)o).max);
						parentNode.Nodes.Add(node);
						CreateTreeNode(node, (FeatureSetType)o, treeView);
					}
				}
			}

		}

		
		private void CreateTreeNode(FeatureTreeNode parentNode, FeatureSetType featureSet, TriStateTreeView treeView)
		{
			if (featureSet.Feature != null)
			{
				foreach (object o in featureSet.Feature)
				{
					FeatureTreeNode node = new FeatureTreeNode();
					node.Text = ((FeatureType)o).name;
					switch (((FeatureType)o).configuration)
					{
						case ConfigType.Included:
                            if (((FeatureType)o).kind == KindType.Mandatory)
                            {
                                //treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                treeView.SetChecked(node, TriStateTreeView.CheckState.Greyed);
                            }
							else
                                treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
							break;
						case ConfigType.Excluded:
							treeView.SetChecked(node, TriStateTreeView.CheckState.Unchecked);
							break;
						case ConfigType.Unspecified:
							treeView.SetChecked(node, TriStateTreeView.CheckState.QuestionMark);
							break;
					}
					node.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
					parentNode.Nodes.Add(node);
				}
			}

		}


		public void SaveModel(string path)
		{
			fileName = path;
			SaveModel();
		}


		// save model as xml file
		public void SaveModel()
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);

			XmlSerializer xmlSerializer = new XmlSerializer(this.rootFeature.GetType());
			xmlSerializer.Serialize(fs, this.rootFeature);

			fs.Close();
		}


		public ArrayList CheckConfiguredModel()
		{
			ArrayList array = new ArrayList();
			
			if (rootFeature.Items != null)
			{
				foreach (object o in rootFeature.Items)
				{
					if (o.GetType() == typeof(FeatureSetType))
					{
						CheckFeatureSetChildren((FeatureSetType)o, ref array);
					}
					else
					{
						if(((FeatureType)o).configuration == ConfigType.Included)
							CheckSubFeatures((FeatureType)o, ref array);
					}
					
				}
			}
			return array;
		}


		private void CheckSubFeatures(FeatureType feature, ref ArrayList array)
		{
			if (feature.Items != null)
			{
				foreach (object o in feature.Items)
				{
					if (o.GetType() == typeof(FeatureSetType))
					{
						CheckFeatureSetChildren((FeatureSetType)o, ref array);
					}
					else
					{
						if (((FeatureType)o).configuration == ConfigType.Included)
							CheckSubFeatures((FeatureType)o, ref array);
					}
				}
			}
		}
		

		private void CheckFeatureSetChildren(FeatureSetType featureSet, ref ArrayList array)
		{
			int number = 0;
									
			if (!(featureSet.max.Equals("n")) || !(featureSet.max.Equals("N")))
			{
				int min = Int32.Parse(featureSet.min);
				int max = Int32.Parse(featureSet.max);

				foreach (object o in featureSet.Feature)
				{
					if (((FeatureType)o).configuration == ConfigType.Included)
						number++;
				}

				if (number > max)
				{
					// Number fuer Max ausserhalb des Bereichs
					string children = "";
					foreach (object o in featureSet.Feature)
					{
						if (!children.Equals(""))
							children = string.Concat(children, " | ", ((FeatureType)o).name);
						else
							children = ((FeatureType)o).name;
					}
					array.Add(string.Format("WRONG CONFIGURATION: FeatureSet [{0}...{1}]({2}) - too many features selected", featureSet.min, featureSet.max, children));
				}

				else if (number < min)
				{
					// Number fuer Min ausserhalb des Bereichs
					string children = "";
					foreach (object o in featureSet.Feature)
					{
						if (!children.Equals(""))
							children = string.Concat(children, " | ", ((FeatureType)o).name);
						else
							children = ((FeatureType)o).name;
					}
					array.Add(string.Format("WRONG CONFIGURATION: FeatureSet [{0}...{1}]({2}) - too little features selected", featureSet.min, featureSet.max, children));
				}
				else
					return;  // Ok
			}

			else
			{
				int min = Int32.Parse(featureSet.min);

				foreach (object o in featureSet.Feature)
				{
					if (((FeatureType)o).configuration == ConfigType.Included)
						number++;
				}

				if (number < min)
				{
					// Number fuer Min ausserhalb des Bereichs
					array.Add(string.Format("WRONG CONFIGURATION: FeatureSet [{0}...{1}] - too little features selected", featureSet.min, featureSet.max));
				}
				else
					return;  // Ok

			}
			
			
		}


        public void ShowOnlyVariabilityFeatures(TriStateTreeView treeView, FeatureModel featureModel)
        {
            
            //FeatureModelConfiguration fmc = new FeatureModelConfiguration(this.fileName);
            //rootFeature = fmc.GetFeatureModelConfigurationModel();
            rootFeature = featureModel.RootFeature;


            // Clear TriStateTreeView
            treeView.Nodes.Clear();

            //
            treeView.BeginUpdate();

            treeView.InitializeRootFeature(ref rootFeature);
            FeatureTreeNode rn = new FeatureTreeNode();
            rn.Text = rootFeature.name;
            rn.InitializeRootFeature(ref rootFeature);
            //treeView.SetChecked(rn, TriStateTreeView.CheckState.Checked);
            treeView.SetChecked(rn, TriStateTreeView.CheckState.Greyed);
            treeView.Nodes.Add(rn);

            foreach (object o in rootFeature.Items)
            {
                if (o.GetType() == typeof(FeatureType))
                {
                    FeatureType ft = (FeatureType)o;
                    if (HasVariableSubFeatures(ft) == true)
                    {
                        FeatureTreeNode subRootNode = new FeatureTreeNode();
                        subRootNode.Text = ft.name;
                        subRootNode.InitializeFeature(ref ft);

                        if (ft.kind == KindType.Optional || ft.kind == KindType.FeatureSetFeature)
                            subRootNode.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

                        switch (ft.configuration)
                        {
                            case ConfigType.Included:
                                if (ft.kind == KindType.Mandatory)
                                {
                                    //treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
                                    treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Greyed);
                                }
                                else
                                    treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
                                break;
                            case ConfigType.Excluded:
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Unchecked);
                                break;
                            case ConfigType.Unspecified:
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.QuestionMark);
                                break;
                        }

                        rn.Nodes.Add(subRootNode);
                        CreateVariabilityTreeNode(subRootNode, ft, treeView);
                        //CreateTreeNode(subRootNode, ft, treeView);

                    }

                    else
                    {
                        if (((FeatureType)o).kind == KindType.Optional)
                        {
                            FeatureTreeNode node = new FeatureTreeNode();
                            node.Text = ((FeatureType)o).name;
                            node.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

                            switch (((FeatureType)o).configuration)
                            {
                                case ConfigType.Included:
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                    break;
                                case ConfigType.Unspecified:
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.QuestionMark);
                                    break;
                                case ConfigType.Excluded:
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.Unchecked);
                                    break;
                            }

                            rn.Nodes.Add(node);
                        }
                    }


                    
                }

                else if (o.GetType() == typeof(FeatureSetType))
                {
                    FeatureSetType fst = (FeatureSetType)o;
                    FeatureTreeNode subRootNode = new FeatureTreeNode();
                    subRootNode.Text = string.Format("FeatureSet [{0}...{1}]", fst.min, fst.max);
                    treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.FeatureSet);
                    rn.Nodes.Add(subRootNode);
                    CreateTreeNode(subRootNode, fst, treeView);
                }
            }

            treeView.ExpandAll();
            treeView.EndUpdate();
        }


        //create TriStateTreeView from Object Model
        public void ShowAllFeatures(TriStateTreeView treeView, FeatureModel fm)
        {
            rootFeature = fm.RootFeature;

            // Clear TriStateTreeView
            treeView.Nodes.Clear();

            //
            treeView.BeginUpdate();

            treeView.InitializeRootFeature(ref rootFeature);
            FeatureTreeNode rn = new FeatureTreeNode();
            rn.Text = rootFeature.name;
            rn.InitializeRootFeature(ref rootFeature);
            //treeView.SetChecked(rn, TriStateTreeView.CheckState.Checked);
            treeView.SetChecked(rn, TriStateTreeView.CheckState.Greyed);
            treeView.Nodes.Add(rn);


            foreach (object o in rootFeature.Items)
            {
                if (o.GetType() == typeof(FeatureType))
                {
                    FeatureType ft = (FeatureType)o;
                    FeatureTreeNode subRootNode = new FeatureTreeNode();
                    subRootNode.Text = ft.name;
                    subRootNode.InitializeFeature(ref ft);

                    if (ft.kind == KindType.Optional || ft.kind == KindType.FeatureSetFeature)
                        subRootNode.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

                    switch (ft.configuration)
                    {
                        case ConfigType.Included:
                            if (ft.kind == KindType.Mandatory)
                            {
                                //treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Greyed);
                            }
                            else
                                treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Checked);
                            break;
                        case ConfigType.Excluded:
                            treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.Unchecked);
                            break;
                        case ConfigType.Unspecified:
                            treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.QuestionMark);
                            break;
                    }

                    rn.Nodes.Add(subRootNode);
                    CreateTreeNode(subRootNode, ft, treeView);
                }

                else if (o.GetType() == typeof(FeatureSetType))
                {
                    FeatureSetType fst = (FeatureSetType)o;
                    FeatureTreeNode subRootNode = new FeatureTreeNode();
                    subRootNode.Text = string.Format("FeatureSet [{0}...{1}]", fst.min, fst.max);
                    treeView.SetChecked(subRootNode, TriStateTreeView.CheckState.FeatureSet);
                    rn.Nodes.Add(subRootNode);
                    CreateTreeNode(subRootNode, fst, treeView);
                }
            }

            treeView.ExpandAll();
            treeView.EndUpdate();
        }


        private bool HasVariableSubFeatures(FeatureType ft)
        {
            if (ft.Items != null)
            {
                foreach (object o in ft.Items)
                {
                    if (o.GetType() == typeof(FeatureType))
                    {
                        FeatureType feature = (FeatureType)o;
                        if (feature.kind == KindType.Optional)
                        {
                            return true;
                        }
                        else
                        {
                            if (HasVariableSubFeatures(feature) == true)
                            {
                                return true;
                            }
                        }
                    }
                    else
                        return true;
                }
                return false;
            }
            else
                return false;
        }


        // recursive method
        private void CreateVariabilityTreeNode(FeatureTreeNode parentNode, FeatureType feature, TriStateTreeView treeView)
        {
            if (feature.Items != null)
            {
                foreach (object o in feature.Items)
                {
                    if (o.GetType() == typeof(FeatureType))
                    {
                        if (HasVariableSubFeatures((FeatureType)o) == true)
                        {
                            FeatureTreeNode node = new FeatureTreeNode();
                            node.Text = ((FeatureType)o).name;

                            if (((FeatureType)o).kind == KindType.Optional || ((FeatureType)o).kind == KindType.FeatureSetFeature)
                                node.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

                            switch (((FeatureType)o).configuration)
                            {
                                case ConfigType.Included:
                                    if (((FeatureType)o).kind == KindType.Mandatory)
                                    {
                                        //treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                        treeView.SetChecked(node, TriStateTreeView.CheckState.Greyed);
                                    }
                                    else
                                        treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                    break;
                                case ConfigType.Unspecified:
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.QuestionMark);
                                    break;
                                case ConfigType.Excluded:
                                    treeView.SetChecked(node, TriStateTreeView.CheckState.Unchecked);
                                    break;
                            }

                            parentNode.Nodes.Add(node);
                            CreateVariabilityTreeNode(node, ((FeatureType)o), treeView);
                        }
                        else
                        {
                            if (((FeatureType)o).kind == KindType.Optional)
                            {
                                FeatureTreeNode node = new FeatureTreeNode();
                                node.Text = ((FeatureType)o).name;
                                node.NodeFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

                                switch (((FeatureType)o).configuration)
                                {
                                    case ConfigType.Included:
                                        treeView.SetChecked(node, TriStateTreeView.CheckState.Checked);
                                        break;
                                    case ConfigType.Unspecified:
                                        treeView.SetChecked(node, TriStateTreeView.CheckState.QuestionMark);
                                        break;
                                    case ConfigType.Excluded:
                                        treeView.SetChecked(node, TriStateTreeView.CheckState.Unchecked);
                                        break;
                                }
                                
                                parentNode.Nodes.Add(node);
                            }
                        }
                    }
                    else
                    {
                        FeatureTreeNode node = new FeatureTreeNode();
                        treeView.SetChecked(node, TriStateTreeView.CheckState.FeatureSet);
                        node.Text = string.Format("FeatureSet [{0}...{1}]", ((FeatureSetType)o).min, ((FeatureSetType)o).max);
                        parentNode.Nodes.Add(node);
                        CreateTreeNode(node, (FeatureSetType)o, treeView);
                    }
                }
            }

        }

	}
}
