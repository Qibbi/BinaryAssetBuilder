using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public abstract class AStructWrapper<T> : IDisposable where T : unmanaged
    {
        private bool _disposed;
        private IntPtr _hData;

        protected unsafe T* Data;

        protected abstract void Swap();

        public unsafe AStructWrapper()
        {
            _hData = Marshal.AllocHGlobal(Unsafe.SizeOf<T>());
            if (_hData != IntPtr.Zero)
            {
                Native.MsVcRt.MemSet(_hData, 0, new Native.SizeT(Unsafe.SizeOf<T>()));
                Data = (T*)_hData;
            }
        }

        public virtual unsafe void LoadFromBuffer(byte[] buffer, bool isBigEndian)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                Native.MsVcRt.MemCpy((IntPtr)Data, (IntPtr)pBuffer, new Native.SizeT(Unsafe.SizeOf<T>()));
                if (isBigEndian)
                {
                    Swap();
                }
            }
        }

        public virtual void LoadFromStream(Stream input, bool isBigEndian)
        {
            byte[] buffer = new byte[Unsafe.SizeOf<T>()];
            input.Read(buffer, 0, Unsafe.SizeOf<T>());
            LoadFromBuffer(buffer, isBigEndian);
        }

        public virtual unsafe void SaveToStream(Stream output, bool isBigEndian)
        {
            if (isBigEndian)
            {
                Swap();
            }
            byte[] buffer = new byte[Unsafe.SizeOf<T>()];
            new UnmanagedMemoryStream((byte*)Data, Unsafe.SizeOf<T>()).Read(buffer, 0, Unsafe.SizeOf<T>());
            output.Write(buffer, 0, Unsafe.SizeOf<T>());
            if (isBigEndian)
            {
                Swap();
            }
        }

        protected virtual unsafe void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Data = null;
                }

                if (_hData != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(_hData);
                    _hData = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        ~AStructWrapper()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
