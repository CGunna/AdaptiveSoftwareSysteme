using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class ExampleRow
    {
        private List<Example> items;

        public List<Example> Items { get => this.items; }

        public ExampleRow()
        {
            this.items = new List<Example>();
        }

        public override string ToString()
        {
            string s = string.Empty;

            foreach (var item in this.Items)
            {
                s += $"{ item.ToString() } ";
            }

            return s;
        }
    }
}
