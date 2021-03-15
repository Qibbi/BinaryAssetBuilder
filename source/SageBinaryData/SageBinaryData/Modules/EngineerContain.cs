using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EngineerContainModuleData
    {
        public ContainModuleData Base;
        public AssetReference<ObjectCreationList> ReplaceWith;
        public unsafe StringHash* NameOfVoiceToUseForFriendlyEnter;
        public unsafe StringHash* NameOfVoiceToUseForHostileEnter;
        public unsafe AssetReference<FXList>* FXForRepair;
        public unsafe AssetReference<FXList>* FXForCapture;
        public unsafe AssetReference<FXList>* FXForReplace;
        public unsafe AssetReference<FXList>* FXForCaptureAndReplace;
        public unsafe AnsiString* EvaEventForRepair;
        public unsafe AnsiString* EvaEventForCapture;
        public unsafe AnsiString* EvaEventForReplace;
        public unsafe AnsiString* EvaEventForCaptureAndReplace;
        public unsafe ObjectFilter* CanEnterFilter;
        public SageBool ImmediatelyEnabled;
    }
}
