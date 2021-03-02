using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BinaryAssetBuilder.Core.IO
{
    public class FileNameXmlResolver : XmlUrlResolver
    {
        private readonly string _baseDirectory;

        public List<PathMapItem> Paths { get; } = new List<PathMapItem>();

        public FileNameXmlResolver(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            string originalString = absoluteUri.OriginalString;
            string targetPath;
            if (absoluteUri.Scheme == "data" || absoluteUri.Scheme == "art" || absoluteUri.Scheme == "audio")
            {
                targetPath = FileNameResolver.ResolvePath(_baseDirectory, absoluteUri.OriginalString);
                absoluteUri = new Uri($"file://{targetPath}");
            }
            else if (absoluteUri.Scheme == "file")
            {
                StringBuilder result = new StringBuilder(256);
                if (Native.ShlwApi.PathRelativePathToW(result, _baseDirectory, 16u, absoluteUri.LocalPath, 128u))
                {
                    originalString = result.ToString();
                    targetPath = absoluteUri.LocalPath;
                }
                else
                {
                    throw new BinaryAssetBuilderException(ErrorCode.IllegalPath, "Illegal absolute path used in XInclude statement: {0}", absoluteUri.AbsolutePath);
                }
            }
            else
            {
                throw new BinaryAssetBuilderException(ErrorCode.IllegalPath, "Illegal URI scheme used in XInclude statement: {0}", absoluteUri.OriginalString);
            }
            Paths.Add(new PathMapItem(originalString, targetPath));
            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
    }
}
