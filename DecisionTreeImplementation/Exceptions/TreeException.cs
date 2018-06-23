// ----------------------------------------------------------------------- 
// <copyright file="TreeException.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the TreeException class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation.Exceptions
{
    /// <summary>
    /// Represents the TreeException class.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TreeException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeException"/> class.
        /// </summary>
        /// <param name="message">Die Meldung, in der der Fehler beschrieben wird.</param>
        public TreeException(string message)
			: base(message)
        {
        }
    }
}
