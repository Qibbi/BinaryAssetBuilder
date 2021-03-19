using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LinearDamageUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.StartDistanceOffset), "0"), &objT->StartDistanceOffset, state);
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.Radius), "10.0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.Length), null), &objT->Length, state);
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.SweepFXList), null), &objT->SweepFXList, state);
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.SweepWeapon), null), &objT->SweepWeapon, state);
        Marshal(node.GetAttributeValue(nameof(LinearDamageUpdateModuleData.Speed), "1.0"), &objT->Speed, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
