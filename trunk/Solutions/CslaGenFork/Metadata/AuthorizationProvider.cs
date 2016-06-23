using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum AuthorizationProvider
    {
        IsInRole,
        IsNotInRole,
        Custom
    }
}
