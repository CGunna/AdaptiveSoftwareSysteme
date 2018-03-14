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
    public abstract class TreeVisualizationObject
    {
        public const int NodeWidth = 150;
        public const int NodeHeight = 100;

        public const int SmallNodeWidth = 45;
        public const int SmallNodeHeight = 30;
        protected Brush BackgroundColor = Brushes.Tomato;

        private int zIndex = 5;

        protected Viewbox viewbox;

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

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.viewbox.Width = NodeWidth;
            this.viewbox.Height = NodeHeight;
            Canvas.SetZIndex(this.viewbox, int.MaxValue);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.viewbox.Width = SmallNodeWidth;
            this.viewbox.Height = SmallNodeHeight;
            Canvas.SetZIndex(this.viewbox, this.zIndex);
        }
    }
}
