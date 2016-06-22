using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class AuthorizationRuleCollection : List<AuthorizationRule>
    {
        public AuthorizationRule Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(p => p.Name.Equals(name));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        public void OnParentChanged(IHaveBusinessRules sender, EventArgs e)
        {
            foreach (var rule in this)
            {
                rule.Parent = sender.Name;
                foreach (var constructor in rule.Constructors)
                {
                    foreach (var parameter in constructor.ConstructorParameters)
                    {
                        if (parameter.Type == "IMemberInfo" && parameter.Name == "element")
                        {
                            parameter.Value = sender.Name;
                            break;
                        }
                    }
                }
            }
        }
    }
}