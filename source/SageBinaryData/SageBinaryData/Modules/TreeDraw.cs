using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DTreeDrawModuleData
    {
        public DrawModuleData Base;
        public AssetReference<BaseRenderAssetType> Model;
        public AssetReference<Texture> Texture;
        public uint MoveOutwardTime;
        public uint MoveInwardTime;
        public float MoveOutwardDistanceFactor;
        public float DarkeningFactor;
        public AssetReference<FXList> ToppleFX;
        public AssetReference<FXList> BounceFX;
        public Percentage InitialVelocityPercent;
        public Percentage InitialAccelPercent;
        public Percentage BounceVelocityPercent;
        public float MinimumToppleSpeed;
        public float SinkDistance;
        public Duration SinkTime;
        public AssetReference<GameObject> MorphTree;
        public Duration MorphTime;
        public AssetReference<FXList> MorphFX;
        public uint FadeRate;
        public uint FadeTarget;
        public float FadeDistance;
        public SageBool KillWhenFinishedToppling;
        public SageBool DoTopple;
        public SageBool TaintedTree;
    }
}
