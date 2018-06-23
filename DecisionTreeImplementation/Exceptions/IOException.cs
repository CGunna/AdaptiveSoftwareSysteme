// ----------------------------------------------------------------------- 
// <copyright file="IOException.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the IOException class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation.Exceptions
{
    /// <summary>
    /// Represents the IOException class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Exceptions.TreeException" />
    public class IOException : TreeException
    {
        private const string message = "An error occured during File operation. Make sure all paths are correct, and accesable!";

        /// <summary>
        /// Initializes a new instance of the <see cref="IOException"/> class.
        /// </summary>
        public IOException()
            : base(message)
        {
        }
    }
}
