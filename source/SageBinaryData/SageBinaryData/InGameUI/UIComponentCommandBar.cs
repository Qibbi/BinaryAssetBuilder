using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentCommandBar
    {
        public UIBaseComponent Base;
        public int StackLevels;
        public AnsiString CommandBarImageBaseName;
        public AnsiString RenderClockName;
        public StringHash TabNameBookmarks;
        public StringHash TabNamePowers;
        public StringHash TabNameGroundUnits;
        public StringHash TabNameVehicles;
        public StringHash TabNameAirUnits;
        public StringHash TabNameStructures;
        public StringHash TabNameBaseDefenses;
        public float ClockScale;
        public TypedAssetId<PackedTextureImage> ClockImage;
        public TypedAssetId<LogicCommand> DrillUpButtonId;
        public TypedAssetId<LogicCommand> StanceDrillDownButtonId;
        public TypedAssetId<LogicCommand> TogglePowerButtonId;
        public TypedAssetId<LogicCommand> SelfRepairButtonId;
        public TypedAssetId<LogicCommand> SellButtonId;
        public TypedAssetId<LogicCommand> SetDefaultBuildingButtonId;
        public int UnitCapFlashSeconds;
        public int UnitCapFinalWarningAmount;
        public int UnitCapInitialWarningAmount;
        public AnsiString UnitCapNoMoreCP;
        public AnsiString UnitCapAlmostNoMoreCP;
        public Color ClockColor;
    }
}
