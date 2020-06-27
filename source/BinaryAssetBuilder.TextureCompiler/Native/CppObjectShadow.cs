using System;
using System.Runtime.InteropServices;

namespace Native
{
    internal abstract class ACppObjectShadow : CppObject
    {
        public ICallbackable Callback { get; private set; }

        protected abstract CppObjectVtbl GetVtbl { get; }

        internal static unsafe T ToShadow<T>(IntPtr thisPtr) where T : ACppObjectShadow
        {
            return (T)GCHandle.FromIntPtr(*(((IntPtr*)thisPtr) + 1)).Target;
        }

        public unsafe virtual void Initialize(ICallbackable callback)
        {
            Callback = callback;
            NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
            GCHandle handle = GCHandle.Alloc(this);
            Marshal.WriteIntPtr(NativePointer, GetVtbl.Pointer);
            *((IntPtr*)NativePointer + 1) = GCHandle.ToIntPtr(handle);
        }

        protected override unsafe void Dispose(bool disposing)
        {
            if (NativePointer != IntPtr.Zero)
            {
                GCHandle.FromIntPtr(*(((IntPtr*)NativePointer) + 1)).Free();
                Marshal.FreeHGlobal(NativePointer);
                NativePointer = IntPtr.Zero;
            }
            Callback = null;
            base.Dispose(disposing);
        }
    }
}