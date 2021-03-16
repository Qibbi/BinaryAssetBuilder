using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum FXListBehaviorType
    {
        onDeath,
        onDamaged,
        onCreate,
        onTransitionToDamaged,
        onTransitionToReallyDamaged,
        onTransitionToRubble,
        onBecomingTemporarySlave,
        onBecomingTemporaryOwner,
        onEndingTemporarySlave,
        onEndingTemporaryOwner,
    }

    public enum FXListBehaviorDirection
    {
        Front,
        Rear,
        Side,
        Top,
        Default
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXListBehaviorEvent
    {
        public FXListBehaviorType Index;
        public AssetReference<FXList> FX;
        public float MinThreshold;
        public float MaxThreshold;
        public FXListBehaviorDirection Direction;
        public SageBool OrientToObject;
        public SageBool ForceUseDoFXObj;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXListBehaviorModuleData
    {
        public DieModuleData Base;
        public List<FXListBehaviorEvent> Event;
    }
}
