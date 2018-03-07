using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    public interface IExample
    {
        IFeature RelatedFeature { get; set; }

        double Value { get; set; }
    }
}
