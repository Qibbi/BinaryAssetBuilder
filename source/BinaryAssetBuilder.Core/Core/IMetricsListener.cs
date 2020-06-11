namespace BinaryAssetBuilder.Core
{
    public interface IMetricsListener
    {
        void Open();

        void Close();

        void SubmitMetrics(Metric metric);
    }
}