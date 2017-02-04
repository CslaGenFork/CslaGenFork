using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Access level for use in properties.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum AccessorVisibility
    {
        Default = 0,
        Private = 5,
        Public = 1,
        Protected = 2,
        ProtectedInternal = 3,
        Internal = 4
    }
}
