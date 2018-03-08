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
    class VisualTreeNode
    {
        private double left;

        private double top;

        private readonly Node node;

        public VisualTreeNode(Node actualNode)
        {
            this.node = actualNode;
            this.Visualize();
        }

        /// <summary>
        /// Gets or sets the border of the node.
        /// </summary>
        /// <value>
        /// The border of the node.
        /// </value>
        public Viewbox MyBorder { get; set; }

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
                Canvas.SetLeft(this.MyBorder, this.left);
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
                this.top = value + (this.MyBorder.Height / 2);
                Canvas.SetTop(this.MyBorder, this.top);
            }
        }

        public override string ToString()
        {
            return this.node.ToString();
        }

        private void Visualize()
        {
            this.MyBorder = new Viewbox();
            this.MyBorder.Width = 150;
            this.MyBorder.Height = 100;

            Grid grid = new Grid();
            Ellipse circle = new Ellipse();
            circle.HorizontalAlignment = HorizontalAlignment.Center;
            circle.Height = 100;
            circle.Fill = new SolidColorBrush(Colors.White);
            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.VerticalAlignment = VerticalAlignment.Center;
            circle.Width = 150;
            circle.Opacity = 1;
            Canvas.SetZIndex(circle, -5);

            TextBlock block = new TextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.Text = this.ToString();
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 10;
            block.Foreground = new SolidColorBrush(Colors.Black);
            grid.Children.Add(block);
            grid.Children.Add(circle);

            this.MyBorder.Child = grid;
        }
    }
}
