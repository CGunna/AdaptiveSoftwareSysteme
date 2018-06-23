// ----------------------------------------------------------------------- 
// <copyright file="MyRegressionTree.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the MyRegressionTree class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the MyRegressionTree class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Tree" />
    [Serializable]
    public class MyRegressionTree : Tree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyRegressionTree"/> class.
        /// Just for serialization purposes.
        /// </summary>
        public MyRegressionTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyRegressionTree"/> class.
        /// </summary>
        /// <param name="exampleData">The example data.</param>
        public MyRegressionTree(ITreeExampleData exampleData)
        {
            this.existingFeatures = new List<string>();
            this.leaves = new List<Node>();

            // For every row in the example data
            foreach (var exampleRow in exampleData.ExampleRows)
            {
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
            this.rootNode = new RegressionTreeNode(this, exampleData.ExampleRows, null);
        }
    }
}
