using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum AttachUpdateFlagsType
    {
        NONE,
        FIND_BEST_PARENT,
        UNCONTAINED_ONLY,
        SAME_PLAYER_ONLY,
        ONE_ATTACH_PER_PARENT
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttachUpdateFlagsBitFlags
    {
        public const int Count = 0x00000005;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttachUpdateModuleData
    {
        public UpdateModuleData Base;
        public ObjectStatusBitFlags ParentStatus;
        public ObjectStatusBitFlags ForbiddenParentStatus;
        public float Range;
        public float CloseEnoughRange;
        public AnsiString ParentOwnerAttachmentEvaEvent;
        public AnsiString ParentAllyAttachmentEvaEvent;
        public AnsiString ParentEnemyAttachmentEvaEvent;
        public AssetReference<FXList> AttachFXList;
        public AnsiString ParentOwnerDiedEvaEvent;
        public AnsiString ParentAllyDiedEvaEvent;
        public AnsiString ParentEnemyDiedEvaEvent;
        public Time InitialAttachDelay;
        public Time IdleScanDelay;
        public AttachUpdateFlagsBitFlags Flags;
        public unsafe ObjectFilter* ObjectFilter;
        public SageBool ShouldStickToParent;
        public SageBool Teleport;
        public SageBool UseGeometry;
        public SageBool DetachWhenParentHealed;
        public SageBool DetachWhenParentOutOfSlavedRange;
        public SageBool RequireFullyHealedToDetach;
        public SageBool ScanForNewParentWhenDetached;
        public SageBool CanAttachToHordeMembers;
    }
}
