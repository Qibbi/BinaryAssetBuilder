using BinaryAssetBuilder.Core;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BinaryAssetBuilder
{
    [XmlType("plugin")]
    public class PluginDescriptor
    {
        [XmlIgnore] public IAssetBuilderPluginBase Plugin { get; private set; }
        [XmlIgnore] public List<uint> HandledTypes { get; } = new List<uint>();
        [XmlAttribute("assetTypes")] public string AssetTypes { get; set; }
        [XmlAttribute("enabled")] public bool IsEnabled { get; set; }
        [XmlAttribute("targetType")] public string QualifiedName { get; set; }
        [XmlAttribute("useBuildCache")] public bool UseBuildCache { get; set; }
        [XmlAttribute("configSection")] public string ConfigSection { get; set; }

        public void Initialize(TargetPlatform targetPlatform)
        {
            if (!IsEnabled)
            {
                return;
            }
            if (QualifiedName is null)
            {
                throw new ApplicationException($"Target type not set");
            }
            Type type = Type.GetType(QualifiedName);
            if (type is null)
            {
                throw new ApplicationException($"'{QualifiedName}' not found");
            }
            if (!(Activator.CreateInstance(type) is IAssetBuilderPluginBase plugin))
            {
                throw new ApplicationException($"'{QualifiedName}' does not implement {nameof(IAssetBuilderPluginBase)}");
            }
            Plugin = plugin;
            if (!string.IsNullOrEmpty(AssetTypes) && !AssetTypes.Equals("#all"))
            {
                string assetTypes = AssetTypes;
                char[] separator = new char[] { ',' };
                foreach (string str in assetTypes.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    HandledTypes.Add(InstanceHandle.GetTypeId(str.Trim()));
                }
            }
            Plugin.Initialize(null, targetPlatform);
        }

        public void ReInitialize(TargetPlatform targetPlatform)
        {
            if (!IsEnabled)
            {
                return;
            }
            if (Plugin is null)
            {
                Initialize(targetPlatform);
            }
            else
            {
                Plugin.ReInitialize(null, targetPlatform);
            }
        }
    }
}
