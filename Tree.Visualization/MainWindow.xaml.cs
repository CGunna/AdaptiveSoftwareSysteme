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
            if (int.TryParse(this.DimensionBox.Text, out int dimension))
            {
                this.TreeCanvas.Children.Clear();

                ExampleFactory factory = new ExampleFactory(dimension);
                this.tree = new MyDecisionTree(factory.GetIrisExamples());

                this.tree.Split();

                DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(this.tree, this.TreeCanvas);
                renderer.Visualize();

                var examples = factory.GetIrisTestSet();

                this.tree.Prune(examples);
            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
            }
        }
    }
}
