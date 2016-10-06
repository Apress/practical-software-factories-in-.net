using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Collections;


namespace FeatureModelConfigurationLib
{
    public class FeatureModelConfiguration
    {
        private string filename;



        public FeatureModelConfiguration(string _filename)
        {
            filename = _filename;
        }


        public RootFeatureType GetFeatureModelConfigurationModel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RootFeatureType));
            RootFeatureType rootFeature = new RootFeatureType();

            try
            {
                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream(filename, FileMode.Open);
                XmlReader reader = new XmlTextReader(fs);

                // Use the Deserialize method to restore the object's state.
                rootFeature = (RootFeatureType)serializer.Deserialize(reader);

                // Release FileStream
                fs.Close();

            }
            catch (Exception)
            {
                return null;
            }

            return rootFeature;
        }


        public FeatureType GetFeatureByXPath(string xpathexpression)
        {
            XPathDocument doc = new XPathDocument(filename);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select(xpathexpression);

            if (iter.Count == 0)
            {
                return null;
            }

            else
            {
                FeatureType feature = new FeatureType();
                feature.Items = null;


                while (iter.MoveNext())
                {
                    if (iter.Current.NodeType == XPathNodeType.Element)
                    {
                        //Check for attributes.
                        if (iter.Current.HasAttributes == true)
                        {
                            feature.name = iter.Current.GetAttribute("name", "");
                            switch (iter.Current.GetAttribute("kind", ""))
                            {
                                case "Mandatory":
                                    feature.kind = KindType.Mandatory;
                                    break;
                                case "Optional":
                                    feature.kind = KindType.Optional;
                                    break;
                                case "FeatureSetFeature":
                                    feature.kind = KindType.FeatureSetFeature;
                                    break;
                            }

                            switch (iter.Current.GetAttribute("configuration", ""))
                            {
                                case "Included":
                                    feature.configuration = ConfigType.Included;
                                    break;
                                case "Excluded":
                                    feature.configuration = ConfigType.Excluded;
                                    break;
                                case "Unspecified":
                                    feature.configuration = ConfigType.Unspecified;
                                    break;
                            }
                        }
                    }
                }
                return feature;
            }
        }

        public ArrayList GetFeatureByName(string featurename)
        {
            
            XPathDocument doc = new XPathDocument(filename);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select(String.Format("//Feature[@name='{0}']", featurename));
          
            if (iter.Count > 0)
            {
                ArrayList features = new ArrayList();
                
                while (iter.MoveNext())
                {
                    FeatureType feature = new FeatureType();

                    if (iter.Current.NodeType == XPathNodeType.Element)
                    {
                        //Check for attributes.
                        if (iter.Current.HasAttributes == true)
                        {
                            feature.name = iter.Current.GetAttribute("name", "");
                            switch (iter.Current.GetAttribute("kind", ""))
                            {
                                case "Mandatory":
                                    feature.kind = KindType.Mandatory;
                                    break;
                                case "Optional":
                                    feature.kind = KindType.Optional;
                                    break;
                                case "FeatureSetFeature":
                                    feature.kind = KindType.FeatureSetFeature;
                                    break;
                            }

                            switch (iter.Current.GetAttribute("configuration", ""))
                            {
                                case "Included":
                                    feature.configuration = ConfigType.Included;
                                    break;
                                case "Excluded":
                                    feature.configuration = ConfigType.Excluded;
                                    break;
                                case "Unspecified":
                                    feature.configuration = ConfigType.Unspecified;
                                    break;
                            }
                        }
                    }
                features.Add(feature);
                }
            return features;                        
            }

            else
            {
                return null;
            }

        }


    }
}
