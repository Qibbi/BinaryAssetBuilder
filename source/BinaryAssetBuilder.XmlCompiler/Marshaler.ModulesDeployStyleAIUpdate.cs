using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DeployStyleAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.UnpackTime), "0s"), &objT->UnpackTime, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.PackTime), "0s"), &objT->PackTime, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.ResetTurretBeforePacking), "false"), &objT->ResetTurretBeforePacking, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.TurretsFunctionOnlyWhenDeployed), "false"), &objT->TurretsFunctionOnlyWhenDeployed, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.TurretsMustCenterBeforePacking), "false"), &objT->TurretsMustCenterBeforePacking, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.MustDeployToAttack), "false"), &objT->MustDeployToAttack, state);
        Marshal(node.GetAttributeValue(nameof(DeployStyleAIUpdateModuleData.DeployedAttributeModifierName), null), &objT->DeployedAttributeModifierName, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
