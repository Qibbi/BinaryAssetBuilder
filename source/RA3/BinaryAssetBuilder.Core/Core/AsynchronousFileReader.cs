using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryAssetBuilder.Core
{
    public class AsynchronousFileReader
    {
        private const int _queueSize = 1;

        private readonly Queue<IAsyncResult> _jobQueue = new Queue<IAsyncResult>();
        private FileStream _stream;

        public uint FileSize => (uint)_stream.Length;
        public Chunk CurrentChunk { get; private set; }

        public AsynchronousFileReader(string path)
        {
            _stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 8, true);
            if (_stream is null)
            {
                return;
            }
            for (int idx = 0; idx < _queueSize; ++idx)
            {
                Chunk chunk = new Chunk();
                _jobQueue.Enqueue(_stream.BeginRead(chunk.Data, 0, chunk.Data.Length, null, chunk));
            }
        }

        public bool BeginRead()
        {
            if (_jobQueue.Count == 0 || CurrentChunk != null || _stream is null)
            {
                return false;
            }
            IAsyncResult asyncResult = _jobQueue.Dequeue();
            asyncResult.AsyncWaitHandle.WaitOne();
            CurrentChunk = asyncResult.AsyncState as Chunk;
            CurrentChunk.BytesRead = _stream.EndRead(asyncResult);
            if (CurrentChunk.BytesRead != 0)
            {
                return true;
            }
            CurrentChunk.Dispose();
            while (_jobQueue.Count > 0)
            {
                IAsyncResult readResult = _jobQueue.Dequeue();
                readResult.AsyncWaitHandle.WaitOne();
                _stream.EndRead(readResult);
                (readResult.AsyncState as Chunk)?.Dispose();
            }
            return false;
        }

        public void EndRead()
        {
            if (CurrentChunk is null || _stream is null)
            {
                return;
            }
            CurrentChunk.BytesRead = 0;
            _jobQueue.Enqueue(_stream.BeginRead(CurrentChunk.Data, 0, CurrentChunk.Data.Length, null, CurrentChunk));
            CurrentChunk = null;
        }
    }
}
