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
        public const int NodeWidth = 150;
        public const int NodeHeight = 100;

        public const int SmallNodeWidth = 45;
        public const int SmallNodeHeight = 30;

        private double left;

        private double top;

        private double oldLeft;
        private double oldTop;
        private VisualSplit[] outgoingSplits;

        public readonly Node node;

        public VisualTreeNode(Node actualNode)
        {
            this.node = actualNode;
            this.Visualize();
            this.outgoingSplits = new VisualSplit[2];
        }

        /// <summary>
        /// Gets or sets the border of the node.
        /// </summary>
        /// <value>
        /// The border of the node.
        /// </value>
        public Viewbox MyBorder { get; set; }

        public VisualSplit[] OutgoingSplits
        {
            get { return this.outgoingSplits; }
            set { this.outgoingSplits = value; }
        }

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
                this.top = value;
                //this.top = value + (this.MyBorder.Height / 2);
                Canvas.SetTop(this.MyBorder, this.top);
            }
        }

        public override string ToString()
        {
            return this.node.ToString();
        }

        public void BuildSplits()
        {
            VisualSplit leftSplit = new VisualSplit(this.node.OutgoingSplit);
            leftSplit.LeftFrom = this.Left;
            leftSplit.LeftTo = this.Top;

            this.OutgoingSplits[0] = leftSplit;

            VisualSplit rightSplit = new VisualSplit(this.node.OutgoingSplit);
            rightSplit.LeftFrom = this.Left;
            rightSplit.LeftTo = this.Top;

            this.OutgoingSplits[1] = rightSplit;
        }

        private void Visualize()
        {
            this.MyBorder = new Viewbox();
            this.MyBorder.Width = SmallNodeWidth;
            this.MyBorder.Height = SmallNodeWidth;

            Grid layout = new Grid();

            Grid grid = new Grid();
            Rectangle circle = new Rectangle();
            circle.HorizontalAlignment = HorizontalAlignment.Center;
            circle.Height = NodeHeight;
            circle.Fill = new SolidColorBrush(Colors.Turquoise);
            circle.Stroke = new SolidColorBrush(Colors.White);
            circle.VerticalAlignment = VerticalAlignment.Center;
            circle.Width = NodeWidth;
            circle.Opacity = 1;
            Canvas.SetZIndex(circle, -5);

            TextBlock block = new TextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.Text = this.ToString();
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 13;
            block.Foreground = new SolidColorBrush(Colors.White);
            grid.Children.Add(block);
            grid.Children.Add(circle);
            
            grid.MouseLeave += Grid_MouseLeave;
            grid.MouseEnter += Grid_MouseEnter;
            
            layout.Children.Add(grid);
            
            this.MyBorder.Child = layout;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MyBorder.Width = NodeWidth;
            this.MyBorder.Height = NodeHeight;
            Canvas.SetZIndex(this.MyBorder, int.MaxValue);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.MyBorder.Width = SmallNodeWidth;
            this.MyBorder.Height = SmallNodeHeight;
            Canvas.SetZIndex(this.MyBorder, 5);
        }
    }
}
