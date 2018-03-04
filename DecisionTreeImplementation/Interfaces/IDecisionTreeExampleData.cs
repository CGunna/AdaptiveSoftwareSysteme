using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IDecisionTreeExampleData
    {
        List<IFeature> Features { get; }

        List<IExampleRow> ExampleRows { get;  }

        int Dimensions { get; }

        IDecisionTreeCategory[,] GetTestData();
    }
}
