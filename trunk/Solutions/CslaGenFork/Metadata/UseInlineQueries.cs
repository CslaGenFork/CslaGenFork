using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum UseInlineQueries
    {
        Never,
        [Description("Specify by Object")]
        SpecifyByObject,
        Always
    }
}
