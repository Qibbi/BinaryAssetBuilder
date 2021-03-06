using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FadeData
    {
        public int FrameCount;
        public Color3f StartColor;
        public Color3f EndColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VideoEvent : IPolymophic
    {
        public uint TypeId;
        public unsafe FadeData* FadeIn;
        public unsafe FadeData* FadeOut;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MovieEvent
    {
        public VideoEvent Base;
        public AnsiString MovieName;
    }

    public enum TextJustificationType
    {
        LEFT,
        RIGHT,
        CENTER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TextInstance
    {
        public List<AnsiString> TextId;
        public TextJustificationType Justification;
        public float XOffset;
        public float YOffset;
        public AnsiString Font;
        public int PointSize;
        public Color3f TextColor;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct TitleCardEvent
    {
        public VideoEvent Base;
        public Time DisplayTime;
        public List<TextInstance> TextInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VideoEventList
    {
        public BaseAssetType Base;
        public PolymorphicList<VideoEvent> EventList;
    }
}
