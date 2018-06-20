using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation.Exceptions
{
    public class InvalidArgumentException : TreeException
    {
        private const string msg = "The argument is invalid. Check your input!";

        public InvalidArgumentException(string message = null) : 
            base(message == null ? msg : message)
        {
        }
    }
}
