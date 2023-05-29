using System.Collections.Generic;
using BinaryAssetBuilder.Core.Diagnostics;

namespace BinaryAssetBuilder.Core
{
    public class PluginRegistry
    {
        private sealed class NullPlugin : IAssetBuilderPlugin
        {
            public uint AllTypesHash => 0u;

            public uint VersionNumber => 0u;

            public void Initialize(TargetPlatform platform)
            {
            }

            public void ReInitialize(TargetPlatform platform)
            {
            }

            public AssetBuffer ProcessInstance(InstanceDeclaration instance)
            {
                _tracer.TraceError("Couldn't process {0}. No matching plugin found.", instance.Handle);
                return null;
            }

            public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
            {
                return new ExtendedTypeInformation
                {
                    TypeName = "<Unknown>",
                    TypeId = typeId,
                    TypeHash = 0,
                    ProcessingHash = 0,
                    HasCustomData = false
                };
            }
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(PluginRegistry), "Maps types to plugins");

        private readonly Dictionary<uint, IAssetBuilderPlugin> _pluginMap = new Dictionary<uint, IAssetBuilderPlugin>();
        private Dictionary<uint, ExtendedTypeInformation> _typeInfoMap = new Dictionary<uint, ExtendedTypeInformation>();
        private readonly Dictionary<uint, bool> _buildCacheMap = new Dictionary<uint, bool>();
        private readonly bool _defaultUseBuildCache;

        public IAssetBuilderPlugin DefaultPlugin { get; set; } = new NullPlugin();
        public Dictionary<uint, IAssetBuilderPlugin>.ValueCollection AllPlugins => _pluginMap.Values;
        public uint AssetBuilderPluginsVersion
        {
            get
            {
                uint result = 0;
                foreach (IAssetBuilderPlugin plugin in AllPlugins)
                {
                    result += plugin.VersionNumber;
                }
                return result + DefaultPlugin.VersionNumber;
            }
        }

        public PluginRegistry(PluginDescriptor[] plugins, TargetPlatform platform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                if (plugin.IsEnabled)
                {
                    plugin.Initialize(platform);
                    if (plugin.Plugin is not IAssetBuilderPlugin babPlugin)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, $"'{plugin.QualifiedName}' does not implement {nameof(IAssetBuilderPlugin)}");
                    }
                    if (plugin.HandledTypes.Count > 0)
                    {
                        foreach (uint handledType in plugin.HandledTypes)
                        {
                            AddPlugin(handledType, babPlugin);
                            _buildCacheMap[handledType] = plugin.UseBuildCache;
                        }
                    }
                    else
                    {
                        DefaultPlugin = babPlugin;
                        _defaultUseBuildCache = plugin.UseBuildCache;
                    }
                }
            }
        }

        public void ReInitialize(PluginDescriptor[] plugins, TargetPlatform platform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                plugin.ReInitialize(platform);
            }
            _typeInfoMap = new Dictionary<uint, ExtendedTypeInformation>();
        }

        public void AddPlugin(uint typeId, IAssetBuilderPlugin plugin)
        {
            _pluginMap.Add(typeId, plugin);
        }

        public IAssetBuilderPlugin GetPlugin(uint typeId)
        {
            if (!_pluginMap.TryGetValue(typeId, out IAssetBuilderPlugin result))
            {
                result = DefaultPlugin;
            }
            return result;
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            if (!_typeInfoMap.TryGetValue(typeId, out ExtendedTypeInformation result))
            {
                IAssetBuilderPlugin plugin = GetPlugin(typeId);
                if (plugin is not null)
                {
                    result = plugin.GetExtendedTypeInformation(typeId);
                }
                _buildCacheMap.TryGetValue(typeId, out bool defaultUseBuildCache);
                result.UseBuildCache = defaultUseBuildCache;
                _typeInfoMap.Add(typeId, result);
            }
            return result;
        }
    }
}
