using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryAssetBuilder.Native
{
    internal static class ShlwApi
    {
        private const string _moduleName = "shlwapi.dll";

        public static readonly IntPtr HModule;

        public delegate bool PathCanonicalizeWDelegate(StringBuilder result, string path);

        public static PathCanonicalizeWDelegate PathCanonicalizeW;

        static ShlwApi()
        {
            HModule = NativeLibrary.Load(_moduleName);
            PathCanonicalizeW = Marshal.GetDelegateForFunctionPointer<PathCanonicalizeWDelegate>(NativeLibrary.GetExport(HModule, nameof(PathCanonicalizeW)));
        }
    }
}
