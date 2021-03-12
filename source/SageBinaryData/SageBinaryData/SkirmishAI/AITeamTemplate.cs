using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CreateUnitInfo
    {
        public int MinUnits;
        public int MaxUnits;
        public TypedAssetId<GameObject> UnitName;
        public int ExperienceLevel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AITeamTemplate
    {
        public int MinUnits;
        public unsafe int* MaxUnits;
        public KindOfBitFlags IncludeKindOf;
        public KindOfBitFlags ExcludeKindOf;
        public List<CreateUnitInfo> CreateUnits;
        public SageBool AlwaysRecruit;
        public SageBool AlwaysRelease;
        public SageBool AutoReinforce;
    }
}
