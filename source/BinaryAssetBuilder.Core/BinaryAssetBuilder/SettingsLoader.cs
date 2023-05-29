using System;
using System.IO;
using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.IO;

namespace BinaryAssetBuilder
{
    public class SettingsLoader
    {
        private static string[] ProcessPaths(string combinedPaths)
        {
            string[] paths = combinedPaths.Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < paths.Length; ++idx)
            {
                if (paths[idx] != "*")
                {
                    paths[idx] = ShPath.Canonicalize(Path.Combine(Settings.Current.DataRoot, paths[idx]));
                }
            }
            return paths;
        }

        private static void SetConfiguration(Settings settings, string configName)
        {
            string artPaths = null;
            string audioPaths = null;
            string dataPaths = null;
            if (!string.IsNullOrEmpty(configName))
            {
                BuildConfiguration result = null;
                foreach (BuildConfiguration buildConfiguration in settings.BuildConfigurations)
                {
                    if (buildConfiguration.Name.Equals(configName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = buildConfiguration;
                        break;
                    }
                }
                if (result is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Invalid build configuration '{0}' specified.", configName);
                }
                artPaths = result.ArtPaths;
                audioPaths = result.AudioPaths;
                dataPaths = result.DataPaths;
                settings.Postfix = result.Postfix;
                settings.StreamPostfix = !result.AppendPostfixToStream || result.StreamPostfix is not null || string.IsNullOrEmpty(result.Postfix)
                    ? (result.StreamPostfix is not null ? result.StreamPostfix : string.Empty)
                    : "_" + result.Postfix;
            }
            else
            {
                settings.Postfix = null;
            }
            if (artPaths is null)
            {
                artPaths = settings.DefaultArtPaths;
            }
            if (audioPaths is null)
            {
                audioPaths = settings.DefaultAudioPaths;
            }
            if (dataPaths is null)
            {
                dataPaths = settings.DefaultDataPaths;
            }
            if (string.IsNullOrEmpty(artPaths) || string.IsNullOrEmpty(audioPaths) || string.IsNullOrEmpty(dataPaths))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "No search paths for selected configuration specified.");
            }
            settings.ArtPaths = ProcessPaths(artPaths);
            settings.AudioPaths = ProcessPaths(audioPaths);
            settings.DataPaths = ProcessPaths(dataPaths);
            if (settings.MonitorPaths is not null)
            {
                settings.ProcessedMonitorPaths = ProcessPaths(settings.MonitorPaths);
            }
        }

        public static Settings GetSettingsForConfiguration(string configName)
        {
            Settings settings = Settings.Current.Clone() as Settings;
            SetConfiguration(settings, configName);
            return settings;
        }

        public static void PostProcessSettings(string anchorPath)
        {
            Settings current = Settings.Current;
            if (Path.GetFileName(anchorPath) == "running")
            {
                anchorPath = Path.GetDirectoryName(anchorPath);
            }
            if (!Path.IsPathRooted(current.DataRoot))
            {
                current.DataRoot = Path.GetFullPath(Path.Combine(anchorPath, current.DataRoot));
            }
            if (!Path.IsPathRooted(current.SchemaPath))
            {
                current.SchemaPath = Path.GetFullPath(Path.Combine(anchorPath, current.SchemaPath));
            }
            if (!Path.IsPathRooted(current.InputPath))
            {
                current.InputPath = Path.GetFullPath(Path.Combine(current.DataRoot, current.InputPath));
            }
            if (string.IsNullOrEmpty(current.OutputDirectory))
            {
                current.OutputDirectory = Path.GetDirectoryName(current.InputPath);
            }
            if (string.IsNullOrEmpty(current.IntermediateOutputDirectory) || !current.LinkedStreams)
            {
                current.IntermediateOutputDirectory = current.OutputDirectory;
            }
            if (current.BuildCache && string.IsNullOrEmpty(current.BuildCacheDirectory))
            {
                current.BuildCacheDirectory = Path.Combine(current.OutputDirectory, "cache");
            }
            if (current.SessionCache && string.IsNullOrEmpty(current.SessionCacheDirectory))
            {
                current.SessionCacheDirectory = current.OutputDirectory;
            }
            current.BigEndian = current.TargetPlatform != TargetPlatform.Win32;
            SetConfiguration(current, current.BuildConfigurationName);
        }
    }
}
