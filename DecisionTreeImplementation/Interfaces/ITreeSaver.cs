// ----------------------------------------------------------------------- 
// <copyright file="ITreeSaver.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ITreeSaver class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation.Interfaces
{
    /// <summary>
    /// Represents the ITreeSaver class.
    /// </summary>
    public interface ITreeSaver
    {
        /// <summary>
        /// Exports the specified tree.
        /// </summary>
        /// <param name="tree">The tree to export.</param>
        /// <param name="path">The path where to export the tree.</param>
        void Export(Tree tree, string path);

        /// <summary>
        /// Imports the specified path.
        /// </summary>
        /// <param name="path">The path to the file from where to import.</param>
        /// <returns>The reconstructed tree.</returns>
        Tree Import(string path);
    }
}
