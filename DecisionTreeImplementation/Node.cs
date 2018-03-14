using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class Node
    {

        private readonly MyDecisionTree tree;

        public ICollection<IExampleRow> Population { get; set; }

        public Split OutgoingSplit { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public Node(MyDecisionTree tree)
        {
            this.tree = tree;
        }

        public Node(MyDecisionTree tree, ICollection<IExampleRow> population)
            : this(tree)
        {
            this.Population = population.OrderBy(x => x.Class).ToList();
        }

        public void TrySplit()
        {
            // declare temp values
            double entropy = this.GetEntropie();
            double bestInformationGain = -1;
            string bestFeature = "";
            double bestValue = double.NaN;
            Node left = null;
            Node right = null;

            // for every feature
            foreach (var possibleFeature in this.tree.ExisitingFeatures)
            {
                // for every citizen
                foreach (var citizen in this.Population) 
                    // TODO optimize -> maybe we can do it without the 3rd loop when we order the values
                    //.OrderBy(x => x.Items.Where(y => y.RelatedFeature.Name == possibleFeature)))
                {
                    // get split value
                    var value = citizen.Items.Where(x => x.RelatedFeature.Name == possibleFeature).Single().Value;

                    // create 2 buckets for seperation
                    List<IExampleRow> smallerEqual = new List<IExampleRow>();
                    List<IExampleRow> greater = new List<IExampleRow>();

                    // put the current split value in the left bucket
                    smallerEqual.Add(citizen);

                    foreach (var splitCandidate in this.Population.Where(x => x != citizen))
                    {
                        // check if values are smaller or equal -> if so put them in left bucket else right
                        if (splitCandidate.Items.Where(x => x.RelatedFeature.Name == possibleFeature).Single()?.Value <= value)
                            smallerEqual.Add(splitCandidate);
                        else
                            greater.Add(splitCandidate);
                    }

                    // Create new Nodes
                    Node leftTemp = new Node(this.tree, smallerEqual);
                    Node rightTemp = new Node(this.tree, greater);

                    // step by step
                    double entropyP1 = leftTemp.GetEntropie();
                    double entropyP2 = rightTemp.GetEntropie();

                    // multiply with w(i) and add those 2 nodes together
                    double sAfter = ((smallerEqual.Count / (double)this.Population.Count) * entropyP1) + ((greater.Count / (double)this.Population.Count) * entropyP2);
                     
                    // subtract from original entropy to get the Information Gain of the Split
                    double informationGain = entropy - sAfter;

                    // check if the calculated values are better than the values calculated in an iteration before
                    if (informationGain >= bestInformationGain)
                    {
                        bestInformationGain = informationGain;
                        left = leftTemp;
                        right = rightTemp;
                        bestFeature = possibleFeature;
                        bestValue = value;
                    }
                }
            }

            if (left != null && right != null)
            {
                // Recursion terminition condition
                if (bestInformationGain <= 0)
                {
                    return;
                }

                // Store split for information Gain
                this.OutgoingSplit = new Split(bestFeature, bestInformationGain, bestValue);

                // set successors
                this.LeftNode = left;
                this.RightNode = right;

                // Recursive Call
                this.LeftNode.TrySplit();
                this.RightNode.TrySplit();
            }
        }

        public double GetEntropie()
        {
            double entropie = 0;

            foreach (string className in this.tree.ExistingClasses)
            {
                double fraction = this.Population.Count(x => x.Class == className) / (double)this.Population.Count;

                if (fraction != 0)
                {
                    entropie += (-1 * (fraction)) * Math.Log(fraction, this.tree.ExistingClasses.Count);
                }
            }

            return entropie;
        }

        public override string ToString()
        {
            string s = string.Empty;

            foreach (var availableClass in this.tree.ExistingClasses)
            {
                s += $"{availableClass}: ({this.Population.Count(x => x.Class == availableClass)}/{this.Population.Count})";
                s += Environment.NewLine;
            }

            s += $"Entropie: {Math.Round(this.GetEntropie(), 2)}";
            return s;
        }
    }
}
