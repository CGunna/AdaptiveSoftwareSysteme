using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeImplementation
{
    public class Edge
    {
        public Edge(string edgeValue)
        {
            this.Value = edgeValue;
        }

        public string Value { get; set; }
    }
}
