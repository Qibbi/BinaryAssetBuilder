using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MissileUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.FuelLifetime), "0s"), &objT->FuelLifetime, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.IgnitionDelay), "0s"), &objT->IgnitionDelay, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.DistanceToTravelBeforeTurning), "0.0"), &objT->DistanceToTravelBeforeTurning, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.DistanceToTargetBeforeDiving), "0"), &objT->DistanceToTargetBeforeDiving, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.IgnitionFX), null), &objT->IgnitionFX, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.DetonateOnNoFuel), "false"), &objT->DetonateOnNoFuel, state);
        Marshal(node.GetAttributeValue(nameof(MissileUpdateModuleData.ExhaustTemplate), null), &objT->ExhaustTemplate, state);
        Marshal(node, (BezierProjectileBehaviorModuleData*)objT, state);
    }
}
