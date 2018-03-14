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
    public class VisualSplit : TreeVisualizationObject
    {
        private double leftFrom;
        private double topFrom;

        private double leftTo1;
        private double topTo1;

        private readonly Split split;


        public bool IsLeft { get => this.LeftTo - this.LeftFrom < 0; }

        public double LeftFrom
        {
            get
            {
                return leftFrom;
            }
            set
            {
                leftFrom = value + VisualTreeNode.SmallNodeWidth / 2;
                double myLeft = this.IsLeft ? this.LeftFrom - Math.Abs((this.LeftTo - this.LeftFrom)) / 2 : this.LeftFrom + Math.Abs((this.LeftTo - this.LeftFrom)) / 2;
                Canvas.SetLeft(this.viewbox, myLeft - VisualTreeNode.SmallNodeWidth / 2);
            }
        }
        public double TopFrom
        {
            get
            {
                return topFrom;
            }
            set
            {
                topFrom = value + VisualTreeNode.SmallNodeHeight / 2;
                double myTop = this.TopFrom + Math.Abs((this.TopTo - this.TopFrom)) / 2;
                Canvas.SetTop(this.viewbox, myTop - VisualTreeNode.SmallNodeHeight / 2);
            }
        }
        public double LeftTo
        {
            get
            {
                return leftTo1;
            }
            set
            {
                leftTo1 = value + VisualTreeNode.SmallNodeWidth /2;
                double myLeft = this.IsLeft ? this.LeftFrom - Math.Abs((this.LeftTo - this.LeftFrom)) / 2 : this.LeftFrom + Math.Abs((this.LeftTo - this.LeftFrom)) / 2;
                Canvas.SetLeft(this.viewbox, myLeft - VisualTreeNode.SmallNodeWidth / 2);
            }
        }
        public double TopTo
        {
            get
            {
                return topTo1;
            }
            set
            {
                topTo1 = value + VisualTreeNode.SmallNodeHeight / 2;
                double myTop = this.TopFrom + Math.Abs((this.TopTo - this.TopFrom)) / 2;
                Canvas.SetTop(this.viewbox, myTop - VisualTreeNode.SmallNodeHeight / 2);
            }
        }


        public VisualSplit(Split split)
        {
            this.split = split;
            this.viewbox = new Viewbox();
            base.BackgroundColor = Brushes.MediumSeaGreen;
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

        public Line GetLine()
        {
            return this.CreateLine(this.LeftFrom, this.TopFrom, this.LeftTo, this.TopTo);
        }

        public override string ToString()
        {
            return this.split.ToString();
        }
    }
}
