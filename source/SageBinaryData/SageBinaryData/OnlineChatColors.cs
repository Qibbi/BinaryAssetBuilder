using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OnlineChatColors
    {
        public BaseAssetType Base;
        public Color Default;
        public Color CurrentRoom;
        public Color ChatRoom;
        public Color Game;
        public Color GameFull;
        public Color GameCRCMismatch;
        public Color PlayerNormal;
        public Color PlayerBuddy;
        public Color PlayerOwner;
        public Color OfflinePlayerBuddy;
        public Color PlayerSelf;
        public Color PlayerIgnored;
        public Color OfflinePlayerIgnored;
        public Color ChatNormal;
        public Color ChatEmote;
        public Color ChatOwner;
        public Color ChatOwnerEmote;
        public Color ChatPrivate;
        public Color ChatPrivateEmote;
        public Color ChatPrivateOwner;
        public Color ChatPrivateOwnerEmote;
        public Color ChatBuddy;
        public Color ChatSelf;
        public Color AcceptTrue;
        public Color AcceptFalse;
        public Color MapSelected;
        public Color MapUnselected;
        public Color MessageOfTheDay;
        public Color MessageOfTheDayHeading;
    }
}
