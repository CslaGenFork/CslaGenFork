using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum ParentPropertiesUsage
    {
        InsertOnly,
        [Description("Insert/Update/Delete")]
        InsertUpdateDelete
    }
}