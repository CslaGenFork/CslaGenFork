using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum BusinessRuleRunModes
    {
        Default,
        [Description("Deny as Affected Property")]
        DenyAsAffectedProperty,
        DenyCheckRules,
        [Description("Deny on Server Side Portal")]
        DenyOnServerSidePortal
    }
}