using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DTreeDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.Model), null), &objT->Model, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MoveOutwardTime), null), &objT->MoveOutwardTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MoveInwardTime), null), &objT->MoveInwardTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MoveOutwardDistanceFactor), null), &objT->MoveOutwardDistanceFactor, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.DarkeningFactor), null), &objT->DarkeningFactor, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.ToppleFX), null), &objT->ToppleFX, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.BounceFX), null), &objT->BounceFX, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.KillWhenFinishedToppling), null), &objT->KillWhenFinishedToppling, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.DoTopple), null), &objT->DoTopple, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.InitialVelocityPercent), null), &objT->InitialVelocityPercent, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.InitialAccelPercent), null), &objT->InitialAccelPercent, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.BounceVelocityPercent), null), &objT->BounceVelocityPercent, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MinimumToppleSpeed), null), &objT->MinimumToppleSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.SinkDistance), null), &objT->SinkDistance, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.SinkTime), null), &objT->SinkTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MorphTree), null), &objT->MorphTree, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MorphTime), null), &objT->MorphTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.MorphFX), null), &objT->MorphFX, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.TaintedTree), null), &objT->TaintedTree, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.FadeRate), null), &objT->FadeRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.FadeTarget), null), &objT->FadeTarget, state);
        Marshal(node.GetAttributeValue(nameof(W3DTreeDrawModuleData.FadeDistance), null), &objT->FadeDistance, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}