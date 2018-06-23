// ----------------------------------------------------------------------- 
// <copyright file="TreeVisualizationObject.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the TreeVisualizationObject class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace Tree.Visualization
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents the TreeVisualizationObject class.
    /// </summary>
    public abstract class TreeVisualizationObject
    {
        /// <summary>
        /// The node width
        /// </summary>
        public const int NodeWidth = 150;

        /// <summary>
        /// The node height
        /// </summary>
        public const int NodeHeight = 100;

        /// <summary>
        /// The small node width
        /// </summary>
        public const int SmallNodeWidth = 45;

        /// <summary>
        /// The small node height
        /// </summary>
        public const int SmallNodeHeight = 30;

        /// <summary>
        /// The background color
        /// </summary>
        protected Brush BackgroundColor = Brushes.Tomato;

        /// <summary>
        /// The z index
        /// </summary>
        private int zIndex = 5;

        /// <summary>
        /// The viewbox to draw in.
        /// </summary>
        protected Viewbox viewbox;

        /// <summary>
        /// Visualizes this instance.
        /// </summary>
        /// <returns>Returns the created Viewbox object.</returns>
        public virtual Viewbox Visualize()
        {
            this.viewbox.Width = SmallNodeWidth;
            this.viewbox.Height = SmallNodeWidth;

            Grid layout = new Grid();

            Grid grid = new Grid();
            Rectangle circle = new Rectangle();
            circle.HorizontalAlignment = HorizontalAlignment.Center;
            circle.Height = NodeHeight;
            circle.Fill = this.BackgroundColor;
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

            this.viewbox.Child = layout;

            return this.viewbox;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.viewbox.Width = NodeWidth;
            this.viewbox.Height = NodeHeight;
            Canvas.SetZIndex(this.viewbox, int.MaxValue);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.viewbox.Width = SmallNodeWidth;
            this.viewbox.Height = SmallNodeHeight;
            Canvas.SetZIndex(this.viewbox, this.zIndex);
        }
    }
}
