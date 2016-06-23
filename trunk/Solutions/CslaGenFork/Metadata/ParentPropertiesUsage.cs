using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum ParentPropertiesUsage
    {
        InsertOnly,
        [Description("Insert/Update/Delete")]
        InsertUpdateDelete
    }
}