using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class DecisionTreeExample : IDecisionTreeExample
    {
        private List<Feature> features;
        private List<ExampleRow> exampleRows;
        private int dimensions;

        public List<Feature> Features { get => this.features; }
        public List<ExampleRow> ExampleRows { get => this.exampleRows; }

        public int Dimensions { get => this.dimensions; }

        public DecisionTreeExample()
        {
            this.features = new List<Feature>();
            this.exampleRows = new List<ExampleRow>();
            this.dimensions = 2;
        }
    }
}
