using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public class ReferencedManifest
    {
        public bool IsPatch { [return: MarshalAs(UnmanagedType.U1)] get; }
        public string Path { get; }

        public ReferencedManifest(string path, [MarshalAs(UnmanagedType.U1)] bool isPatch)
        {
            Path = path;
            IsPatch = isPatch;
        }
    }
}