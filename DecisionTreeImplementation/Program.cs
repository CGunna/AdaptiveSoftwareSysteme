using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleFactory exampleFactory = new ExampleFactory();

            IDecisionTreeExampleData decisionTreeExample = exampleFactory.GetIrisExamples();

            DecisionTree tree = new DecisionTree(decisionTreeExample);

            Console.WriteLine("Start Entropie: " + tree.RootNode.GetEntropie());

            tree.RootNode.TrySplit();
            Console.ReadKey(true);
        }
    }
}
