using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TemporalSineWave* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TemporalSineWave.WaveLength), null), &objT->WaveLength, state);
        Marshal(node.GetAttributeValue(nameof(TemporalSineWave.Amplitude), null), &objT->Amplitude, state);
    }

    public static unsafe void Marshal(Node node, CameraShift* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(CameraShift.Randomness), null), &objT->Randomness, state);
        Marshal(node.GetChildNodes(nameof(CameraShift.SineWave)), &objT->SineWave, state);
    }

    public static unsafe void Marshal(Node node, PhaseEffect* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PhaseEffect.PhaseMaskModel), null), &objT->PhaseMaskModel, state);
        Marshal(node.GetChildNode(nameof(PhaseEffect.PhaseStateShader), null), &objT->PhaseStateShader, state);
        Marshal(node.GetChildNode(nameof(PhaseEffect.CameraShift), null), &objT->CameraShift, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}