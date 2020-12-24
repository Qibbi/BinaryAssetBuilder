using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXShaderConstant* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXShaderConstant.Name), null), &objT->Name, state);
    }

    public static unsafe void Marshal(Node node, FXShaderConstantBool* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXShaderConstantBool.Value), null), &objT->Value, state);
        Marshal(node, (FXShaderConstant*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXShaderConstantFloat* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(FXShaderConstantFloat.Value)), &objT->Value, state);
        Marshal(node, (FXShaderConstant*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXShaderConstantInt* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXShaderConstantInt.Value), null), &objT->Value, state);
        Marshal(node, (FXShaderConstant*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXShaderConstantTexture* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXShaderConstantTexture.Value), null), &objT->Value, state);
        Marshal(node, (FXShaderConstant*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXShaderConstant** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0u;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x89181982u:
                MarshalPolymorphicType<FXShaderConstantInt, FXShaderConstant>(node, objT, state);
                break;
            case 0xA3F84C3Du:
                MarshalPolymorphicType<FXShaderConstantBool, FXShaderConstant>(node, objT, state);
                break;
            case 0xA59096A6u:
                MarshalPolymorphicType<FXShaderConstantTexture, FXShaderConstant>(node, objT, state);
                break;
            case 0xDF08DF25u:
                MarshalPolymorphicType<FXShaderConstantFloat, FXShaderConstant>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, FXShaderMaterial* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXShaderMaterial.ShaderName), null), &objT->ShaderName, state);
        Marshal(node.GetAttributeValue(nameof(FXShaderMaterial.TechniqueName), string.Empty), &objT->TechniqueName, state);
        Marshal(node.GetAttributeValue(nameof(FXShaderMaterial.TechniqueIndex), "0"), &objT->TechniqueIndex, state);
        Marshal(node.GetChildNode(nameof(FXShaderMaterial.Constants), null), &objT->Constants, state);
    }
}