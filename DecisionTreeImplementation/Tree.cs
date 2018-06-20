using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the abstract tree class.
    /// </summary>
    [Serializable]
    public abstract class Tree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tree"/> class.
        /// </summary>
        public Tree()
        {
        }

        /// <summary>
        /// The root node of the tree. 
        /// </summary>
        protected Node rootNode;

        /// <summary>
        /// The leaves of the tree.
        /// </summary>
        protected List<Node> leaves;

        /// <summary>
        /// The existing features in the tree.
        /// </summary>
        protected List<string> existingFeatures;

        /// <summary>
        /// Gets the rootnode.
        /// </summary>
        /// <value>
        /// The root node.
        /// </value>
        public Node RootNode { get => this.rootNode; }

        /// <summary>
        /// Gets the exisiting features.
        /// </summary>
        /// <value>
        /// The exisiting features.
        /// </value>
        public ICollection<string> ExisitingFeatures { get => this.existingFeatures; }

        /// <summary>
        /// Starts the splitting process.
        /// The actual splitting logic is implemented recursive in the nodes.
        /// To start the process - the tree calls the first node (root node).
        /// </summary>
        public virtual void Split()
        {
            this.rootNode.TrySplit();
        }

        /// <summary>
        /// Validates the given test set.
        /// Basically the same as in the above split method.
        /// The nodes care recursively for the test sets.
        /// This method just starts the process in the rootnode.
        /// </summary>
        /// <param name="testSet">The test set.</param>
        public virtual void ValidateTestSet(ITreeExampleData testSet)
        {
            foreach (var example in testSet.ExampleRows)
            {
                this.rootNode.CareForTestExample(example);
            }
        }

        /// <summary>
        /// Iterates through the tree and returns an enumerable of all leaves in the tree.
        /// </summary>
        /// <returns>An enumerable of all leaves in the tree.</returns>
        public virtual IEnumerable<Node> GetLeaves()
        {
            if (this.leaves == null)
                this.leaves = new List<Node>();
            else
                this.leaves.Clear();

            this.GetLeaf(this.RootNode);

            foreach (Node leaf in this.leaves)
                yield return leaf;
        }

        /// <summary>
        /// Recursive handling through the tree.
        /// Internal Helper method for GetLeaves().
        /// Adds the found leaves to the internal list.
        /// </summary>
        /// <param name="start">The node where to start.</param>
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
