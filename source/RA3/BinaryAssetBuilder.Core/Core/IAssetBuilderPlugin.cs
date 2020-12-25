namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderPlugin : IAssetBuilderPluginBase
    {
        AssetBuffer ProcessInstance(InstanceDeclaration declaration);

        uint GetAllTypesHash();

        uint GetVersionNumber();

        ExtendedTypeInformation GetExtendedTypeInformation(uint typeId);
    }
}