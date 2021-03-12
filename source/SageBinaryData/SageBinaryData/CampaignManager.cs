using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum CampaignFlagType
    {
        Use_Alternate_Ending,
        Use_Alternate_Campaign_Failure,
        LUNCH_AT_IHOP,
        GDI_1_2_CampaignFlag_Snipers_Rescued,
        GDI_1_3_CampaignFlag_Mission_Complete,
        GDI_4_2_CampaignFlag_PlayedFirst,
        GDI_4_2_CampaignFlag_SnipersRescued,
        GDI_4_2_ZoneTroopersRescued,
        GDI_4_2_CommandoWin,
        GDI_4_3_CampaignFlag_PlayedFirst,
        GDI_4_3_Reinforcements,
        NOD_1_1_CampaignFlag_LessGroundForces,
        NOD_1_1_CampaignFlag_Attack_Bike_IDB,
        NOD_1_2_CampaignFlag_NoOrcas,
        NOD_4_2_CampaignFlag_IonCannonDestroyed,
        NOD_5_2_CampaignFlag_Stasis_Chamber_Destroyed,
        NOD_5_2_CampaignFlag_GravityStabilizer_Destroyed,
        Alien_1_2_CampaignFlag_Mastermind_Survived
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CampaignFlagBitFlags
    {
        public const int Count = 0x00000012;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MissionTemplate
    {
        public BaseAssetType Base;
        public AnsiString IntroMovieName;
        public AnsiString DisplayName;
        public AnsiString Title;
        public AnsiString BriefingText;
        public AnsiString BriefingMovie;
        public AnsiString LoadScreenImage;
        public AnsiString LoadScreenText;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* LoadScreenMusic;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* LoadScreenVoice;
        public AnsiString MapName;
        public AnsiString VictoryMovieName;
        public AnsiString DefeatMovieName;
        public List<int> Prerequisite;
        public List<AnsiString> Objective;
        public List<AnsiString> BonusObjective;
        public SageBool BriefingMovieFullScreen;
        public SageBool RequiredToCompleteTheaterOfWar;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TheaterOfWarTemplate
    {
        public BaseAssetType Base;
        public AnsiString DisplayName;
        public AnsiString AptTow;
        public int AutoStartMission;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* SummaryScreenMusic;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* SelectionScreenMusic;
        public List<AssetReference<MissionTemplate>> Mission;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CampaignTemplate
    {
        public BaseAssetType Base;
        public AnsiString DisplayName;
        public AnsiString FinalMovie;
        public AnsiString AlternateFinalMovie;
        public AnsiString ConsoleAutosaveFilename;
        public List<AssetReference<TheaterOfWarTemplate>> TheaterOfWar;
    }
}
