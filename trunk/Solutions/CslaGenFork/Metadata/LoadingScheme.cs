using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for LoadingScheme.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum LoadingScheme
    {
        None = 1,
        SelfLoad,
        ParentLoad
    }
}