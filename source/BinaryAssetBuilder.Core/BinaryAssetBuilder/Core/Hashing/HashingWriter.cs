using System.IO;
using System.Text;

namespace BinaryAssetBuilder.Core.Hashing
{
    internal sealed class HashingWriter : TextWriter
    {
        private const int _hashingSize = 512;

        private uint _runningHash;
        private string _leftoverChars = string.Empty;

        public override Encoding Encoding => Encoding.Default;

        public HashingWriter(uint runningHash)
        {
            _runningHash = runningHash;
        }

        public override void Write(char value)
        {
            Write(new string(value, 1));
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Write(new string(buffer, index, count));
        }

        public override void Write(string value)
        {
            string current = value;
            if (_leftoverChars.Length > 0)
            {
                current = _leftoverChars + value;
            }
            if (current.Length < _hashingSize)
            {
                _leftoverChars = current;
            }
            else
            {
                for (int idx = 0; idx + _hashingSize < current.Length; idx += _hashingSize)
                {
                    _runningHash = HashProvider.GetTextHash(_runningHash, current.Substring(idx, _hashingSize));
                }
                int length = current.Length % _hashingSize;
                if (length == 0)
                {
                    _leftoverChars = string.Empty;
                }
                else
                {
                    _leftoverChars = current.Substring(current.Length - length, length);
                }
            }
        }

        public uint GetFinalHash()
        {
            return _leftoverChars.Length > 0 ? HashProvider.GetTextHash(_runningHash, _leftoverChars) : _runningHash;
        }
    }
}
