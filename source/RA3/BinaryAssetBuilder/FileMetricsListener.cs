using Metrics;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;

namespace BinaryAssetBuilder
{
    public class FileMetricsListener : IMetricsListener
    {
        private readonly Dictionary<string, Metric> _metrics = new Dictionary<string, Metric>();
        private readonly string _filePathStub;
        private readonly MetricDescriptor[] _descriptors;

        public FileMetricsListener(MetricDescriptor[] descriptors)
        {
            _filePathStub = ((NameValueCollection)ConfigurationManager.GetSection("BABFileMetricsListener"))["filepathstub"];
            _descriptors = descriptors;
        }

        private void FlushMetrics()
        {
            StringBuilder categories = new StringBuilder("Time,User,Machine");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:G},{1},{2}", DateTime.Now, MetricManager.AppData.UserName, MetricManager.AppData.MachineName);
            foreach (MetricDescriptor descriptor in _descriptors)
            {
                categories.AppendFormat(",{0}", descriptor.Name);
                if (_metrics.TryGetValue(descriptor.Name, out Metric metric))
                {
                    if (metric.Descriptor.Type == MetricType.Duration)
                    {
                        sb.AppendFormat(",{0}", TimeSpan.FromSeconds((double)metric.Data));
                    }
                    else if (metric.Descriptor.Type == MetricType.Enabled)
                    {
                        sb.AppendFormat(",{0}", (bool)metric.Data ? 1 : 0);
                    }
                    else
                    {
                        sb.AppendFormat(",{0}", metric.Data);
                    }
                }
                else
                {
                    sb.Append(",");
                }
            }
            _metrics.Clear();
            try
            {
                FileInfo fileInfo = new FileInfo(_filePathStub + MetricManager.AppData.MachineName + ".csv");
                StreamWriter writer = fileInfo.AppendText();
                if (fileInfo.Length == 0L)
                {
                    writer.WriteLine(categories.ToString());
                }
                writer.WriteLine(sb.ToString());
                writer.Close();
            }
            catch
            {
            }
        }

        public void Open()
        {
        }

        public void Close()
        {
            FlushMetrics();
            _metrics.Clear();
        }

        public void SubmitMetrics(Metric metric)
        {
            _metrics.Add(metric.Name, metric);
        }
    }
}
