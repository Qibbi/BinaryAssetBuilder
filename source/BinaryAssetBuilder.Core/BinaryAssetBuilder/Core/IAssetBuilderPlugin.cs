namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderPlugin : IAssetBuilderPluginBase
    {
        uint AllTypesHash { get; }
        uint VersionNumber { get; }

        AssetBuffer ProcessInstance(InstanceDeclaration instance);

        ExtendedTypeInformation GetExtendedTypeInformation(uint typeId);
    }
}
