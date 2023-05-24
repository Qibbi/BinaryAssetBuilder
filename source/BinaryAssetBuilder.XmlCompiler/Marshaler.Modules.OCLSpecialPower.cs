using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OCLUpgradePair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OCLUpgradePair.Science), null), &objT->Science, state);
        Marshal(node.GetAttributeValue(nameof(OCLUpgradePair.OCL), null), &objT->OCL, state);
    }

    public static unsafe void Marshal(Node node, OCLSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.OCL), null), &objT->OCL, state);
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.CreateLocation), null), &objT->CreateLocation, state);
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.MaxCreateCount), "0"), &objT->MaxCreateCount, state);
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.NumberToSpawn), "1"), &objT->NumberToSpawn, state);
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.DestinationOCL), null), &objT->DestinationOCL, state);
        Marshal(node.GetAttributeValue(nameof(OCLSpecialPowerModuleData.RegisterObjectsWithSpecialAbilityUpdate), "false"), &objT->RegisterObjectsWithSpecialAbilityUpdate, state);
        Marshal(node.GetChildNodes(nameof(OCLSpecialPowerModuleData.UpgradeOCL)), &objT->UpgradeOCL, state);
        Marshal(node.GetChildNode(nameof(OCLSpecialPowerModuleData.NearestSecondaryObjectFilter), null), &objT->NearestSecondaryObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(OCLSpecialPowerModuleData.Upgrade)), &objT->Upgrade, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
