using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleBaseModule : IPolymorphic
{
    public uint TypeId;
}

[StructLayout(LayoutKind.Sequential)]
public struct RandCoord3D
{
#pragma warning disable IDE1006 // Naming Styles
    public ClientRandomVariable x;
    public ClientRandomVariable y;
    public ClientRandomVariable z;
#pragma warning restore IDE1006 // Naming Styles
}

public enum FXParticleSystem_Type
{
    INVALID_TYPE,
    PARTICLE,
    DRAWABLE,
    STREAK,
    VOLUME_PARTICLE,
    GPU_PARTICLE,
    GPU_TERRAINFIRE,
    SWARM,
    TRAIL
}

public enum FXParticleSystem_Priority
{
    INVALID_PRIORITY,
    ULTRA_HIGH_ONLY,
    HIGH_OR_ABOVE,
    MEDIUM_OR_ABOVE,
    LOW_OR_ABOVE,
    VERY_LOW_OR_ABOVE,
    ALWAYS_RENDER
}

public enum FXParticleSystem_WindMotion
{
    INVALID,
    NOT_USED,
    PING_PONG,
    CIRCULAR
}

public enum FXParticleSystem_GeometryType
{
    INVALID,
    SIMPLE_QUAD,
    CENTERED_QUAD,
    TWO_CONCENTRIC_QUADS
}

public enum FXParticleSystem_ShaderType
{
    INVALID_SHADER,
    ADDITIVE,
    ADDITIVE_ALPHA_TEST,
    ALPHA,
    ALPHA_TEST,
    MULTIPLY,
    ADDITIVE_NO_DEPTH_TEST,
    ALPHA_NO_DEPTH_TEST,
    W3D_DIFFUSE,
    W3D_ALPHA,
    W3D_EMISSIVE
}

public enum FXParticleSystem_RotationType
{
    INVALID_ROTATION,
    ROTATION_OFF,
    ROTATE_X,
    ROTATE_Y,
    ROTATE_Z,
    ROTATE_V
}
