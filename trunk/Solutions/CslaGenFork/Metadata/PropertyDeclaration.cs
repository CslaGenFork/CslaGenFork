using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Declaration mode of the property.
    /// </summary>
    public enum PropertyDeclaration
    {
        Managed,
        [Description("Managed with Type Conversion")]
        ManagedWithTypeConversion,
        Unmanaged,
        [Description("Unmanaged with Type Conversion")]
        UnmanagedWithTypeConversion,
        AutoProperty,
        [Description("Classic INPC Property")]
        ClassicProperty,
        [Description("Classic INPC Property with Type Conversion")]
        ClassicPropertyWithTypeConversion,
        NoProperty
    }
}