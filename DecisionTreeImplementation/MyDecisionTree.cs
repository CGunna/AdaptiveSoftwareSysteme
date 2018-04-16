using System;
using System.Collections;
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
        private List<Node> leaves;

        public Node RootNode { get => this.rootNode; }

        public ICollection<string> ExistingClasses { get => this.existingClasses; }
        public ICollection <string> ExisitingFeatures { get => this.existingFeatures; }

        public MyDecisionTree(IDecisionTreeExampleData exampleData)
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

        public void Split()
        {
            this.rootNode.TrySplit();
        }

        public void ValidateTestSet(IDecisionTreeExampleData testSet)
        {
            foreach (var example in testSet.ExampleRows)
            {
                this.rootNode.CareForTestExample(example);
            }
        }

        public IEnumerable<Node> GetLeafes()
        {
            if (this.leaves == null)
                this.leaves = new List<Node>();
            else
                this.leaves.Clear();

            this.GetLeaf(this.RootNode);

            foreach (Node leaf in this.leaves)
                yield return leaf;
        }

        private void GetLeaf(Node start)
        {
            if (start.IsLeaf)
            {
                this.leaves.Add(start);
            }

            if (start.LeftNode != null)
            {
                this.GetLeaf(start.LeftNode);
            }

            if (start.RightNode != null)
            {
                this.GetLeaf(start.RightNode);
            }
        }
    }
}
