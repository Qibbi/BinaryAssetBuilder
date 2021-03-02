using System.Collections.Generic;
using System.IO;

namespace BinaryAssetBuilder.Utility
{
    public class UInt32Buffer
    {
        private readonly List<uint> _data;

        public int Length => _data.Count * 4;

        public UInt32Buffer()
        {
            _data = new List<uint>();
        }

        public int AddValue(uint value)
        {
            int result = _data.Count * 4;
            _data.Add(value);
            return result;
        }

        public void SaveToStream(Stream output, bool isBigEndian)
        {
            BinaryWriter writer = new BinaryWriter(output);
            if (isBigEndian)
            {
                for (int idx = 0; idx < _data.Count; ++idx)
                {
                    writer.Write(Endian.BigEndian(_data[idx]));
                }
            }
            else
            {
                for (int idx = 0; idx < _data.Count; ++idx)
                {
                    writer.Write(_data[idx]);
                }
            }
        }
    }
}
