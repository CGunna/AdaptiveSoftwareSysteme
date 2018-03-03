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
        public IDecisionTreeExample GetIrisExamples()
        {
            return this.GetDecisionTreeExample(@"Examples\iris.csv");
        }

        private IDecisionTreeExample GetDecisionTreeExample(string csvPath)
        {
            IDecisionTreeExample decisionTreeExample = new DecisionTreeExample();

            try
            {
                var lines = File.ReadAllLines(csvPath).Select(x => x.Split(';')).ToArray();

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
                            // Add Feature
                            decisionTreeExample.Features.Add(new Feature(line[j]));
                    }
                    else // Example
                    {
                        // filter empty columns
                        var line = lines[i].Where(x => x != string.Empty).ToArray();

                        // Create row
                        ExampleRow row = new ExampleRow();

                        // Columns
                        for (int j = 0; j < line.Length; j++)
                            // Add Items to row
                            row.Items.Add(new Example(decisionTreeExample.Features[j], line[j]));

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
