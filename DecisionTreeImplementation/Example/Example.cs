﻿namespace DecisionTree.Implementation
{
    internal class Example : IExample
    {
        public IFeature RelatedFeature { get; set; }

        public object Value { get; set; }

        public Example()
        {
        }

        public Example(IFeature feature, object value)
        {
            this.RelatedFeature = feature;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.RelatedFeature?.Name}: {this.Value}";
        }
    }
}