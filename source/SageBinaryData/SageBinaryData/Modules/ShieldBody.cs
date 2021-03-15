using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ShieldBodyModuleData
    {
        public ActiveBodyModuleData Base;
        public AssetReference<FXList> ShieldEnabledFX;
        public AssetReference<FXList> ShieldDepleteFX;
        public AssetReference<FXList> ShieldRechargeEndFX;
        public AssetReference<FXList> ShieldTakeDamageFX;
        public float ShieldAmount;
        public unsafe AssetReference<ArmorTemplate>* ShieldArmor;
        public Time ShieldRechargeIdleTime;
        public ModelConditionFlagType ShieldActiveModelCondition;
    }
}
