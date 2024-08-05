using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityCylinder* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocityCylinder.Radial), null), &objT->Radial, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocityCylinder.Normal), null), &objT->Normal, state);
        Marshal(node, (FXParticleEmissionVelocityBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityOrtho* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocityOrtho.Position), null), &objT->Position, state);
        Marshal(node, (FXParticleEmissionVelocityBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityOutward* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocityOutward.Speed), null), &objT->Speed, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocityOutward.OtherSpeed), null), &objT->OtherSpeed, state);
        Marshal(node, (FXParticleEmissionVelocityBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVelocitySphere* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVelocitySphere.Speed), null), &objT->Speed, state);
        Marshal(node, (FXParticleEmissionVelocityBase*)objT, state);
    }

#if TIBERIUMWARS
    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityHemisphere* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleEmissionVelocitySphere*)objT, state);
    }
#endif

    public static unsafe void Marshal(Node node, FXParticleEmissionVelocityBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
#if TIBERIUMWARS
            case 0xB7B54FC2u:
                MarshalPolymorphicType<FXParticleEmissionVelocityHemisphere, FXParticleEmissionVelocityBase>(node, objT, state);
                break;
#endif
            case 0x8BB38534u:
                MarshalPolymorphicType<FXParticleEmissionVelocitySphere, FXParticleEmissionVelocityBase>(node, objT, state);
                break;
            case 0xCF2FD6DFu:
                MarshalPolymorphicType<FXParticleEmissionVelocityOutward, FXParticleEmissionVelocityBase>(node, objT, state);
                break;
            case 0xE7528102u:
                MarshalPolymorphicType<FXParticleEmissionVelocityOrtho, FXParticleEmissionVelocityBase>(node, objT, state);
                break;
            case 0xF1EC3B2Eu:
                MarshalPolymorphicType<FXParticleEmissionVelocityCylinder, FXParticleEmissionVelocityBase>(node, objT, state);
                break;
        }
    }
}
