using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    /// <summary>
    /// Represents the abstract Node class.
    /// </summary>
    [Serializable]
    public abstract class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// Just for serialization purposes.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        public Node(Tree tree)
        {
            this.tree = tree;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="population">The population.</param>
        public Node(Tree tree, ICollection<IExampleRow> population)
            : this(tree)
        {
            this.Population = population.OrderBy(x => x.Class).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="population">The population.</param>
        /// <param name="parent">The parent.</param>
        public Node(Tree tree, ICollection<IExampleRow> population, Node parent)
            : this(tree, population)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// The tree where this node belongs to.
        /// </summary>
        protected readonly Tree tree;

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        /// <value>
        /// The population.
        /// </value>
        public ICollection<IExampleRow> Population { get; set; }

        /// <summary>
        /// Gets or sets the outgoing split.
        /// </summary>
        /// <value>
        /// The outgoing split.
        /// </value>
        public Split OutgoingSplit { get; set; }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        /// <value>
        /// The left node.
        /// </value>
        public Node LeftNode { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        /// <value>
        /// The right node.
        /// </value>
        public Node RightNode { get; set; }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        public Node Parent { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is a leaf.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is a leaf; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeaf => this.LeftNode == null && this.RightNode == null;

        /// <summary>
        /// Handle through the tree and check where the example data would land
        /// or how it would be classified. Set this result in the example data.
        /// </summary>
        /// <param name="example">The example to classify.</param>
        public abstract void CareForTestExample(IExampleRow example);

        /// <summary>
        /// Split the node based on the calculation of the best split.
        /// </summary>
        public abstract void TrySplit();

        /// <summary>
        /// Get the constant value of the node. E.g. for the decision tree
        /// node it would be the entropy. 
        /// </summary>
        /// <returns></returns>
        public abstract double GetConstantValue();

        /// <summary>
        /// Creates a concrete succesor.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="population">The population.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>A concrete Node object.</returns>
        public abstract Node CreateSuccesor(Tree tree, ICollection<IExampleRow> population, Node parent);

        /// <summary>
        /// Gets the best split comparison value.
        /// </summary>
        /// <param name="leftTemp">The left temporary.</param>
        /// <param name="rightTemp">The right temporary.</param>
        /// <returns>The best split value calculation result.</returns>
        public abstract double GetBestSplitComparisonValue(Node leftTemp, Node rightTemp);
    }
}
