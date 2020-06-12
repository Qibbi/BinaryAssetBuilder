using System;

namespace BinaryAssetBuilder.Core
{
    public class MetricTimer : IDisposable
    {
        private DateTime _startTime = DateTime.Now;
        private string _userData;
        private string _descriptorName;

        public MetricTimer(string descriptorName, string userData)
        {
            _descriptorName = descriptorName;
            _userData = userData;
        }

        public MetricTimer(MetricDescriptor descriptor, string userData) : this(descriptor.Name, userData)
        {
        }

        public MetricTimer(string descriptorName) : this(descriptorName, null)
        {
        }

        public MetricTimer(MetricDescriptor descriptor) : this(descriptor.Name, null)
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