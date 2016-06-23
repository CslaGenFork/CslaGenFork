using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum UnitOfWorkFunction
    {
        [Description("Creator/Getter")]
        CreatorGetter,
        Creator,
        Getter,
        [Description("Updater (unsupported)")]
        Updater,
        [Description("Deleter (unsupported)")]
        Deleter
    }
}