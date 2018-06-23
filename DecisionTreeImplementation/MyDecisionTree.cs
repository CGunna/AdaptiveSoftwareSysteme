// ----------------------------------------------------------------------- 
// <copyright file="MyDecisionTree.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the MyDecisionTree class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the MyDecisionTree class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Tree" />
    [Serializable]
    public class MyDecisionTree : Tree
    {
        /// <summary>
        /// Provides a list of all existing classes in the tree.
        /// </summary>
        private List<string> existingClasses;

        /// <summary>
        /// Gets the existing classes.
        /// </summary>
        /// <value>
        /// The existing classes.
        /// </value>
        public ICollection<string> ExistingClasses { get => this.existingClasses; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDecisionTree"/> class.
        /// Just for serialization purposes.
        /// </summary>
        public MyDecisionTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDecisionTree"/> class.
        /// </summary>
        /// <param name="exampleData">The example data.</param>
        public MyDecisionTree(ITreeExampleData exampleData)
        {
            this.existingClasses = new List<string>();
            this.existingFeatures = new List<string>();
            this.leaves = new List<Node>();

            // Foreach row in the example data
            foreach (var exampleRow in exampleData.ExampleRows)
            {
                // Add the class if it is new
                if (!this.existingClasses.Contains(exampleRow.Class))
                    this.existingClasses.Add(exampleRow.Class);

                foreach (var example in exampleRow.Items)
                {
                    // only get as many possible Features as are defined in the dimensions 
                    if (this.existingFeatures.Count >= exampleData.Dimensions)
                        break;

                    // if feature is not in the list -> add it
                    if (!this.existingFeatures.Contains(example.RelatedFeature.Name))
                        this.existingFeatures.Add(example.RelatedFeature.Name);
                }
            }

            // Init the rootnode as concrete node
            this.rootNode = new DecisionTreeNode(this, exampleData.ExampleRows);
        }
    }
}
