using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public class ExampleFactory
    {
        private readonly int dimensions;

        public ExampleFactory(int dimensions = 2)
        {
            this.dimensions = dimensions;
        }

        public ITreeExampleData GetCarExamples()
        {
            return this.GetRegressionTreeExample(@"Examples\cars_TrainingLim.csv");
        }

        public ITreeExampleData GetCarTestSet()
        {
            return this.GetRegressionTreeExample(@"Examples\cars_Test.csv");
        }

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
            catch (FileNotFoundException e)
            {
                // Todo: Error Handling
                throw e;
            }
            catch (IOException e)
            {
                // Todo: Error Handling
                throw e;
            }

            return decisionTreeExample;
        }

        public ITreeExampleData GetIrisExamples()
        {
            return this.GetDecisionTreeExample(@"Examples\iris_Training.csv");
        }

        public ITreeExampleData GetIrisTestSet()
        {
            return this.GetDecisionTreeExample(@"Examples\iris_Test.csv");
        }

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
            catch (FileNotFoundException e)
            {
                // Todo: Error Handling
                throw e;
            }
            catch (IOException e)
            {
                // Todo: Error Handling
                throw e;
            }

            return decisionTreeExample;
        }
    }
}
