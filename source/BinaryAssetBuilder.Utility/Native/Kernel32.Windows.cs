using System;
using System.Runtime.InteropServices;

namespace Native
{
    public static partial class Kernel32
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public delegate bool AllocConsoleDelegate();
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public delegate IntPtr GetConsoleWindowDelegate();

        public static readonly AllocConsoleDelegate AllocConsole;
        public static readonly GetConsoleWindowDelegate GetConsoleWindow;
    }
}
