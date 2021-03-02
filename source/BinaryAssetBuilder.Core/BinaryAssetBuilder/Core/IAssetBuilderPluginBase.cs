namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderPluginBase
    {
        void Initialize(TargetPlatform platform);

        void ReInitialize(TargetPlatform platform);
    }
}
