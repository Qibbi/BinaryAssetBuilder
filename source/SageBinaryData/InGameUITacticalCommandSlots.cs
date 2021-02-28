using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIGroupSelectionGroupCommandSlots
    {
        public AssetReference<HotKeySlot> Create;
        public AssetReference<HotKeySlot> AddTo;
        public AssetReference<HotKeySlot> Select;
        public AssetReference<HotKeySlot> View;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIViewBookmarkCommandSlots
    {
        public AssetReference<HotKeySlot> GoTo;
        public AssetReference<HotKeySlot> Save;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIGroupSelectionCommandSlots
    {
        public BaseAssetType Base;
        public List<InGameUIGroupSelectionGroupCommandSlots> Group;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUILookAtCommandSlots
    {
        public BaseAssetType Base;
        public List<InGameUIViewBookmarkCommandSlots> ViewBookmark;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUITacticalCommandSlots
    {
        public BaseAssetType Base;
        public AssetReference<HotKeySlot> AllCheer;
        public AssetReference<HotKeySlot> AttackMove;
        public AssetReference<HotKeySlot> CameraReset;
        public AssetReference<HotKeySlot> CameraRotateLeft;
        public AssetReference<HotKeySlot> CameraRotateRight;
        public AssetReference<HotKeySlot> CameraScrollDown;
        public AssetReference<HotKeySlot> CameraScrollLeft;
        public AssetReference<HotKeySlot> CameraScrollRight;
        public AssetReference<HotKeySlot> CameraScrollUp;
        public AssetReference<HotKeySlot> CameraZoomIn;
        public AssetReference<HotKeySlot> CameraZoomOut;
        public AssetReference<HotKeySlot> ChatWithAllies;
        public AssetReference<HotKeySlot> ChatWithBuddies;
        public AssetReference<HotKeySlot> ChatWithEveryone;
        public AssetReference<HotKeySlot> CreateFormation;
        public AssetReference<HotKeySlot> CycleHarvesters;
        public AssetReference<HotKeySlot> ForceAttack;
        public AssetReference<HotKeySlot> ForceAttackMove;
        public AssetReference<HotKeySlot> ForceMove;
        public AssetReference<HotKeySlot> GoToNextBuildQueue;
        public AssetReference<HotKeySlot> GoToPriorBuildQueue;
        public AssetReference<HotKeySlot> OpenMessenger;
        public AssetReference<HotKeySlot> OpenPauseScreen;
        public AssetReference<HotKeySlot> OpenStatusScreen;
        public AssetReference<HotKeySlot> PlaceBeacon;
        public AssetReference<HotKeySlot> PlaceRallyPoint;
        public AssetReference<HotKeySlot> PlanningMode;
        public AssetReference<HotKeySlot> PreferSelection;
        public AssetReference<HotKeySlot> ReverseMove;
        public AssetReference<HotKeySlot> Scatter;
        public AssetReference<HotKeySlot> SelectAll;
        public AssetReference<HotKeySlot> SelectMatchingUnits;
        public AssetReference<HotKeySlot> Sell;
        public AssetReference<HotKeySlot> SellMode;
        public AssetReference<HotKeySlot> ShowAllHealthBars;
        public AssetReference<HotKeySlot> StanceAggressive;
        public AssetReference<HotKeySlot> StanceGuard;
        public AssetReference<HotKeySlot> StanceHoldFire;
        public AssetReference<HotKeySlot> StanceHoldPosition;
        public AssetReference<HotKeySlot> Stop;
        public AssetReference<HotKeySlot> TelestratorErase;
        public AssetReference<HotKeySlot> TelestratorNextColor;
        public AssetReference<HotKeySlot> TelestratorNextLineWidth;
        public AssetReference<HotKeySlot> TelestratorPriorColor;
        public AssetReference<HotKeySlot> TelestratorToggle;
        public AssetReference<HotKeySlot> ToggleFastForwardMode;
        public AssetReference<HotKeySlot> ToggleHUD;
        public AssetReference<HotKeySlot> TogglePowerMode;
        public AssetReference<HotKeySlot> ToggleRepairMode;
        public AssetReference<HotKeySlot> ViewHomeBase;
        public AssetReference<HotKeySlot> ViewLastEvaEvent;
        public AssetReference<HotKeySlot> WaypointMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUISideBarBuildQueuePageSlot
    {
        public ProductionQueueType QueueType;
        public AssetReference<HotKeySlot> Slot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUISideBarCommandSlots
    {
        public BaseAssetType Base;
        public AssetReference<HotKeySlot> SelectionRefinementPage;
        public List<InGameUISideBarBuildQueuePageSlot> BuildQueuePage;
        public List<AssetReference<HotKeySlot>> ButtonSlot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIPlayerPowerCommandSlots
    {
        public BaseAssetType Base;
        public List<AssetReference<HotKeySlot>> Slot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIUnitAbilityCommandSlots
    {
        public BaseAssetType Base;
        public List<AssetReference<HotKeySlot>> Slot;
    }
}
