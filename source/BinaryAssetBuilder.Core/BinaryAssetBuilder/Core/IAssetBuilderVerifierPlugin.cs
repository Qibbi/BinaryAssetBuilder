namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderVerifierPlugin : IAssetBuilderPluginBase
    {
        bool VerifyInstance(InstanceDeclaration instance);
    }
}
