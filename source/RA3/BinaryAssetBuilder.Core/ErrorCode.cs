namespace BinaryAssetBuilder
{
    public enum ErrorCode
    {
        InternalError = 1,
        ReadingSchema,
        IllegalPath,
        SchemaValidation,
        DuplicateInstance,
        UnknownReference,
        ReferencingError,
        CircularDependency,
        MissingReference,
        InheritFromError,
        InputXmlFileNotFound,
        NoDataRootSpecified,
        TextureAssetDependency,
        IllegalPathAlias,
        DuplicateDefine,
        HashCollision,
        BadTextureFile,
        ExpressionEvaluationError,
        DependencyCacheFailure,
        OverridingSameNameInSameFile,
        FileNotFound,
        InvalidArgument,
        XmlFormattingError,
        LockedFile,
        UnexpectedSize,
        NetworkCacheFailure,
        NoIdAttributeForAsset,
        InvalidCustomDataFilePath,
        ErrorContactingBabClient,
        PathMonitor,
        GameDataVerification
    }
}
