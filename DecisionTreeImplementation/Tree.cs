using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public abstract class Tree
    {
        protected Node rootNode;
        protected List<Node> leaves;
        protected List<string> existingFeatures;

        public Node RootNode { get => this.rootNode; }

        public ICollection<string> ExisitingFeatures { get => this.existingFeatures; }

        public virtual void Split()
        {
            this.rootNode.TrySplit();
        }

        /// <summary>
        /// Validates a 
        /// </summary>
        /// <param name="testSet"></param>
        public virtual void ValidateTestSet(ITreeExampleData testSet)
        {
            foreach (var example in testSet.ExampleRows)
            {
                this.rootNode.CareForTestExample(example);
            }
        }

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
