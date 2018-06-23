// ----------------------------------------------------------------------- 
// <copyright file="MainWindow.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the MainWindow class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace Tree.Visualization
{
    using DecisionTree.Implementation;
    using Microsoft.Win32;
    using System.Windows;

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The created tree.
        /// </summary>
        private DecisionTree.Implementation.Tree tree;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the RecalculateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RecalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExampleFactory factory = new ExampleFactory(this.GetDimension());
                this.tree = new MyDecisionTree(factory.GetIrisExamples());
                IGardener gardener = new ReducedErrorPruningForDecisionTrees((MyDecisionTree)tree);

                this.Split(tree, gardener, factory.GetIrisTestSet());
            }
            catch (DecisionTree.Implementation.Exceptions.TreeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the RecalculateRegressionTreeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RecalculateRegressionTreeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExampleFactory factory = new ExampleFactory(this.GetDimension());
                this.tree = new MyRegressionTree(factory.GetCarExamples());
                IGardener gardener = new ReducedErrorPruningForRegressionTrees((MyRegressionTree)tree, 7);

                this.Split(tree, gardener, factory.GetCarTestSet());
            }
            catch (DecisionTree.Implementation.Exceptions.TreeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <returns>The dimension.</returns>
        private int GetDimension()
        {
            if (!int.TryParse(this.DimensionBox.Text, out int dimension))
            {
                MessageBox.Show("Dimension has to be an integer number!");
                return -1;
            }

            return dimension;
        }

        /// <summary>
        /// Splits the specified tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="gardener">The gardener.</param>
        /// <param name="testdata">The testdata.</param>
        private void Split(DecisionTree.Implementation.Tree tree, IGardener gardener, ITreeExampleData testdata)
        {
            tree.Split();

            if (this.PruneBox.IsChecked == true)
            {
                gardener.Prune(tree, testdata);
            }

            DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(tree, this.TreeCanvas);
            renderer.Visualize();
        }

        /// <summary>
        /// Handles the Click event of the ImportButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "dat files (*.dat)|*.dat";
            DecisionTree.Implementation.Interfaces.ITreeSaver treeSaver = new BinaryTreeSaver();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    this.tree = treeSaver.Import(openFileDialog.FileName);

                    DecisionTreeWPFRenderer renderer = new DecisionTreeWPFRenderer(tree, this.TreeCanvas);
                    renderer.Visualize();
                }
                catch (DecisionTree.Implementation.Exceptions.TreeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ExportButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".dat";
            if (saveFileDialog.ShowDialog() == true)
            {
                var path = saveFileDialog.FileName;

                DecisionTree.Implementation.Interfaces.ITreeSaver treeSaver = new BinaryTreeSaver();

                try
                {
                    treeSaver.Export(this.tree, path);
                }
                catch (DecisionTree.Implementation.Exceptions.TreeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ImportCSVButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ImportCSVButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
