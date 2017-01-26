using System;
using System.Collections.Generic;
using System.Text;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util
{
    /// <summary>
    /// Summary description for TypeHelper.
    /// </summary>
    public static class TypeHelper
    {
        public static TypeCodeEx GetTypeCodeEx(this Type type)
        {
            if (type == null)
                return TypeCodeEx.Empty;
            if (type == typeof(Boolean))
                return TypeCodeEx.Boolean;
            if (type == typeof(Byte))
                return TypeCodeEx.Byte;
            if (type == typeof(Char))
                return TypeCodeEx.Char;
            if (type == typeof(DateTime))
            {
                if (GeneratorController.Current.CurrentUnit.Params.SmartDateDefault)
                    return TypeCodeEx.SmartDate;

                return TypeCodeEx.DateTime;
            }
            if (type == typeof(DateTimeOffset))
            {
                if (GeneratorController.Current.CurrentUnit.Params.SmartDateDefault)
                    return TypeCodeEx.SmartDate;

                return TypeCodeEx.DateTimeOffset;
            }
            if (type == typeof(TimeSpan))
                return TypeCodeEx.TimeSpan;
            if (type == typeof(DBNull))
                return TypeCodeEx.DBNull;
            if (type == typeof(Decimal))
                return TypeCodeEx.Decimal;
            if (type == typeof(Double))
                return TypeCodeEx.Double;
            if (type == typeof(Guid))
                return TypeCodeEx.Guid;
            if (type == typeof(Int16))
                return TypeCodeEx.Int16;
            if (type == typeof(Int32))
                return TypeCodeEx.Int32;
            if (type == typeof(Int64))
                return TypeCodeEx.Int64;
            if (type == typeof(SByte))
                return TypeCodeEx.SByte;
            if (type == typeof(Single))
                return TypeCodeEx.Single;
            if (type == typeof(String))
                return TypeCodeEx.String;
            if (type == typeof(UInt16))
                return TypeCodeEx.UInt16;
            if (type == typeof(UInt32))
                return TypeCodeEx.UInt32;
            if (type == typeof(UInt64))
                return TypeCodeEx.UInt64;
            if (type == typeof(byte[]))
                return TypeCodeEx.ByteArray;

            return TypeCodeEx.Object;
        }

        public static bool IsNullAllowedOnType(this TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                case TypeCodeEx.Byte:
                case TypeCodeEx.Char:
                case TypeCodeEx.Decimal:
                case TypeCodeEx.Double:
                case TypeCodeEx.Guid:
                case TypeCodeEx.Int16:
                case TypeCodeEx.Int32:
                case TypeCodeEx.Int64:
                case TypeCodeEx.SByte:
                case TypeCodeEx.Single:
                case TypeCodeEx.UInt16:
                case TypeCodeEx.UInt32:
                case TypeCodeEx.UInt64:
                case TypeCodeEx.TimeSpan:
                case TypeCodeEx.DateTimeOffset:
                case TypeCodeEx.DateTime:
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.String:
                    return true;

                /*
                 * These are not nullable:
                case TypeCodeEx.ByteArray:
                case TypeCodeEx.CustomType:
                case TypeCodeEx.DBNull:
                case TypeCodeEx.Empty:
                case TypeCodeEx.Object:
                 */
            }
            return false;
        }

        public static bool IsNumeric(this TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Byte:
                case TypeCodeEx.Decimal:
                case TypeCodeEx.Double:
                case TypeCodeEx.Int16:
                case TypeCodeEx.Int32:
                case TypeCodeEx.Int64:
                case TypeCodeEx.SByte:
                case TypeCodeEx.Single:
                case TypeCodeEx.UInt16:
                case TypeCodeEx.UInt32:
                case TypeCodeEx.UInt64:
                    return true;

                /*
                 * These are not numeric:
                case TypeCodeEx.Boolean:
                case TypeCodeEx.ByteArray:
                case TypeCodeEx.Char:
                case TypeCodeEx.CustomType:
                case TypeCodeEx.DBNull:
                case TypeCodeEx.Empty:
                case TypeCodeEx.Guid:
                case TypeCodeEx.Object:
                case TypeCodeEx.TimeSpan:
                case TypeCodeEx.DateTimeOffset:
                case TypeCodeEx.DateTime:
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.String:
                 */
            }
            return false;
        }

        public static bool IsCollectionType(this CslaObjectType cslaType)
        {
            if (cslaType.IsEditableRootCollection() ||
                cslaType.IsEditableChildCollection() ||
                cslaType.IsDynamicEditableRootCollection() ||
                cslaType.IsReadOnlyCollection())
            {
                return true;
            }

            return false;
        }

        public static bool IsCollectionType(this CslaObjectInfo info)
        {
            return info.ObjectType.IsCollectionType();
        }

        public static bool IsObjectType(this CslaObjectType cslaType)
        {
            if (cslaType.IsEditableRoot() ||
                cslaType.IsEditableChild() ||
                cslaType.IsEditableSwitchable() ||
                cslaType.IsDynamicEditableRoot() ||
                cslaType.IsReadOnlyObject())
                return true;

            return false;
        }

        public static bool IsObjectType(this CslaObjectInfo info)
        {
            return info.ObjectType.IsObjectType();
        }

        public static bool IsEditableType(this CslaObjectType cslaType)
        {
            if (cslaType.IsEditableChild() ||
                cslaType.IsEditableChildCollection() ||
                cslaType.IsEditableRoot() ||
                cslaType.IsEditableRootCollection() ||
                cslaType.IsEditableSwitchable() ||
                cslaType.IsDynamicEditableRoot() ||
                cslaType.IsDynamicEditableRootCollection())
                return true;

            return false;
        }

        public static bool IsEditableType(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableType();
        }

        public static bool IsReadOnlyType(this CslaObjectType cslaType)
        {
            if (cslaType.IsReadOnlyCollection() ||
                cslaType.IsReadOnlyObject())
                return true;

            return false;
        }

        public static bool IsReadOnlyType(this CslaObjectInfo info)
        {
            return info.ObjectType.IsReadOnlyType();
        }

        // TODO Same "IsChildType" name but different results!!! When fixing, check also templates.
        public static bool IsChildType(this CslaObjectType cslaType)
        {
            if (cslaType.IsEditableChild() ||
                cslaType.IsEditableChildCollection())
                return true;

            return false;
        }

        // TODO Same "IsChildType" name but different results!!! When fixing, check also templates.
        public static bool IsChildType(this CslaObjectInfo info)
        {
            if (info.IsEditableSwitchable() ||
                info.IsEditableChild() ||
                info.IsEditableChildCollection() ||
                ((info.IsReadOnlyObject() ||
                  info.IsReadOnlyCollection()) &&
                 info.ParentType != string.Empty))
                return true;

            return false;
        }

        public static bool IsRootType(this CslaObjectInfo info)
        {
            if (info.IsEditableRoot() ||
                info.IsEditableRootCollection() ||
                info.IsDynamicEditableRoot() ||
                info.IsDynamicEditableRootCollection() ||
                info.IsEditableSwitchable() ||
                ((info.IsReadOnlyObject() ||
                  info.IsReadOnlyCollection()) &&
                 info.ParentType == string.Empty))
                return true;

            return false;
        }

        public static bool IsNotRootType(this CslaObjectInfo info)
        {
            if (info.IsEditableChild() ||
                (info.IsReadOnlyObject() &&
                 info.ParentType != string.Empty))
                return true;

            return false;
        }

        public static bool IsItemType(this CslaObjectInfo info)
        {
            var cslaType = info.ObjectType;
            if (cslaType.IsEditableRoot() ||
                cslaType.IsEditableChild() ||
                cslaType.IsDynamicEditableRoot() ||
                cslaType.IsReadOnlyObject())
            {
                var parent = info.Parent.CslaObjects.Find(info.ParentType);
                if (parent != null && parent.ObjectType.IsCollectionType())
                    return true;
            }

            return false;
        }

        public static bool IsRootOrRootItem(this CslaObjectInfo info)
        {
            var result = !info.IsChildType();
            if (!result)
            {
                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo != null)
                    result = !parentInfo.IsChildType();
            }
            return result;
        }

        public static bool IsNotDbConsumer(this CslaObjectInfo info)
        {
            return info.IsUnitOfWork() ||
                   info.IsBaseClass() ||
                   info.IsCriteriaClass();
        }

        public static bool CanHaveParentProperties(this CslaObjectInfo info)
        {
            if (info.ObjectType.IsCollectionType())
                return false; // Object is a collection and thus has no Properties

            if (info.IsEditableRoot() ||
                info.IsDynamicEditableRoot())
                return false; // Object is root and thus has no ParentType

            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent == null)
                return info.IsReadOnlyObject();
            // Object is ReadOnly and might have ParentProperties

            if (parent.ObjectType.IsCollectionType()) // ParentType is a collection and thus has no Properties
            {
                if (parent.IsEditableRootCollection() ||
                    parent.IsDynamicEditableRootCollection() ||
                    (parent.IsReadOnlyCollection() && parent.ParentType == string.Empty))
                    return false; // ParentType is a root collection; end of line

                return true; // There should be a grand-parent with properties
            }

            if (parent.ObjectType.IsObjectType())
                return true; // ParentType exists and has properties

            return false;
        }

        public static CslaObjectInfo FindParentObject(this CslaObjectInfo info)
        {
            CslaObjectInfo parentInfo = null;

            if (string.IsNullOrEmpty(info.ParentType))
            {
                // no parent specified; find the object whose child is this object
                foreach (var cslaObject in info.Parent.CslaObjects)
                {
                    foreach (var childProperty in cslaObject.GetAllChildProperties())
                    {
                        if (childProperty.TypeName == info.ObjectName)
                            parentInfo = cslaObject;
                    }
                    if (parentInfo != null)
                        break;
                }
            }
            else
            {
                parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
            }

            if (parentInfo != null)
            {
                if (parentInfo.ItemType == info.ObjectName)
                    return parentInfo.FindParentObject();

                if (parentInfo.GetAllChildProperties().FindType(info.ObjectName) != null)
                    return parentInfo;

                /*if (parentInfo.GetCollectionChildProperties().FindType(info.ObjectName) != null)
                    return parentInfo;*/
            }

            return null;
        }

        public static CslaObjectInfo FindAncestor(this CslaObjectInfo info)
        {
            while (true)
            {
                if (info.ParentType == string.Empty) // no parent specified; this is the last ancestor
                    return info;

                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo == null) // the parent wasn't found; for practical purposes, this is the last ancestor
                    return info;

                var notFound = true;
                foreach (var child in parentInfo.AllChildProperties)
                {
                    if (child.TypeName == info.ParentType)
                    {
                        notFound = false;
                        break;
                    }
                }

                if (notFound) // the parent doesn't know the child; for practical purposes, this is the last ancestor
                    return info;

                info = parentInfo;
            }
        }

        public static List<string> GetObjectTree(this CslaObjectInfo info)
        {
            return info.FindAncestor().GetDescendents();
        }

        public static List<string> GetDescendents(this CslaObjectInfo info)
        {
            var result = new List<string> {info.ObjectName};

            if (info.ObjectType.IsCollectionType())
            {
                result.AddRange(info.Parent.CslaObjects.Find(info.ItemType).GetDescendents());
            }

            foreach (var child in info.GetCollectionChildProperties())
            {
                var childTypeName = child.TypeName;
                if (childTypeName == string.Empty)
                    continue;

                result.Add(childTypeName);

                var childInfo = info.Parent.CslaObjects.Find(childTypeName);
                result.AddRange(info.Parent.CslaObjects.Find(childInfo.ItemType).GetDescendents());
            }

            foreach (var child in info.GetNonCollectionChildProperties())
            {
                var childTypeName = child.TypeName;
                if (childTypeName == string.Empty)
                    continue;

                result.AddRange(info.Parent.CslaObjects.Find(childTypeName).GetDescendents());
            }

            return result;
        }

        public static string AddSpaceBeforeUpperCase(this string text)
        {
            //http://stackoverflow.com/questions/272633/add-spaces-before-capital-letters

            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var newText = new StringBuilder(text.Length*2);
            newText.Append(text[0]);
            for (var i = 1; i < text.Length; i++)
            {
                var currentUpper = char.IsUpper(text[i]);
                var prevUpper = char.IsUpper(text[i - 1]);
                var nextUpper = (text.Length > i + 1)
                    ? char.IsUpper(text[i + 1]) || char.IsWhiteSpace(text[i + 1])
                    : prevUpper;
                var spaceExists = char.IsWhiteSpace(text[i - 1]);
                if (currentUpper && !spaceExists && (!nextUpper || !prevUpper))
                    newText.Append(' ');

                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        #region EditableRoot

        public static bool IsEditableRoot(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.EditableRoot;
        }

        public static bool IsEditableRoot(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableRoot();
        }

        public static bool IsNotEditableRoot(this CslaObjectType cslaType)
        {
            return !cslaType.IsEditableRoot();
        }

        public static bool IsNotEditableRoot(this CslaObjectInfo info)
        {
            return !info.IsEditableRoot();
        }

        #endregion

        #region EditableChild

        public static bool IsEditableChild(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.EditableChild;
        }

        public static bool IsEditableChild(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableChild();
        }

        public static bool IsNotEditableChild(this CslaObjectType cslaType)
        {
            return !cslaType.IsEditableChild();
        }

        public static bool IsNotEditableChild(this CslaObjectInfo info)
        {
            return !info.IsEditableChild();
        }

        #endregion

        #region EditableSwitchable

        public static bool IsEditableSwitchable(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.EditableSwitchable;
        }

        public static bool IsEditableSwitchable(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableSwitchable();
        }

        public static bool IsNotEditableSwitchable(this CslaObjectType cslaType)
        {
            return !cslaType.IsEditableSwitchable();
        }

        public static bool IsNotEditableSwitchable(this CslaObjectInfo info)
        {
            return !info.IsEditableSwitchable();
        }

        #endregion

        #region DynamicEditableRoot

        public static bool IsDynamicEditableRoot(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.DynamicEditableRoot;
        }

        public static bool IsDynamicEditableRoot(this CslaObjectInfo info)
        {
            return info.ObjectType.IsDynamicEditableRoot();
        }

        public static bool IsNotDynamicEditableRoot(this CslaObjectType cslaType)
        {
            return !cslaType.IsDynamicEditableRoot();
        }

        public static bool IsNotDynamicEditableRoot(this CslaObjectInfo info)
        {
            return !info.IsDynamicEditableRoot();
        }

        #endregion

        #region EditableRootCollection

        public static bool IsEditableRootCollection(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.EditableRootCollection;
        }

        public static bool IsEditableRootCollection(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableRootCollection();
        }

        public static bool IsNotEditableRootCollection(this CslaObjectType cslaType)
        {
            return !cslaType.IsEditableRootCollection();
        }

        public static bool IsNotEditableRootCollection(this CslaObjectInfo info)
        {
            return !info.IsEditableRootCollection();
        }

        #endregion

        #region DynamicEditableRootCollection

        public static bool IsDynamicEditableRootCollection(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.DynamicEditableRootCollection;
        }

        public static bool IsDynamicEditableRootCollection(this CslaObjectInfo info)
        {
            return info.ObjectType.IsDynamicEditableRootCollection();
        }

        public static bool IsNotDynamicEditableRootCollection(this CslaObjectType cslaType)
        {
            return !cslaType.IsDynamicEditableRootCollection();
        }

        public static bool IsNotDynamicEditableRootCollection(this CslaObjectInfo info)
        {
            return !info.IsDynamicEditableRootCollection();
        }

        #endregion

        #region EditableChildCollection

        public static bool IsEditableChildCollection(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.EditableChildCollection;
        }

        public static bool IsEditableChildCollection(this CslaObjectInfo info)
        {
            return info.ObjectType.IsEditableChildCollection();
        }

        public static bool IsNotEditableChildCollection(this CslaObjectType cslaType)
        {
            return !cslaType.IsEditableChildCollection();
        }

        public static bool IsNotEditableChildCollection(this CslaObjectInfo info)
        {
            return !info.IsEditableChildCollection();
        }

        #endregion

        #region ReadOnlyObject

        public static bool IsReadOnlyObject(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.ReadOnlyObject;
        }

        public static bool IsReadOnlyObject(this CslaObjectInfo info)
        {
            return info.ObjectType.IsReadOnlyObject();
        }

        public static bool IsNotReadOnlyObject(this CslaObjectType cslaType)
        {
            return !cslaType.IsReadOnlyObject();
        }

        public static bool IsNotReadOnlyObject(this CslaObjectInfo info)
        {
            return !info.IsReadOnlyObject();
        }

        #endregion

        #region ReadOnlyCollection

        public static bool IsReadOnlyCollection(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.ReadOnlyCollection;
        }

        public static bool IsReadOnlyCollection(this CslaObjectInfo info)
        {
            return info.ObjectType.IsReadOnlyCollection();
        }

        public static bool IsNotReadOnlyCollection(this CslaObjectType cslaType)
        {
            return !cslaType.IsReadOnlyCollection();
        }

        public static bool IsNotReadOnlyCollection(this CslaObjectInfo info)
        {
            return !info.IsReadOnlyCollection();
        }

        #endregion

        #region NameValueList

        public static bool IsNameValueList(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.NameValueList;
        }

        public static bool IsNameValueList(this CslaObjectInfo info)
        {
            return info.ObjectType.IsNameValueList();
        }

        public static bool IsNotNameValueList(this CslaObjectType cslaType)
        {
            return !cslaType.IsNameValueList();
        }

        public static bool IsNotNameValueList(this CslaObjectInfo info)
        {
            return !info.IsNameValueList();
        }

        #endregion

        #region UnitOfWork

        public static bool IsUnitOfWork(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.UnitOfWork;
        }

        public static bool IsUnitOfWork(this CslaObjectInfo info)
        {
            return info.ObjectType.IsUnitOfWork();
        }

        public static bool IsNotUnitOfWork(this CslaObjectType cslaType)
        {
            return !cslaType.IsUnitOfWork();
        }

        public static bool IsNotUnitOfWork(this CslaObjectInfo info)
        {
            return !info.IsUnitOfWork();
        }

        #endregion

        #region CriteriaClass

        public static bool IsCriteriaClass(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.CriteriaClass;
        }

        public static bool IsCriteriaClass(this CslaObjectInfo info)
        {
            return info.ObjectType.IsCriteriaClass();
        }

        public static bool IsNotCriteriaClass(this CslaObjectType cslaType)
        {
            return !cslaType.IsCriteriaClass();
        }

        public static bool IsNotCriteriaClass(this CslaObjectInfo info)
        {
            return !info.IsCriteriaClass();
        }

        #endregion

        #region BaseClass

        public static bool IsBaseClass(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.BaseClass;
        }

        public static bool IsBaseClass(this CslaObjectInfo info)
        {
            return info.ObjectType.IsBaseClass();
        }

        public static bool IsNotBaseClass(this CslaObjectType cslaType)
        {
            return !cslaType.IsBaseClass();
        }

        public static bool IsNotBaseClass(this CslaObjectInfo info)
        {
            return !info.IsBaseClass();
        }

        #endregion

        #region PlaceHolder

        public static bool IsPlaceHolder(this CslaObjectType cslaType)
        {
            return cslaType == CslaObjectType.PlaceHolder;
        }

        public static bool IsPlaceHolder(this CslaObjectInfo info)
        {
            return info.ObjectType.IsPlaceHolder();
        }

        public static bool IsNotPlaceHolder(this CslaObjectType cslaType)
        {
            return !cslaType.IsPlaceHolder();
        }

        public static bool IsNotPlaceHolder(this CslaObjectInfo info)
        {
            return !info.IsPlaceHolder();
        }

        #endregion
    }
}