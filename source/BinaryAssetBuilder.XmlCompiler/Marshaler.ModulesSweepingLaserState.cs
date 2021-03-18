using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SweepingLaserStateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SweepingLaserStateModuleData.Radius), "10.0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(SweepingLaserStateModuleData.SweepFXList), null), &objT->SweepFXList, state);
        Marshal(node.GetAttributeValue(nameof(SweepingLaserStateModuleData.VeteranSweepFXList), null), &objT->VeteranSweepFXList, state);
        Marshal(node.GetAttributeValue(nameof(SweepingLaserStateModuleData.SweepFXTimeout), "0s"), &objT->SweepFXTimeout, state);
        Marshal(node.GetAttributeValue(nameof(SweepingLaserStateModuleData.SweepWeapon), null), &objT->SweepWeapon, state);
        Marshal(node, (LaserStateModuleData*)objT, state);
    }
}
