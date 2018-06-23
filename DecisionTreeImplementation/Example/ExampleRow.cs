// ----------------------------------------------------------------------- 
// <copyright file="ExampleRow.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ExampleRow class..</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the Example class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.IExampleRow" />
    [Serializable]
    class ExampleRow : IExampleRow
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<IExample> Items { get; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the classification.
        /// </summary>
        /// <value>
        /// The classification.
        /// </value>
        public IClassificationResult Classification { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleRow"/> class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        public ExampleRow(string className)
            : this()
        {
            this.Class = className;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleRow"/> class.
        /// </summary>
        public ExampleRow()
        {
            this.Items = new List<IExample>();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Class;
        }
    }
}
