using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
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