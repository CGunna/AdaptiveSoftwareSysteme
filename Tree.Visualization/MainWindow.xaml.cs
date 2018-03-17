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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDecisionTree tree;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void RecalculateButton_Click(object sender, RoutedEventArgs e)
        {
            this.TreeCanvas.Children.Clear();

            int dimension = 0;
            if (int.TryParse(this.DimensionBox.Text, out dimension))
            {
                ExampleFactory factory = new ExampleFactory(dimension);
                this.tree = new MyDecisionTree(factory.GetIrisExamples());

                this.tree.RootNode.TrySplit();

                DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(this.tree, this.TreeCanvas);
                renderer.Visualize();
            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
            }
        }
    }
}
