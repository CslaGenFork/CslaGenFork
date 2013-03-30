using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class ParameterCollection : List<Parameter>
    {
        public virtual bool Contains(Criteria crit, Property prop)
        {
            for (var i = 0; i < Count; ++i)
                if (this[i].Criteria == crit && this[i].Property == prop)
                    return true;
            return false;
        }
    }
}