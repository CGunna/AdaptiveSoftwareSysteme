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

            root.Left = (this.canvas.ActualWidth / 2) - 75;
            root.Top = 10;


            this.canvas.Children.Add(root.MyBorder);
        }
    }
}
