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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void RecalculateButton_Click(object sender, RoutedEventArgs e)
        {
            ExampleFactory factory = new ExampleFactory(this.GetDimension());
            MyDecisionTree tree = new MyDecisionTree(factory.GetIrisExamples());
            IGardener gardener = new ReducedErrorPruningForDecisionTrees(tree);

            this.Split(tree, gardener, factory.GetIrisTestSet());
        }

        private void RecalculateRegressionTreeButton_Click(object sender, RoutedEventArgs e)
        {
            ExampleFactory factory = new ExampleFactory(this.GetDimension());
            MyRegressionTree tree = new MyRegressionTree(factory.GetCarExamples());
            IGardener gardener = new ReducedErrorPruningForRegressionTrees(tree, 7);

            this.Split(tree, gardener, factory.GetCarTestSet());
        }

        private int GetDimension()
        {
            if (int.TryParse(this.DimensionBox.Text, out int dimension))
            {
            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
            }

            return dimension;
        }

        private void Split(DecisionTree.Implementation.Tree tree, IGardener gardener, ITreeExampleData testdata)
        {
            this.TreeCanvas.Children.Clear();

            tree.Split();

            if (this.PruneBox.IsChecked == true)
            {
                gardener.Prune(tree, testdata);
            }

            DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(tree, this.TreeCanvas);
            renderer.Visualize();
        }
    }
}
