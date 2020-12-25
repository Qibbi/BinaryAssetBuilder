using System;

namespace BinaryAssetBuilder.Native
{
    public static partial class User32
    {
        public delegate bool ShowWindowDelegate(IntPtr hWnd, int nCmdShow);
        public delegate bool SetLayeredWindowAttributesDelegate(IntPtr hWnd, uint crKey, byte bAlpha, int dwFlags);

        public static readonly ShowWindowDelegate ShowWindow;
        public static readonly SetLayeredWindowAttributesDelegate SetLayeredWindowAttributes;
    }
}
