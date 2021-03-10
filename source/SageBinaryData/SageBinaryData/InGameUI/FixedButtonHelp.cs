using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIFixedButtonHelp
    {
        public unsafe InGameUISimpleHelpTemplate* AggressiveStance;
        public unsafe InGameUISimpleHelpTemplate* AircraftTab;
        public unsafe InGameUISimpleHelpTemplate* AircraftTypeTab;
        public unsafe InGameUISimpleHelpTemplate* AttackMove;
        public unsafe InGameUISimpleHelpTemplate* ForceAttack;
        public unsafe InGameUISimpleHelpTemplate* ForceMove;
        public unsafe InGameUISimpleHelpTemplate* GuardStance;
        public unsafe InGameUISimpleHelpTemplate* HoldGroundStance;
        public unsafe InGameUISimpleHelpTemplate* HoldFireStance;
        public unsafe InGameUISimpleHelpTemplate* InfantryTab;
        public unsafe InGameUISimpleHelpTemplate* InfantryTypeTab;
        public unsafe InGameUISimpleHelpTemplate* IntelligenceDatabase;
        public unsafe InGameUISimpleHelpTemplate* MainStructureTab;
        public unsafe InGameUISimpleHelpTemplate* MainStructureTypeTab;
        public unsafe InGameUISimpleHelpTemplate* Messenger;
        public unsafe InGameUISimpleHelpTemplate* Objectives;
        public unsafe InGameUISimpleHelpTemplate* OtherStructureTab;
        public unsafe InGameUISimpleHelpTemplate* OtherStructureTypeTab;
        public unsafe InGameUISimpleHelpTemplate* PlanningMode;
        public unsafe InGameUISimpleHelpTemplate* PlayerStatus;
        public unsafe InGameUISimpleHelpTemplate* ReplayFastForward;
        public unsafe InGameUISimpleHelpTemplate* ReverseMove;
        public unsafe InGameUISimpleHelpTemplate* SelectionRefinementTab;
        public unsafe InGameUISimpleHelpTemplate* SellMode;
        public unsafe InGameUISimpleHelpTemplate* Stop;
        public unsafe InGameUISimpleHelpTemplate* TogglePowerMode;
        public unsafe InGameUISimpleHelpTemplate* ToggleRepairMode;
        public unsafe InGameUISimpleHelpTemplate* VehicleTab;
        public unsafe InGameUISimpleHelpTemplate* VehicleTypeTab;
        public unsafe InGameUISimpleHelpTemplate* VoiceChatMode;
        public unsafe InGameUISimpleHelpTemplate* VoiceChatTalk;
        public unsafe InGameUISimpleHelpTemplate* WaypointMode;
    }
}
