using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public abstract class ReducedErrorPruning : IGardener
    {
        private readonly Tree tree;

        public ReducedErrorPruning(Tree tree)
        {
            this.tree = tree;   
        }

        public Tree Prune(Tree mytree, ITreeExampleData testSet)
        {
            // At the beginning -> Validate Set
            // Then calculate some kind of prediction accuracy factor
            bool changed = false;

            do
            {
                tree.ValidateTestSet(testSet);

                double startAccuracy = this.GetPredicitionAccuracy(testSet);
                changed = false;

                foreach (Node leaf in mytree.GetLeaves())
                {
                    if (leaf.Parent != null)
                    {
                        Node leftTemp = leaf.Parent.LeftNode;
                        Node rightTemp = leaf.Parent.RightNode;

                        leaf.Parent.LeftNode = null;
                        leaf.Parent.RightNode = null;

                        mytree.ValidateTestSet(testSet);
                        double tempAccuracy = this.GetPredicitionAccuracy(testSet);

                        if (tempAccuracy < startAccuracy)
                        {
                            // reverse the change
                            leaf.Parent.LeftNode = leftTemp;
                            leaf.Parent.RightNode = rightTemp;
                        }
                        else
                        {
                            // leave it as it is and continue
                            leaf.Parent.OutgoingSplit = null;
                            changed = true;
                        }
                    }
                }

            } while (changed);

            return mytree;
        }

        public abstract double GetPredicitionAccuracy(ITreeExampleData testSet);
    }
}
