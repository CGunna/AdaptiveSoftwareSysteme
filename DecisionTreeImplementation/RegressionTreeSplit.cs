using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    public class RegressionTreeSplit : Split
    {
        public RegressionTreeSplit()
        {
        }

        public bool Left { get; set; }

        public double LeftDeviance { get; set; }

        public double RightDeviance { get; set; }

        public RegressionTreeSplit(string featureName, double value, double leftDeviance, double rightDeviance) 
            : base(featureName, value)
        {
            this.LeftDeviance = leftDeviance;
            this.RightDeviance = rightDeviance;
        }

        public override string ToString(bool left)
        {
            string deviance = "";

            if (left)
            {
                deviance += $"Left Deviance: {Math.Round(this.LeftDeviance, 2)}";
            }
            else
            {
                deviance += $"Right Deviance: {Math.Round(this.RightDeviance, 2)}";
            }

            return $"Feature: {this.FeatureName}\r\nAt value: {this.Value}\r\n{deviance}";
        }
    }
}
