using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DLLicenseGroup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DLLicenseGroup.LicenseMask), null), &objT->LicenseMask, state);
        Marshal(node.GetChildNodes(nameof(DLLicenseGroup.Asset)), &objT->Asset, state);
    }

    public static unsafe void Marshal(Node node, DLPatch* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DLPatch.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(DLPatch.PatchNumber), null), &objT->PatchNumber, state);
    }

    public static unsafe void Marshal(Node node, DLContent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DLContent.PackageNumber), null), &objT->PackageNumber, state);
        Marshal(node.GetChildNodes(nameof(DLContent.License)), &objT->License, state);
        Marshal(node.GetChildNodes(nameof(DLContent.Patch)), &objT->Patch, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}