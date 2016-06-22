using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleConstructorCollection : List<BusinessRuleConstructor>
    {
        public new void Add(BusinessRuleConstructor item)
        {
            item.NameChanged += OnNameChanged;
            item.ActiveChanged += OnActiveChanged;
            base.Add(item);
        }

        public BusinessRuleConstructor Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        public BusinessRuleConstructor OldActive(BusinessRuleConstructor newActive)
        {
            foreach (var property in this)
            {
                if (property.IsActive && property != newActive)
                    return property;
            }
            return null;
        }

        private void OnNameChanged(BusinessRuleConstructor sender, EventArgs e)
        {
            // remove (Active) from all constructor's name
            foreach (var cTor in this)
            {
                if (cTor.Name.EndsWith(" (Active)"))
                    cTor.SetName(cTor.Name.Substring(0,
                        cTor.Name.LastIndexOf(" (Active)", StringComparison.InvariantCulture)));
            }
            sender.SetName(sender.Name + " (Active)");
        }

        private void OnActiveChanged(BusinessRuleConstructor sender, EventArgs e)
        {
            if (sender.Name.EndsWith(" (Active)"))
                sender.SetName(sender.Name.Substring(0,
                    sender.Name.LastIndexOf(" (Active)", StringComparison.InvariantCulture)));

            var oldActive = OldActive(sender);
            if (oldActive != null)
            {
                if (oldActive.Name.EndsWith(" (Active)"))
                {
                    oldActive.SetName(oldActive.Name.Substring(0,
                        oldActive.Name.LastIndexOf(" (Active)", StringComparison.InvariantCulture)));
                }
                oldActive.IsActive = false;
            }
            sender.SetName(sender.Name + " (Active)");
        }
    }
}