using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Native
{
    public static partial class Kernel32
    {
        public enum FileCreationDispositionType : uint
        {
            /// <summary>
            /// Creates a new file, only if it does not already exist.
            /// </summary>
            CreateNew = 1,
            /// <summary>
            /// Creates a new file, always.
            /// </summary>
            CreateAlways,
            /// <summary>
            /// Opens a file or device, only if it exists.
            /// </summary>
            OpenExisting,
            /// <summary>
            /// Opens a file, always.
            /// </summary>
            OpenAlways,
            /// <summary>
            /// Opens a file and truncates it so that its size is zero bytes, only if it exists.
            /// </summary>
            TruncateExisting
        }

        public delegate IntPtr CreateFileWDelegate([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
                                                   int dwDesiredAccess,
                                                   int dwSharedMode,
                                                   IntPtr lpSecurityAttributes,
                                                   FileCreationDispositionType dwCreationDisposition,
                                                   int dwFlagsAndAttributes,
                                                   IntPtr hTemplateFile);
        public delegate bool FlushFileBuffersDelegate(IntPtr hFile);

        public static readonly CreateFileWDelegate CreateFileW;
        public static readonly FlushFileBuffersDelegate FlushFileBuffers;
    }
}
