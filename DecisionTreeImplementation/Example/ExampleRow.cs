using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class ExampleRow : IExampleRow
    {
        private List<IExample> items;

        public List<IExample> Items { get => this.items; }

        public string Class { get => this.items.Where(x => x.RelatedFeature.Name.ToUpper() == "Class".ToUpper()).First().Value.ToString(); }

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
