using System;
using System.IO;

namespace BinaryAssetBuilder.Metrics
{
    public class ConsoleMetricsListener : IMetricsListener
    {
        private readonly TextWriter _outputStream;

        public ConsoleMetricsListener()
        {
            _outputStream = Console.Out;
        }

        public ConsoleMetricsListener(TextWriter output)
        {
            _outputStream = output;
        }

        public void Open()
        {
        }

        public void Close()
        {
        }

        public void SubmitMetrics(Metric metric)
        {
            _outputStream.WriteLine(metric.ToString());
        }
    }
}
