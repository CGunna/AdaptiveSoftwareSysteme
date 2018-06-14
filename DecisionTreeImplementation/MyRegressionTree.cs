using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    public class MyRegressionTree : Tree
    {
        public MyRegressionTree()
        {
        }

        public MyRegressionTree(ITreeExampleData exampleData)
        {
            this.existingFeatures = new List<string>();
            this.leaves = new List<Node>();

            foreach (var exampleRow in exampleData.ExampleRows)
            {
                foreach (var example in exampleRow.Items)
                {
                    // only get as many possible Features as are defined in the dimensions 
                    if (this.existingFeatures.Count >= exampleData.Dimensions)
                        break;

                    // if feature is not in the list -> add it
                    if (!this.existingFeatures.Contains(example.RelatedFeature.Name))
                        this.existingFeatures.Add(example.RelatedFeature.Name);
                }
            }

            this.rootNode = new RegressionTreeNode(this, exampleData.ExampleRows, null);
        }
    }
}
