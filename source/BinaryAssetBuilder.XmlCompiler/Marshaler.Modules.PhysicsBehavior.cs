using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PhysicsBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.TumbleRandomly), "false"), &objT->TumbleRandomly, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.MaxXRotationVelocity), "360.0"), &objT->MaxXRotationVelocity, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.MaxYRotationVelocity), "360.0"), &objT->MaxYRotationVelocity, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.MaxZRotationVelocity), "360.0"), &objT->MaxZRotationVelocity, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.AllowBouncing), "false"), &objT->AllowBouncing, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.KillWhenRestingOnGround), "false"), &objT->KillWhenRestingOnGround, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.GravityMultiplier), "1.0"), &objT->GravityMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.OrientToFlightPath), "false"), &objT->OrientToFlightPath, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.ShockStunnedTimeLow), "5"), &objT->ShockStunnedTimeLow, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.ShockStunnedTimeHigh), "10"), &objT->ShockStunnedTimeHigh, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.ShockStandingTime), "5"), &objT->ShockStandingTime, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.FirstHeight), "1.3"), &objT->FirstHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.SecondHeight), "1.3"), &objT->SecondHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.FirstPercentIndent), "33"), &objT->FirstPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.SecondPercentIndent), "66"), &objT->SecondPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceCount), "2"), &objT->BounceCount, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceDistance), "5.0"), &objT->BounceDistance, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceFirstHeight), "1.3"), &objT->BounceFirstHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceSecondHeight), "1.3"), &objT->BounceSecondHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceFirstPercentIndent), "33"), &objT->BounceFirstPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.BounceSecondPercentIndent), "66"), &objT->BounceSecondPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.GroundHitFX), null), &objT->GroundHitFX, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.GroundBounceFX), null), &objT->GroundBounceFX, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.IgnoreTerrainHeight), "false"), &objT->IgnoreTerrainHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.FirstPercentHeight), "33"), &objT->FirstPercentHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.SecondPercentHeight), "66"), &objT->SecondPercentHeight, state);
        Marshal(node.GetAttributeValue(nameof(PhysicsBehaviorModuleData.CurveFlattenMinDist), "0"), &objT->CurveFlattenMinDist, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
