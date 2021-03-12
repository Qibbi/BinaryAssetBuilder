# BinaryAssetBuilder
BinaryAssetBuilder implementation for Kane's Wrath in .Net Core

### First Version will be for Tiberium Wars
I decided to first make a TW version so I can be sure everything works.

### Implemented Asset Types
* [ ] TestGameObject
* [ ] TestTexture
* [ ] TestTextureCollection
* [x] WeaponTemplate                                            0xE3996069
* [x] LocomotorTemplate                                         0xBD8F61A4
* [ ] GameObject
* [ ] FXParticleSystemTemplate
* [x] Weather                                                   0x368A8BA2
* [x] ShadowMap                                                 0xC6389FA6
* [x] WaterTransparency                                         0x331DA6CE
* [ ] Texture
* [ ] OnDemandTexture
* [ ] W3DMesh
* [ ] W3DContainer
* [ ] W3DHierarchy
* [x] W3DAnimation                                              0xCC069193
* [ ] W3DCollisionBox
* [ ] ArmyDefinition
* [ ] AIPersonalityDefinition
* [ ] FXList
* [ ] ObjectCreationList
* [x] ObjectFilterAsset                                         0x25970AF7
* [ ] SpecialPowerTemplate
* [ ] UpgradeTemplate
* [ ] SkirmishOpeningMove
* [ ] AIStateDefinition
* [ ] AIStrategicStateDefinition
* [ ] AIBudgetStateDefinition
* [ ] AITargetingHeuristic
* [ ] GameMap
* [x] AttributeModifier                                         0xD24E7201
* [x] ArmorTemplate                                             0x9CDD1086
* [x] MissionTemplate                                           0x0D283295
* [x] TheaterOfWarTemplate                                      0xE60C9724
* [x] CampaignTemplate                                          0xAC60B530
* [x] RadiusCursorLibrary                                       0xD62B490F
* [ ] AudioFile
* [x] AudioEvent                                                0x1B886049
* [x] MusicTrack                                                0x1469548A
* [x] DialogEvent                                               0x8655CDB4
* [x] AmbientStream                                             0xDABB1C4B
* [x] Multisound                                                0x12B1C67C
* [x] MusicPalette                                              0x6A7AF822
* [x] MusicScriptConditionNugget_LocalPlayerIsObserver          0xAFB6AF3A
* [x] MusicScriptConditionNugget_UnitsFarFromBase               0xD889BF98
* [x] MusicScriptConditionNugget_TimeFromStartOfLevel           0xAA4A9E23
* [x] MusicScriptConditionNugget_TrackPlayedCount               0x4FCFFAB1
* [x] MusicScriptConditionNugget_SpecificTrackTypePlaying       0xBCAD9B77
* [x] MusicScriptConditionNugget_AnyTrackPlaying                0x337BC326
* [x] MusicScriptConditionNugget_ObjectsOfTypeExist             0x9586411C
* [x] MusicScriptConditionNugget_EvaEventPlayedRecently         0x1F200F13
* [x] MusicScriptConditionNugget_ObjectsNearEvaEvent            0x0EC4D160
* [x] MusicScriptConditionNugget_ScoredKillCount                0x5C0F93DC
* [x] MusicScriptConditionNugget_Not                            0xB886383B
* [x] MusicScriptConditionNugget_Or                             0x81114695
* [x] MusicScriptConditionNugget_And                            0x10173347
* [x] MusicScriptTrack                                          0x702C8407
* [x] LocalBuildListMonitor                                     0x99CC030A
* [x] MpGameRules                                               0xEDDBB607
* [x] ExperienceLevelTemplate                                   0xAE55047B
* [x] MissionObjectiveList                                      0xC385A8C1
* [x] StringHashTable                                           0x2C112832
* [x] InGameUISettings                                          0x49FE3760
* [x] DamageFX                                                  0x4DF81EBD
* [x] MultiplayerSettings                                       0x1BAF4C42
* [x] OnlineChatColors                                          0xF3645AA7
* [x] MultiplayerColor                                          0x966F336A
* [x] GameLODPreset                                             0x19DAC24D
* [x] StaticGameLOD                                             0xBEAF1CC9
* [x] DynamicGameLOD                                            0x71BAD792
* [x] AudioLOD                                                  0x3ABBF00F
* [x] VideoEventList                                            0x999FCBE3
* [x] UIConfigList                                              0xB3B7607A
* [x] PackedTextureImage                                        0x2FAEB748
* [ ] OnDemandTextureImage
* [ ] TerrainTextureAtlas
* [x] Mouse                                                     0x73FE99B0
* [x] Achievement                                               0xC8D16E6D
* [x] StanceTemplate                                            0x5C6E0E41
* [x] TargetingCompareList                                      0x57CA5C81
* [x] TargetingDistanceCompare                                  0xED45F096
* [x] TargetingCombatChainCompare                               0x553808EF
* [x] TargetingInTurretArcCompare                               0xCD24391A
* [x] Road                                                      0xDCF3C28B
* [x] Environment                                               0x878C42E0
* [x] LogicCommand                                              0x97D0A46E
* [x] LogicCommandSet                                           0x6D148BD7
* [x] MiscAudio                                                 0xFA4817E2
* [x] AudioSettings                                             0x89AA7DDE
* [x] CrowdResponse                                             0x66FB33A0
* [x] MapMetaData                                               0x59013A51
* [x] LargeGroupAudioMap                                        0x9CBC0553
* [x] AptAptData                                                0x36866072
* [x] AptConstData                                              0x1CE8E595
* [x] AptDatData                                                0x3BF7FEB9
* [x] AptGeometryData                                           0x58F89E8B
* [x] MappableKey                                               0xE005A668
* [x] HotKeySlot                                                0x1AC54E60
* [x] DefaultHotKeys                                            0x0E12479D
* [x] InGameUIGroupSelectionCommandSlots                        0xF6CE1A68
* [x] InGameUILookAtCommandSlots                                0x8F9F9918
* [x] InGameUITacticalCommandSlots                              0xC24AEFF1
* [x] InGameUIVoiceChatCommandSlots                             0x3592E352
* [x] InGameUISideBarCommandSlots                               0xAF956455
* [x] InGameUIPlayerPowerCommandSlots                           0x4AB425C6
* [x] InGameUIUnitAbilityCommandSlots                           0x9DAA4182
* [x] GameScriptList                                            0x5AC6FA18
* [x] IntelDB                                                   0xFBB64F90
* [x] BootupDisplaySequence                                     0x84C1C2F0
* [x] UnitTypeIcon                                              0xF7AB74BE
* [x] ImageSequence                                             0x217CF953
* [x] UnitOverlayIconSettings                                   0xDFC78E66
* [x] TheVersion                                                0xF659EF49
* [x] DLContent                                                 0x4E1A5713
* [x] PhaseEffect                                               0x4877D566
* [x] ConnectionLineManager                                     0x7AEB73B2
* [x] InGameUIFixedElementHotKeySlotMap                         0x475EA260

### Tiberium Wars Only Types
* [ ] AudioFileMP3Passthrough
* [ ] MP3MusicTrack
* [ ] MP3DialogEvent
* [ ] MP3AmbientStream
* [x] UnitAbilityButtonTemplateStore                            0x5A48D289
* [x] PlayerPowerButtonTemplateStore                            0xDB57AB4F
* [x] CommandSet                                                0x3CFF78A1

### Kane's Wrath Only Types
* [ ] UnitAbilityButtonTemplate
* [ ] PlayerPowerButtonTemplate
* [ ] StrikeForceBuildTemplate
* [ ] MetagameOperationsInfoType
* [ ] MetaGameUITacticalCommandSlots
* [ ] MetaGameUICommonOpCommandSlots
* [ ] MetaGameMapZoneData
* [ ] MetaGameStaticData
* [ ] ButtonSingleStateData
* [ ] JoypadCommandBarTemplate
* [ ] JoypadCommandBarButtonTemplate
* [ ] UIJoypadCommandBarButtonBuild
* [ ] UIJoypadCommandBarHomogenousGroup
* [ ] UIJoypadCommandBarMixedGroup
* [ ] UIJoypadCommandBarSingleUnit
* [ ] UIJoypadCommandBarStances
* [ ] UIJoypadCommandBarTopMenu
* [ ] UIJoypadCommandBarMgTopMenu
