namespace BinaryAssetBuilder.Utility
{
    public class ReferencedManifest
    {
        public bool IsPatch { get; }
        public string Path { get; }

        public ReferencedManifest(string path, bool isPatch)
        {
            Path = path;
            IsPatch = isPatch;
        }
    }
}