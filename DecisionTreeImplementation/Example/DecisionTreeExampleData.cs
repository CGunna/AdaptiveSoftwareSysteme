// ----------------------------------------------------------------------- 
// <copyright file="DecisionTreeExampleData.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the DecisionTreeExampleData class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the DecisionTreeExampleData class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.ITreeExampleData" />
    class DecisionTreeExampleData : ITreeExampleData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionTreeExampleData"/> class.
        /// </summary>
        /// <param name="dimensions">The dimensions.</param>
        public DecisionTreeExampleData(int dimensions)
        {
            this.Features = new List<IFeature>();
            this.ExampleRows = new List<IExampleRow>();
            this.Dimensions = dimensions;
        }

        /// <summary>
        /// Gets the existing features.
        /// </summary>
        /// <value>
        /// The existing features.
        /// </value>
        public List<IFeature> Features { get; }

        /// <summary>
        /// Gets the example rows.
        /// </summary>
        /// <value>
        /// The example rows.
        /// </value>
        public List<IExampleRow> ExampleRows { get; }

        /// <summary>
        /// Gets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        public int Dimensions { get; }
    }
}
