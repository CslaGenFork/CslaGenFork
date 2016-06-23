using System.ComponentModel;

namespace CslaGenerator.Metadata
{
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