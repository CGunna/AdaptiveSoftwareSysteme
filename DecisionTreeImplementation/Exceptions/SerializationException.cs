using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation.Exceptions
{
    class SerializationException : TreeException
    {
        private const string message = "An error occured during Serialization/Deserialization. Make sure all paths are correct, and the file is valid!";

        public SerializationException()
            : base(message)
        {

        }
    }
}
