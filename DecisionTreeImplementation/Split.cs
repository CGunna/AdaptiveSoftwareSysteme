using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class Split
    {
        public string FeatureName { get; set; }

        public double Value { get; set; }

        public Split(string featureName, double value)
        {
            this.FeatureName = featureName;
            this.Value = value;
        }

        public virtual string ToString(bool left) => this.ToString();
    }
}
