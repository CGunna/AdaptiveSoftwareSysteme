using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class DecisionTreeNode : Node
    {
        public DecisionTreeNode(Tree tree, ICollection<IExampleRow> population, Node parent)
            : base(tree, population, parent)
        {
        }

        public DecisionTreeNode(Tree tree, ICollection<IExampleRow> population)
            : base(tree, population)
        {
        }

        private double GetEntropie()
        {
            double entropie = 0;

            foreach (string className in ((MyDecisionTree)this.tree).ExistingClasses)
            {
                double fraction = this.Population.Count(x => x.Class == className) / (double)this.Population.Count;

                if (fraction != 0)
                {
                    //entropie += (-1 * (fraction)) * Math.Log(fraction, this.tree.ExistingClasses.Count);

                    entropie += (-1 * (fraction)) * Math.Log(fraction, 2);
                }
            }

            return entropie;
        }

        public override double GetSplitValue()
        {
            return this.GetEntropie();
        }

        public override string ToString()
        {
            if (this.IsLeaf)
            {
                return this.Population.Max(x => x.Class);
            }
            else
            {
                string s = string.Empty;

                foreach (var availableClass in ((MyDecisionTree)this.tree).ExistingClasses)
                {
                    s += $"{availableClass}: ({this.Population.Count(x => x.Class == availableClass)}/{this.Population.Count})";
                    s += Environment.NewLine;
                }

                s += $"Entropie: {Math.Round(this.GetEntropie(), 2)}";
                return s;
            }
        }

        public override Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent)
        {
            return new DecisionTreeNode(tree, population, parent);
        }
    }
}
