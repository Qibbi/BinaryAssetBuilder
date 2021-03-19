using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InitialPayload
    {
        public TypedAssetId<GameObject> Name;
        public int Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UpgradeCreation
    {
        public AssetReference<UpgradeTemplate> Upgrade;
        public TypedAssetId<GameObject> Template;
        public uint Num;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TransportContainModuleData
    {
        public OpenContainModuleData Base;
        public uint Slots;
        public AnsiString ExitBone;
        public Velocity ExitPitchRate;
        public float HealthRegenPercentPerSec;
        public Duration ExitDelay;
        public KindOfBitFlags TypeOneForWeaponSet;
        public KindOfBitFlags TypeTwoForWeaponSet;
        public KindOfBitFlags TypeOneForWeaponState;
        public KindOfBitFlags TypeTwoForWeaponState;
        public KindOfBitFlags TypeThreeForWeaponState;
        public AssetReference<WeaponTemplate> GrabWeapon;
        public ModelConditionFlagType ConditionForEntry;
        public Duration ThrowOutPassengersDelay;
        public AssetReference<WeaponTemplate> ThrowOutPassengersLandingWarhead;
        public float EnterFadeTime;
        public float ExitFadeTime;
        public float ReleaseSnappyness;
        public List<InitialPayload> InitialPayload;
        public unsafe Coord3D* ThrowOutPassengersVelocity;
        public List<UpgradeCreation> UpgradeCreationTrigger;
        public unsafe ObjectFilter* FadeFilter;
        public SageBool ScatterNearbyOnExit;
        public SageBool OrientLikeContainerOnExit;
        public SageBool DestroyRidersWhoAreNotFreeToExit;
        public SageBool ForceOrientationContainer;
        public SageBool CanGrabStructure;
        public SageBool FireGrabWeaponOnVictim;
        public SageBool ShouldThrowOutPassengers;
        public SageBool FadePassengerOnEnter;
        public SageBool FadePassengerOnExit;
        public SageBool FadeReverse;
        public SageBool ExtendedExitContainerChecks;
    }
}
