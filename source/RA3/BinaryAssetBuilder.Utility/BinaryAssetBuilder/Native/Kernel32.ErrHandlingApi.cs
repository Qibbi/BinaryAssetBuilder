namespace BinaryAssetBuilder.Native
{
    internal static partial class Kernel32
    {
        public delegate int GetLastErrorDelegate();

        public static readonly GetLastErrorDelegate GetLastError;
    }
}
