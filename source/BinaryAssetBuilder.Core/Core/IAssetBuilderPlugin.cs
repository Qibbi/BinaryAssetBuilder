namespace BinaryAssetBuilder.Core
{
    public interface IAssetBuilderPlugin : IAssetBuilderPluginBase
    {
        AssetBuffer ProcessInstance(InstanceDeclaration instance);

        uint GetAllTypesHash();

        ExtendedTypeInformation GetExtendedTypeInformation(uint typeId);
    }
}