using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IDecisionTreeCategory
    {
        double X { get;  }
        double Y { get;  }
        string Category { get; }
    }
}
