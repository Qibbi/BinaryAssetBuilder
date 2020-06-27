using System;

namespace Native
{
    public abstract class ADisposeBase : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public event EventHandler<EventArgs> Disposing;
        public event EventHandler<EventArgs> Disposed;

        private void CheckAndDispose(bool disposing)
        {
            if (!IsDisposed)
            {
                Disposing?.Invoke(this, DisposeEventArgs.Get(disposing));
                Dispose(disposing);
                GC.SuppressFinalize(this);
                IsDisposed = true;
                Disposed?.Invoke(this, DisposeEventArgs.Get(disposing));
            }
        }

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            CheckAndDispose(true);
        }

        ~ADisposeBase()
        {
            CheckAndDispose(false);
        }
    }
}
