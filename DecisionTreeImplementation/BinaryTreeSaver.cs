using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DecisionTree.Implementation
{
    public class BinaryTreeSaver : Interfaces.ITreeSaver
    {
        /// <summary>
        /// Serializes an object to the given path
        /// </summary>
        /// <param name="tree">The object to serialize.</param>
        /// <param name="path">The path to save the object.</param>
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
            }
        }

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
