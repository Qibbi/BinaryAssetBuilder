using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeployStyleAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public Time UnpackTime;
        public Time PackTime;
        public AssetReference<AttributeModifier> DeployedAttributeModifierName;
        public SageBool ResetTurretBeforePacking;
        public SageBool TurretsFunctionOnlyWhenDeployed;
        public SageBool TurretsMustCenterBeforePacking;
        public SageBool MustDeployToAttack;
    }
}
