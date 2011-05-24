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
            var lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
                lst.Add(obj.ObjectName);
            return lst;
        }

        public List<string> GetAllParentNames(CslaObjectInfo info)
        {
            var lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsParentAllowed(obj.ObjectType, info.ObjectType) &&
                    obj != info)
                    lst.Add(obj.ObjectName);
            }
            return lst;
        }

        public List<string> GetAllParentNames(CslaObjectType cslaType)
        {
            var lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsParentAllowed(obj.ObjectType, cslaType))
                    lst.Add(obj.ObjectName);
            }
            return lst;
        }

        public List<string> GetAllChildNames(CslaObjectInfo info)
        {
            var lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsChildAllowed(obj.ObjectType, info.ObjectType) &&
                    obj != info)
                    lst.Add(obj.ObjectName);
            }
            return lst;
        }

        public List<string> GetAllChildNames(CslaObjectType cslaType)
        {
            var lst = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsChildAllowed(obj.ObjectType, cslaType))
                    lst.Add(obj.ObjectName);
            }
            return lst;
        }

    }
}
