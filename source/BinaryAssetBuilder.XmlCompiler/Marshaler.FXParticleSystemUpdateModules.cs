using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleUpdateBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleUpdateDefault* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleUpdateDefault.Rotation), "ROTATION_OFF"), &objT->Rotation, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.SizeRate), null), &objT->SizeRate, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.SizeRateDamping), null), &objT->SizeRateDamping, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngleZ), null), &objT->AngleZ, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngularRateZ), null), &objT->AngularRateZ, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngularDamping), null), &objT->AngularDamping, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngleXY), null), &objT->AngleXY, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngularRateXY), null), &objT->AngularRateXY, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateDefault.AngularDampingXY), null), &objT->AngularDampingXY, state);
        Marshal(node, (FXParticleUpdateBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleUpdateRenderObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleUpdateRenderObject.Rotation), "ROTATION_OFF"), &objT->Rotation, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.AngleZ), null), &objT->AngleZ, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.AngularRateZ), null), &objT->AngularRateZ, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.AngularDamping), null), &objT->AngularDamping, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.StartSize), null), &objT->StartSize, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.SizeRate), null), &objT->SizeRate, state);
        Marshal(node.GetChildNode(nameof(FXParticleUpdateRenderObject.SizeDamping), null), &objT->SizeDamping, state);
        Marshal(node, (FXParticleUpdateBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleUpdateBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x0DFB6E4Au:
                MarshalPolymorphicType<FXParticleUpdateRenderObject, FXParticleUpdateBase>(node, objT, state);
                break;
            case 0xAEDEA298u:
                MarshalPolymorphicType<FXParticleUpdateDefault, FXParticleUpdateBase>(node, objT, state);
                break;
        }
    }
}
