using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Native
{
    public static partial class Kernel32
    {
        private const string _moduleName = "kernel32.dll";

        public static readonly IntPtr HModule;
        static Kernel32()
        {
            HModule = NativeLibrary.Load(_moduleName);
            // HandleApi
            CloseHandle = Marshal.GetDelegateForFunctionPointer<CloseHandleDelegate>(NativeLibrary.GetExport(HModule, nameof(CloseHandle)));
            // FileApi
            CreateFileW = Marshal.GetDelegateForFunctionPointer<CreateFileWDelegate>(NativeLibrary.GetExport(HModule, nameof(CreateFileW)));
            FlushFileBuffers = Marshal.GetDelegateForFunctionPointer<FlushFileBuffersDelegate>(NativeLibrary.GetExport(HModule, nameof(FlushFileBuffers)));
            // ErrHandlingApi
            GetLastError = Marshal.GetDelegateForFunctionPointer<GetLastErrorDelegate>(NativeLibrary.GetExport(HModule, nameof(GetLastError)));
            // WinBase
            FormatMessageW = Marshal.GetDelegateForFunctionPointer<FormatMessageWDelegate>(NativeLibrary.GetExport(HModule, nameof(FormatMessageW)));
            // Windows
            AllocConsole = Marshal.GetDelegateForFunctionPointer<AllocConsoleDelegate>(NativeLibrary.GetExport(HModule, nameof(AllocConsole)));
            GetConsoleWindow = Marshal.GetDelegateForFunctionPointer<GetConsoleWindowDelegate>(NativeLibrary.GetExport(HModule, nameof(GetConsoleWindow)));
        }
    }
}
