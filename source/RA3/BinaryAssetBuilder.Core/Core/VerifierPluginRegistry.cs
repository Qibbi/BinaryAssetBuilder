using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.Core
{
    public class VerifierPluginRegistry
    {
        private class NullVertifierPlugin : IAssetBuilderVerifierPlugin
        {
            public void Initialize(object configObject, TargetPlatform targetPlatform)
            {
            }

            public void ReInitialize(object configObject, TargetPlatform targetPlatform)
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

        public VerifierPluginRegistry(PluginDescriptor[] plugins, TargetPlatform targetPlatform)
        {
            foreach (PluginDescriptor plugin in plugins)
            {
                plugin.Initialize(targetPlatform);
                if (!(plugin.Plugin is IAssetBuilderVerifierPlugin verifierPlugin))
                {
                    throw new ApplicationException($"'{plugin.QualifiedName}' does not implement {nameof(IAssetBuilderVerifierPlugin)}");
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

        public void ReInitialize(PluginDescriptor[] plguins, TargetPlatform targetPlatform)
        {
            foreach (PluginDescriptor plugin in plguins)
            {
                plugin.ReInitialize(targetPlatform);
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
