using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BaseRenderAssetType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }

    private static unsafe void Marshal(Node node, Vector2* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Vector2.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(Vector2.Y), null), &objT->Y, state);
    }

    private static unsafe void Marshal(Node node, Vector3* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Vector3.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(Vector3.Y), null), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(Vector3.Z), null), &objT->Z, state);
    }

    private static unsafe void Marshal(Node node, Vector4* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Vector4.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(Vector4.Y), null), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(Vector4.Z), null), &objT->Z, state);
        Marshal(node.GetAttributeValue(nameof(Vector4.W), null), &objT->W, state);
    }

    private static unsafe void Marshal(Node node, Quaternion* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Quaternion.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.Y), null), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.Z), null), &objT->Z, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.W), null), &objT->W, state);
    }

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

    private static unsafe void MarshalRenderObjectReference(Node node, AssetReference<BaseAssetType>* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        List list = node.GetChildNodes(null);
        if (list is null || list.GetCount() != 1)
        {
            return;
        }
        Marshal(list.GetNextNode(), objT, state);
    }

    public static unsafe void Marshal(Node node, SubObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SubObject.BoneIndex), null), &objT->BoneIndex, state);
        Marshal(node.GetAttributeValue(nameof(SubObject.SubObjectID), ""), &objT->SubObjectID, state);
        MarshalRenderObjectReference(node.GetChildNode(nameof(SubObject.RenderObject), null), &objT->RenderObject, state);
    }

    public static unsafe void Marshal(Node node, W3DContainer* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DContainer.Hierarchy), null), &objT->Hierarchy, state);
        Marshal(node.GetChildNodes(nameof(W3DContainer.SubObject)), &objT->SubObject, state);
        Marshal(node, (BaseRenderAssetType*)objT, state);
    }

    private static unsafe void Marshal(Node node, W3DHierarchy.HierarchyPivot.Matrix* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M00), null), &objT->M00, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M10), null), &objT->M10, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M20), null), &objT->M20, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M30), null), &objT->M30, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M01), null), &objT->M01, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M11), null), &objT->M11, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M21), null), &objT->M21, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M31), null), &objT->M31, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M02), null), &objT->M02, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M12), null), &objT->M12, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M22), null), &objT->M22, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M32), null), &objT->M32, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M03), null), &objT->M03, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M13), null), &objT->M13, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M23), null), &objT->M23, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Matrix.M33), null), &objT->M33, state);
    }

    public static unsafe void Marshal(Node node, W3DHierarchy.HierarchyPivot* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(W3DHierarchy.HierarchyPivot.Parent), null), &objT->Parent, state);
        Marshal(node.GetChildNode(nameof(W3DHierarchy.HierarchyPivot.Translation), null), &objT->Translation, state);
        Marshal(node.GetChildNode(nameof(W3DHierarchy.HierarchyPivot.Rotation), null), &objT->Rotation, state);
        Marshal(node.GetChildNode(nameof(W3DHierarchy.HierarchyPivot.FixupMatrix), null), &objT->FixupMatrix, state);
    }

    public static unsafe void Marshal(Node node, W3DHierarchy* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(W3DHierarchy.Pivot)), &objT->Pivot, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, W3DCollisionBox* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DCollisionBox.JoypadPickingOnly), "false"), &objT->JoypadPickingOnly, state);
        Marshal(node.GetChildNode(nameof(W3DCollisionBox.Center), null), &objT->Center, state);
        Marshal(node.GetChildNode(nameof(W3DCollisionBox.Extent), null), &objT->Extent, state);
        Marshal(node, (BaseRenderAssetType*)objT, state);
    }
}