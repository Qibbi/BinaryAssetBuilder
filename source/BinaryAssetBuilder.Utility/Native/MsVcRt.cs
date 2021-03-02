using System;
using System.Runtime.InteropServices;

namespace Native
{
    public static class MsVcRt
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr MemSetDelegate(IntPtr ptr, byte value, SizeT count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MemICmpDelegate([In] IntPtr buf1, [In] IntPtr buf2, SizeT size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr MemCpyDelegate(IntPtr dest, [In] IntPtr src, SizeT count);
        [UnmanagedFunctionPointer(CallingConvention.FastCall)]
        public delegate SizeT StrLenDelegate([In] IntPtr str);

        private const string _moduleName = "msvcrt.dll";

        public static readonly IntPtr HModule;

        public static readonly MemSetDelegate MemSet;
        public static readonly MemICmpDelegate MemICmp;
        public static readonly MemCpyDelegate MemCpy;

        static MsVcRt()
        {
            HModule = NativeLibrary.Load(_moduleName);
            MemSet = Marshal.GetDelegateForFunctionPointer<MemSetDelegate>(NativeLibrary.GetExport(HModule, "memset"));
            MemICmp = Marshal.GetDelegateForFunctionPointer<MemICmpDelegate>(NativeLibrary.GetExport(HModule, "_memicmp"));
            MemCpy = Marshal.GetDelegateForFunctionPointer<MemCpyDelegate>(NativeLibrary.GetExport(HModule, "memcpy"));
        }
    }
}
