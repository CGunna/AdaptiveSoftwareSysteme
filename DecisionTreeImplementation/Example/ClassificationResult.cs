// ----------------------------------------------------------------------- 
// <copyright file="ClassificationResult.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the ClassificationResult implementation.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;

    /// <summary>
    /// Contains the ClassificationResult class.
    /// </summary>
    [Serializable]
    class ClassificationResult : IClassificationResult
    {
        /// <summary>
        /// Gets or sets the name of the classification.
        /// </summary>
        /// <value>
        /// The name of the classification.
        /// </value>
        public string ClassifiedAs { get; set; }

        /// <summary>
        /// Gets the classified row.
        /// </summary>
        /// <value>
        /// The classified row.
        /// </value>
        public IExampleRow ClassifiedRow { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationResult"/> class.
        /// </summary>
        /// <param name="row">The classified row.</param>
        public ClassificationResult(IExampleRow row)
        {
            this.ClassifiedRow = row;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Classified as: { this.ClassifiedAs }";
        }
    }
}
