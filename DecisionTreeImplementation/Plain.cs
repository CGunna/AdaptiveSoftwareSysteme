using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class Plain
    {
        

        public IExampleRow[,] CoordinatePlain { get; set; }

        public IDecisionTreeExampleData Input { get; set; }

        public Plain(IDecisionTreeExampleData exampleData)
        {
            this.Input = exampleData;
            this.CoordinatePlain = new IExampleRow
                [exampleData.ExampleRows.Count, exampleData.ExampleRows.Count];
        }
    }
}
