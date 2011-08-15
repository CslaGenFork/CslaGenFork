namespace CslaGenerator.Metadata
{
    public interface IHaveBusinessRules
    {
        string Name { get; set; }

        BusinessRuleCollection BusinessRules { get; }

        string ReadRoles { get; set; }
        string WriteRoles { get; set; }
        AuthorizationProvider AuthzProvider { get; set; }
        AuthorizationRule ReadAuthzRuleType { get; set; }
        AuthorizationRule WriteAuthzRuleType { get; set; }
    }
}