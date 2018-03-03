using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IDecisionTreeExampleData
    {
        List<Feature> Features { get; }

        List<ExampleRow> ExampleRows { get;  }

        int Dimensions { get; }

        ITestData[] GetTestData();
    }
}
