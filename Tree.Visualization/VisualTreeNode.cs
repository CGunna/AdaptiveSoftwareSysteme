// ----------------------------------------------------------------------- 
// <copyright file="VisualTreeNode.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the VisualTreeNode class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace Tree.Visualization
{
    using DecisionTree.Implementation;
    using System.Windows.Controls;

    /// <summary>
    /// Represents the VisualTreeNode class.
    /// </summary>
    /// <seealso cref="Tree.Visualization.TreeVisualizationObject" />
    public class VisualTreeNode : TreeVisualizationObject
    {
        /// <summary>
        /// The left coordinate.
        /// </summary>
        private double left;

        /// <summary>
        /// The top coordinate.
        /// </summary>
        private double top;

        /// <summary>
        /// The node implementation object.
        /// </summary>
        public readonly Node node;

        /// <summary>
        /// Gets a value indicating whether this instance is leaf.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is leaf; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeaf => this.node.IsLeaf;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTreeNode"/> class.
        /// </summary>
        /// <param name="actualNode">The actual node.</param>
        public VisualTreeNode(Node actualNode)
        {
            this.node = actualNode;
            this.OutgoingSplits = new VisualSplit[2];
            this.viewbox = new Viewbox();

            VisualSplit leftSplit = new VisualSplit(this.node.OutgoingSplit);
            this.OutgoingSplits[0] = leftSplit;

            VisualSplit rightSplit = new VisualSplit(this.node.OutgoingSplit);
            this.OutgoingSplits[1] = rightSplit;
        }

        /// <summary>
        /// Gets or sets the outgoing splits.
        /// </summary>
        /// <value>
        /// The outgoing splits.
        /// </value>
        public VisualSplit[] OutgoingSplits { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left position of the node.
        /// </value>
        public double Left
        {
            get
            {
                return this.left;
            }

            set
            {
                //this.left = value - (this.MyBorder.Width / 2);
                this.left = value;
                Canvas.SetLeft(this.viewbox, this.left);
            }
        }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>
        /// The top position of the node.
        /// </value>
        public double Top
        {
            get
            {
                return this.top;
            }

            set
            {
                this.top = value;
                //this.top = value + (this.MyBorder.Height / 2);
                Canvas.SetTop(this.viewbox, this.top);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.node.ToString();
        }

        /// <summary>
        /// Visualizes this instance.
        /// </summary>
        /// <returns>
        /// Returns the created Viewbox object.
        /// </returns>
        public override Viewbox Visualize()
        {
            this.viewbox = base.Visualize();

            return this.viewbox;
        }
    }
}
