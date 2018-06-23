// ----------------------------------------------------------------------- 
// <copyright file="InvalidArgumentException.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the InvalidArgumentException class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation.Exceptions
{
    /// <summary>
    /// Represents the InvalidArgumentException class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Exceptions.TreeException" />
    public class InvalidArgumentException : TreeException
    {
        private const string msg = "The argument is invalid. Check your input!";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// </summary>
        /// <param name="message">Die Meldung, in der der Fehler beschrieben wird.</param>
        public InvalidArgumentException(string message = null) : 
            base(message == null ? msg : message)
        {
        }
    }
}
