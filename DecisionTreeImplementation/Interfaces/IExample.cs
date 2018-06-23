// ----------------------------------------------------------------------- 
// <copyright file="IExample.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the IExample class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the IExample class.
    /// </summary>
    public interface IExample
    {
        /// <summary>
        /// Gets or sets the related feature.
        /// </summary>
        /// <value>
        /// The related feature.
        /// </value>
        IFeature RelatedFeature { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        double Value { get; set; }
    }
}
