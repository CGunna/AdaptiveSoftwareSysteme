using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeImplementation
{
    class ExampleFactory
    {
        public DecisionTree CreateWeatherExample()
        {
            var tree = new DecisionTree("Weather");

            tree.Root.AddChild("False", "Rainy");
            tree.Root.AddChild("True", "Cloudy");

            return tree;
        }
    }
}
