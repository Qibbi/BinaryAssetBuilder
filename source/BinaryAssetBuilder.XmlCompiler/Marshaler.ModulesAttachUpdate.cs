using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AttachUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentStatus), null), &objT->ParentStatus, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ForbiddenParentStatus), null), &objT->ForbiddenParentStatus, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.Range), null), &objT->Range, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.CloseEnoughRange), "1000.0"), &objT->CloseEnoughRange, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ShouldStickToParent), "true"), &objT->ShouldStickToParent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.Teleport), "true"), &objT->Teleport, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.UseGeometry), "true"), &objT->UseGeometry, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.DetachWhenParentHealed), "false"), &objT->DetachWhenParentHealed, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.DetachWhenParentOutOfSlavedRange), "false"), &objT->DetachWhenParentOutOfSlavedRange, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.RequireFullyHealedToDetach), "false"), &objT->RequireFullyHealedToDetach, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ScanForNewParentWhenDetached), "false"), &objT->ScanForNewParentWhenDetached, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentOwnerAttachmentEvaEvent), null), &objT->ParentOwnerAttachmentEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentAllyAttachmentEvaEvent), null), &objT->ParentAllyAttachmentEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentEnemyAttachmentEvaEvent), null), &objT->ParentEnemyAttachmentEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.AttachFXList), null), &objT->AttachFXList, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentOwnerDiedEvaEvent), null), &objT->ParentOwnerDiedEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentAllyDiedEvaEvent), null), &objT->ParentAllyDiedEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.ParentEnemyDiedEvaEvent), null), &objT->ParentEnemyDiedEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.InitialAttachDelay), null), &objT->InitialAttachDelay, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.IdleScanDelay), "0.35s"), &objT->IdleScanDelay, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.CanAttachToHordeMembers), "false"), &objT->CanAttachToHordeMembers, state);
        Marshal(node.GetAttributeValue(nameof(AttachUpdateModuleData.Flags), "NONE"), &objT->Flags, state);
        Marshal(node.GetChildNode(nameof(AttachUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
