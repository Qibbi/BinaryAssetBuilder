using BinaryAssetBuilder.Core;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BinaryAssetBuilder
{
    public class Settings : ICloneable
    {
        public static Settings Current;

        [XmlIgnore] public readonly bool PartialSessionCache = true;
        [XmlIgnore] public readonly bool CompressedSessionCache = true;
        [XmlIgnore] public readonly TargetPlatform TargetPlatform;
        [XmlIgnore] public readonly bool AlwaysTouchCache;
        [XmlIgnore] public readonly bool IsMetricsReporting;
        [OptionalCommandLineOption("sp"), Description("Schema describing the XML file processsed"), XmlAttribute("schema")] public string SchemaPath { get; set; }
        [OptionalCommandLineOption("bcp,bcd"), Description("Directory used for caching assets on the network"), XmlAttribute("buildCacheRoot")] public string BuildCacheDirectory { get; set; }
        [OptionalCommandLineOption("bc"), Description("Enable build cache"), XmlAttribute("buildCache")] public bool UseBuildCache { get; set; }
        [OptionalCommandLineOption("scd,scp"), Description("Directory used for storing the session cache"), XmlIgnore] public string SessionCacheDirectory { get; set; }
        [OptionalCommandLineOption("sc"), Description("Enable session cache"), XmlIgnore] public bool UseSessionCache { get; set; }
        [OptionalCommandLineOption("oof"), Description("Uses the old asset output format with three separate files"), XmlIgnore] public bool OldOutputFormat { get; set; }
        [OptionalCommandLineOption("dr"), Description("Directory used as a root for all stream XML files"), XmlAttribute("dataRoot")] public string DataRoot { get; set; }
        [OptionalCommandLineOption("cl", 0, 2), Description("Cache level used for building data"), XmlIgnore] public int CacheLevel { get; set; } = 2;
        [OptionalCommandLineOption("tl", 0, 9), Description("Trace level used for output"), XmlIgnore] public int TraceLevel { get; set; } = 3;
        [OptionalCommandLineOption("el", 0, 1), Description("Error level for reporting"), XmlIgnore] public int ErrorLevel { get; set; }
        [OptionalCommandLineOption("bcn"), Description("Name of build configuration to use"), XmlIgnore] public string BuildConfigurationName { get; set; }
        [OptionalCommandLineOption("poe"), Description("Pause after build is complete if errors occurred"), XmlIgnore] public bool PauseOnError { get; set; }
        [OptionalCommandLineOption("sf"), Description("Enable single file mode"), XmlIgnore] public bool SingleFile { get; set; }
        [OptionalCommandLineOption("fsc"), Description("Prevents updating the session cache (used for debugging)"), XmlIgnore] public bool FreezeSessionCache { get; set; }
        [OptionalCommandLineOption("ls"), Description("Enables linked streams"), XmlIgnore] public bool LinkedStreams { get; set; }
        [OptionalCommandLineOption("iod"), Description("Directory for intermediate files"), XmlIgnore] public string IntermediateOutputDirectory { get; set; }
        [OptionalCommandLineOption("oix"), Description("Generates intermediate XML files for testing purposes"), XmlIgnore] public bool OutputIntermediateXml { get; set; }
        [OptionalCommandLineOption("gui"), Description("Creates a new window for text output"), XmlIgnore] public bool GuiMode { get; set; }
        [OptionalCommandLineOption("od"), Description("Output directory for generated data"), XmlIgnore] public string OutputDirectory { get; set; }
        [OrderedCommandLineOption(0), DisplayName("input_path"), Description("XML file to process"), XmlIgnore] public string InputPath { get; set; }
        [XmlIgnore] public string[] DataPaths { get; set; }
        [XmlIgnore] public string[] ArtPaths { get; set; }
        [XmlIgnore] public string[] AudioPaths { get; set; }
        [XmlArray("plugins")] public PluginDescriptor[] Plugins { get; set; }
        [XmlArray("verifiers")] public PluginDescriptor[] VerifierPlugins { get; set; }
        [XmlArray("buildConfigurations")] public BuildConfiguration[] BuildConfigurations { get; set; }
        [OptionalCommandLineOption("art"), Description("Default search paths for ART: path alias"), XmlAttribute("defaultArtPaths")] public string DefaultArtPaths { get; set; }
        [OptionalCommandLineOption("audio"), Description("Default search paths for AUDIO: path alias"), XmlAttribute("defaultAudioPaths")] public string DefaultAudioPaths { get; set; }
        [OptionalCommandLineOption("data"), Description("Default search paths for DATA: path alias"), XmlAttribute("defaultDataPaths")] public string DefaultDataPaths { get; set; }
        [XmlIgnore] public string Postfix { get; set; }
        [XmlIgnore] public string StreamPostfix { get; set; }
        [XmlIgnore] public bool BigEndian { get; set; }
        [OptionalCommandLineOption("ss"), Description("Sort assets in a manner that is stable, but slower"), XmlIgnore] public bool StableSort { get; set; }
        [OptionalCommandLineOption("bps"), Description("Base stream upon which to do a patch"), XmlIgnore] public string BasePatchStream { get; set; }
        [OptionalCommandLineOption("pc"), Description("If true, referenced streams will not be compiled if their .manifest output is available"), XmlAttribute("usePrecompiled")] public bool UsePrecompiled { get; set; }
        [OptionalCommandLineOption("vf"), Description("If true, generates a .version file for each stream containing the stream suffix used"), XmlAttribute("versionFiles")] public bool VersionFiles { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
