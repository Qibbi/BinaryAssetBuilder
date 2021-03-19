using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpawnCrateUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.MaxCrates), "20"), &objT->MaxCrates, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.CreateFrequency), "30s"), &objT->CreateFrequency, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.CrateLifetime), "120s"), &objT->CrateLifetime, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.MapExclusionMargin), "50.0"), &objT->MapExclusionMargin, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.BlockingUnitRange), "30.0"), &objT->BlockingUnitRange, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.BlockingStartPositionRange), "300.0"), &objT->BlockingStartPositionRange, state);
        Marshal(node.GetAttributeValue(nameof(SpawnCrateUpdateModuleData.Flags), "DELETE_EXPIRED_CRATES"), &objT->Flags, state);
        Marshal(node.GetChildNodes(nameof(SpawnCrateUpdateModuleData.CrateList)), &objT->CrateList, state);
        Marshal(node.GetChildNode(nameof(SpawnCrateUpdateModuleData.BlockingUnits), null), &objT->BlockingUnits, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
