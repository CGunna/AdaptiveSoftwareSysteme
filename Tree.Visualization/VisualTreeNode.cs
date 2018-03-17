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
    public class VisualTreeNode : TreeVisualizationObject
    {

        private double left;

        private double top;

        private VisualSplit[] outgoingSplits;

        public readonly Node node;

        public bool IsLeaf => this.node.IsLeaf;

        public VisualTreeNode(Node actualNode)
        {
            this.node = actualNode;
            this.outgoingSplits = new VisualSplit[2];
            this.viewbox = new Viewbox();

            VisualSplit leftSplit = new VisualSplit(this.node.OutgoingSplit);
            this.OutgoingSplits[0] = leftSplit;

            VisualSplit rightSplit = new VisualSplit(this.node.OutgoingSplit);
            this.OutgoingSplits[1] = rightSplit;
        }

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

        public override string ToString()
        {
            return this.node.ToString();
        }

        public override Viewbox Visualize()
        {
            this.viewbox = base.Visualize();

            return this.viewbox;
        }
    }
}
