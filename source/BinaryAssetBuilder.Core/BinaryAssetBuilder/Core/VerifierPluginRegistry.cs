using System.Collections.Generic;
using BinaryAssetBuilder.Core.Diagnostics;

namespace BinaryAssetBuilder.Core
{
    public class VerifierPluginRegistry
    {
        private sealed class NullVertifierPlugin : IAssetBuilderVerifierPlugin
        {
            public void Initialize(TargetPlatform platform)
            {
            }

            public void ReInitialize(TargetPlatform platform)
            {
            }

            public bool VerifyInstance(InstanceDeclaration instance)
            {
                return true;
            }
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(VerifierPluginRegistry), "Maps types to vertifier plugins");
        private readonly Dictionary<uint, IAssetBuilderVerifierPlugin> _pluginMap = new Dictionary<uint, IAssetBuilderVerifierPlugin>();

        public IAssetBuilderVerifierPlugin DefaultPlugin { get; set; } = new NullVertifierPlugin();

        public VerifierPluginRegistry(PluginDescriptor[] plugins, TargetPlatform platform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                if (plugin.IsEnabled)
                {
                    plugin.Initialize(platform);
                    if (plugin.Plugin is not IAssetBuilderVerifierPlugin verifierPlugin)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, $"'{plugin.QualifiedName}' does not implement {nameof(IAssetBuilderVerifierPlugin)}");
                    }
                    if (plugin.HandledTypes.Count > 0)
                    {
                        foreach (uint handledType in plugin.HandledTypes)
                        {
                            AddPlugin(handledType, verifierPlugin);
                        }
                    }
                    else
                    {
                        DefaultPlugin = verifierPlugin;
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
        }

        public void AddPlugin(uint typeId, IAssetBuilderVerifierPlugin plugin)
        {
            _pluginMap.Add(typeId, plugin);
        }

        public IAssetBuilderVerifierPlugin GetPlugin(uint typeId)
        {
            if (!_pluginMap.TryGetValue(typeId, out IAssetBuilderVerifierPlugin result))
            {
                result = DefaultPlugin;
            }
            return result;
        }
    }
}
