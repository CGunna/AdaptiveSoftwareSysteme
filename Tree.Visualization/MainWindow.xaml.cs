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
using Microsoft.Win32;

namespace Tree.Visualization
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DecisionTree.Implementation.Tree tree;

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
            this.tree = new MyDecisionTree(factory.GetIrisExamples());
            IGardener gardener = new ReducedErrorPruningForDecisionTrees((MyDecisionTree)tree);

            this.Split(tree, gardener, factory.GetIrisTestSet());
        }

        private void RecalculateRegressionTreeButton_Click(object sender, RoutedEventArgs e)
        {
            ExampleFactory factory = new ExampleFactory(this.GetDimension());
            this.tree = new MyRegressionTree(factory.GetCarExamples());
            IGardener gardener = new ReducedErrorPruningForRegressionTrees((MyRegressionTree)tree, 7);

            this.Split(tree, gardener, factory.GetCarTestSet());
        }

        private int GetDimension()
        {
            if (int.TryParse(this.DimensionBox.Text, out int dimension))
            {
                if (dimension <= 0)
                {
                    MessageBox.Show("Dimension has to greater than zero!");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Dimension has to be an integer number!");
                return -1;
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

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            DecisionTree.Implementation.Interfaces.ITreeSaver treeSaver = new BinaryTreeSaver();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    this.tree = treeSaver.Import(openFileDialog.FileName);
                }
                catch (DecisionTree.Implementation.Exceptions.IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(tree, this.TreeCanvas);
            renderer.Visualize();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var path = saveFileDialog.FileName;

                DecisionTree.Implementation.Interfaces.ITreeSaver treeSaver = new BinaryTreeSaver();

                try
                {
                    treeSaver.Export(this.tree, path);
                }
                catch (DecisionTree.Implementation.Exceptions.IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
