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

        public override double GetConstantValue()
        {
            return this.GetEntropie();
        }

        public override string ToString()
        {
            if (this.IsLeaf)
            {
                return this.Population.Max(x => x.Class) + (this.Population.Count > 1 ? $"\r\nPopulation: {this.Population.Count}" : "");
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

        public override double GetBestSplitComparisonValue(Node leftTemp, Node rightTemp)
        {
            double informationGain = 0;

            // step by step
            double constantValueP1 = leftTemp.GetConstantValue();
            double constantValueP2 = rightTemp.GetConstantValue();

            // multiply with w(i) and add those 2 nodes together
            double sAfter = ((leftTemp.Population.Count / (double)this.Population.Count) * constantValueP1) + ((rightTemp.Population.Count / (double)this.Population.Count) * constantValueP2);

            // subtract from original entropy to get the Information Gain of the Split
            informationGain = this.GetConstantValue() - sAfter;

            return informationGain;
        }


        public override void CareForTestExample(IExampleRow example)
        {
            if (!this.IsLeaf)
            {
                // Compare Values of the Feature of the current split
                if (example.Items.Where(x =>
                    x.RelatedFeature.Name == this.OutgoingSplit.FeatureName).Single().Value
                    <= this.OutgoingSplit.Value)
                {
                    // If smaller equal -> recursion to the left
                    this.LeftNode?.CareForTestExample(example);
                }
                else
                {
                    // If greater -> recursion to the right
                    this.RightNode?.CareForTestExample(example);
                }
            }
            else
            {
                IClassificationResult result = new ClassificationResult(example);
                result.ClassifiedAs = this.Population.Max(x => x.Class);

                example.Classification = result;
            }
        }

        public override void TrySplit()
        {
            // declare temp values
            double constantValue = this.GetConstantValue();
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
                    Node leftTemp = this.CreateSuccesor(this.tree, smallerEqual, this);
                    Node rightTemp = this.CreateSuccesor(this.tree, greater, this);

                    double informationGain = this.GetBestSplitComparisonValue(leftTemp, rightTemp);

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
                this.OutgoingSplit = new DecisionTreeSplit(bestFeature, bestInformationGain, bestValue);

                // set successors
                this.LeftNode = left;
                this.RightNode = right;

                // Recursive Call
                this.LeftNode.TrySplit();
                this.RightNode.TrySplit();
            }
        }
    }
}
