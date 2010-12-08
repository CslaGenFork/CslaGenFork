using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public class CslaObjectInfoCollection : BindingList<CslaObjectInfo>
    {
        public CslaObjectInfo Find(string name)
        {
            foreach (CslaObjectInfo c in this)
            {
                if (c.ObjectName.Equals(name))
                    return c;
            }
            return null;
        }

        public List<string> GetAllObjectNames()
        {
            List<String> lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
                lst.Add(obj.ObjectName);
            return lst;
        }

    }
}
