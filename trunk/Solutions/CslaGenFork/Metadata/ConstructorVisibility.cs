using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum ConstructorVisibility
    {
        Default,
        Private,
        Protected,
        ProtectedInternal,
        Internal
    }
}