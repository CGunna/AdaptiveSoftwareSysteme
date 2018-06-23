// ----------------------------------------------------------------------- 
// <copyright file="SerializationException.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the SerializationException class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation.Exceptions
{
    /// <summary>
    /// Represents the SerializationException class.
    /// </summary>
    /// <seealso cref="DecisionTree.Implementation.Exceptions.TreeException" />
    class SerializationException : TreeException
    {
        private const string message = "An error occured during Serialization/Deserialization. Make sure all paths are correct, and the file is valid!";

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationException"/> class.
        /// </summary>
        public SerializationException()
            : base(message)
        {

        }
    }
}
