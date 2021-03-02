using System;

namespace BinaryAssetBuilder.Metrics
{
    public class MetricTimer : IDisposable
    {
        private readonly DateTime _startTime = DateTime.Now;
        private readonly string _userData;
        private readonly string _descriptorName;

        public MetricTimer(string descriptorName, string userData = null)
        {
            _descriptorName = descriptorName;
            _userData = userData;
        }

        public MetricTimer(MetricDescriptor descriptor, string userData = null) : this(descriptor.Name, userData)
        {
        }

        public void Dispose()
        {
            TimeSpan time = DateTime.Now - _startTime;
            if (!string.IsNullOrEmpty(_userData))
            {
                MetricManager.Submit(_descriptorName, time, _userData);
            }
            else
            {
                MetricManager.Submit(_descriptorName, time);
            }
        }
    }
}
