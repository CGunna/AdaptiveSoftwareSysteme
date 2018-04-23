using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public abstract class Node
    {
        protected readonly Tree tree;

        public ICollection<IExampleRow> Population { get; set; }

        public Split OutgoingSplit { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public Node Parent { get; set; }

        public bool IsLeaf => this.LeftNode == null && this.RightNode == null;

        public Node(Tree tree)
        {
            this.tree = tree;
        }

        public Node(Tree tree, ICollection<IExampleRow> population)
            : this(tree)
        {
            this.Population = population.OrderBy(x => x.Class).ToList();
        }

        public Node(Tree tree, ICollection<IExampleRow> population, Node parent)
            : this(tree, population)
        {
            this.Parent = parent;
        }
        

        internal void CareForTestExample(IExampleRow example)
        {
            if (!this.IsLeaf)
            {
                // Compare Values of the Feature of the current split
                if (example.Items.Where(x =>
                    x.RelatedFeature.Name == this.OutgoingSplit.FeatureName).Single().Value
                    <= this.OutgoingSplit.Value)
                {
                    // If smaller equal -> recursion to the left
                    this.LeftNode?.CareForTestExample(example);
                }
                else
                {
                    // If greater -> recursion to the right
                    this.RightNode?.CareForTestExample(example);
                }
            }
            else
            {
                IClassificationResult result = new ClassificationResult(example);
                result.ClassifiedAs = this.ToString();

                example.Classification = result;
            }
        }

        public abstract void TrySplit();

        public abstract double GetConstantValue();

        public abstract Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent);

        public abstract double GetBestSplitComparisonValue(Node leftTemp, Node rightTemp);
    }
}
