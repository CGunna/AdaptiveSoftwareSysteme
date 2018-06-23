// ----------------------------------------------------------------------- 
// <copyright file="ReducedErrorPruning.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ReducedErrorPruning class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the ReducedErrorPruning class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.IGardener" />
    public abstract class ReducedErrorPruning : IGardener
    {
        /// <summary>
        /// The tree to prune.
        /// </summary>
        private readonly Tree tree;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedErrorPruning"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        public ReducedErrorPruning(Tree tree)
        {
            this.tree = tree;   
        }

        /// <summary>
        /// Prunes the specified mytree.
        /// </summary>
        /// <param name="mytree">The mytree.</param>
        /// <param name="testSet">The test set.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the predicition accuracy.
        /// </summary>
        /// <param name="testSet">The test set.</param>
        /// <returns>The calculated prediction accuracy.</returns>
        public abstract double GetPredicitionAccuracy(ITreeExampleData testSet);
    }
}
