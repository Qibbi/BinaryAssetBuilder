using System;
using System.Runtime.InteropServices;

namespace Native
{
    internal static class D3D9
    {
        private const string _moduleName = "d3d9.dll";

        public static readonly IntPtr HModule;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr Direct3DCreate9Delegate(uint sdkVersion);

        public static Direct3DCreate9Delegate Direct3DCreate9;

        static D3D9()
        {
            HModule = NativeLibrary.Load(_moduleName);

            Direct3DCreate9 = Marshal.GetDelegateForFunctionPointer<Direct3DCreate9Delegate>(NativeLibrary.GetExport(HModule, nameof(Direct3DCreate9)));
        }
    }
}
