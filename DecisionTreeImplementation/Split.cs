using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class Split
    {
        public double InformationGain { get; set; }

        public string FeatureName { get; set; }

        public Split(string featureName, double informationGain)
        {
            this.InformationGain = informationGain;
            this.FeatureName = featureName;
        }
    }
}
