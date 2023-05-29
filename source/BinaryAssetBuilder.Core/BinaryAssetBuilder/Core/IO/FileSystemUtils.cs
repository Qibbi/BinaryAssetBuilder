using System;
using System.Text;

namespace BinaryAssetBuilder.Core.IO
{
    public static class FileSystemUtils
    {
        public static string GetErrorString(int code)
        {
            StringBuilder sb = new StringBuilder(256);
            Native.Kernel32.FormatMessageW(4096, IntPtr.Zero, code, 0, sb, 256, IntPtr.Zero);
            return $"{code}: {sb}";
        }

        public static void FlushVolume(char drive)
        {
            string str = "\\\\.\\" + drive + ":\0";
            IntPtr fileW = Native.Kernel32.CreateFileW(str, 0x40000000, 2, IntPtr.Zero, Native.Kernel32.FileCreationDispositionType.OpenExisting, 0, IntPtr.Zero);
            if (fileW == new IntPtr(-1))
            {
                int lastError = Native.Kernel32.GetLastError();
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, $"Could not open handle to {str}, error: {GetErrorString(lastError)}");
            }
            if (!Native.Kernel32.FlushFileBuffers(fileW))
            {
                int lastError = Native.Kernel32.GetLastError();
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, $"Could not flush {str}, error: {GetErrorString(lastError)}");
            }
            if (!Native.Kernel32.CloseHandle(fileW))
            {
                int lastError = Native.Kernel32.GetLastError();
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, $"Could not close {str}, error: {GetErrorString(lastError)}");
            }
        }
    }
}
