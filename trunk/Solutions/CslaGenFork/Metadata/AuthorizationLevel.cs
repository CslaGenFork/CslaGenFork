using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// AuthorizationLevel to use in objects and properties.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum AuthorizationLevel
    {
        None,
        ObjectLevel,
        PropertyLevel,
        FullSupport,
        Custom
    }
}