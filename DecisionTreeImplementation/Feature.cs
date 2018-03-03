namespace DecisionTree.Implementation
{
    public class Feature
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