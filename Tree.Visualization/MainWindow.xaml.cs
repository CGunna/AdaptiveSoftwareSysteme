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
            if (int.TryParse(this.DimensionBox.Text, out int dimension))
            {
                this.TreeCanvas.Children.Clear();

                ExampleFactory factory = new ExampleFactory(dimension);
                var decisiontree = new MyDecisionTree(factory.GetIrisExamples());

                decisiontree.Split();

                if (this.PruneBox.IsChecked == true)
                {
                    IGardener pruner = new ReducedErrorPruning();
                    var examples = factory.GetIrisTestSet();

                    pruner.Prune(decisiontree, examples);
                }

                DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(decisiontree, this.TreeCanvas);
                renderer.Visualize();
            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
            }
        }

        private void RecalculateRegressionTreeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(this.DimensionBox.Text, out int dimension))
            {
                this.TreeCanvas.Children.Clear();

                ExampleFactory factory = new ExampleFactory(dimension);
                var regressionTree = new MyRegressionTree(factory.GetCarExamples());
                regressionTree.Split();


            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
            }
        }
    }
}
