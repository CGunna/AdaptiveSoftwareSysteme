using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation.Exceptions
{
    public class IOException : System.IO.IOException
    {
        private const string message = "An error occured during File operation. Make sure all paths are correct, and accesable!";

        public IOException()
            : base(message)
        {
            
        }
    }
}
