using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class ReducedErrorPruning : IGardener
    {
        public MyDecisionTree Prune(MyDecisionTree tree, IDecisionTreeExampleData testSet)
        {
            // At the beginning -> Validate Set
            // Then calculate some kind of prediction accuracy factor
            bool changed = false;

            do
            {
                tree.ValidateTestSet(testSet);

                double startAccuracy = this.GetPredicitionAccuracy(tree, testSet);
                changed = false;

                foreach (Node leaf in tree.GetLeafes())
                {
                    Node leftTemp = leaf.Parent.LeftNode;
                    Node rightTemp = leaf.Parent.RightNode;

                    leaf.Parent.LeftNode = null;
                    leaf.Parent.RightNode = null;

                    tree.ValidateTestSet(testSet);
                    double tempAccuracy = this.GetPredicitionAccuracy(tree, testSet);

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

            } while (changed);

            return tree;
        }

        private double GetPredicitionAccuracy(MyDecisionTree tree, IDecisionTreeExampleData testSet)
        {
            double testExampleCount = testSet.ExampleRows.Count;
            double deviationCount = 0;

            foreach (var example in testSet.ExampleRows)
            {
                if (example.Classification.ClassifiedAs != example.Class)
                {
                    deviationCount++;
                }
            }

            return 1 - deviationCount / testExampleCount;
        }
    }
}
