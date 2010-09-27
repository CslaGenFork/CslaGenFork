using System;
using System.Collections;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    public class ParameterCollection : System.Collections.Generic.List<Parameter>
    {

        public virtual bool Contains(Criteria crit, Property prop)
        {
            for (int i = 0; i < Count; ++i)
                if (this[i].Criteria == crit && this[i].Property == prop)
                    return true;
            return false;
        }
    }
}
