using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ClusterBombUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.WeaponName), null), &objT->WeaponName, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.InitialWeaponName), null), &objT->InitialWeaponName, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.Radius), "0.0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.NumBomblets), "0"), &objT->NumBomblets, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.MinDelay), "0s"), &objT->MinDelay, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.MaxDelay), "0s"), &objT->MaxDelay, state);
        Marshal(node.GetAttributeValue(nameof(ClusterBombUpdateModuleData.BombletFX), null), &objT->BombletFX, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
