using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling.Validation;
using System.Text.RegularExpressions;
using System;


namespace ISpySoft.FeatureModelLanguage.DomainModel
{
    [ValidationState(ValidationState.Enabled)]
    public partial class FeatureSet
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]



        private void ValidateState(ValidationContext context)
        {
            MinPropertyState minstate = GetMinPropertyState(this.Min, this.Max);
            MaxPropertyState maxstate = GetMaxPropertyState(this.Min, this.Max);

            if (IsConnectedToRootFeature())
            {
                if (GetNumberOfSubFeatures() == 0)
                    context.LogError(string.Format("{0}: No subfeatures", this.Name), "myError", this);
                if (GetNumberOfSubFeatures() < 2 && GetNumberOfSubFeatures() != 0)
                    context.LogError(string.Format("{0}: Too little subfeatures. At least two subfeatures are required", this.Name), "myError", this);
                if (this.Min.Equals("") && this.Max.Equals(""))
                    context.LogError(string.Format("{0}: No values for 'Min' and 'Max'", this.Name), "myError", this);
                if (this.Min.Equals("") && !(this.Max.Equals("")))
                    context.LogError(string.Format("{0}: No value for 'Min'", this.Name), "myError", this);
                if (this.Max.Equals("") && !(this.Min.Equals("")))
                    context.LogError(string.Format("{0}: No value for 'Max'", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_Regex)
                    context.LogError(string.Format("{0}: Invalid value for 'Min'. Only '0' and positive numbers allowed", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_ToBig)
                    context.LogError(string.Format("{0}: Invalid value for 'Min'. 'Min' must not be bigger than 'Max'", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_Subfeatures)
                    context.LogError(string.Format("{0}: Invalid value for 'Min'. 'Min' must not be bigger than number of subfeatures", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_Regex && !(this.Max.Equals("")))
                    context.LogError(string.Format("{0}: Invalid value for 'Max'. Only numbers >= 1 or 'N' allowed", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_ToSmall)
                    context.LogError(string.Format("{0}: Invalid value for 'Max'. 'Max' must not be smaller than 'Min'", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_Subfeatures)
                    context.LogError(string.Format("{0}: Invalid value for 'Max'. 'Max' must not be bigger than number of subfeatures", this.Name), "myError", this);
            }

            else
            {
                if (HasParent() == false)
                    context.LogWarning(string.Format("{0}: No parent feature", this.Name), "myError", this);
                if (GetNumberOfSubFeatures() == 0)
                    context.LogWarning(string.Format("{0}: No subfeatures", this.Name), "myError", this);
                if (GetNumberOfSubFeatures() < 2 && GetNumberOfSubFeatures() != 0)
                    context.LogWarning(string.Format("{0}: Too little subfeatures. At least two subfeatures are required", this.Name), "myError", this);
                if (this.Min.Equals("") && this.Max.Equals(""))
                    context.LogWarning(string.Format("{0}: No values for 'Min' and 'Max'", this.Name), "myError", this);
                if (this.Min.Equals("") && !(this.Max.Equals("")))
                    context.LogWarning(string.Format("{0}: No value for 'Min'", this.Name), "myError", this);
                if (this.Max.Equals("") && !(this.Min.Equals("")))
                    context.LogWarning(string.Format("{0}: No value for 'Max'", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_Regex)
                    context.LogWarning(string.Format("{0}: Invalid value for 'Min'. Only '0' and positive numbers allowed", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_ToBig)
                    context.LogWarning(string.Format("{0}: Invalid value for 'Min'. 'Min' must not be bigger than 'Max'", this.Name), "myError", this);
                if (minstate == MinPropertyState.Invalid_Subfeatures)
                    context.LogWarning(string.Format("{0}: Invalid value for 'Min'. 'Min' must not be bigger than number of subfeatures", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_Regex && !(this.Max.Equals("")))
                    context.LogWarning(string.Format("{0}: Invalid value for 'Max'. Only numbers >= 1 or 'N' allowed", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_ToSmall)
                    context.LogWarning(string.Format("{0}: Invalid value for 'Max'. 'Max' must not be smaller than 'Min'", this.Name), "myError", this);
                if (maxstate == MaxPropertyState.Invalid_Subfeatures)
                    context.LogWarning(string.Format("{0}: Invalid value for 'Max'. 'Max' must not be bigger than number of subfeatures", this.Name), "myError", this);
            }
        }


        private bool IsConnectedToRootFeature()
        {
            AbstractFeature af = GetParentFeature(this);
            if (af == null)
                return false;
            else
                return true;
        }


        private AbstractFeature GetParentFeature(FeatureSet featureSet)
        {
            foreach (object o in featureSet.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeatureSet))
                {
                    if (((RelationshipFeatureSet)o).ObjectTransitionFrom.GetType() == typeof(RootFeature))
                        return ((RelationshipFeatureSet)o).ObjectTransitionFrom;
                    else if (((RelationshipFeatureSet)o).ObjectTransitionFrom.GetType() == typeof(Feature))
                        return GetParentFeature((Feature)((RelationshipFeatureSet)o).ObjectTransitionFrom);
                }
            }
            return null;
        }

                
        private AbstractFeature GetParentFeature(Feature feature)
        {
            foreach (object o in feature.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeature))
                {
                    if (feature == ((RelationshipFeature)o).TransitionTo)
                    {
                        if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(RootFeature))
                            return ((RelationshipFeature)o).TransitionFrom;
                        else if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(FeatureSet))
                            return GetParentFeature((FeatureSet)(((RelationshipFeature)o).TransitionFrom));
                        else if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(Feature))
                            return GetParentFeature((Feature)(((RelationshipFeature)o).TransitionFrom));
                    }
                }
            }
            return null;

        }


        private bool HasParent()
        {
            foreach (object o in this.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeatureSet))
                    return true;
            }
            return false;
        }
  
        
        private int GetNumberOfSubFeatures()
        {
            AbstractFeatureMoveableCollection collection = this.TransitionTo;
            if (collection == null)
                return 0;
            else 
                return collection.Count;
        }

        
        private MinPropertyState GetMinPropertyState(string minValue, string maxValue)
        {
            System.Text.RegularExpressions.Regex minRegex = new System.Text.RegularExpressions.Regex("^[0-9]*$");
            System.Text.RegularExpressions.Regex maxRegex = new System.Text.RegularExpressions.Regex("^([1-9][0-9]*|n|N)$");

            if (minRegex.IsMatch(minValue.Trim()))
            {
                if (maxRegex.IsMatch(maxValue.Trim()))
                {
                    int subfeatures = GetNumberOfSubFeatures();

                    if (maxValue.Trim().Equals("n") || maxValue.Trim().Equals("N"))
                    {
                        if (Int32.Parse(minValue.Trim()) > subfeatures)
                        {
                            return MinPropertyState.Invalid_Subfeatures;
                        }
                        else
                            return MinPropertyState.Valid;
                    }
                    else
                    {
                        if (Int32.Parse(minValue.Trim()) > subfeatures)
                        {
                            return MinPropertyState.Invalid_Subfeatures;
                        }

                        else if (Int32.Parse(minValue.Trim()) > Int32.Parse(maxValue.Trim()))
                        {
                            return MinPropertyState.Invalid_ToBig;
                        }
                        else
                            return MinPropertyState.Valid;
                    }
                }
                else
                {
                    int subfeatures = GetNumberOfSubFeatures();

                    if (!(minValue.Trim().Equals("")))
                    {
                        if (Int32.Parse(minValue.Trim()) > subfeatures)
                        {
                            return MinPropertyState.Invalid_Subfeatures;
                        }
                        else
                            return MinPropertyState.Valid;
                    }

                    else
                        return MinPropertyState.Valid;
                }
            }
            else
                return MinPropertyState.Invalid_Regex;
        }


        private MaxPropertyState GetMaxPropertyState(string minValue, string maxValue)
        {
            System.Text.RegularExpressions.Regex minRegex = new System.Text.RegularExpressions.Regex("^[0-9]*$");
            System.Text.RegularExpressions.Regex maxRegex = new System.Text.RegularExpressions.Regex("^([1-9][0-9]*|n|N)$");

            if (maxRegex.IsMatch(maxValue.Trim()))
            {
                if (minRegex.IsMatch(minValue.Trim()))
                {
                    int subfeatures = GetNumberOfSubFeatures();

                    if (maxValue.Trim().Equals("n") || maxValue.Trim().Equals("N"))
                    {
                        return MaxPropertyState.Valid;
                    }
                    else
                    {
                        if (Int32.Parse(maxValue.Trim()) > subfeatures)
                        {
                            return MaxPropertyState.Invalid_Subfeatures;
                        }
                        else if (Int32.Parse(maxValue.Trim()) < Int32.Parse(minValue.Trim()))
                        {
                            return MaxPropertyState.Invalid_ToSmall;
                        }
                        else
                            return MaxPropertyState.Valid;
                    }
                }
                else
                {
                    int subfeatures = GetNumberOfSubFeatures();
                    if (maxValue.Trim().Equals("n") || maxValue.Trim().Equals("N"))
                    {
                        return MaxPropertyState.Valid;
                    }
                    else
                    {
                        if (Int32.Parse(maxValue.Trim()) > subfeatures)
                        {
                            return MaxPropertyState.Invalid_Subfeatures;
                        }
                        else
                            return MaxPropertyState.Valid;
                    }
                }
            }
            else
                return MaxPropertyState.Invalid_Regex;
        }


        
        public enum MinPropertyState
        {
            Valid,
            Invalid_Regex,
            Invalid_ToBig,
            Invalid_Subfeatures
        }

        public enum MaxPropertyState
        {
            Valid,
            Invalid_Regex,
            Invalid_ToSmall,
            Invalid_Subfeatures
        } 
    }




    [ValidationState(ValidationState.Enabled)]
    public partial class FeatureModel
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]

        private void ValidateState(ValidationContext context)
        {
            if (this.Elements != null)
            {
                int count = 0;
                foreach (object o in this.Elements)
                {
                    if (o.GetType() == typeof(RootFeature))
                    {
                        count++;
                        if (RootFeatureHasChild((RootFeature)o) == false)
                        {
                            context.LogError(string.Format("Rootfeature: no subfeatures"), "myError", this);
                        }
                    }
                }
              
                if (count > 1)
                {
                    context.LogError(string.Format("Only one rootfeature allowed: There are {0} rootfeatures within the featuremodel", count.ToString()), "myError", this);
                }
            }
        }

        private bool RootFeatureHasChild(RootFeature rf)
        {
            if (rf.GetElementLinks() != null)
            {
                foreach (object obj in rf.GetElementLinks())
                {
                    if (obj.GetType() == typeof(RelationshipFeature) || obj.GetType() == typeof(RelationshipFeatureSet))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }

    }



    [ValidationState(ValidationState.Enabled)]
    public partial class Feature
    {
        [ValidationMethod(ValidationCategory.Open | ValidationCategory.Save | ValidationCategory.Menu)]
        private void ValidateState(ValidationContext context)
        {
            AbstractFeature af = GetParentFeature();

            if (IsConnectedToRootFeature())
            {
                if (af != null)
                {
                    if (af.GetType() == typeof(Feature) || af.GetType() == typeof(RootFeature))
                    {
                        if (this.Kind == FeatureKind.FeatureSetFeature)
                            context.LogError(string.Format("{0}: Invalid 'Kind' property state", this.Name), "myError", this);
                    }
                    else if (af.GetType() == typeof(FeatureSet) || af.GetType() == typeof(RootFeature))
                    {
                        if (this.Kind != FeatureKind.FeatureSetFeature)
                            context.LogError(string.Format("{0}: Invalid 'Kind' property state", this.Name), "myError", this);
                    }
                }
            }
            else
            {
                if (HasParent() == false)
                {
                    context.LogWarning(string.Format("{0}: No parent feature", this.Name), "myError", this);
                    if (this.Kind == FeatureKind.FeatureSetFeature)
                        context.LogWarning(string.Format("{0}: Invalid 'Kind' property state", this.Name), "myError", this);
                }

                if (af != null)
                {
                    if (af.GetType() == typeof(Feature))
                    {
                        if (this.Kind == FeatureKind.FeatureSetFeature)
                            context.LogWarning(string.Format("{0}: Invalid 'Kind' property state", this.Name), "myError", this);
                    }
                    else if (af.GetType() == typeof(FeatureSet))
                    {
                        if (this.Kind != FeatureKind.FeatureSetFeature)
                            context.LogWarning(string.Format("{0}: Invalid 'Kind' property state", this.Name), "myError", this);
                    }
                }
            }
        }


        private bool IsConnectedToRootFeature()
        {
            AbstractFeature af = GetParentFeature(this);
            if (af == null)
                return false;
            else
                return true;
        }


        private AbstractFeature GetParentFeature(FeatureSet featureSet)
        {
            foreach (object o in featureSet.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeatureSet))
                {
                    if (((RelationshipFeatureSet)o).ObjectTransitionFrom.GetType() == typeof(RootFeature))
                        return ((RelationshipFeatureSet)o).ObjectTransitionFrom;
                    else if (((RelationshipFeatureSet)o).ObjectTransitionFrom.GetType() == typeof(Feature))
                        return GetParentFeature((Feature)((RelationshipFeatureSet)o).ObjectTransitionFrom);
                }
            }
            return null;
        }


        private AbstractFeature GetParentFeature(Feature feature)
        {
            foreach (object o in feature.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeature))
                {
                    if (feature == ((RelationshipFeature)o).TransitionTo)
                    {
                        if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(RootFeature))
                            return ((RelationshipFeature)o).TransitionFrom;
                        else if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(FeatureSet))
                            return GetParentFeature((FeatureSet)(((RelationshipFeature)o).TransitionFrom));
                        else if (((RelationshipFeature)o).TransitionFrom.GetType() == typeof(Feature))
                            return GetParentFeature((Feature)(((RelationshipFeature)o).TransitionFrom));
                    }
                }
            }
            return null;

        }
        
        
        
        private bool HasParent()
        {
            
            foreach (object o in this.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeatureSet))
                {
                    AbstractFeature roletarget = ((RelationshipFeatureSet)o).ObjectTransitionTo;
                    if (this == roletarget)
                        return true;

                }
                else if (o.GetType() == typeof(RelationshipFeature))
                {
                    AbstractFeature roletarget = ((RelationshipFeature)o).TransitionTo;
                    if (this == roletarget)
                        return true;
                }
            }
            return false;
        }

        private AbstractFeature GetParentFeature()
        {
            foreach (object o in this.GetElementLinks())
            {
                if (o.GetType() == typeof(RelationshipFeatureSet))
                {
                    AbstractFeature roletarget = ((RelationshipFeatureSet)o).ObjectTransitionTo;
                    if (this == roletarget)
                        return ((RelationshipFeatureSet)o).ObjectTransitionFrom;

                }
                else if (o.GetType() == typeof(RelationshipFeature))
                {
                    AbstractFeature roletarget = ((RelationshipFeature)o).TransitionTo;
                    if (this == roletarget)
                        return ((RelationshipFeature)o).TransitionFrom;
                }
            }
            return null;
        }

        
        
    }


}