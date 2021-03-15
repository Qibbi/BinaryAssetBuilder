using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GameObjectEvaEvents* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDieOwner), null), &objT->EvaEventDieOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDieAlly), null), &objT->EvaEventDieAlly, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDieEnemy), null), &objT->EvaEventDieEnemy, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventSoldOwner), null), &objT->EvaEventSoldOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDamagedOwner), null), &objT->EvaEventDamagedOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDamagedFromShroudedSourceOwner), null), &objT->EvaEventDamagedFromShroudedSourceOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDamagedByFireOwner), null), &objT->EvaEventDamagedByFireOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventSecondDamageFarFromFirstOwner), null), &objT->EvaEventSecondDamageFarFromFirstOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventSecondDamageFarFromFirstScanRange), "200"), &objT->EvaEventSecondDamageFarFromFirstScanRange, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventSecondDamageFarFromFirstTimeoutMS), "31000"), &objT->EvaEventSecondDamageFarFromFirstTimeoutMS, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventAmbushed), null), &objT->EvaEventAmbushed, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventRepairingOwner), null), &objT->EvaEventRepairingOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEnemyObjectSightedEvent), null), &objT->EvaEnemyObjectSightedEvent, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEnemyObjectSightedAfterRespawnEvent), null), &objT->EvaEnemyObjectSightedAfterRespawnEvent, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaOnFirstSightingEventEnemy), null), &objT->EvaOnFirstSightingEventEnemy, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaOnFirstSightingEventNonEnemy), null), &objT->EvaOnFirstSightingEventNonEnemy, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDetectedEnemy), null), &objT->EvaEventDetectedEnemy, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDetectedAlly), null), &objT->EvaEventDetectedAlly, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventDetectedOwner), null), &objT->EvaEventDetectedOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventAvailableForProduction), null), &objT->EvaEventAvailableForProduction, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventProductionStarted), null), &objT->EvaEventProductionStarted, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventProductionComplete), null), &objT->EvaEventProductionComplete, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventPlacementFailed), null), &objT->EvaEventPlacementFailed, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventCannotBuildDueToFullBuildQueue), null), &objT->EvaEventCannotBuildDueToFullBuildQueue, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventBuildOnHold), null), &objT->EvaEventBuildOnHold, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventBuildCancelled), null), &objT->EvaEventBuildCancelled, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventPromotedOwner), null), &objT->EvaEventPromotedOwner, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventManuallyPoweredOff), null), &objT->EvaEventManuallyPoweredOff, state);
        Marshal(node.GetAttributeValue(nameof(GameObjectEvaEvents.EvaEventManuallyPoweredOn), null), &objT->EvaEventManuallyPoweredOn, state);
    }
}
