using System.IO;

namespace BinaryAssetBuilder.Core
{
    public class FileNameResolver
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(FileNameResolver), "Resolves aliased path names specified in documents");
        private static readonly char[] _splitCharacters = new[] { ':' };

        private static string BuildPathProbe(string baseDirectory, string templatePath)
        {
            return templatePath == "*" ? baseDirectory : Path.GetFullPath(Path.Combine(Settings.Current.DataRoot, templatePath));
        }

        private static string SearchPaths(string baseDirectory, string path, params string[] includePaths)
        {
            string result = null;
            foreach (string includePath in includePaths)
            {
                string testPath = includePath == "*" ? baseDirectory : includePath;
                if (!string.IsNullOrEmpty(Settings.Current.Postfix))
                {
                    result = ShPath.Canonicalize(Path.Combine(testPath,
                                                 Path.GetDirectoryName(path),
                                                 $"{Path.GetFileNameWithoutExtension(path)}_{Settings.Current.Postfix}{Path.GetExtension(path)}"));
                    if (File.Exists(result))
                    {
                        break;
                    }
                }
                result = Path.GetFullPath(Path.Combine(testPath, path));
                if (File.Exists(result))
                {
                    break;
                }
            }
            return result;
        }

        public static FileNameXmlResolver GetXmlResolver(string baseDirectory)
        {
            return new FileNameXmlResolver(baseDirectory);
        }

        public static string ResolvePath(string baseDirectory, string targetPath)
        {
            string result = null;
            if (!Path.IsPathRooted(baseDirectory))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "An illegal relative path {0} is used as base directory. This is a bug in the code.", baseDirectory);
            }
            if (Path.IsPathRooted(targetPath))
            {
                result = targetPath;
            }
            else
            {
                string[] pathArray = targetPath.Split(_splitCharacters);
                if (pathArray.Length == 1)
                {
                    result = ShPath.Canonicalize(Path.Combine(baseDirectory, targetPath));
                }
                else
                {
                    if (pathArray.Length > 2)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.IllegalPath, "An illegal path {0} is used as a reference to another asset or document.", targetPath);
                    }
                    string str = pathArray[1].Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                    string lower = pathArray[0].ToLower();
                    if (lower == "art")
                    {
                        if (string.IsNullOrEmpty(ShPath.RemoveFileSpec(str)))
                        {
                            foreach (string artPath in Settings.Current.ArtPaths)
                            {
                                string testPath = artPath == "*" ? baseDirectory : Path.Combine(artPath, str.Substring(0, 2));
                                if (!string.IsNullOrEmpty(Settings.Current.Postfix))
                                {
                                    result = ShPath.Canonicalize(Path.Combine(testPath, $"{Path.GetFileNameWithoutExtension(str)}_{Settings.Current.Postfix}{Path.GetExtension(str)}"));
                                    if (File.Exists(result))
                                    {
                                        break;
                                    }
                                }
                                result = ShPath.Canonicalize(Path.Combine(testPath, str));
                                if (File.Exists(result))
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            result = SearchPaths(baseDirectory, str, Settings.Current.ArtPaths);
                        }
                    }
                    else if (lower == "data")
                    {
                        result = SearchPaths(baseDirectory, str, Settings.Current.DataPaths);
                    }
                    else if (lower == "audio")
                    {
                        result = SearchPaths(baseDirectory, str, Settings.Current.AudioPaths);
                    }
                    else if (lower == "root")
                    {
                        result = SearchPaths(baseDirectory, str, Settings.Current.DataRoot); ;
                    }
                    else
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.IllegalPathAlias, "An illegal alias {0} is used in path {1}.", lower, targetPath);
                    }
                }
            }
            _tracer.TraceData("Resolve Path Result: {0}", result);
            return result;
        }

        public static string GetDataRoot(string fileName)
        {
            string result = string.Empty;
            foreach (string dataPath in Settings.Current.DataPaths)
            {
                if (fileName.StartsWith(dataPath, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    result = dataPath;
                    break;
                }
            }
            return result;
        }
    }
}