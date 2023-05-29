using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace BinaryAssetBuilder.Metrics
{
    public static class MetricManager
    {
        private static readonly ArrayList _listeners = new ArrayList();
        private static bool _sessionOpen;
        private static readonly Dictionary<string, MetricDescriptor> _descriptorMap = new Dictionary<string, MetricDescriptor>();

        public static bool IsEnabled { get; set; }
        public static MetricApplicationData AppData { get; } = new MetricApplicationData();

        public static void AddListener(IMetricsListener listener)
        {
            if (_sessionOpen)
            {
                throw new InvalidOperationException("Cannot add new listener while session is open.");
            }
            _listeners.Add(listener);
        }

        private static void SubmitInternal(MetricDescriptor descriptor, object[] samples)
        {
            if (!_sessionOpen || !IsEnabled || samples.Length == 0)
            {
                return;
            }
            object sample = samples[0];
            object obj = descriptor.Type switch
            {
                MetricType.Duration => sample.GetType() != typeof(TimeSpan) ? Convert.ToDouble(sample, CultureInfo.InvariantCulture) : ((TimeSpan)sample).TotalSeconds,
                MetricType.Size => Convert.ToInt64(sample, CultureInfo.InvariantCulture),
                MetricType.Count => Convert.ToInt32(sample, CultureInfo.InvariantCulture),
                MetricType.Ratio => Convert.ToSingle(sample, CultureInfo.InvariantCulture),
                MetricType.Name => Convert.ToString(sample, CultureInfo.InvariantCulture),
                MetricType.Enabled => Convert.ToBoolean(sample, CultureInfo.InvariantCulture),
                MetricType.Success => Convert.ToBoolean(sample, CultureInfo.InvariantCulture),
                _ => sample,
            };
            samples[0] = obj;
            foreach (IMetricsListener listener in _listeners)
            {
                listener.SubmitMetrics(new Metric(descriptor, samples));
            }
        }

        public static MetricDescriptor GetDescriptor(string name, MetricType type, string description)
        {
            string lower = name.ToLowerInvariant();
            if (!_descriptorMap.TryGetValue(lower, out MetricDescriptor result))
            {
                result = new MetricDescriptor(name, type, description);
                _descriptorMap.Add(lower, result);
            }
            return result;
        }

        public static void OpenSession()
        {
            if (_sessionOpen)
            {
                throw new InvalidOperationException("Session already opened.");
            }
            foreach (IMetricsListener listener in _listeners)
            {
                listener.Open();
            }
            _sessionOpen = true;
            IsEnabled = true;
        }

        public static void Submit(string descriptorName, params object[] dataList)
        {
            if (!_descriptorMap.TryGetValue(descriptorName.ToLowerInvariant(), out MetricDescriptor descriptor))
            {
                return;
            }
            SubmitInternal(descriptor, dataList);
        }

        public static void Submit(MetricDescriptor descriptor, params object[] dataList)
        {
            if (!_descriptorMap.ContainsKey(descriptor.Name.ToLowerInvariant()))
            {
                return;
            }
            SubmitInternal(descriptor, dataList);
        }

        public static void CloseSession()
        {
            if (!_sessionOpen)
            {
                throw new InvalidOperationException("Session not opened.");
            }
            foreach (IMetricsListener listener in _listeners)
            {
                listener.Close();
            }
            _sessionOpen = false;
        }
    }
}
