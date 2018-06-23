// ----------------------------------------------------------------------- 
// <copyright file="DecisionTreeWPFRenderer.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the DecisionTreeWPFRenderer class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace Tree.Visualization
{
    using System.Windows.Controls;

    /// <summary>
    /// Represenst the DecisionTreeWPFRenderer class.
    /// </summary>
    class DecisionTreeWPFRenderer
    {
        /// <summary>
        /// The canvas to draw on.
        /// </summary>
        private Canvas canvas;

        /// <summary>
        /// The tree that has to be drawn.
        /// </summary>
        private DecisionTree.Implementation.Tree tree;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionTreeWPFRenderer"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="canvas">The canvas.</param>
        public DecisionTreeWPFRenderer(DecisionTree.Implementation.Tree tree, Canvas canvas)
        {
            this.tree = tree;
            this.canvas = canvas;
            this.canvas.Children.Clear();
        }

        /// <summary>
        /// Visualizes this instance.
        /// </summary>
        public void Visualize()
        {
            // create VisualTreeNode for RootNode
            VisualTreeNode root = new VisualTreeNode(this.tree.RootNode);

            // calculate the coordinates to begin with
            double startLeft = (this.canvas.ActualWidth / 2) - VisualTreeNode.SmallNodeWidth / 2;

            this.DrawNode(root, startLeft, 10, 2.5);
        }

        /// <summary>
        /// Draws the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="divisor">The divisor.</param>
        private void DrawNode(VisualTreeNode node, double left, double top, double divisor)
        {
            node.Left = left;
            node.Top = top;
            // Draw Node
            this.canvas.Children.Add(node.Visualize());

            // Recursion for left side
            if (node.node.LeftNode != null)
            {
                VisualSplit leftSplit = node.OutgoingSplits[0];
                leftSplit.LeftFrom = left;
                leftSplit.TopFrom = top;

                leftSplit.LeftTo = left - left / divisor;
                leftSplit.TopTo = top + 100;

                this.canvas.Children.Add(leftSplit.GetLine());
                this.canvas.Children.Add(leftSplit.Visualize());

                VisualTreeNode leftNode = new VisualTreeNode(node.node.LeftNode);
                this.DrawNode(leftNode, left - left / divisor, top + 100, divisor * 2);
            }

            // Recursion for right side
            if (node.node.RightNode != null)
            {
                VisualSplit rightSplit = node.OutgoingSplits[1];
                rightSplit.LeftFrom = left;
                rightSplit.TopFrom = top;

                rightSplit.LeftTo = left + left / divisor;
                rightSplit.TopTo = top + 100;
                this.canvas.Children.Add(rightSplit.GetLine());
                this.canvas.Children.Add(rightSplit.Visualize());

                VisualTreeNode rightNode = new VisualTreeNode(node.node.RightNode);
                this.DrawNode(rightNode, left + left / divisor, top + 100, divisor * 2);
            }
        }
    }
}
