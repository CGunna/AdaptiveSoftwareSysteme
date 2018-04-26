using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class ReducedErrorPruningForDecisionTrees : ReducedErrorPruning
    {
        public ReducedErrorPruningForDecisionTrees(MyDecisionTree tree) 
            : base(tree)
        {
        }

        public override double GetPredicitionAccuracy(ITreeExampleData testSet)
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
