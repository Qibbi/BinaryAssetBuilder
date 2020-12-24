using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StartPositionObject
    {
        public AnsiString Name;
        public Coord3D Position;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MetaDataObject
    {
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<MetaDataObject> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
        public AnsiString Description;
        public AnsiString DisplayName;
        public int NumPlayers;
        public uint CRC;
        public AnsiString FileName;
        public int Width;
        public int Height;
        public int BorderSize;
        public List<StartPositionObject> StartPosition;
        public SageBool IsMultiplayer;
        public SageBool IsOfficial;
    }
}
