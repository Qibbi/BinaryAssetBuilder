using System;

namespace Native
{
    public class DisposeEventArgs : EventArgs
    {
        public static DisposeEventArgs DisposingEventArgs { get; } = new DisposeEventArgs(true);
        public static DisposeEventArgs NotDisposingEventArgs { get; } = new DisposeEventArgs(false);

        public bool Disposing { get; }

        private DisposeEventArgs(bool disposing)
        {
            Disposing = disposing;
        }

        public static DisposeEventArgs Get(bool disposing)
        {
            return disposing ? DisposingEventArgs : NotDisposingEventArgs;
        }
    }
}
