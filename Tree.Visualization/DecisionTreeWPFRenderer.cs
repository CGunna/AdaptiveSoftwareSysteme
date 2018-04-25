﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DecisionTree.Implementation;

namespace Tree.Visualization
{
    class DecisionTreeWPFRenderer
    {
        private Canvas canvas;
        private DecisionTree.Implementation.Tree tree;

        public DecisionTreeWPFRenderer(DecisionTree.Implementation.Tree tree, Canvas canvas)
        {
            this.tree = tree;
            this.canvas = canvas;
        }

        public void Visualize()
        {
            // create VisualTreeNode for RootNode
            VisualTreeNode root = new VisualTreeNode(this.tree.RootNode);

            // calculate the coordinates to begin with
            double startLeft = (this.canvas.ActualWidth / 2) - VisualTreeNode.SmallNodeWidth / 2;

            this.DrawNode(root, startLeft, 10, 2.5);
        }

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
