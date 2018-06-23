// ----------------------------------------------------------------------- 
// <copyright file="ExampleFactory.cs" company="Gunter Wiesinger"> 
// Copyright (c) Gunter Wiesinger. All rights reserved. 
// </copyright> 
// <summary>Contains the implementation of the ExampleFactory class.</summary> 
// <author>Gunter Wiesinger/Auto generated</author> 
// -----------------------------------------------------------------------
namespace DecisionTree.Implementation
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Represens the ExampleFactory class.
    /// </summary>
    public class ExampleFactory
    {
        /// <summary>
        /// The dimensions to use.
        /// </summary>
        private readonly int dimensions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleFactory"/> class.
        /// </summary>
        /// <param name="dimensions">The dimensions.</param>
        /// <exception cref="DecisionTree.Implementation.Exceptions.InvalidArgumentException">Dimension has to be greater than 0!</exception>
        public ExampleFactory(int dimensions = 2)
        {
            if (dimensions <= 0)
            {
                throw new Exceptions.InvalidArgumentException("Dimension has to be greater than 0!");
            }

            this.dimensions = dimensions;
        }

        /// <summary>
        /// Gets the car examples.
        /// </summary>
        /// <returns>The example data object.</returns>
        public ITreeExampleData GetCarExamples()
        {
            return this.GetRegressionTreeExample(@"Examples\cars_TrainingLim.csv");
        }

        /// <summary>
        /// Gets the car test set.
        /// </summary>
        /// <returns>The example data object.</returns>
        public ITreeExampleData GetCarTestSet()
        {
            return this.GetRegressionTreeExample(@"Examples\cars_Test.csv");
        }

        /// <summary>
        /// Gets the regression tree example.
        /// </summary>
        /// <param name="csvPath">The CSV path.</param>
        /// <returns>The example data object.</returns>
        /// <exception cref="ArgumentException">CSV has to have an estimation column!</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.InvalidArgumentException">CSV has to have an estimation column!</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.IOException">An IO operation went wrong!</exception>
        private ITreeExampleData GetRegressionTreeExample(string csvPath)
        {
            ITreeExampleData decisionTreeExample = new DecisionTreeExampleData(this.dimensions);
            string estimationItemName = string.Empty;
            try
            {
                var lines = File.ReadAllLines(csvPath).Select(x => x.Split(';')).ToArray();
                int estimationColumn = -1;
                // We assume that the first row contains the feature names
                // The rest should be the examples
                for (int i = 0; i < lines.Length; i++) // Rows
                {
                    // Feature
                    if (i == 0)
                    {
                        // filter empty columns
                        var line = lines[i].Where(x => x != string.Empty).ToArray();

                        estimationColumn = line.Length;
                        // Columns
                        for (int j = 0; j < line.Length; j++)
                        {
                            decisionTreeExample.Features.Add(new Feature(line[j]));

                            if (j == estimationColumn - 1)
                            {
                                estimationItemName = line[j];
                            }
                        }
                    }
                    else // Example
                    {
                        if (estimationColumn <= 0)
                            throw new ArgumentException("CSV has to have an estimation column!");

                        // filter empty columns
                        var line = lines[i].Where(x => x != string.Empty).ToArray();

                        string className = string.Empty;
                        // Create row
                        ExampleRow row = new ExampleRow();

                        // Columns
                        for (int j = 0; j < line.Length; j++)
                        {
                            row.Items.Add(new Example(decisionTreeExample.Features[j], double.Parse(line[j])));
                        }

                        row.Class = estimationItemName;
                        decisionTreeExample.ExampleRows.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is IOException || e is ArgumentException)
                {
                    if (e is ArgumentException)
                    {
                        throw new Exceptions.InvalidArgumentException(e.Message);
                    }

                    throw new Exceptions.IOException();
                }

                throw e;
            }

            return decisionTreeExample;
        }

        /// <summary>
        /// Gets the iris examples.
        /// </summary>
        /// <returns>The tree example data object.</returns>
        public ITreeExampleData GetIrisExamples()
        {
            return this.GetDecisionTreeExample(@"Examples\iris_Training.csv");
        }

        /// <summary>
        /// Gets the iris test set.
        /// </summary>
        /// <returns>The tree example data object.</returns>
        public ITreeExampleData GetIrisTestSet()
        {
            return this.GetDecisionTreeExample(@"Examples\iris_Test.csv");
        }

        /// <summary>
        /// Gets the decision tree example.
        /// </summary>
        /// <param name="csvPath">The CSV path.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">CSV has to have a class column!</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.InvalidArgumentException">CSV has to have an estimation column!</exception>
        /// <exception cref="DecisionTree.Implementation.Exceptions.IOException">An IO operation went wrong!</exception>
        private ITreeExampleData GetDecisionTreeExample(string csvPath)
        {
            ITreeExampleData decisionTreeExample = new DecisionTreeExampleData(this.dimensions);

            try
            {
                var lines = File.ReadAllLines(csvPath).Select(x => x.Split(';')).ToArray();
                int classColumn = -1;
                // We assume that the first row contains the feature names
                // The rest should be the examples
                for (int i = 0; i < lines.Length; i++) // Rows
                {
                    // Feature
                    if (i == 0)
                    {
                        // filter empty columns
                        var line = lines[i].Where(x => x != string.Empty).ToArray();

                        // Columns
                        for (int j = 0; j < line.Length; j++)
                        {
                            if (line[j].ToUpper() != "class".ToUpper())
                                // Add Feature
                                decisionTreeExample.Features.Add(new Feature(line[j]));
                            else
                                classColumn = j;
                        }
                    }
                    else // Example
                    {
                        if (classColumn <= 0)
                            throw new ArgumentException("CSV has to have a class column!");

                        // filter empty columns
                        var line = lines[i].Where(x => x != string.Empty).ToArray();

                        string className = string.Empty;
                        // Create row
                        ExampleRow row = new ExampleRow();

                        // Columns
                        for (int j = 0; j < line.Length; j++)
                        {
                            if (j == classColumn)
                                className = line[j];
                            else
                                // Add Items to row
                                row.Items.Add(new Example(decisionTreeExample.Features[j], double.Parse(line[j])));
                        }

                        row.Class = className;
                        decisionTreeExample.ExampleRows.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is IOException || e is ArgumentException)
                {
                    if (e is ArgumentException)
                    {
                        throw new Exceptions.InvalidArgumentException(e.Message);
                    }

                    throw new Exceptions.IOException();
                }

                throw e;
            }

            return decisionTreeExample;
        }
    }
}
