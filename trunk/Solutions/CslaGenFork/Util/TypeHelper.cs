using System;
using System.Collections.Generic;
using System.Data;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util
{
    /// <summary>
    /// Summary description for TypeHelper.
    /// </summary>
    public static class TypeHelper
    {
        public static bool IsStringType(DbType dbType)
        {
            if (dbType == DbType.String || dbType == DbType.StringFixedLength ||
                dbType == DbType.AnsiString || dbType == DbType.AnsiStringFixedLength)
            {
                return true;
            }

            return false;
        }

        public static TypeCodeEx GetTypeCodeEx(Type type)
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

        public static SqlDbType GetSqlDbType(TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                    return SqlDbType.Bit;
                case TypeCodeEx.Byte:
                    return SqlDbType.TinyInt;
                case TypeCodeEx.ByteArray:
                    return SqlDbType.Image;
                case TypeCodeEx.Char:
                    return SqlDbType.Char;
                case TypeCodeEx.TimeSpan:
                    return SqlDbType.Time;
                case TypeCodeEx.DateTimeOffset:
                    return SqlDbType.DateTimeOffset;
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DateTime:
                    return SqlDbType.DateTime;
                case TypeCodeEx.Decimal:
                    return SqlDbType.Decimal;
                case TypeCodeEx.Double:
                    return SqlDbType.Float;
                case TypeCodeEx.Guid:
                    return SqlDbType.UniqueIdentifier;
                case TypeCodeEx.Int16:
                    return SqlDbType.SmallInt;
                case TypeCodeEx.Int32:
                    return SqlDbType.Int;
                case TypeCodeEx.Int64:
                    return SqlDbType.BigInt;
                case TypeCodeEx.SByte:
                    return SqlDbType.TinyInt;
                case TypeCodeEx.Single:
                    return SqlDbType.Real;
                case TypeCodeEx.String:
                    return SqlDbType.VarChar;
                case TypeCodeEx.UInt16:
                    return SqlDbType.Int;
                case TypeCodeEx.UInt32:
                    return SqlDbType.BigInt;
                case TypeCodeEx.UInt64:
                    return SqlDbType.BigInt;
                case TypeCodeEx.Object:
                    return SqlDbType.Image;
                default:
                    return SqlDbType.VarChar;
            }
        }

        public static DbType GetDbType(TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                    return DbType.Boolean;
                case TypeCodeEx.Byte:
                    return DbType.Byte;
                case TypeCodeEx.ByteArray:
                    return DbType.Binary;
                case TypeCodeEx.Char:
                    return DbType.StringFixedLength;
                case TypeCodeEx.TimeSpan:
                    return DbType.Time;
                case TypeCodeEx.DateTimeOffset:
                    return DbType.DateTimeOffset;
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DateTime:
                    return DbType.DateTime;
                case TypeCodeEx.Decimal:
                    return DbType.Decimal;
                case TypeCodeEx.Double:
                    return DbType.Double;
                case TypeCodeEx.Guid:
                    return DbType.Guid;
                case TypeCodeEx.Int16:
                    return DbType.Int16;
                case TypeCodeEx.Int32:
                    return DbType.Int32;
                case TypeCodeEx.Int64:
                    return DbType.Int64;
                case TypeCodeEx.SByte:
                    return DbType.SByte;
                case TypeCodeEx.Single:
                    return DbType.Single;
                case TypeCodeEx.String:
                    return DbType.String;
                case TypeCodeEx.UInt16:
                    return DbType.UInt16;
                case TypeCodeEx.UInt32:
                    return DbType.UInt32;
                case TypeCodeEx.UInt64:
                    return DbType.UInt64;
                case TypeCodeEx.Object:
                    return DbType.Binary;
                default:
                    return DbType.String;
            }
        }

        public static bool IsNullableType(TypeCodeEx type)
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
                    return true;

                /*
                 * These are not nullable:
                case TypeCodeEx.ByteArray:
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DBNull:
                case TypeCodeEx.Empty:
                case TypeCodeEx.Object:
                case TypeCodeEx.String:
                 */
            }
            return false;
        }

        public static bool IsNullAllowedOnType(TypeCodeEx type)
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
                case TypeCodeEx.DBNull:
                case TypeCodeEx.Empty:
                case TypeCodeEx.Object:
                 */
            }
            return false;
        }

        public static TypeCodeEx GetBackingFieldType(ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
                return prop.BackingFieldType;

            return prop.PropertyType;
        }

        public static bool IsCollectionType(this CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection)
            {
                return true;
            }

            return false;
        }

        public static bool IsObjectType(this CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableSwitchable ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsEditableType(this CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableSwitchable ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.DynamicEditableRootCollection)
                return true;

            return false;
        }

        public static bool IsReadOnlyType(this CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.ReadOnlyCollection ||
                cslaType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsChildType(this CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableChildCollection)
                return true;

            return false;
        }

        public static bool IsChildType(this CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableSwitchable ||
                info.ObjectType == CslaObjectType.EditableChild ||
                info.ObjectType == CslaObjectType.EditableChildCollection ||
                ((info.ObjectType == CslaObjectType.ReadOnlyObject ||
                  info.ObjectType == CslaObjectType.ReadOnlyCollection) &&
                 info.ParentType != string.Empty))
                return true;

            return false;
        }

        public static bool IsRootType(this CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.EditableRootCollection ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                info.ObjectType == CslaObjectType.EditableSwitchable ||
                ((info.ObjectType == CslaObjectType.ReadOnlyObject ||
                  info.ObjectType == CslaObjectType.ReadOnlyCollection) &&
                 info.ParentType == string.Empty))
                return true;

            return false;
        }

        public static bool IsNotRootType(this CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableChild ||
                (info.ObjectType == CslaObjectType.ReadOnlyObject &&
                 info.ParentType != string.Empty))
                return true;

            return false;
        }

        public static bool IsItemType(this CslaObjectInfo info)
        {
            var cslaType = info.ObjectType;
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.ReadOnlyObject)
            {
                var parent = info.Parent.CslaObjects.Find(info.ParentType);
                if (parent != null && IsCollectionType(parent.ObjectType))
                    return true;
            }

            return false;
        }

        public static bool IsRootOrRootItem(this CslaObjectInfo info)
        {
            bool result = !IsChildType(info);
            if (!result)
            {
                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo != null)
                    result = !IsChildType(parentInfo);
            }
            return result;
        }

        public static bool IsNotDbConsumer(this CslaObjectInfo info)
        {
            return info.ObjectType == CslaObjectType.UnitOfWork ||
                   info.ObjectType == CslaObjectType.BaseClass ||
                   info.ObjectType == CslaObjectType.CriteriaClass;
        }

        public static bool CanHaveParentProperties(this CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                return false; // Object is a collection and thus has no Properties

            if (info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot)
                return false; // Object is root and thus has no ParentType

            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent == null)
                return info.ObjectType == CslaObjectType.ReadOnlyObject;
            // Object is ReadOnly and might have ParentProperties

            if (IsCollectionType(parent.ObjectType)) // ParentType is a collection and thus has no Properties
            {
                if (parent.ObjectType == CslaObjectType.EditableRootCollection ||
                    parent.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                    (parent.ObjectType == CslaObjectType.ReadOnlyCollection && parent.ParentType == string.Empty))
                    return false; // ParentType is a root collection; end of line

                return true; // There should be a grand-parent with properties
            }

            if (IsObjectType(parent.ObjectType))
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

        private static CslaObjectInfo FindAncestor(this CslaObjectInfo info)
        {
            while (true)
            {
                if (info.ParentType == string.Empty) // no parent specified; this is the last ancestor
                    return info;

                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo == null) // the parent wasn't found; for practical purposes, this is the last ancestor
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
    }
}