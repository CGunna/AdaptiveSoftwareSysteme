// ----------------------------------------------------------------------- 
// <copyright file="IExampleRow.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the IExampleRow.cs class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the IExampleRow class.
    /// </summary>
    public interface IExampleRow
    {
        /// <summary>
        /// Gets the associated class.
        /// </summary>
        /// <value>
        /// The associated class.
        /// </value>
        string Class { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        List<IExample> Items { get; }

        /// <summary>
        /// Gets or sets the classification.
        /// </summary>
        /// <value>
        /// The classification.
        /// </value>
        IClassificationResult Classification { get; set; }
    }
}
