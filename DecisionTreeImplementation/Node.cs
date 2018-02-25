using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeImplementation
{
    public class Node
    {
        public string Value { get; set; }

        public Edge InputEdge { get; set; }

        public List<Node> ChildNodes { get; set; }

        public Node(string attributeValue)
        {
            this.Value = attributeValue;
            this.ChildNodes = new List<Node>();
        }

        public Node AddChild(string childValue, string edgeValue)
        {
            Node n = new Node(childValue);
            n.InputEdge = new Edge(edgeValue);
            this.ChildNodes.Add(n);

            return n;
        }
    }
}
