using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    public class RegressionTreeNode : Node
    {
        public RegressionTreeNode()
        {
        }

        public RegressionTreeNode(Tree tree, ICollection<IExampleRow> population, Node parent)
            : base(tree, population, parent)
        {

        }

        public override Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent) => new RegressionTreeNode(tree, population, parent);

        public override double GetConstantValue() => this.GetMeanOfResponses();

        private double GetMeanOfResponses()
        {
            if (this.Population.Count > 0)
            {
                 return this.Population.Average(x => x.Items.Where(y => y.RelatedFeature.Name == x.Class).Single().Value); 
            }
            else
            {
                return 0;
            }
        }

        public double GetDeviance(double meanOfResponses)
        {
            double deviance = 0;

            foreach (var example in this.Population)
            {
                deviance += Math.Pow(example.Items.Where(x => x.RelatedFeature.Name == example.Class).Single().Value - meanOfResponses, 2);
            }

            return deviance;
        }

        public override double GetBestSplitComparisonValue(Node leftTemp, Node rightTemp)
        {
            RegressionTreeNode left = leftTemp as RegressionTreeNode;
            RegressionTreeNode right = rightTemp as RegressionTreeNode;

            return left.GetDeviance(left.GetMeanOfResponses()) + right.GetDeviance(right.GetMeanOfResponses());
        }

        public override void TrySplit()
        {
            // declare temp values
            double smallestLeftDeviance = double.MaxValue;
            double smallestRightDeviance = double.MaxValue;
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

                    double leftDeviance = ((RegressionTreeNode)leftTemp).GetDeviance(((RegressionTreeNode)leftTemp).GetMeanOfResponses());
                    double rightDeviance = ((RegressionTreeNode)rightTemp).GetDeviance(((RegressionTreeNode)rightTemp).GetMeanOfResponses());

                    // check if the calculated values are better than the values calculated in an iteration before
                    if (leftDeviance <= smallestLeftDeviance && rightDeviance <= smallestRightDeviance)
                    {
                        smallestRightDeviance = rightDeviance;
                        smallestLeftDeviance = leftDeviance;

                        left = leftTemp;
                        right = rightTemp;
                        bestFeature = possibleFeature;
                        bestValue = value;
                    }
                }
            }

            if (left != null && right != null)
            {
                if (smallestLeftDeviance != 0)
                {
                    // Store split for information Gain
                    this.OutgoingSplit = new RegressionTreeSplit(bestFeature, bestValue, smallestLeftDeviance, smallestRightDeviance);

                    // set successors
                    this.LeftNode = left;
                    this.RightNode = right;

                    // Recursive Call
                    this.LeftNode.TrySplit();
                }

                if (smallestRightDeviance != 0)
                {
                    // Store split for information Gain
                    this.OutgoingSplit = new RegressionTreeSplit(bestFeature, bestValue, smallestLeftDeviance, smallestRightDeviance);

                    // set successors
                    this.LeftNode = left;
                    this.RightNode = right;

                    // Recursive Call
                    this.RightNode.TrySplit();
                }

                // Recursion terminition
                return;
            }
        }

        public override string ToString()
        {
            if (this.IsLeaf)
            {
                return $"{this.Population.First().Class}: {Math.Round(this.GetConstantValue(), 2)}" + (this.Population.Count > 1 ? $"\r\nPopulation: {this.Population.Count}" : ""); ;
            }
            else
            {
                string s = string.Empty;
                s += $"Population: {this.Population.Count}\r\n";
                s += $"MOR: {Math.Round(this.GetConstantValue(), 2)}";
                return s;
            }
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
                result.ClassifiedAs = this.ToString();
                result.Value = this.GetMeanOfResponses();

                example.Classification = result;
            }
        }
    }
}
