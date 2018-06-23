// ----------------------------------------------------------------------- 
// <copyright file="ReducedErrorPruningForRegressionTrees.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ReducedErrorPruningForRegressionTrees class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represenst the ReducedErrorPruningForRegressionTrees class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.ReducedErrorPruning" />
    public class ReducedErrorPruningForRegressionTrees : ReducedErrorPruning
    {
        /// <summary>
        /// The margin needed for the prediction accuracy calculation.
        /// </summary>
        private readonly double margin;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedErrorPruningForRegressionTrees"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="faultyTolerancePercentage">The faulty tolerance percentage.</param>
        public ReducedErrorPruningForRegressionTrees(MyRegressionTree tree, double faultyTolerancePercentage)
            : base(tree)
        {
            var values = new List<double>();

            foreach (var leaf in tree.GetLeaves())
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

        /// <summary>
        /// Gets the predicition accuracy.
        /// </summary>
        /// <param name="testSet">The test set.</param>
        /// <returns>
        /// The calculated prediction accuracy.
        /// </returns>
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
