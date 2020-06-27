using System;
using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    [Guid("D0223B96-BF7A-43fd-92BD-A43B0D82B9EB")]
    public partial class Device : ComObject
    {
        public Direct3D Direct3D
        {
            get
            {
                GetDirect3D(out Direct3D result);
                return result;
            }
        }

        public Device(IntPtr nativePtr) : base(nativePtr)
        {
        }

        public static explicit operator Device(IntPtr nativePtr)
        {
            return nativePtr == IntPtr.Zero ? null : new Device(nativePtr);
        }
    }
}
