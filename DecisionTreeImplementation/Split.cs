// ----------------------------------------------------------------------- 
// <copyright file="Split.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the Split class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;

    /// <summary>
    /// Represenst the Split class.
    /// </summary>
    [Serializable]
    public class Split
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Split"/> class.
        /// </summary>
        public Split()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Split"/> class.
        /// </summary>
        /// <param name="featureName">Name of the feature.</param>
        /// <param name="value">The value.</param>
        public Split(string featureName, double value)
        {
            this.FeatureName = featureName;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>
        /// The name of the feature.
        /// </value>
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="left">if set to <c>true</c> [left].</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public virtual string ToString(bool left) => this.ToString();
    }
}
