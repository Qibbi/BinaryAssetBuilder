using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BezierProjectileBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.TumbleRandomly), "false"), &objT->TumbleRandomly, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.DetonateCallsKill), "false"), &objT->DetonateCallsKill, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.OrientToFlightPath), "false"), &objT->OrientToFlightPath, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FirstHeight), null), &objT->FirstHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SecondHeight), null), &objT->SecondHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FirstHeightMin), null), &objT->FirstHeightMin, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FirstHeightMax), null), &objT->FirstHeightMax, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SecondHeightMin), null), &objT->SecondHeightMin, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SecondHeightMax), null), &objT->SecondHeightMax, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FirstPercentIndent), null), &objT->FirstPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SecondPercentIndent), null), &objT->SecondPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.CrushStyle), "false"), &objT->CrushStyle, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.DieOnImpact), "false"), &objT->DieOnImpact, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FinalStuckTime), null), &objT->FinalStuckTime, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PreLandingStateTime), null), &objT->PreLandingStateTime, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceCount), null), &objT->BounceCount, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceDistance), null), &objT->BounceDistance, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceFirstHeight), null), &objT->BounceFirstHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceSecondHeight), null), &objT->BounceSecondHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceFirstPercentIndent), null), &objT->BounceFirstPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.BounceSecondPercentIndent), null), &objT->BounceSecondPercentIndent, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GarrisonHitKillRequiredKindOf), null), &objT->GarrisonHitKillRequiredKindOf, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GarrisonHitKillForbiddenKindOf), null), &objT->GarrisonHitKillForbiddenKindOf, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GarrisonHitKillCount), null), &objT->GarrisonHitKillCount, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GarrisonHitKillFX), null), &objT->GarrisonHitKillFX, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GroundHitFX), null), &objT->GroundHitFX, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.MaxDistanceReachedFX), null), &objT->MaxDistanceReachedFX, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GroundBounceFX), null), &objT->GroundBounceFX, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GroundHitWeapon), null), &objT->GroundHitWeapon, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.GroundBounceWeapon), null), &objT->GroundBounceWeapon, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FlightPathAdjustDistPerSecond), null), &objT->FlightPathAdjustDistPerSecond, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FlightPathAdjustStraightOnly), "false"), &objT->FlightPathAdjustStraightOnly, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.IgnoreTerrainHeight), "false"), &objT->IgnoreTerrainHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FirstPercentHeight), null), &objT->FirstPercentHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SecondPercentHeight), null), &objT->SecondPercentHeight, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.CurveFlattenMinDist), null), &objT->CurveFlattenMinDist, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PreLandingEmotion), null), &objT->PreLandingEmotion, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PreLandingEmotionRadius), null), &objT->PreLandingEmotionRadius, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.InvisibleTime), null), &objT->InvisibleTime, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.FadeInTime), null), &objT->FadeInTime, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PostLandingStateTime), null), &objT->PostLandingStateTime, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PostLandingEmotion), null), &objT->PostLandingEmotion, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PostLandingEmotionRadius), null), &objT->PostLandingEmotionRadius, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.SidewaysDrift), null), &objT->SidewaysDrift, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.PingPongSidewaysDrift), "true"), &objT->PingPongSidewaysDrift, state);
        Marshal(node.GetAttributeValue(nameof(BezierProjectileBehaviorModuleData.MaxDistanceToTravel), "1000000"), &objT->MaxDistanceToTravel, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
