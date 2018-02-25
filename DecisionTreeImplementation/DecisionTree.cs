using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeImplementation
{
    public class DecisionTree
    {
        private Node root;

        public DecisionTree(string rootValue)
        {
            this.root = new Node(rootValue);
        }

        public Node Root => this.root;
    }
}
