using System.Collections.Generic;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public class CslaObjectInfoCollection : BindingList<CslaObjectInfo>
    {
        public CslaObjectInfo Find(string name)
        {
            foreach (var c in this)
            {
                if (c.ObjectName.Equals(name))
                    return c;
            }
            return null;
        }

        public List<string> GetAllObjectNames()
        {
            var lst = new List<string>();
            foreach (var obj in this)
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
            foreach (var obj in this)
            {
                if (RelationRulesEngine.IsParentAllowed(obj.ObjectType, cslaType))
                    lst.Add(obj.ObjectName);
            }
            return lst;
        }

        public string FindNameAvailable(string item, int counter)
        {
            if (Find(item + (counter == 0 ? "" : "#" + counter)) == null)
                return item + (counter == 0 ? "" : "#" + counter);

            return FindNameAvailable(item, counter + 1);
        }

        public void InsertAtTop(CslaObjectInfo item)
        {
            InsertAtTop(item, false);
        }

        public void InsertAtTop(CslaObjectInfo item, bool isUnique)
        {
            if (isUnique)
                item.ObjectName = FindNameAvailable(item.ObjectName, 0);

            Insert(0, item);
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
