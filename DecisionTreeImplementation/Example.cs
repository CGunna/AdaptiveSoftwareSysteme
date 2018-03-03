namespace DecisionTree.Implementation
{
    public class Example
    {
        public Feature RelatedFeature { get; set; }

        public object Value { get; set; }

        public Example()
        {
        }

        public Example(Feature feature, object value)
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