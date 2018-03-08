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

        private double leftTo2;
        private double topTo2;

        private readonly Split split;


        public double LeftFrom
        {
            get { return leftFrom; }
            set { leftFrom = value; }
        }
        public double TopFrom
        {
            get { return topFrom; }
            set { topFrom = value; }
        }
        public double LeftTo1
        {
            get { return leftTo1; }
            set { leftTo1 = value; }
        }
        public double TopTo1
        {
            get { return topTo1; }
            set { topTo1 = value; }
        }
        public double LeftTo2
        {
            get { return leftTo2; }
            set { leftTo2 = value; }
        }
        public double TopTo2
        {
            get { return topTo2; }
            set { topTo2 = value; }
        }


        public VisualSplit(Split split)
        {
            this.split = split;
        }

        public Line GetLeftLine()
        {
            return this.CreateLine(leftFrom, topFrom, leftTo1, topTo1);
        }

        public Line GetRightLine()
        {
            return this.CreateLine(leftFrom, topFrom, leftTo2, topTo2);
        }

        private Line CreateLine(double leftFrom, double topFrom, double leftTo, double topTo)
        {
            Line line = new Line();
            line.X1 = leftFrom;
            line.Y1 = topFrom;

            line.X2 = leftTo;
            line.Y2 = topTo;

            return line;
        }
    }
}
