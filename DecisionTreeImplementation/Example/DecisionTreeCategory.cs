using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class DecisionTreeCategory : IDecisionTreeCategory
    {
        private string category;

        private double x;

        private double y;

        public double X { get => this.x; }
        public double Y { get => this.y; }
        public string Category { get => this.category; }

        public DecisionTreeCategory(string category, double x, double y)
        {
            this.category = category;
            this.x = x;
            this.y = y;
        }
    }
}
