using System.Text;

namespace BinaryAssetBuilder.Core
{
    public static class ShPath
    {
        private const int MaxPath = 260;

        public static string Canonicalize(string path)
        {
            StringBuilder result = new StringBuilder(path, 260);
            return !Native.ShlwApi.PathCanonicalizeW(result, path) ? string.Empty : result.ToString();
        }
    }
}
