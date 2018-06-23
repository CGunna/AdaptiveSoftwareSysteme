// ----------------------------------------------------------------------- 
// <copyright file="DecisionTreeSplit.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the DecisionTreeSplit class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;

    /// <summary>
    /// Represents the DecisionTreeSplit class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Split" />
    [Serializable]
    public class DecisionTreeSplit : Split
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionTreeSplit"/> class.
        /// </summary>
        public DecisionTreeSplit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionTreeSplit"/> class.
        /// </summary>
        /// <param name="featureName">Name of the feature.</param>
        /// <param name="informationGain">The information gain.</param>
        /// <param name="value">The value.</param>
        public DecisionTreeSplit(string featureName, double informationGain, double value) 
            : base(featureName, value)
        {
            this.InformationGain = informationGain;
        }

        /// <summary>
        /// Gets or sets the information gain.
        /// </summary>
        /// <value>
        /// The information gain.
        /// </value>
        public double InformationGain { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Feature: {this.FeatureName}\r\nAt value: {this.Value}\r\nInformation Gain: {Math.Round(this.InformationGain, 3)}";
    }
}
