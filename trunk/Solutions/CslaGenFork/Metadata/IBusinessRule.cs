using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public interface IBusinessRule
    {
        bool IsPropertyRule { get; set; }
        string Parent { get; set; }
        string Name { get; set; }
        int NumberGenericParameters { get; set; }
        string OriginalGenericParameter1 { get; set; }
        string OriginalGenericParameter2 { get; set; }
        string GenericParameter1 { get; set; }
        string GenericParameter2 { get; set; }
        string ObjectName { get; set; }
        string AssemblyFile { get; set; }
        string Type { get; set; }
        List<string> BaseRuleProperties { get; set; }
        BusinessRuleConstructorCollection Constructors { get; set; }
        BusinessRulePropertyCollection RuleProperties { get; set; }
    }
}
