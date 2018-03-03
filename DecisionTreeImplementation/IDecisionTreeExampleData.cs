using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IDecisionTreeExample
    {
        List<Feature> Features { get; }

        List<ExampleRow> ExampleRows { get;  }

        int Dimensions { get; }
    }
}
