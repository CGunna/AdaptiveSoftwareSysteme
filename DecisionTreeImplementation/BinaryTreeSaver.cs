// ----------------------------------------------------------------------- 
// <copyright file="BinaryTreeSaver.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the BinaryTreeSaver class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class BinaryTreeSaver : Interfaces.ITreeSaver
    {
        /// <summary>
        /// Serializes an object to the given path
        /// </summary>
        /// <param name="tree">The object to serialize.</param>
        /// <param name="path">The path to save the object.</param>
        /// <exception cref="DecisionTree.Implementation.Exceptions.IOException">Thrown when IO operation fails.</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.SerializationException">Thrown when Serialization operation fails.</exception>
        public void Export(Tree tree, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, tree);
                }
                catch (IOException)
                {
                    throw new Exceptions.IOException();
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    throw new Exceptions.SerializationException();
                }
            }
        }

        /// <summary>
        /// Imports the specified path.
        /// </summary>
        /// <param name="path">The path to the file from where to import.</param>
        /// <returns>
        /// The reconstructed tree.
        /// </returns>
        /// <exception cref="DecisionTree.Implementation.Exceptions.IOException">Thrown when IO operation fails.</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.SerializationException">Thrown when Serialization operation fails.</exception>
        public Tree Import(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    return formatter.Deserialize(fs) as Tree;
                }
                catch (IOException)
                {
                    throw new Exceptions.IOException();
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    throw new Exceptions.SerializationException();
                }
            }
        }
    }
}
