using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum GeometryType
    {
        SPHERE,
        BOX,
        CYLINDER
    }

    public enum ContactPointGenerationType
    {
        NONE,
        VEHICLE,
        STRUCTURE,
        INFANTRY,
        SQUAD_MEMBER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ContactPoint
    {
        public AnsiString Label;
        public Coord3D Pos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Shape
    {
        public GeometryType Type;
        public ContactPointGenerationType ContactPointGeneration;
        public AnsiString Name;
        public float MajorRadius;
        public float MinorRadius;
        public AnsiString Other;
        public float Height;
        public Angle FrontAngle;
        public unsafe Coord3D* Offset;
        public SageBool Active;
        public SageBool UsedForHealthBox;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Geometry
    {
        public unsafe Coord2D* RotationAnchorOffset;
        public List<Shape> Shape;
        public List<ContactPoint> ContactPoint;
        public SageBool IsSmall;
    }
}
