using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SCBaseType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SCBaseType.Type), null), &objT->Type, state);
    }

    public static unsafe void Marshal(Node node, SCFXListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SCFXListType.FX)), &objT->FX, state);
        Marshal(node, (SCBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, SCOCLListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SCOCLListType.OCL)), &objT->OCL, state);
        Marshal(node, (SCBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, StructureCollapseUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.MinCollapseDelay), "0"), &objT->MinCollapseDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.MaxCollapseDelay), "0"), &objT->MaxCollapseDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.MinBurstDelay), "9999"), &objT->MinBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.MaxBurstDelay), "0"), &objT->MaxBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.BigBurstFrequency), "0"), &objT->BigBurstFrequency, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.CollapseDamping), "0"), &objT->CollapseDamping, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.MaxShudder), "0"), &objT->MaxShudder, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.DestroyObjectWhenDone), "false"), &objT->DestroyObjectWhenDone, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.CollapseHeight), "0"), &objT->CollapseHeight, state);
        Marshal(node.GetAttributeValue(nameof(StructureCollapseUpdateModuleData.CrushingWeapon), null), &objT->CrushingWeapon, state);
        Marshal(node.GetChildNodes(nameof(StructureCollapseUpdateModuleData.OCL)), &objT->OCL, state);
        Marshal(node.GetChildNodes(nameof(StructureCollapseUpdateModuleData.FX)), &objT->FX, state);
        Marshal(node.GetChildNode(nameof(StructureCollapseUpdateModuleData.Die), null), &objT->Die, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
