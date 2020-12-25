using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.Core
{
    public class PluginRegistry
    {
        private class NullPlugin : IAssetBuilderPlugin
        {
            public void Initialize(object configObject, TargetPlatform targetPlatform)
            {
            }

            public void ReInitialize(object configObject, TargetPlatform targetPlatform)
            {
            }

            public AssetBuffer ProcessInstance(InstanceDeclaration instance)
            {
                _tracer.TraceError("Couldn't process {0}. No matching plugin found.", instance.Handle);
                return null;
            }

            public uint GetAllTypesHash()
            {
                return 0u;
            }

            public uint GetVersionNumber()
            {
                return 0u;
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
        private readonly Dictionary<uint, ExtendedTypeInformation> _typeInfoMap = new Dictionary<uint, ExtendedTypeInformation>();
        private readonly Dictionary<uint, bool> _buildCacheMap = new Dictionary<uint, bool>();
        private readonly bool _defaultUseBuildCache;

        public IAssetBuilderPlugin DefaultPlugin { get; set; } = new NullPlugin();
        public Dictionary<uint, IAssetBuilderPlugin>.ValueCollection AllPlugins => _pluginMap.Values;
        public uint AssetBuilderPluginVersion
        {
            get
            {
                uint result = 0;
                foreach (IAssetBuilderPlugin plugin in AllPlugins)
                {
                    result += plugin.GetVersionNumber();
                }
                return result + DefaultPlugin.GetVersionNumber();
            }
        }

        public PluginRegistry(PluginDescriptor[] plugins, TargetPlatform targetPlatform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                plugin.Initialize(targetPlatform);
                if (!(plugin.Plugin is IAssetBuilderPlugin babPlugin))
                {
                    throw new ApplicationException($"'{plugin.QualifiedName}' does not implement {nameof(IAssetBuilderPlugin)}");
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

        public void ReInitialize(PluginDescriptor[] plugins, TargetPlatform targetPlatform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                plugin.ReInitialize(targetPlatform);
            }
            _typeInfoMap.Clear();
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
                if (plugin != null)
                {
                    result = plugin.GetExtendedTypeInformation(typeId);
                }
                if (!_buildCacheMap.TryGetValue(typeId, out bool useBuildCache))
                {
                    useBuildCache = _defaultUseBuildCache;
                }
                result.UseBuildCache = useBuildCache;
                _typeInfoMap.Add(typeId, result);
            }
            return result;
        }
    }
}
