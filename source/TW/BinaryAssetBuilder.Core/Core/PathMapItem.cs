namespace BinaryAssetBuilder.Core
{
    public class PathMapItem
    {
        public string SourceUri;
        public string TargetPath;

        public PathMapItem(string sourceUri, string targetPath)
        {
            SourceUri = sourceUri;
            TargetPath = targetPath;
        }
    }
}