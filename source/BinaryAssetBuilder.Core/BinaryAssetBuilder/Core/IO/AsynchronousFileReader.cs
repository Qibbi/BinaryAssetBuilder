using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryAssetBuilder.Core.IO
{
    public sealed class AsynchronousFileReader : IDisposable
    {
        private const int QueueSize = 1;

        private Queue<IAsyncResult> _jobQueue = new Queue<IAsyncResult>();
        private FileStream _stream;
        private Chunk _currentChunk;

        public uint FileSize => _stream is null ? 0u : (uint)_stream.Length;
        public Chunk CurrentChunk => _currentChunk;

        public AsynchronousFileReader(string path)
        {
            _stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 8, true);
            if (_stream is null)
            {
                return;
            }
            for (int idx = 0; idx < QueueSize; ++idx)
            {
                Chunk chunk = new Chunk();
                _jobQueue.Enqueue(_stream.BeginRead(chunk.Data, 0, chunk.Data.Length, null, chunk));
            }
        }

        public bool BeginRead()
        {
            if (_jobQueue.Count == 0 || _currentChunk is not null || _stream is null)
            {
                return false;
            }
            IAsyncResult asyncResult = _jobQueue.Dequeue();
            asyncResult.AsyncWaitHandle.WaitOne();
            _currentChunk = asyncResult.AsyncState as Chunk;
            _currentChunk.BytesRead = _stream.EndRead(asyncResult);
            if (_currentChunk.BytesRead != 0)
            {
                return true;
            }
            _currentChunk.Dispose();
            while (_jobQueue.Count > 0)
            {
                IAsyncResult nextResult = _jobQueue.Dequeue();
                nextResult.AsyncWaitHandle.WaitOne();
                _stream.EndRead(nextResult);
                (nextResult.AsyncState as Chunk).Dispose();
            }
            _stream.Close();
            _stream = null;
            return false;
        }

        public void EndRead()
        {
            if (_currentChunk is null || _stream is null)
            {
                return;
            }
            _currentChunk.BytesRead = 0;
            _jobQueue.Enqueue(_stream.BeginRead(_currentChunk.Data, 0, _currentChunk.Data.Length, null, _currentChunk));
            _currentChunk = null;
        }

        public void Dispose()
        {
            _stream?.Dispose();
            _stream = null;
            _currentChunk?.Dispose();
            _currentChunk = null;
        }
    }
}
