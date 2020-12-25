using BinaryAssetBuilder.Core;

namespace BinaryAssetBuilder
{
    public interface IAssetBuilderPluginBase
    {
        void Initialize(object configObject, TargetPlatform targetPlatform);

        void ReInitialize(object configObject, TargetPlatform targetPlatform);
    }
}
