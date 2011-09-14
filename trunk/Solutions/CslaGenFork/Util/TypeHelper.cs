using System;
using System.Data;
using CslaGenerator.Metadata;
using CslaGenerator.Util.PropertyBags;
using System.ComponentModel;

namespace CslaGenerator.Util
{
    /// <summary>
    /// Summary description for TypeHelper.
    /// </summary>
    public class TypeHelper
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

        public static bool IsCollectionType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRootCollection || 
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection )
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
                case TypeCodeEx.DateTime:
                    return true;

                /*
                 * These are not nullable:
                case Metadata.TypeCodeEx.ByteArray:
                case Metadata.TypeCodeEx.SmartDate:
                case Metadata.TypeCodeEx.DBNull:
                case Metadata.TypeCodeEx.Empty:
                case Metadata.TypeCodeEx.Object:
                case Metadata.TypeCodeEx.String:
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
        
        public static void GetContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is PropertyBag)
                {
                    var pBag = (PropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetAssociativeEntityContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is AssociativeEntityPropertyBag)
                {
                    var pBag = (AssociativeEntityPropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetConvertValuePropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is ConvertValuePropertyBag)
                {
                    var pBag = (ConvertValuePropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is BusinessRuleConstructorBag)
                {
                    var pBag = (BusinessRuleConstructorBag)context.Instance;
                    if (pBag.SelectedObject[0].ConstructorParameter0.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter0;
                    else if (pBag.SelectedObject[0].ConstructorParameter1.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter1;
                    else if (pBag.SelectedObject[0].ConstructorParameter2.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter2;
/*                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;*/
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetInheritedTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is InheritedTypePropertyBag or PropertyGrid
                if (context.Instance is InheritedTypePropertyBag)
                {
                    var pBag = (InheritedTypePropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }
        
        public static void GetAuthorizationTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is AuthorizationRuleBag)
                {
                    var pBag = (AuthorizationRuleBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetBusinessRuleTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is BusinessRuleBag)
                {
                    var pBag = (BusinessRuleBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        /*public static void GetBusinessRulePropertyTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is BusinessRulePropertyBag)
                {
                    var pBag = (BusinessRulePropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }*/

        public static void GetUnitOfWorkPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is UnitOfWorkPropertyBag or PropertyGrid
                if (context.Instance is UnitOfWorkPropertyBag)
                {
                    var pBag = (UnitOfWorkPropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetChildPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is ChildPropertyBag or PropertyGrid
                if (context.Instance is ChildPropertyBag)
                {
                    var pBag = (ChildPropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetValuePropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is ValuePropertyBag or PropertyGrid
                if (context.Instance is ValuePropertyBag)
                {
                    var pBag = (ValuePropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

    }
}
