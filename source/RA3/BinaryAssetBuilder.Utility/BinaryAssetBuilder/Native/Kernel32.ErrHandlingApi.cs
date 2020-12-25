namespace BinaryAssetBuilder.Native
{
    public static partial class Kernel32
    {
        public delegate int GetLastErrorDelegate();

        public static readonly GetLastErrorDelegate GetLastError;
    }
}
