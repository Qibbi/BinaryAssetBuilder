using System;
using System.ComponentModel;
using System.Xml;
using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.CommandLine;
using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Core.Xml;

namespace BinaryAssetBuilder
{
    public class Settings : ISerializable, ICloneable
    {
        public static Settings Current;

        private string _schemaPath;
        private bool _buildCache = true;
        private string _buildCacheDirectory;
        private string _dataRoot;
        private PluginDescriptor[] _plugins;
        private PluginDescriptor[] _verifierPlugins;
        private BuildConfiguration[] _buildConfigurations;
        private string _defaultArtPaths;
        private string _defaultAudioPaths;
        private string _defaultDataPaths;
        private string _monitorPaths;
        private bool _usePrecompiled;
        private bool _versionFiles;
        private bool _resident;
        private bool _enableStreamHints;
        private bool _outputAssetReport;
        private bool _outputStringHashes = true;
        private StringHashBinDescriptor[] _stringHashBinDescriptors;

        [OptionalCommandLineOption("sp"), Description("Schema describing the XML file processsed")] public string SchemaPath { get => _schemaPath; set => _schemaPath = value; }
        [OptionalCommandLineOption("bc"), Description("Enable build cache")] public bool BuildCache { get => _buildCache; set => _buildCache = value; }
        [OptionalCommandLineOption("bcp,bcd"), Description("Directory used for caching assets on the network")] public string BuildCacheDirectory { get => _buildCacheDirectory; set => _buildCacheDirectory = value; }
        [OptionalCommandLineOption("sc"), Description("Enable session cache")] public bool SessionCache { get; set; } = true;
        [OptionalCommandLineOption("scd,scp"), Description("Directory used for storing the session cache")] public string SessionCacheDirectory { get; set; }
        [OptionalCommandLineOption("psc"), Description("Save session cache on aborted build")] public bool PartialSessionCache { get; set; } = true;
        [OptionalCommandLineOption("csc"), Description("Generate compressed session cache")] public bool CompressedSessionCache { get; set; } = true;
        [OptionalCommandLineOption("fsc"), Description("Prevents updating the session cache (used for debugging)")] public bool FreezeSessionCache { get; set; }
        [OptionalCommandLineOption("atc"), Description("Touch files in build cache even when not copied")] public bool AlwaysTouchCache { get; set; }
        [OptionalCommandLineOption("tp"), Description("Target platform for generated data")] public TargetPlatform TargetPlatform { get; set; }
        [OptionalCommandLineOption("mr"), Description("Enable metrics reporting")] public bool MetricsReporting { get; set; }
        [OptionalCommandLineOption("dr"), Description("Directory used as a root for all stream XML files")] public string DataRoot { get => _dataRoot; set => _dataRoot = value; }
        [OptionalCommandLineOption("tl", 0, 9), Description("Trace level used for output")] public int TraceLevel { get; set; } = 3;
        [OptionalCommandLineOption("el", 0, 1), Description("Error level for reporting")] public int ErrorLevel { get; set; }
        [OptionalCommandLineOption("bcn"), Description("Name of build configuration to use")] public string BuildConfigurationName { get; set; }
        [OptionalCommandLineOption("poe"), Description("Pause after build is complete if errors occurred")] public bool PauseOnError { get; set; }
        [OptionalCommandLineOption("sf"), Description("Enable single file mode")] public bool SingleFile { get; set; }
        [OptionalCommandLineOption("ls"), Description("Enables linked streams")] public bool LinkedStreams { get; set; }
        [OptionalCommandLineOption("oix"), Description("Generates intermediate XML files for testing purposes")] public bool OutputIntermediateXml { get; set; }
        [OptionalCommandLineOption("iod"), Description("Directory for intermediate files")] public string IntermediateOutputDirectory { get; set; }
        [OptionalCommandLineOption("slowclean"), Description("Forces the slow asset and cdata cleanup")] public bool ForceSlowCleanup { get; set; }
        [OptionalCommandLineOption("od"), Description("Output directory for generated data")] public string OutputDirectory { get; set; }
        [OrderedCommandLineOption(0), DisplayName("input_path"), Description("XML file to process")] public string InputPath { get; set; }
        public string[] DataPaths { get; set; }
        public string[] ArtPaths { get; set; }
        public string[] AudioPaths { get; set; }
        public string[] ProcessedMonitorPaths { get; set; }
        public PluginDescriptor[] Plugins { get => _plugins; set => _plugins = value; }
        public PluginDescriptor[] VerifierPlugins { get => _verifierPlugins; set => _verifierPlugins = value; }
        public BuildConfiguration[] BuildConfigurations { get => _buildConfigurations; set => _buildConfigurations = value; }
        [OptionalCommandLineOption("art"), Description("Default search paths for ART: path alias")] public string DefaultArtPaths { get => _defaultArtPaths; set => _defaultArtPaths = value; }
        [OptionalCommandLineOption("audio"), Description("Default search paths for AUDIO: path alias")] public string DefaultAudioPaths { get => _defaultAudioPaths; set => _defaultAudioPaths = value; }
        [OptionalCommandLineOption("data"), Description("Default search paths for DATA: path alias")] public string DefaultDataPaths { get => _defaultDataPaths; set => _defaultDataPaths = value; }
        [OptionalCommandLineOption("mp"), Description("Additional paths which should be monitored for changes in persistent mode")] public string MonitorPaths { get => _monitorPaths; set => _monitorPaths = value; }
        public string Postfix { get; set; }
        public string StreamPostfix { get; set; }
        public bool BigEndian { get; set; }
        [OptionalCommandLineOption("ss"), Description("Sort assets in a manner that is stable, but slower")] public bool StableSort { get; set; }
        [OptionalCommandLineOption("bps"), Description("Base stream upon which to do a patch")] public string BasePatchStream { get; set; }
        [OptionalCommandLineOption("pc"), Description("If true, referenced streams will not be compiled if their .manifest output is available")] public bool UsePrecompiled { get => _usePrecompiled; set => _usePrecompiled = value; }
        [OptionalCommandLineOption("vf"), Description("If true, generates a .version file for each stream containing the stream suffix used")] public bool VersionFiles { get => _versionFiles; set => _versionFiles = value; }
        [OptionalCommandLineOption("cpf"), Description("If specified, appends this postfix to the configuration-defined stream postfix, useful for versioning")] public string CustomPostfix { get; set; } = string.Empty;
        [OptionalCommandLineOption("res,pers"), Description("If true, BAB runs as a background process to greatly reduce load/shutdown times")] public bool Resident { get => _resident; set => _resident = value; }
        [OptionalCommandLineOption("sh"), Description("If true, the stream hints saved in the session cache will be used to only build the streams that have dirty assets in them")] public bool StreamHints { get => _enableStreamHints; set => _enableStreamHints = value; }
        public string AssetNamespace { get; set; } = SchemaSet.XmlNamespace;
        [OptionalCommandLineOption("oar"), Description("Specifies whether to compile an asset report")] public bool OutputAssetReport { get => _outputAssetReport; set => _outputAssetReport = value; }
        [OptionalCommandLineOption("osh"), Description("")] public bool OutputStringHashes { get => _outputStringHashes; set => _outputStringHashes = value; }
        public StringHashBinDescriptor[] StringHashBinDescriptors { get => _stringHashBinDescriptors; set => _stringHashBinDescriptors = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetAttributeValue(nameof(SchemaPath), null), ref _schemaPath);
            Marshaler.Marshal(node.GetAttributeValue(nameof(BuildCache), "true"), ref _buildCache);
            Marshaler.Marshal(node.GetAttributeValue(nameof(BuildCacheDirectory), null), ref _buildCacheDirectory);
            Marshaler.Marshal(node.GetAttributeValue(nameof(DataRoot), null), ref _dataRoot);
            Marshaler.Marshal(node.GetChildNodes("Plugin"), ref _plugins);
            Marshaler.Marshal(node.GetChildNodes("Verifier"), ref _verifierPlugins);
            Marshaler.Marshal(node.GetChildNodes("BuildConfiguration"), ref _buildConfigurations);
            Marshaler.Marshal(node.GetAttributeValue(nameof(DefaultArtPaths), null), ref _defaultArtPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(DefaultAudioPaths), null), ref _defaultAudioPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(DefaultDataPaths), null), ref _defaultDataPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(MonitorPaths), null), ref _monitorPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(UsePrecompiled), null), ref _usePrecompiled);
            Marshaler.Marshal(node.GetAttributeValue(nameof(VersionFiles), null), ref _versionFiles);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Resident), null), ref _resident);
            Marshaler.Marshal(node.GetAttributeValue(nameof(StreamHints), null), ref _enableStreamHints);
            Marshaler.Marshal(node.GetAttributeValue(nameof(OutputAssetReport), null), ref _outputAssetReport);
            Marshaler.Marshal(node.GetAttributeValue(nameof(OutputStringHashes), "true"), ref _outputStringHashes);
            Marshaler.Marshal(node.GetChildNodes("StringHashBin"), ref _stringHashBinDescriptors);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(SchemaPath), _schemaPath);
            writer.WriteAttributeString(nameof(BuildCache), _buildCache.ToString());
            writer.WriteAttributeString(nameof(BuildCacheDirectory), _buildCacheDirectory);
            writer.WriteAttributeString(nameof(DataRoot), _dataRoot);
            if (_plugins is not null)
            {
                foreach (PluginDescriptor plugin in _plugins)
                {
                    writer.WriteStartElement("Plugin");
                    plugin.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
            if (_verifierPlugins is not null)
            {
                foreach (PluginDescriptor plugin in _verifierPlugins)
                {
                    writer.WriteStartElement("Verifier");
                    plugin.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
            if (_buildConfigurations is not null)
            {
                foreach (BuildConfiguration buildConfiguration in _buildConfigurations)
                {
                    writer.WriteStartElement("BuildConfiguration");
                    buildConfiguration.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
            writer.WriteAttributeString(nameof(DefaultArtPaths), _defaultArtPaths);
            writer.WriteAttributeString(nameof(DefaultAudioPaths), _defaultAudioPaths);
            writer.WriteAttributeString(nameof(DefaultDataPaths), _defaultDataPaths);
            writer.WriteAttributeString(nameof(MonitorPaths), _monitorPaths);
            writer.WriteAttributeString(nameof(UsePrecompiled), _usePrecompiled.ToString());
            writer.WriteAttributeString(nameof(VersionFiles), _versionFiles.ToString());
            writer.WriteAttributeString(nameof(Resident), _resident.ToString());
            writer.WriteAttributeString(nameof(StreamHints), _enableStreamHints.ToString());
            writer.WriteAttributeString(nameof(OutputAssetReport), _outputAssetReport.ToString());
            writer.WriteAttributeString(nameof(OutputStringHashes), _outputStringHashes.ToString());
            if (_stringHashBinDescriptors is not null)
            {
                foreach (StringHashBinDescriptor stringHashBin in _stringHashBinDescriptors)
                {
                    writer.WriteStartElement("StringHashBin");
                    stringHashBin.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
