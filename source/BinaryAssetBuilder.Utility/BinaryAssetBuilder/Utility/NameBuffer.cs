using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public class NameBuffer
    {
        private readonly List<byte> _data;
        private readonly Dictionary<int, int> _positions;

        public int Length => _data.Count;

        public NameBuffer()
        {
            _data = new List<byte>();
            _positions = new Dictionary<int, int>();
        }

        public unsafe int AddName(string name)
        {
            int nameHash = name.GetHashCode();
            if (!_positions.TryGetValue(nameHash, out int result))
            {
                IntPtr hName = Marshal.StringToHGlobalAnsi(name);
                byte* pName = (byte*)hName.ToPointer();
                result = _data.Count;
                while (*pName != 0)
                {
                    _data.Add(*pName);
                    ++pName;
                }
                _data.Add(0);
                Marshal.FreeHGlobal(hName);
                _positions.Add(nameHash, result);
            }
            return result;
        }

        public void SaveToStream(Stream output)
        {
            output.Write(_data.ToArray(), 0, _data.Count);
        }
    }
}
