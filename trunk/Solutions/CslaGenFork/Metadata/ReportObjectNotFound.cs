using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum ReportObjectNotFound
    {
        None,
        [Description("IsLoaded Property")]
        IsLoadedProperty,
        ThrowException
    }
}