// ----------------------------------------------------------------------- 
// <copyright file="ReducedErrorPruningForDecisionTrees.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ReducedErrorPruningForDecisionTrees class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the ReducedErrorPruningForDecisionTrees class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.ReducedErrorPruning" />
    public class ReducedErrorPruningForDecisionTrees : ReducedErrorPruning
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedErrorPruningForDecisionTrees"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        public ReducedErrorPruningForDecisionTrees(MyDecisionTree tree) 
            : base(tree)
        {
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
                if (example.Classification.ClassifiedAs != example.Class)
                {
                    deviationCount++;
                }
            }

            return 1 - deviationCount / testExampleCount;
        }
    }
}
