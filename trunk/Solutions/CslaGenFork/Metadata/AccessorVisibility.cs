namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Access level for use in properties.
    /// </summary>
    public enum AccessorVisibility
    {
        Default = 0,
        Private = 5,
        Public = 1,
        Protected = 2,
        ProtectedInternal = 3,
        Internal = 4,
        NoSetter = 6
    }
}
