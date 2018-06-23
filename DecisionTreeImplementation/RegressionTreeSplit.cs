// ----------------------------------------------------------------------- 
// <copyright file="RegressionTreeSplit.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the RegressionTreeSplit class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;

    /// <summary>
    /// Represents the RegressionTreeSplit class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Split" />
    [Serializable]
    public class RegressionTreeSplit : Split
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegressionTreeSplit"/> class.
        /// </summary>
        public RegressionTreeSplit()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RegressionTreeSplit"/> is left.
        /// </summary>
        /// <value>
        ///   <c>true</c> if left; otherwise, <c>false</c>.
        /// </value>
        public bool Left { get; set; }

        /// <summary>
        /// Gets or sets the left deviance.
        /// </summary>
        /// <value>
        /// The left deviance.
        /// </value>
        public double LeftDeviance { get; set; }

        /// <summary>
        /// Gets or sets the right deviance.
        /// </summary>
        /// <value>
        /// The right deviance.
        /// </value>
        public double RightDeviance { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegressionTreeSplit"/> class.
        /// </summary>
        /// <param name="featureName">Name of the feature.</param>
        /// <param name="value">The value.</param>
        /// <param name="leftDeviance">The left deviance.</param>
        /// <param name="rightDeviance">The right deviance.</param>
        public RegressionTreeSplit(string featureName, double value, double leftDeviance, double rightDeviance) 
            : base(featureName, value)
        {
            this.LeftDeviance = leftDeviance;
            this.RightDeviance = rightDeviance;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="left">if set to <c>true</c> [left].</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString(bool left)
        {
            string deviance = "";

            if (left)
            {
                deviance += $"Left Deviance: {Math.Round(this.LeftDeviance, 2)}";
            }
            else
            {
                deviance += $"Right Deviance: {Math.Round(this.RightDeviance, 2)}";
            }

            return $"Feature: {this.FeatureName}\r\nAt value: {this.Value}\r\n{deviance}";
        }
    }
}
