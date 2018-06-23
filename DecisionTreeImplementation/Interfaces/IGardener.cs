// ----------------------------------------------------------------------- 
// <copyright file="IGardener.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the IGardener class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the IGardener class.
    /// </summary>
    public interface IGardener
    {
        /// <summary>
        /// Prunes the specified tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="testSet">The test set.</param>
        /// <returns>The pruned tree.</returns>
        Tree Prune(Tree tree, ITreeExampleData testSet);
    }
}
