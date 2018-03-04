namespace DecisionTree.Implementation
{
    internal class Feature : IFeature
    {
        public string Name { get; set; }

        public Feature(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}