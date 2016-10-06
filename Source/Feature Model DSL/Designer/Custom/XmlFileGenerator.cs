using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace ISpySoft.FeatureModelLanguage.Designer.Custom
{
	class XmlFileGenerator
	{
		public void GenerateXmlFile(Microsoft.VisualStudio.Modeling.Diagrams.Diagram diagram)
		{
			foreach (Object o in diagram.ModelElement.GetElementLinks())
			{
				if (o.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.ActivityGraphHasElements))
				{
					ISpySoft.FeatureModelLanguage.DomainModel.ActivityGraphHasElements element = (ISpySoft.FeatureModelLanguage.DomainModel.ActivityGraphHasElements)o;
					ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature abstractFeature = element.Elements;
					if (abstractFeature.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RootFeature))
					{
						if (abstractFeature.GetElementLinks().Count > 0)
						{
							XmlDocument doc;
							doc = new XmlDocument();
							XmlElement rootfeatureElement = doc.CreateElement("RootFeature");
							rootfeatureElement.SetAttribute("name", abstractFeature.Name);
							doc.AppendChild(rootfeatureElement);


							foreach (Microsoft.VisualStudio.Modeling.ModelElement elem in abstractFeature.GetElementLinks())
							{
								if (elem.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature))
								{
									ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature relationshipFeature = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature)elem;
									ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeature.TransitionTo;
									GetSubFeatures(childFeature, ref doc, rootfeatureElement);

								}
								else if (elem.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet))
								{
									ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet relationshipFeatureSet = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet)elem;
									ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeatureSet.ObjectTransitionTo;
									GetSubFeatures(childFeature, ref doc, rootfeatureElement);
								}

							}

							SaveFileDialog saveFileDialog = new SaveFileDialog();
							saveFileDialog.Filter = "Feature Configuration Files (*.featureconfig)|*.featureconfig|All Files (*.*)|*.*";
							saveFileDialog.FilterIndex = 1;

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								doc.Save(saveFileDialog.FileName);
							}
						}
					}
				}
			}
		}

		
		void GetSubFeatures(ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature feature, ref XmlDocument xmldoc, XmlElement xmlele)
		{
			XmlElement subelement = null;

			if (feature.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.Feature))
			{
				subelement = xmldoc.CreateElement("Feature");
				subelement.SetAttribute("name", feature.Name);
				foreach (System.ComponentModel.PropertyDescriptor property in feature.GetProperties())
				{
					if (property.Name == "Kind")
					{
						ISpySoft.FeatureModelLanguage.DomainModel.FeatureKind kind = (ISpySoft.FeatureModelLanguage.DomainModel.FeatureKind)property.GetValue(property);
						subelement.SetAttribute("kind", kind.ToString());
                        if (kind.ToString().Equals("Mandatory"))
                            subelement.SetAttribute("configuration", "Included");
                        else
                            subelement.SetAttribute("configuration", "Unspecified");
					}
				}
                
				xmlele.AppendChild(subelement);
				foreach (Microsoft.VisualStudio.Modeling.ModelElement element in feature.GetElementLinks())
				{
					if (element.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature))
					{
						ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature relationshipFeature = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature)element;
						ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeature.TransitionTo;
						if (childFeature != feature)
						{
							GetSubFeatures(childFeature, ref xmldoc, subelement);
						}

					}
					else if (element.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet))
					{
						ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet relationshipFeatureSet = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet)element;
						ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeatureSet.ObjectTransitionTo;
						if (childFeature != feature)
						{
							GetSubFeatures(childFeature, ref xmldoc, subelement);
						}
					}
				}
			}
			else if (feature.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.FeatureSet))
			{
				subelement = xmldoc.CreateElement("FeatureSet");
				foreach (System.ComponentModel.PropertyDescriptor property in feature.GetProperties())
				{
					if (property.Name == "Min")
					{
						subelement.SetAttribute("min", (string)property.GetValue(property));
					}
					if (property.Name == "Max")
					{
						
						subelement.SetAttribute("max", (string)property.GetValue(property));
					}
				}
				xmlele.AppendChild(subelement);
				foreach (Microsoft.VisualStudio.Modeling.ModelElement element in feature.GetElementLinks())
				{
					if (element.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature))
					{
						ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature relationshipFeature = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeature)element;
						ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeature.TransitionTo;
						if (childFeature != feature)
						{
							GetSubFeatures(childFeature, ref xmldoc, subelement);
						}

					}
					else if (element.GetType() == typeof(ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet))
					{
						ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet relationshipFeatureSet = (ISpySoft.FeatureModelLanguage.DomainModel.RelationshipFeatureSet)element;
						ISpySoft.FeatureModelLanguage.DomainModel.AbstractFeature childFeature = relationshipFeatureSet.ObjectTransitionTo;
						if (childFeature != feature)
						{
							GetSubFeatures(childFeature, ref xmldoc, subelement);
						}

					}
				}
			}
		}
	}
}
