namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderPlugin : IAssetBuilderPluginBase
    {
        AssetBuffer ProcessInstance(InstanceDeclaration declaration);

        uint GetAllTypesHash();

        ExtendedTypeInformation GetExtendedTypeInformation(uint typeId);
    }
}