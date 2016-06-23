using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum CslaPropertyMode
    {
        Default,
        Standard,
        Managed,
        ManagedBackingField
    }
}