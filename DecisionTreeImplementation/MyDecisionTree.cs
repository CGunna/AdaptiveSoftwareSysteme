using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class MyDecisionTree : Tree
    {
        private List<string> existingClasses;

        public ICollection<string> ExistingClasses { get => this.existingClasses; }

        public MyDecisionTree(ITreeExampleData exampleData)
        {
            this.existingClasses = new List<string>();
            this.existingFeatures = new List<string>();
            this.leaves = new List<Node>();

            foreach (var exampleRow in exampleData.ExampleRows)
            {
                if (!this.existingClasses.Contains(exampleRow.Class))
                    this.existingClasses.Add(exampleRow.Class);

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

            this.rootNode = new DecisionTreeNode(this, exampleData.ExampleRows);
        }
    }
}
