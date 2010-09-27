namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Declaration mode of the property.
    /// </summary>
    public enum PropertyDeclaration
    {
        Managed,
        ManagedWithTypeConversion,
        Unmanaged,
        UnmanagedWithTypeConversion,
        AutoProperty,
        ClassicProperty,
        ClassicPropertyWithTypeConversion,
        NoProperty
    }
}
