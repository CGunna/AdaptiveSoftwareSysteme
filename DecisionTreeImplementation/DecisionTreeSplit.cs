using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    public class DecisionTreeSplit : Split
    {
        public DecisionTreeSplit()
        {
        }

        public DecisionTreeSplit(string featureName, double informationGain, double value) 
            : base(featureName, value)
        {
            this.InformationGain = informationGain;
        }

        public double InformationGain { get; set; }

        public override string ToString() => $"Feature: {this.FeatureName}\r\nAt value: {this.Value}\r\nInformation Gain: {Math.Round(this.InformationGain, 3)}";
    }
}
