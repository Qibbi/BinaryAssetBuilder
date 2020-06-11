using System;
using System.Text;

namespace BinaryAssetBuilder.Core
{
    public class Metric
    {
        private static readonly string[] _bytePostfix = new[] { "Bytes", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };

        public string Name => Descriptor.Name;
        public MetricDescriptor Descriptor { get; }
        public object Data => DataList[0];
        public object[] DataList { get; }
        public DateTime TimeStamp { get; }

        public Metric(MetricDescriptor descriptor, params object[] dataList)
        {
            TimeStamp = DateTime.Now;
            DataList = dataList;
            Descriptor = descriptor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[{TimeStamp:G}] {Descriptor.Description}: ");
            object obj = DataList[0];
            switch (Descriptor.Type)
            {
                case MetricType.Duration:
                    sb.Append(TimeSpan.FromSeconds((double)obj).ToString());
                    break;
                case MetricType.Size:
                    double num = (long)obj;
                    foreach (string str in _bytePostfix)
                    {
                        if (num < 1024.0)
                        {
                            sb.Append($"{num:n} {str}");
                            break;
                        }
                        num /= 1024.0;
                    }
                    break;
                default:
                    sb.Append(obj);
                    break;
            }
            if (DataList.Length > 1)
            {
                sb.Append($" [ {DataList[1]}");
                for (int idx = 2; idx < DataList.Length; ++idx)
                {
                    sb.Append($", {DataList[idx]}");
                }
                sb.Append("]");
            }
            return sb.ToString();
        }
    }
}