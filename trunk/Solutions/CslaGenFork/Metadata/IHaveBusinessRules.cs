namespace CslaGenerator.Metadata
{
    public interface IHaveBusinessRules
    {
        string Name { get; set; }
        BusinessRuleCollection BusinessRules { get; }
    }
}
