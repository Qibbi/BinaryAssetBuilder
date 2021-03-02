namespace BinaryAssetBuilder.Metrics
{
    public interface IMetricsListener
    {
        void Open();

        void Close();

        void SubmitMetrics(Metric metric);
    }
}
