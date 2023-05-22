using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LocomotorTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.Surfaces), ""), &objT->Surfaces, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.LookAheadMult), "1.0"), &objT->LookAheadMult, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MakeTransformNonDirty), "false"), &objT->MakeTransformNonDirty, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaxSpeedDamaged), "100%"), &objT->MaxSpeedDamaged, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MinSpeed), "0%"), &objT->MinSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnTimeSeconds), "1.0s"), &objT->TurnTimeSeconds, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnTimeDamagedSeconds), "0s"), &objT->TurnTimeDamagedSeconds, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SlowTurnRadius), "0.0"), &objT->SlowTurnRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.FastTurnRadius), "0.0"), &objT->FastTurnRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MinRandomTurnRadiusScale), "1.0"), &objT->MinRandomTurnRadiusScale, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaxRandomTurnRadiusScale), "1.0"), &objT->MaxRandomTurnRadiusScale, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnThreshold), "15d"), &objT->TurnThreshold, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnThresholdHS), "180d"), &objT->TurnThresholdHS, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AccelerationSeconds), "1.0s"), &objT->AccelerationSeconds, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.Lift), "0.0"), &objT->Lift, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.LiftDamaged), "-1.0"), &objT->LiftDamaged, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BrakingSeconds), "1.0s"), &objT->BrakingSeconds, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MinTurnSpeed), "1.0s"), &objT->MinTurnSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PreferredHeight), "0.0"), &objT->PreferredHeight, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PreferredAttackHeight), "0.0"), &objT->PreferredAttackHeight, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PreferredHeightDamping), "1.0"), &objT->PreferredHeightDamping, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.CirclingRadius), "0.0"), &objT->CirclingRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.CirclingSpeed), "100%"), &objT->CirclingSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BehaviorZ), nameof(LocoZ.NO_MOTIVE_FORCE)), &objT->BehaviorZ, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.Appearance), nameof(Appearance.FOUR_WHEELS)), &objT->Appearance, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.FormationPriority), nameof(LocoF.MELEE_1)), &objT->FormationPriority, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AccDecTrigger), "0.5"), &objT->AccDecTrigger, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WalkDistance), "0.0"), &objT->WalkDistance, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaxTurnWithoutReform), "360d"), &objT->MaxTurnWithoutReform, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AccelPitchLimit), "0d"), &objT->AccelPitchLimit, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BounceKick), "0d"), &objT->BounceKick, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PitchStiffness), "0.1"), &objT->PitchStiffness, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.RollStiffness), "0.1"), &objT->RollStiffness, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PitchDamping), "0.9"), &objT->PitchDamping, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.RollDamping), "0.9"), &objT->RollDamping, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.PitchByZVelCoef), "0"), &objT->PitchByZVelCoef, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.YawStiffness), "0.0"), &objT->YawStiffness, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.YawDamping), "0.0"), &objT->YawDamping, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaxOverlappedHeight), "99e99"), &objT->MaxOverlappedHeight, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ForwardVelocityPitchFactor), "0.0"), &objT->ForwardVelocityPitchFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.LateralVelocityRollFactor), "0.0"), &objT->LateralVelocityRollFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ForwardAccelerationPitchFactor), "0.0"), &objT->ForwardAccelerationPitchFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.LateralAccelerationRollFactor), "0.0"), &objT->LateralAccelerationRollFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.UniformAxialDamping), "1.0"), &objT->UniformAxialDamping, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnPivotOffset), "0.0"), &objT->TurnPivotOffset, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AirborneTargetingHeight), "99999"), &objT->AirborneTargetingHeight, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.CloseEnoughDist), "1.0"), &objT->CloseEnoughDist, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.IsCloseEnoughDist3D), "false"), &objT->IsCloseEnoughDist3D, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.LocomotorWorksWhenDead), "false"), &objT->LocomotorWorksWhenDead, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AllowMotiveForceWhileAirborne), "false"), &objT->AllowMotiveForceWhileAirborne, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.Apply2DFrictionWhenAirborne), "false"), &objT->Apply2DFrictionWhenAirborne, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.DownhillOnly), "false"), &objT->DownhillOnly, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.StickToGround), "false"), &objT->StickToGround, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.CanMoveBackward), "false"), &objT->CanMoveBackward, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.UpdateWaterWadingConditions), "false"), &objT->UpdateWaterWadingConditions, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.HasSuspension), "false"), &objT->HasSuspension, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaximumWheelExtension), "0.0"), &objT->MaximumWheelExtension, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.MaximumWheelCompression), "0.0"), &objT->MaximumWheelCompression, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WheelTurnAngle), "0.0d"), &objT->WheelTurnAngle, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.IsCrewPowered), "false"), &objT->IsCrewPowered, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.UseTerrainSmoothing), "false"), &objT->UseTerrainSmoothing, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WanderWidthFactor), "0.0"), &objT->WanderWidthFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WanderLengthFactor), "1.0"), &objT->WanderLengthFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WanderAboutPointRadius), "0.0"), &objT->WanderAboutPointRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BurningDeathRadius), "0.0"), &objT->BurningDeathRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BurningDeathIsCavalry), "false"), &objT->BurningDeathIsCavalry, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ChargeMaxSpeed), "0%"), &objT->ChargeMaxSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ChargeAvailable), "false"), &objT->ChargeAvailable, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ChargeIgnoresCondition), "false"), &objT->ChargeIgnoresCondition, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.EnableHighSpeedTurnFlags), "true"), &objT->EnableHighSpeedTurnFlags, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WaitForFormation), "false"), &objT->WaitForFormation, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.RudderCorrectionDegree), "0.0"), &objT->RudderCorrectionDegree, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.RudderCorrectionRate), "0.0"), &objT->RudderCorrectionRate, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ElevatorCorrectionDegree), "0.0"), &objT->ElevatorCorrectionDegree, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ElevatorCorrectionRate), "0.0"), &objT->ElevatorCorrectionRate, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AeleronCorrectionDegree), "0.0"), &objT->AeleronCorrectionDegree, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AeleronCorrectionRate), "0.0"), &objT->AeleronCorrectionRate, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SwoopStandoffRadius), "200.0"), &objT->SwoopStandoffRadius, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SwoopStandoffHeight), "200.0"), &objT->SwoopStandoffHeight, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SwoopTerminalVelocity), "0.07"), &objT->SwoopTerminalVelocity, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SwoopAccelerationRate), "0.003"), &objT->SwoopAccelerationRate, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.SwoopSpeedTuningFactor), "1.0"), &objT->SwoopSpeedTuningFactor, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BackingUpSpeed), "75%"), &objT->BackingUpSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BackingUpStopWhenTurning), "false"), &objT->BackingUpStopWhenTurning, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BackingUpDistanceMin), "0.0"), &objT->BackingUpDistanceMin, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BackingUpDistanceMax), "0.0"), &objT->BackingUpDistanceMax, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BackingUpAngle), "0.5"), &objT->BackingUpAngle, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.RiverModifier), "100%"), &objT->RiverModifier, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ScalesWalls), "false"), &objT->ScalesWalls, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TurnWhileMoving), "true"), &objT->TurnWhileMoving, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ClampOrientationToPathTangent), "false"), &objT->ClampOrientationToPathTangent, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.ReorientIfTurnTooSharp), "false"), &objT->ReorientIfTurnTooSharp, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.BrakeBeforeReorienting), "false"), &objT->BrakeBeforeReorienting, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TakeOffAndLandingSpeed), "0.0"), &objT->TakeOffAndLandingSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TakeOffAndLandingSlowDownDelta), "25.0"), &objT->TakeOffAndLandingSlowDownDelta, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.TakeOffAndLandingSlowDownTime), "2s"), &objT->TakeOffAndLandingSlowDownTime, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AttackPathTrailDistance), "0"), &objT->AttackPathTrailDistance, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AttackPathTrailDistanceMinScale), "1.0"), &objT->AttackPathTrailDistanceMinScale, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AttackPathTrailDistanceMaxScale), "1.0"), &objT->AttackPathTrailDistanceMaxScale, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.AbsoluteMinHeightWorldSpace), "-1000.0"), &objT->AbsoluteMinHeightWorldSpace, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WiggleAmplitude), "0.0"), &objT->WiggleAmplitude, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WiggleFrequency), "0.0"), &objT->WiggleFrequency, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorTemplate.WiggleOffset), "0.0"), &objT->WiggleOffset, state);
#endif
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}