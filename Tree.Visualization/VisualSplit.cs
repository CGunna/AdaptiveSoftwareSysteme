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
    public class VisualSplit
    {
        private double leftFrom;
        private double topFrom;

        private double leftTo1;
        private double topTo1;

        private readonly Split split;


        public bool IsLeft { get => this.LeftTo - this.LeftFrom < 0; }

        public double LeftFrom
        {
            get { return leftFrom; }
            set { leftFrom = value + VisualTreeNode.SmallNodeWidth / 2; }
        }
        public double TopFrom
        {
            get { return topFrom; }
            set { topFrom = value + VisualTreeNode.SmallNodeHeight / 2; }
        }
        public double LeftTo
        {
            get { return leftTo1; }
            set { leftTo1 = value + VisualTreeNode.SmallNodeWidth /2; }
        }
        public double TopTo
        {
            get { return topTo1; }
            set { topTo1 = value + VisualTreeNode.SmallNodeHeight / 2; }
        }

        public Viewbox MyBorder { get; set; }

        public VisualSplit(Split split)
        {
            this.split = split;
        }

        private Line CreateLine(double leftFrom, double topFrom, double leftTo, double topTo)
        {
            Line line = new Line();
            line.X1 = leftFrom;
            line.Y1 = topFrom;

            line.X2 = leftTo;
            line.Y2 = topTo;

            line.StrokeThickness = 2;
            line.Stroke = Brushes.Black;

            Canvas.SetZIndex(line, -100);
            return line;
        }

        private void VisualizeInformation()
        {
            this.MyBorder = new Viewbox();

            
            // Calculation Position of the Box
            double myLeft = this.IsLeft ? this.LeftFrom - Math.Abs((this.LeftTo - this.LeftFrom)) / 2 : this.LeftFrom + Math.Abs((this.LeftTo - this.LeftFrom)) / 2;
            double myTop = this.TopFrom + Math.Abs((this.TopTo - this.TopFrom)) / 2;

            Canvas.SetLeft(this.MyBorder, myLeft - VisualTreeNode.SmallNodeWidth / 2);
            Canvas.SetTop(this.MyBorder, myTop - VisualTreeNode.SmallNodeHeight / 2);
            this.MyBorder.Width = VisualTreeNode.SmallNodeWidth;
            this.MyBorder.Height = VisualTreeNode.SmallNodeHeight;


            Grid layout = new Grid();

            Grid grid = new Grid();
            Rectangle circle = new Rectangle();
            circle.HorizontalAlignment = HorizontalAlignment.Center;
            circle.Height = VisualTreeNode.NodeHeight;
            circle.Fill = new SolidColorBrush(Colors.BlueViolet);
            circle.Stroke = new SolidColorBrush(Colors.White);
            circle.VerticalAlignment = VerticalAlignment.Center;
            circle.Width = VisualTreeNode.NodeWidth;
            circle.Opacity = 1;
            Canvas.SetZIndex(circle, -5);

            TextBlock block = new TextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.Text = this.ToString();
            //block.Text = "Hallo";
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 13;
            block.Foreground = new SolidColorBrush(Colors.White);
            grid.Children.Add(block);
            grid.Children.Add(circle);
            grid.MouseLeave += Grid_MouseLeave;
            grid.MouseEnter += Grid_MouseEnter;

            Canvas.SetZIndex(circle, -65);

            layout.Children.Add(grid);

            this.MyBorder.Child = layout;
        }

        public Line GetLine()
        {
            this.VisualizeInformation();
            return this.CreateLine(this.LeftFrom, this.TopFrom, this.LeftTo, this.TopTo);
        }


        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MyBorder.Width = VisualTreeNode.NodeWidth;
            this.MyBorder.Height = VisualTreeNode.NodeHeight;
            Canvas.SetZIndex(this.MyBorder, int.MaxValue);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.MyBorder.Width = VisualTreeNode.SmallNodeWidth;
            this.MyBorder.Height = VisualTreeNode.SmallNodeHeight;
            Canvas.SetZIndex(this.MyBorder, 0);
        }
        
        public override string ToString()
        {
            return this.split.ToString();
        }
    }
}
