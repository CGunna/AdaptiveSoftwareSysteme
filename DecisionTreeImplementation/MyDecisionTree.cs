using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class MyDecisionTree
    {
        private Node rootNode;
        private List<string> existingClasses;
        private List<string> existingFeatures;

        public Node RootNode { get => this.rootNode; }

        public ICollection<string> ExistingClasses { get => this.existingClasses; }
        public ICollection <string> ExisitingFeatures { get => this.existingFeatures; }

        public MyDecisionTree(IDecisionTreeExampleData exampleData)
        {
            this.existingClasses = new List<string>();
            this.existingFeatures = new List<string>();

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

            this.rootNode = new Node(this, exampleData.ExampleRows);
        }


        /// <summary>
        /// From https://stackoverflow.com/questions/8389232/how-to-find-height-of-bst-iteratively
        /// Thanks to the author: Viacheslav Smityukh
        /// </summary>
        private int GetLen(Node node)
        {
            var result = 0;

            if (node != null)
            {
                result = Math.Max(GetLen(node.LeftNode), GetLen(node.RightNode)) + 1;
            }

            return result;
        }

        public int GetTreeHeight()
        {
            return GetLen(this.rootNode);
        }
    }
}
