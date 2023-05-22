using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ToppleUpdateModuleData
{
    public UpdateModuleData Base;
    public AssetReference<FXList> ToppleFX;
    public AssetReference<FXList> BounceFX;
    public TypedAssetId<GameObject> StumpId;
    public Percentage InitialVelocityPercent;
    public Percentage InitialAccelPercent;
    public Percentage BounceVelocityPercent;
    public float MinimumToppleSpeed;
    public SageBool KillWhenToppled;
    public SageBool KillWhenStartToppled;
    public SageBool KillStumpWhenToppled;
    public SageBool ToppleLeftOrRightOnly;
    public SageBool ReorientToppledRubble;
}
