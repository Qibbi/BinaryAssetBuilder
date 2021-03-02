namespace BinaryAssetBuilder.Metrics
{
    public class MetricDescriptor
    {
        public string Name { get; }
        public MetricType Type { get; }
        public string Description { get; }

        public MetricDescriptor(string name, MetricType type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }
    }
}
