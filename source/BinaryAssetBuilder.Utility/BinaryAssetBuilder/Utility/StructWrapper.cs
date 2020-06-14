using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public abstract class AStructWrapper<T> : IDisposable where T : unmanaged
    {
        public static unsafe int Size { get; } = sizeof(T);

        private IntPtr _hData;

        protected unsafe T* Data;

        protected abstract void Swap();

        public unsafe AStructWrapper()
        {
            _hData = Marshal.AllocHGlobal(Size);
            if (_hData != IntPtr.Zero)
            {
                Native.MsVcRt.MemSet(_hData, 0, new Native.SizeT(Size));
                Data = (T*)_hData;
            }
        }

        public virtual unsafe void LoadFromBuffer(byte[] buffer, [MarshalAs(UnmanagedType.U1)] bool isBigEndian)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                Native.MsVcRt.MemCpy((IntPtr)Data, (IntPtr)pBuffer, new Native.SizeT(Size));
                if (isBigEndian)
                {
                    Swap();
                }
            }
        }

        public virtual void LoadFromStream(Stream input, [MarshalAs(UnmanagedType.U1)] bool isBigEndian)
        {
            byte[] buffer = new byte[Size];
            input.Read(buffer, 0, Size);
            LoadFromBuffer(buffer, isBigEndian);
        }

        public virtual unsafe void SaveToStream(Stream output, [MarshalAs(UnmanagedType.U1)] bool isBigEndian)
        {
            if (isBigEndian)
            {
                Swap();
            }
            byte[] buffer = new byte[Size];
            new UnmanagedMemoryStream((byte*)Data, Size).Read(buffer, 0, Size);
            output.Write(buffer, 0, Size);
            if (isBigEndian)
            {
                Swap();
            }
        }

        public virtual unsafe void Dispose()
        {
            if (_hData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_hData);
                _hData = IntPtr.Zero;
                Data = null;
            }
        }
    }
}
