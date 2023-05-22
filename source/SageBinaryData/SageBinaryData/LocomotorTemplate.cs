using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum Appearance
{
    TWO_LEGS,
    FOUR_WHEELS,
    HOVER,
    HOVER_TANK,
    WINGS,
    FOUR_LEGS_HUGE,
    HORDE,
    HUGE_TWO_LEGS,
    TREADS,
    SHIP,
#if KANESWRATH
    MECHAPEDE,
    MECHAPEDE_HORDE,
#endif
    OTHER
}

public enum Surface
{
    GROUND,
    WATER,
    CLIFF,
    AIR,
    RUBBLE,
    OBSTACLE,
    IMPASSABLE,
    DEEP_WATER,
    WALL_RAILING,
    CRUSHABLE_OBSTACLE
}

[StructLayout(LayoutKind.Sequential)]
public struct LocomotorSurfaceBitFlags
{
    public const int Count = 10;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

public enum LocoZ
{
    NO_MOTIVE_FORCE,
    SEA_LEVEL,
    SURFACE_RELATIVE_HEIGHT_ALLOW_ZERO_HEIGHT,
    SURFACE_RELATIVE_HEIGHT,
    ABSOLUTE_HEIGHT,
    FIXED_SURFACE_RELATIVE_HEIGHT,
    FIXED_ABSOLUTE_HEIGHT,
    RELATIVE_TO_GROUND_AND_BUILDINGS,
    SMOOTH_RELATIVE_TO_HIGHEST_LAYER,
    FLOATING_Z,
    SCALING_WALLS
}

public enum LocoF
{
    NO_FORMATION,
    CAVALRY_1,
    CAVALRY_2,
    CAVALRY_3,
    MELEE_1,
    MELEE_2,
    MELEE_3,
    RANGED_1,
    RANGED_2,
    RANGED_3,
    ARTILLERY_1,
    ARTILLERY_2,
    ARTILLERY_3
}

[StructLayout(LayoutKind.Sequential)]
public struct LocomotorTemplate
{
    public BaseInheritableAsset Base;
    public LocomotorSurfaceBitFlags Surfaces;
    public float LookAheadMult;
    public Percentage MaxSpeedDamaged;
    public Percentage MinSpeed;
    public Time TurnTimeSeconds;
    /// <summary>
    /// 0s means use TurnTimeSeconds.
    /// </summary>
    public Time TurnTimeDamagedSeconds;
    public float SlowTurnRadius;
    public float FastTurnRadius;
    public float MinRandomTurnRadiusScale;
    public float MaxRandomTurnRadiusScale;
    public Angle TurnThreshold;
    public Angle TurnThresholdHS;
    public Time AccelerationSeconds;
    public Percentage Lift;
    public Percentage LiftDamaged;
    public Time BrakingSeconds;
    public Percentage MinTurnSpeed;
    public float PreferredHeight;
    public float PreferredAttackHeight;
    public float PreferredHeightDamping;
    public float CirclingRadius;
    public Percentage CirclingSpeed;
    public LocoZ BehaviorZ;
    public Appearance Appearance;
    public LocoF FormationPriority;
    public float AccDecTrigger;
    public float WalkDistance;
    public Angle MaxTurnWithoutReform;
    public Angle AccelPitchLimit;
    public Angle BounceKick;
    public float PitchStiffness;
    public float RollStiffness;
    public float PitchDamping;
    public float RollDamping;
    public float PitchByZVelCoef;
    public float YawStiffness;
    public float YawDamping;
    public float MaxOverlappedHeight;
    public float ForwardVelocityPitchFactor;
    public float LateralVelocityRollFactor;
    public float ForwardAccelerationPitchFactor;
    public float LateralAccelerationRollFactor;
    public float UniformAxialDamping;
    public float TurnPivotOffset;
    public int AirborneTargetingHeight;
    public float CloseEnoughDist;
    public float MaximumWheelExtension;
    public float MaximumWheelCompression;
    public Angle WheelTurnAngle;
    public float WanderWidthFactor;
    public float WanderLengthFactor;
    public float WanderAboutPointRadius;
    public float BurningDeathRadius;
    public Percentage ChargeMaxSpeed;
    public float RudderCorrectionDegree;
    public float RudderCorrectionRate;
    public float ElevatorCorrectionDegree;
    public float ElevatorCorrectionRate;
    public float AeleronCorrectionDegree;
    public float AeleronCorrectionRate;
    public float SwoopStandoffRadius;
    public float SwoopStandoffHeight;
    public float SwoopTerminalVelocity;
    public float SwoopAccelerationRate;
    public float SwoopSpeedTuningFactor;
    public Percentage BackingUpSpeed;
    public float BackingUpDistanceMin;
    public float BackingUpDistanceMax;
    public float BackingUpAngle;
    public Percentage RiverModifier;
    public float TakeOffAndLandingSpeed;
    public float TakeOffAndLandingSlowDownDelta;
    public Time TakeOffAndLandingSlowDownTime;
    public float AttackPathTrailDistance;
    public float AttackPathTrailDistanceMinScale;
    public float AttackPathTrailDistanceMaxScale;
    public float AbsoluteMinHeightWorldSpace;
#if KANESWRATH
    public float WiggleAmplitude;
    public float WiggleFrequency;
    public float WiggleOffset;
#endif
    public SageBool MakeTransformNonDirty;
    public SageBool IsCloseEnoughDist3D;
    public SageBool LocomotorWorksWhenDead;
    public SageBool AllowMotiveForceWhileAirborne;
    public SageBool Apply2DFrictionWhenAirborne;
    public SageBool DownhillOnly;
    public SageBool StickToGround;
    public SageBool CanMoveBackward;
    public SageBool UpdateWaterWadingConditions;
    public SageBool HasSuspension;
    public SageBool IsCrewPowered;
    public SageBool UseTerrainSmoothing;
    public SageBool BurningDeathIsCavalry;
    public SageBool ChargeAvailable;
    public SageBool ChargeIgnoresCondition;
    public SageBool EnableHighSpeedTurnFlags;
    public SageBool WaitForFormation;
    public SageBool BackingUpStopWhenTurning;
    public SageBool ScalesWalls;
    public SageBool TurnWhileMoving;
    public SageBool ClampOrientationToPathTangent;
    public SageBool ReorientIfTurnTooSharp;
    public SageBool BrakeBeforeReorienting;
}
