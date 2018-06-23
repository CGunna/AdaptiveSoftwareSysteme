// ----------------------------------------------------------------------- 
// <copyright file="VisualSplit.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the VisualSplit class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace Tree.Visualization
{
    using DecisionTree.Implementation;
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents the VisualSplit class.
    /// </summary>
    /// <seealso cref="Tree.Visualization.TreeVisualizationObject" />
    public class VisualSplit : TreeVisualizationObject
    {
        /// <summary>
        /// The left from.
        /// </summary>
        private double leftFrom;

        /// <summary>
        /// The top from.
        /// </summary>
        private double topFrom;

        /// <summary>
        /// The left to1.
        /// </summary>
        private double leftTo1;

        /// <summary>
        /// The top to1.
        /// </summary>
        private double topTo1;

        /// <summary>
        /// The split.
        /// </summary>
        private readonly Split split;

        /// <summary>
        /// Gets a value indicating whether this instance is left.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is left; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeft { get => this.LeftTo - this.LeftFrom < 0; }

        /// <summary>
        /// Gets or sets the left from.
        /// </summary>
        /// <value>
        /// The left from.
        /// </value>
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

        /// <summary>
        /// Gets or sets the top from.
        /// </summary>
        /// <value>
        /// The top from.
        /// </value>
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

        /// <summary>
        /// Gets or sets the left to.
        /// </summary>
        /// <value>
        /// The left to.
        /// </value>
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

        /// <summary>
        /// Gets or sets the top to.
        /// </summary>
        /// <value>
        /// The top to.
        /// </value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualSplit"/> class.
        /// </summary>
        /// <param name="split">The split.</param>
        public VisualSplit(Split split)
        {
            this.split = split;
            this.viewbox = new Viewbox();
            base.BackgroundColor = Brushes.MediumSeaGreen;
        }

        /// <summary>
        /// Creates the line.
        /// </summary>
        /// <param name="leftFrom">The left from.</param>
        /// <param name="topFrom">The top from.</param>
        /// <param name="leftTo">The left to.</param>
        /// <param name="topTo">The top to.</param>
        /// <returns>The created line.</returns>
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

        /// <summary>
        /// Gets the line.
        /// </summary>
        /// <returns>The created line.</returns>
        public Line GetLine()
        {
            return this.CreateLine(this.LeftFrom, this.TopFrom, this.LeftTo, this.TopTo);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.split.ToString(this.IsLeft);
        }
    }
}
