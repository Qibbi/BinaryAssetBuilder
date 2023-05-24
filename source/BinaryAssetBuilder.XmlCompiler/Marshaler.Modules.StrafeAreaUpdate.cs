using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StrafeAreaUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.WeaponName), null), &objT->WeaponName, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.MinRadius), "0"), &objT->MinRadius, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.PreattackDistance), "0"), &objT->PreattackDistance, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.SweepFrequency), "0"), &objT->SweepFrequency, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.SweepAmplitude), "0"), &objT->SweepAmplitude, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.DivingFloor), "0"), &objT->DivingFloor, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.InitialSweepPhase), "0"), &objT->InitialSweepPhase, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.TargetJitterOffset), "0"), &objT->TargetJitterOffset, state);
        Marshal(node.GetAttributeValue(nameof(StrafeAreaUpdateModuleData.ShotsToFirePerFrame), "1"), &objT->ShotsToFirePerFrame, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
