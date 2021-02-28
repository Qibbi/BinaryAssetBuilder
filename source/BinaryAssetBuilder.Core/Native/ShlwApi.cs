using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryAssetBuilder.Native
{
    internal static class ShlwApi
    {
        private const string _moduleName = "shlwapi.dll";

        public static readonly IntPtr HModule;

        public delegate bool PathRemoveFileSpecWDelegate([MarshalAs(UnmanagedType.LPWStr)] StringBuilder path);
        public delegate bool PathCanonicalizeWDelegate([MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, [In, MarshalAs(UnmanagedType.LPWStr)] string path);
        public delegate bool PathRelativePathToWDelegate([MarshalAs(UnmanagedType.LPWStr)] StringBuilder result,
                                                         [In, MarshalAs(UnmanagedType.LPWStr)] string from,
                                                         uint typeFrom,
                                                         [In, MarshalAs(UnmanagedType.LPWStr)] string to,
                                                         uint typeTo);

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
