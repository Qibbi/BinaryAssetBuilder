using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GameObjectEvaEvents
    {
        public unsafe AnsiString* EvaEventDieOwner;
        public unsafe AnsiString* EvaEventDieAlly;
        public unsafe AnsiString* EvaEventDieEnemy;
        public unsafe AnsiString* EvaEventSoldOwner;
        public unsafe AnsiString* EvaEventDamagedOwner;
        public unsafe AnsiString* EvaEventDamagedFromShroudedSourceOwner;
        public unsafe AnsiString* EvaEventDamagedByFireOwner;
        public unsafe AnsiString* EvaEventSecondDamageFarFromFirstOwner;
        public float EvaEventSecondDamageFarFromFirstScanRange;
        public uint EvaEventSecondDamageFarFromFirstTimeoutMS;
        public unsafe AnsiString* EvaEventAmbushed;
        public unsafe AnsiString* EvaEventRepairingOwner;
        public unsafe AnsiString* EvaEnemyObjectSightedEvent;
        public unsafe AnsiString* EvaEnemyObjectSightedAfterRespawnEvent;
        public unsafe AnsiString* EvaOnFirstSightingEventEnemy;
        public unsafe AnsiString* EvaOnFirstSightingEventNonEnemy;
        public unsafe AnsiString* EvaEventDetectedEnemy;
        public unsafe AnsiString* EvaEventDetectedAlly;
        public unsafe AnsiString* EvaEventDetectedOwner;
        public unsafe AnsiString* EvaEventAvailableForProduction;
        public unsafe AnsiString* EvaEventProductionStarted;
        public unsafe AnsiString* EvaEventProductionComplete;
        public unsafe AnsiString* EvaEventPlacementFailed;
        public unsafe AnsiString* EvaEventCannotBuildDueToFullBuildQueue;
        public unsafe AnsiString* EvaEventBuildOnHold;
        public unsafe AnsiString* EvaEventBuildCancelled;
        public unsafe AnsiString* EvaEventPromotedOwner;
        public unsafe AnsiString* EvaEventManuallyPoweredOff;
        public unsafe AnsiString* EvaEventManuallyPoweredOn;
    }
}
