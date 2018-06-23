// ----------------------------------------------------------------------- 
// <copyright file="IClassificationResult.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the IClassificationResult class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the IClassificationResult class.
    /// </summary>
    public interface IClassificationResult
    {
        /// <summary>
        /// Gets or sets the classified as.
        /// </summary>
        /// <value>
        /// The classified as.
        /// </value>
        string ClassifiedAs { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        double Value { get; set; }

        /// <summary>
        /// Gets the classified row.
        /// </summary>
        /// <value>
        /// The classified row.
        /// </value>
        IExampleRow ClassifiedRow { get; }
    }
}
