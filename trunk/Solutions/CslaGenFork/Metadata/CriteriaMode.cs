using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum CriteriaMode
    {
        Simple = 1,
        CriteriaBase,
        BusinessBase,
        CustomCriteriaClass
    }
}