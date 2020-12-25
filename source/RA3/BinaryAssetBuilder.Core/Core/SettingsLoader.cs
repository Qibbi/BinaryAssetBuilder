using System;
using System.IO;

namespace BinaryAssetBuilder.Core
{
    public static class SettingsLoader
    {
        private static string[] ProcessPaths(string combinedPaths)
        {
            string[] result = combinedPaths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < result.Length; ++idx)
            {
                if (result[idx] != "*")
                {
                    result[idx] = ShPath.Canonicalize(Path.Combine(Settings.Current.DataRoot, result[idx]));
                }
            }
            return result;
        }

        private static void SetConfiguration(Settings settings, string configName)
        {
            string art = null;
            string data = null;
            string audio = null;
            if (!string.IsNullOrEmpty(configName))
            {
                BuildConfiguration currentBuildConfiguration = null;
                foreach (BuildConfiguration buildConfiguration in settings.BuildConfigurations)
                {
                    if (buildConfiguration.Name.Equals(configName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        currentBuildConfiguration = buildConfiguration;
                        break;
                    }
                }
                art = currentBuildConfiguration != null ? currentBuildConfiguration.ArtPaths
                                                        : throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Invalid build configuration '{0}' specified.", configName);
                audio = currentBuildConfiguration.AudioPaths;
                data = currentBuildConfiguration.DataPaths;
                settings.Postfix = currentBuildConfiguration.Postfix;
                settings.StreamPostfix = !currentBuildConfiguration.AppendPostfixToStream
                                      || currentBuildConfiguration.StreamPostfix != null
                                      || string.IsNullOrEmpty(currentBuildConfiguration.Postfix)
                                          ? (currentBuildConfiguration.StreamPostfix ?? string.Empty)
                                          : "_" + currentBuildConfiguration.Postfix;
            }
            else
            {
                settings.Postfix = null;
            }
            if (art is null)
            {
                art = settings.DefaultArtPaths;
            }
            if (audio is null)
            {
                audio = settings.DefaultAudioPaths;
            }
            if (data is null)
            {
                data = settings.DefaultDataPaths;
            }
            if (string.IsNullOrEmpty(art) || string.IsNullOrEmpty(data) || string.IsNullOrEmpty(audio))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "No search paths for selected configuration specified.");
            }
            settings.ArtPaths = ProcessPaths(art);
            settings.DataPaths = ProcessPaths(data);
            settings.AudioPaths = ProcessPaths(audio);
            if (settings.MonitorPaths != null)
            {
                settings.ProcessedMonitorPaths = ProcessPaths(settings.MonitorPaths);
            }
        }

        public static Settings GetSettingsForConfiguration(string configName)
        {
            Settings result = (Settings)Settings.Current.Clone();
            SetConfiguration(result, configName);
            return result;
        }

        public static void PostProcessSettings(string anchorPath)
        {
            Settings current = Settings.Current;
            if (Path.GetFileName(anchorPath) == "running")
            {
                anchorPath = Path.GetDirectoryName(anchorPath);
            }
            if (!Path.IsPathRooted(current.InputPath))
            {
                current.InputPath = Path.GetFullPath(Path.Combine(anchorPath, current.InputPath));
            }
            if (!Path.IsPathRooted(current.DataRoot))
            {
                current.DataRoot = Path.GetFullPath(Path.Combine(anchorPath, current.DataRoot));
            }
            if (!Path.IsPathRooted(current.SchemaPath))
            {
                current.SchemaPath = Path.GetFullPath(Path.Combine(anchorPath, current.SchemaPath));
            }
            if (string.IsNullOrEmpty(current.OutputDirectory))
            {
                current.OutputDirectory = Path.GetDirectoryName(current.InputPath);
            }
            else if (!Path.IsPathRooted(current.OutputDirectory))
            {
                current.OutputDirectory = Path.GetFullPath(Path.Combine(anchorPath, current.OutputDirectory));
            }
            if (string.IsNullOrEmpty(current.IntermediateOutputDirectory) || !current.LinkedStreams)
            {
                current.IntermediateOutputDirectory = current.OutputDirectory;
            }
            else if (!Path.IsPathRooted(current.IntermediateOutputDirectory))
            {
                current.IntermediateOutputDirectory = Path.GetFullPath(Path.Combine(anchorPath, current.IntermediateOutputDirectory));
            }
            if (current.UseBuildCache && string.IsNullOrEmpty(current.BuildCacheDirectory))
            {
                current.BuildCacheDirectory = Path.Combine(current.OutputDirectory, "cache");
            }
            if (current.UseSessionCache && string.IsNullOrEmpty(current.SessionCacheDirectory))
            {
                current.SessionCacheDirectory = current.OutputDirectory;
            }
            current.BigEndian = current.TargetPlatform != TargetPlatform.Win32;
            SetConfiguration(current, current.BuildConfigurationName);
        }
    }
}
