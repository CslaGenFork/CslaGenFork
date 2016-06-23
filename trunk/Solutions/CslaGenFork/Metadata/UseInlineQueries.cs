using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum UseInlineQueries
    {
        Never,
        [Description("Specify by Object")]
        SpecifyByObject,
        Always
    }
}
