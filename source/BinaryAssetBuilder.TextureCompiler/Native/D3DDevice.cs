using System;
using System.Runtime.InteropServices;

namespace Native
{
    public class D3DDevice : IDisposable
    {
        private class Vtbl
        {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public unsafe delegate uint ReleaseDelegate([In] ID3DDevice* self);

            public ReleaseDelegate Release;

            public unsafe Vtbl(void** vtbl)
            {
                Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(new IntPtr(vtbl[2]));
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 10752)]
        public struct ID3DDevice
        {
        }

        private unsafe ID3DDevice* _struct;
        private readonly Vtbl _vtbl;

        public unsafe D3DDevice(IntPtr nativePtr)
        {
            _struct = (ID3DDevice*)nativePtr;
            _vtbl = new Vtbl((void**)*(void**)_struct);
        }

        public unsafe uint Release()
        {
            uint result = 0xFFFFFFFFu;
            if (_struct != null)
            {
                result = _vtbl.Release(_struct);
                _struct = null;
            }
            return result;
        }

        public void Dispose()
        {
            Release();
        }
    }
}
