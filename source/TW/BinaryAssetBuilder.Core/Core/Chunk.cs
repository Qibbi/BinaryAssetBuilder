using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.Core
{
    public class Chunk : IDisposable
    {
        private const int _bufferSize = 0x100000;
        private static readonly Stack<byte[]> _bufferStack = new Stack<byte[]>();

        public byte[] Data { get; private set; } = GetBuffer();
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
            if (Data is null)
            {
                return;
            }
            ReleaseBuffer(Data);
            Data = null;
        }
    }
}