using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class RegressionTreeNode : Node
    {
        public RegressionTreeNode(Tree tree, ICollection<IExampleRow> population, Node parent)
            : base(tree, population, parent)
        {

        }

        public override Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent)
        {
            return new RegressionTreeNode(tree, population, parent);
        }

        public override double GetConstantValue()
        {
            return this.GetMeanOfResponses();
        }

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
                // Recursion terminition condition
                if (this.Population.Count == 1)
                {
                    return;
                }

                // Store split for information Gain
                this.OutgoingSplit = new Split(bestFeature, smallestLeftDeviance + smallestRightDeviance, bestValue);

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
