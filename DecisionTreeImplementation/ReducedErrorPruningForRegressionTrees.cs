using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class ReducedErrorPruningForRegressionTrees : ReducedErrorPruning
    {
        private readonly double margin;

        public ReducedErrorPruningForRegressionTrees(MyRegressionTree tree, double faultyTolerancePercentage)
            : base(tree)
        {
            var values = new List<double>();

            foreach (var leaf in tree.GetLeafes())
            {
                foreach (var row in leaf.Population)
                {
                    values.Add(row.Items.Where(x => x.RelatedFeature.Name == row.Class).Single().Value);
                }
            }

            values.Sort();

            double smallestValue = values.First();
            double biggestValue = values.Last();

            // Calculate the value of 1%
            double difference = biggestValue - smallestValue;
            this.margin = (difference / 100) * faultyTolerancePercentage;
        }

        public override double GetPredicitionAccuracy(ITreeExampleData testSet)
        {
            double testExampleCount = testSet.ExampleRows.Count;
            double deviationCount = 0;

            foreach (var example in testSet.ExampleRows)
            {
                // check if classified Value is in the range of the given percentage
                // if not -> increase deviation count

                double value = example.Items.Where(x => x.RelatedFeature.Name == example.Class).Single().Value;
                if (!(value >= example.Classification.Value - this.margin && value <= example.Classification.Value + this.margin))
                {
                    deviationCount++;
                }
            }

            return 1 - deviationCount / testExampleCount;
        }
    }
}
