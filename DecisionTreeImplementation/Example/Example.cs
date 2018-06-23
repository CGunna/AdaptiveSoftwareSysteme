// ----------------------------------------------------------------------- 
// <copyright file="Example.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the example class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;

    /// <summary>
    /// Represents the Example class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.IExample" />
    [Serializable]
    internal class Example : IExample
    {
        /// <summary>
        /// Gets or sets the related feature.
        /// </summary>
        /// <value>
        /// The related feature.
        /// </value>
        public IFeature RelatedFeature { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        /// <param name="feature">The feature in this example.</param>
        /// <param name="value">The value of the feature.</param>
        public Example(IFeature feature, double value)
        {
            this.RelatedFeature = feature;
            this.Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.RelatedFeature?.Name}: {this.Value}";
        }
    }
}