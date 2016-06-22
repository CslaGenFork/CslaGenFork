using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class CslaObjectInfoCollection : BindingList<CslaObjectInfo>
    {
        public CslaObjectInfo Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.ObjectName.Equals(name));
        }

        public CslaObjectInfo FindByGenericName(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.GenericName.Equals(name));
        }

        public List<string> GetAllObjectNames()
        {
            return this.Select(obj => obj.ObjectName).ToList();
        }

        public List<string> GetAllParentNames(CslaObjectInfo info)
        {
            var list = new List<string>();

            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsParentAllowed(obj.ObjectType, info.ObjectType) &&
                    !Equals(obj, info))
                    list.Add(obj.ObjectName);
            }

            return list;
        }

        public List<string> GetAllParentNames(CslaObjectType cslaType)
        {
            var list = new List<string>();

            foreach (var obj in this)
            {
                if (RelationRulesEngine.IsParentAllowed(obj.ObjectType, cslaType))
                    list.Add(obj.ObjectName);
            }

            return list;
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
            var list = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsChildAllowed(obj.ObjectType, info.ObjectType) &&
                    !Equals(obj, info))
                    list.Add(obj.ObjectName);
            }
            return list;
        }

        public List<string> GetAllChildNames(CslaObjectType cslaType)
        {
            var list = new List<string>();
            foreach (CslaObjectInfo obj in this)
            {
                if (RelationRulesEngine.IsChildAllowed(obj.ObjectType, cslaType))
                    list.Add(obj.ObjectName);
            }
            return list;
        }
    }
}