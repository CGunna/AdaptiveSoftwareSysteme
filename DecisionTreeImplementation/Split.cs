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

        public double Value { get; set; }

        public Split(string featureName, double informationGain, double value)
        {
            this.InformationGain = informationGain;
            this.FeatureName = featureName;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Feature: {this.FeatureName}\r\nAt value: {this.Value}\r\nInformation Gain: {Math.Round(this.InformationGain, 3)}";
        }
    }
}
