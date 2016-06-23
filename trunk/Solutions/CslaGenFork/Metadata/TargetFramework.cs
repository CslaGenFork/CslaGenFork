using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum TargetFramework
    {
        [Description("CSLA 4.0")]
        CSLA40,
        [Description("CSLA 4.0 DAL")]
        CSLA40DAL,
        [Description("CSLA 4.5")]
        CSLA45,
        [Description("CSLA 4.5 DAL")]
        CSLA45DAL
    }
}