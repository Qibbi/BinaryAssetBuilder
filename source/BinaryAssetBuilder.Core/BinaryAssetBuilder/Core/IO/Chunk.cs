using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.Core.IO
{
    public sealed class Chunk : IDisposable
    {
        private const int _bufferSize = 0x100000;

        private static readonly Stack<byte[]> _bufferStack = new Stack<byte[]>();

        private byte[] _data = GetBuffer();

        public byte[] Data => _data;
        public int BytesRead { get; set; }

        private static byte[] GetBuffer()
        {
            lock (_bufferStack)
            {
                return _bufferStack.Count == 0 ? new byte[_bufferSize] : _bufferStack.Pop();
            }
        }

        private static void ReleaseBuffer(byte[] buffer)
        {
            lock (_bufferStack)
            {
                _bufferStack.Push(buffer);
            }
        }

        public void Dispose()
        {
            if (_data is null)
            {
                return;
            }
            ReleaseBuffer(_data);
            _data = null;
        }
    }
}
