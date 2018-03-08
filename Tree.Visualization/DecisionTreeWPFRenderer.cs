using System;
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
        private MyDecisionTree tree;

        public DecisionTreeWPFRenderer(MyDecisionTree tree, Canvas canvas)
        {
            this.tree = tree;
            this.canvas = canvas;
        }

        public void Visualize()
        {
            // create VisualTreeNode for RootNode
            VisualTreeNode root = new VisualTreeNode(this.tree.RootNode);

            this.DrawNode(root, (this.canvas.ActualWidth / 2) - VisualTreeNode.NodeWidth / 2, 10);
        }

        private void DrawNode(VisualTreeNode node, double left, double top)
        {
            node.Left = left;
            node.Top = top;

            // Draw Node
            this.canvas.Children.Add(node.MyBorder);

            // TODO Draw Lines
            if (node.node.LeftNode != null)
            {
                VisualTreeNode leftNode = new VisualTreeNode(node.node.LeftNode);
                double newLeft = left - ((leftNode.OldLeft == 0 ? left : leftNode.OldLeft) - left) / 2.1;
                this.DrawNode(leftNode, newLeft, top + 100);
            }

            if (node.node.RightNode != null)
            {
                VisualTreeNode rightNode = new VisualTreeNode(node.node.RightNode);
                this.DrawNode(rightNode, left + left / 2.1 + VisualTreeNode.NodeWidth / 2, top + 100);
            }
        }
    }
}
