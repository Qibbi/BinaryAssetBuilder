using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ExperienceLevelTemplateLevelUpFxList
    {
        public AssetReference<FXList> FxList;
        public AnsiString BoneName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ExperienceLevelTemplate
    {
        public BaseAssetType Base;
        public int Rank;
        public int RequiredExperience;
        public int ExperienceAward;
        public int ExperienceAwardOwnGuysDie;
        public unsafe AssetReference<ExperienceLevelTemplate>* Prerequisite;
        public AssetReference<ObjectCreationList> LevelUpOCL;
        public ModelConditionBitFlags ModelConditionState;
        public Time LevelUpTintPreColorTime;
        public Time LevelUpTintPostColorTime;
        public Time LevelUpTintSustainColorTime;
        public float LevelUpTintFrequency;
        public float LevelUpTintAmplitude;
        public Color4f LevelUpTintColor;
        public List<TypedAssetId<UpgradeTemplate>> Upgrade;
        public List<ExperienceLevelTemplateLevelUpFxList> LevelUpFxList;
        public List<TypedAssetId<GameObject>> Target;
        public List<AssetReference<AttributeModifier>> AttributeModifier;
        public unsafe RadiusDecalTemplate* Decal;
        public SageBool InformUpdateModule;
        public SageBool SinglePlayerOnly;
        public SageBool MultiPlayerOnly;
        public SageBool ShowLevelUpTint;
    }
}
