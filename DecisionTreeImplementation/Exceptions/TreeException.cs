using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation.Exceptions
{
    public class TreeException : System.Exception
    {
        public TreeException(string message)
			: base(message)
        {

        }
    }
}
