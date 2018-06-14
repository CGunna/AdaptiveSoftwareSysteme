using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    [Serializable]
    class ClassificationResult : IClassificationResult
    {
        private readonly IExampleRow row;

        public string ClassifiedAs { get; set; }

        public IExampleRow ClassifiedRow => this.row;

        public double Value { get; set; }

        public ClassificationResult(IExampleRow row)
        {
            this.row = row;
        }

        public override string ToString()
        {
            return $"Classified as: { this.ClassifiedAs }";
        }
    }
}
