// ----------------------------------------------------------------------- 
// <copyright file="ITreeExampleData.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ITreeExampleData class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the ITreeExampleData class.
    /// </summary>
    public interface ITreeExampleData
    {
        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        List<IFeature> Features { get; }

        /// <summary>
        /// Gets the example rows.
        /// </summary>
        /// <value>
        /// The example rows.
        /// </value>
        List<IExampleRow> ExampleRows { get;  }

        /// <summary>
        /// Gets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        int Dimensions { get; }
    }
}
