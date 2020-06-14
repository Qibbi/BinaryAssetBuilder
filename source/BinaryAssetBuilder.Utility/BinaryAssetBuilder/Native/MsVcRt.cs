using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Native
{
    public static class MsVcRt
    {
        public delegate IntPtr ClearMemoryDelegate(IntPtr ptr, byte value, ulong count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MemICmpDelegate([In] IntPtr buf1, [In] IntPtr buf2, SizeT size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr MemCpyDelegate(IntPtr dest, [In] IntPtr src, SizeT count);
        [UnmanagedFunctionPointer(CallingConvention.FastCall)]
        public delegate SizeT StrLenDelegate([In] IntPtr str);

        private const string _moduleName = "msvcrt.dll";

        private static readonly IntPtr _hModule;

        private static readonly ClearMemoryDelegate _clearMemoryInt;

        public static readonly MemICmpDelegate MemICmp;
        public static readonly MemCpyDelegate MemCpy;

        static MsVcRt()
        {
            _hModule = NativeLibrary.Load(_moduleName);
            _clearMemoryInt = Marshal.GetDelegateForFunctionPointer<ClearMemoryDelegate>(NativeLibrary.GetExport(_hModule, "memset"));
            MemICmp = Marshal.GetDelegateForFunctionPointer<MemICmpDelegate>(NativeLibrary.GetExport(_hModule, "_memicmp"));
            MemCpy = Marshal.GetDelegateForFunctionPointer<MemCpyDelegate>(NativeLibrary.GetExport(_hModule, "memcpy"));
        }

        // [DllImport(_moduleName, EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl)]
        // private static extern IntPtr ClearMemory(IntPtr ptr, byte value, ulong count);

        public static IntPtr ClearMemory(IntPtr ptr, byte value, int count)
        {
            return _clearMemoryInt(ptr, value, (ulong)count);
        }
    }
}
