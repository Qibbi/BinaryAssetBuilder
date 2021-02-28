using System;
using System.Collections;
using System.Collections.Generic;

namespace Metrics
{
    public class MetricManager
    {
        private static readonly ArrayList _listeners = new ArrayList();
        private static bool _isSessionOpen = false;
        private static readonly Dictionary<string, MetricDescriptor> _descriptorMap = new Dictionary<string, MetricDescriptor>();

        public static bool IsEnabled { get; set; } = true;
        public static MetricApplicationData AppData { get; } = new MetricApplicationData();

        private static void SubmitInternal(MetricDescriptor descriptor, object[] samples)
        {
            if (!_isSessionOpen || !IsEnabled || samples.Length == 0)
            {
                return;
            }
            object sample = samples[0];
            object obj;
            switch (descriptor.Type)
            {
                case MetricType.Duration:
                    obj = sample.GetType() != typeof(TimeSpan) ? (object)Convert.ToDouble(sample) : (object)((TimeSpan)sample).TotalSeconds;
                    break;
                case MetricType.Size:
                    obj = Convert.ToInt64(sample);
                    break;
                case MetricType.Count:
                    obj = Convert.ToInt32(sample);
                    break;
                case MetricType.Ratio:
                    obj = Convert.ToSingle(sample);
                    break;
                case MetricType.Name:
                    obj = Convert.ToString(sample) ?? string.Empty;
                    break;
                case MetricType.Enabled:
                case MetricType.Success:
                    obj = Convert.ToBoolean(sample);
                    break;
                default:
                    obj = sample;
                    break;
            }
            samples[0] = obj;
            foreach (IMetricsListener listener in _listeners)
            {
                listener.SubmitMetrics(new Metric(descriptor, samples));
            }
        }

        public static void AddListener(IMetricsListener listener)
        {
            if (_isSessionOpen)
            {
                throw new InvalidOperationException("Cannot add a new listener while session is open.");
            }
            _listeners.Add(listener);
        }

        public static void OpenSession()
        {
            if (_isSessionOpen)
            {
                throw new InvalidOperationException("Session already opened.");
            }
            foreach (IMetricsListener listener in _listeners)
            {
                listener.Open();
            }
            _isSessionOpen = true;
            IsEnabled = true;
        }

        public static void CloseSession()
        {
            if (!_isSessionOpen)
            {
                throw new InvalidOperationException("Session not opened.");
            }
            foreach (IMetricsListener listener in _listeners)
            {
                listener.Close();
            }
            _isSessionOpen = false;
        }

        public static void Submit(string descriptorName, params object[] dataList)
        {
            if (!_descriptorMap.TryGetValue(descriptorName.ToLower(), out MetricDescriptor descriptor))
            {
                return;
            }
            SubmitInternal(descriptor, dataList);
        }

        public static void Submit(MetricDescriptor descriptor, params object[] dataList)
        {
            if (!_descriptorMap.ContainsKey(descriptor.Name.ToLower()))
            {
                return;
            }
            SubmitInternal(descriptor, dataList);
        }

        public static MetricDescriptor GetDescriptor(string name, MetricType type, string description)
        {
            string lower = name.ToLower();
            if (!_descriptorMap.TryGetValue(lower, out MetricDescriptor result))
            {
                result = new MetricDescriptor(name, type, description);
                _descriptorMap.Add(lower, result);
            }
            return result;
        }
    }
}
