using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LockonInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonTime), "0.0"), &objT->LockonTime, state);
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonCursor), null), &objT->LockonCursor, state);
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonInitialDist), "100"), &objT->LockonInitialDist, state);
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonFreq), "0.5"), &objT->LockonFreq, state);
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonAngleSpin), "720d"), &objT->LockonAngleSpin, state);
        Marshal(node.GetAttributeValue(nameof(LockonInfo.LockonBlinky), "false"), &objT->LockonBlinky, state);
    }

    public static unsafe void Marshal(Node node, JetAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.OutOfAmmoDamagePerSecond), "0"), &objT->OutOfAmmoDamagePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.OutOfAmmoDamageDelay), null), &objT->OutOfAmmoDamageDelay, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.NeedsRunway), "false"), &objT->NeedsRunway, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.ReturnToBaseWhenVictimDead), "false"), &objT->ReturnToBaseWhenVictimDead, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.KeepsParkingSpaceWhenAirborne), "false"), &objT->KeepsParkingSpaceWhenAirborne, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.TakeoffSpeedForMaxLift), "100"), &objT->TakeoffSpeedForMaxLift, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.TakeoffPause), "0"), &objT->TakeoffPause, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.MinHeight), "0.0"), &objT->MinHeight, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.ParkingOffset), "0.0"), &objT->ParkingOffset, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.SneakyOffsetWhenAttacking), "0.0"), &objT->SneakyOffsetWhenAttacking, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.AttackLocomotorType), null), &objT->AttackLocomotorType, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.AttackLocomotorPersistTime), "0"), &objT->AttackLocomotorPersistTime, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.AttackersMissPersistTime), "0"), &objT->AttackersMissPersistTime, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.ReturnForAmmoLocomotorType), null), &objT->ReturnForAmmoLocomotorType, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.ReturnToBaseIdleTime), "0"), &objT->ReturnToBaseIdleTime, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.CirclesForAttack), "false"), &objT->CirclesForAttack, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.UseForOutOfAmmoCheck), null), &objT->UseForOutOfAmmoCheck, state);
        Marshal(node.GetAttributeValue(nameof(JetAIUpdateModuleData.OutOfAmmoEvaEvent), null), &objT->OutOfAmmoEvaEvent, state);
        Marshal(node.GetChildNode(nameof(JetAIUpdateModuleData.LockonInfo), null), &objT->LockonInfo, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
