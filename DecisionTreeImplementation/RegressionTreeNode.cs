using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class RegressionTreeNode : Node
    {
        public RegressionTreeNode(Tree tree, ICollection<IExampleRow> population, Node parent)
            : base(tree, population, parent)
        {

        }

        public override Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent)
        {
            return new RegressionTreeNode(tree, population, parent);
        }

        public override double GetSplitValue()
        {
            throw new NotImplementedException();
        }
    }
}
