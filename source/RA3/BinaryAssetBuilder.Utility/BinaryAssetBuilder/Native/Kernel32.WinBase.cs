using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryAssetBuilder.Native
{
    internal static partial class Kernel32
    {
        public delegate int FormatMessageWDelegate(int dwFlags,
                                                   [In] IntPtr lpSource,
                                                   int dwMessageId,
                                                   int dwLanguageId,
                                                   [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpBuffer,
                                                   int nSize,
                                                   IntPtr arguments);

        public static readonly FormatMessageWDelegate FormatMessageW;
    }
}
