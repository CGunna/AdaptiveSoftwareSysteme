using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class ExampleFactory
    {
        public IDecisionTreeExampleData GetIrisExamples()
        {
            return this.GetDecisionTreeExample(@"Examples\iris_Mutated.csv");
        }

        private IDecisionTreeExampleData GetDecisionTreeExample(string csvPath)
        {
            IDecisionTreeExampleData decisionTreeExample = new DecisionTreeExampleData();

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
                                row.Items.Add(new Example(decisionTreeExample.Features[j], line[j]));
                        }

                        row.Class = className;
                        decisionTreeExample.ExampleRows.Add(row);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                // Todo: Error Handling
            }
            catch (IOException e)
            {
                // Todo: Error Handling
            }

            return decisionTreeExample;
        }
    }
}
