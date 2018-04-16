using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public interface IGardener
    {
        MyDecisionTree Prune(MyDecisionTree tree, IDecisionTreeExampleData testSet);
    }
}
