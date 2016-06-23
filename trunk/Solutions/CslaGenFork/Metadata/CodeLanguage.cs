using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum CodeLanguage
    {
        [Description("C#")]
        CSharp = 1,
        [Description("Visual Basic")]
        VB
    }
}