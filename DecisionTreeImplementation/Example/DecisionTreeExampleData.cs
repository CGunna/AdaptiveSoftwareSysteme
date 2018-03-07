using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class DecisionTreeExampleData : IDecisionTreeExampleData
    {
        private List<IFeature> features;
        private List<IExampleRow> exampleRows;
        private int dimensions;

        public List<IFeature> Features { get => this.features; }
        public List<IExampleRow> ExampleRows { get => this.exampleRows; }

        public int Dimensions { get => this.dimensions; }

        public DecisionTreeExampleData()
        {
            this.features = new List<IFeature>();
            this.exampleRows = new List<IExampleRow>();
            this.dimensions = 2;
        }
    }
}
