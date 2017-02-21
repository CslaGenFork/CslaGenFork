using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class ParameterCollection : List<Parameter>
    {
        public virtual bool Contains(Criteria crit, Property prop)
        {
            for (var i = 0; i < Count; ++i)
                if (this[i].CriteriaName == crit.Name && this[i].PropertyName == prop.Name)
                    return true;
            return false;
        }
    }
}