using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClickReactionBehaviorModuleData
    {
        public UpdateModuleData Base;
        public int ClickReactionLifeTimer;
        public int ReactionFrames1;
        public int ReactionFrames2;
        public int ReactionFrames3;
        public int ReactionFrames4;
        public int ReactionFrames5;
    }
}
