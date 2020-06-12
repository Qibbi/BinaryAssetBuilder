using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryAssetBuilder.Native
{
    internal static class ShlwApi
    {
        private const string _moduleName = "shlwapi.dll";

        public static readonly IntPtr HModule;

        public delegate bool PathRemoveFileSpecWDelegate(StringBuilder path);
        public delegate bool PathCanonicalizeWDelegate(StringBuilder result, string path);
        public delegate bool PathRelativePathToWDelegate(StringBuilder result, string from, uint typeFrom, string to, uint typeTo);

        public static PathRemoveFileSpecWDelegate PathRemoveFileSpecW;
        public static PathCanonicalizeWDelegate PathCanonicalizeW;
        public static PathRelativePathToWDelegate PathRelativePathToW;

        static ShlwApi()
        {
            HModule = NativeLibrary.Load(_moduleName);

            PathRemoveFileSpecW = Marshal.GetDelegateForFunctionPointer<PathRemoveFileSpecWDelegate>(NativeLibrary.GetExport(HModule, nameof(PathRemoveFileSpecW)));
            PathCanonicalizeW = Marshal.GetDelegateForFunctionPointer<PathCanonicalizeWDelegate>(NativeLibrary.GetExport(HModule, nameof(PathCanonicalizeW)));
            PathRelativePathToW = Marshal.GetDelegateForFunctionPointer<PathRelativePathToWDelegate>(NativeLibrary.GetExport(HModule, nameof(PathRelativePathToW)));
        }
    }
}
