using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DLContentObject
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DLLicenseGroup
    {
        public uint LicenseMask;
        public List<TypedAssetId<DLContentObject>> Asset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DLPatch
    {
        public AnsiString Name;
        public byte PatchNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DLContent
    {
        public BaseAssetType Base;
        public List<DLLicenseGroup> License;
        public List<DLPatch> Patch;
        public byte PackageNumber;
    }
}
