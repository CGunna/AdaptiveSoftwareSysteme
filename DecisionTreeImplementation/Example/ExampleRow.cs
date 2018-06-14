using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    class ExampleRow : IExampleRow
    {
        private List<IExample> items;
        private string className;

        public List<IExample> Items { get => this.items; }

        public string Class { get => this.className; set => this.className = value; }

        public IClassificationResult Classification { get; set; }

        public ExampleRow(string className)
            : this()
        {
            this.className = className;
        }

        public ExampleRow()
        {
            this.items = new List<IExample>();
        }

        public override string ToString()
        {
            return this.Class;
        }
    }
}
