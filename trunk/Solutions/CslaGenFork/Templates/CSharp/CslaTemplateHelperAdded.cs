﻿using System;
using System.Collections;
using System.Collections.Generic;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util
{
    public partial class CslaTemplateHelper
    {
        #region ParameterSet

        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool criteria, bool param)
        {
            bool nullable = AllowNull(prop);
            string propName;
            //propName = (criteria) ? "crit." + FormatPascal(prop.Name) : FormatFieldForPropertyType(info, prop);
            if (criteria)
            {
                propName = "crit." + FormatPascal(prop.Name);
            }
            else if (param)
            {
                propName = FormatCamel(prop.Name);
            }
            else
            {
                propName = FormatFieldForPropertyType(info, prop);
            }

            if (nullable && prop.PropertyType != TypeCodeEx.SmartDate)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    return string.Format("{0} == null ? (object) DBNull.Value : {0}.Value", propName);

                return string.Format("{0} == null ? (object) DBNull.Value : {0}", propName);
            }
            switch (prop.PropertyType)
            {
                case TypeCodeEx.SmartDate:
                    return propName + ".DBValue";
                case TypeCodeEx.Guid:
                    return propName + ".Equals(Guid.Empty) ? (object) DBNull.Value : " + propName;
                default:
                    return propName;
            }
        }

        /// <summary>
        /// Gets the parameter set - for plain properties.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="prop">The prop.</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop)
        {
            return GetParameterSet(info, prop, false, false);
        }

        /// <summary>
        /// Gets the parameter set - for criteria properties.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="prop">The prop.</param>
        /// <param name="criteria">if set to <c>true</c> [criteria].</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool criteria)
        {
            return GetParameterSet(info, prop, criteria, false);
        }

        #endregion

        #region Basic Formats

        public string FormatFieldForPropertyName(CslaObjectInfo info, string name)
        {
            var response = string.Empty;

            ValuePropertyCollection valProps = info.GetAllValueProperties();
            if (valProps.Contains(name))
            {
                ValueProperty prop = valProps.Find(name);
                response = GetFieldReaderStatement(prop.DeclarationMode, name);
            }
            return response;
        }

        public string FormatFieldForPropertyType(CslaObjectInfo info, Property p)
        {
            var response = string.Empty;

            ValuePropertyCollection valProps = info.GetAllValueProperties();
            if (valProps.Contains(p.Name))
            {
                ValueProperty prop = valProps.Find(p.Name);
                response = GetFieldReaderStatement(prop.DeclarationMode, p.Name);
            }
            return response;
        }

        public string FormatEvent(string name)
        {
            return FormatPascal(name);
        }

        public string FormatEventDocumentation(string name)
        {
            var response = string.Empty;

            switch (name)
            {
                case "Create":
                    response += "after setting all defaults for object creation.";
                    break;
                case "FetchPre":
                    response += "after setting query parameters and before the fetch operation.";
                    break;
                case "FetchPost":
                    response += "after the fetch operation (object or collection is fully loaded and set up).";
                    break;
                case "FetchRead":
                    response += "after the low level fetch operation, before the data reader is destroyed.";
                    break;
                case "InsertStart":
                    response += "in DataPortal_Insert, after setting row identifiers (ID) and before setting other query parameters.";
                    break;
                case "InsertPre":
                    response += "in DataPortal_Insert, after setting query parameters and before the insert operation.";
                    break;
                case "InsertPost":
                    response += "in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().";
                    break;
                case "UpdateStart":
                    response += "after setting row identifiers (ID and RowVersion) and before setting other query parameters.";
                    break;
                case "UpdatePre":
                    response += "after setting query parameters and before the update operation.";
                    break;
                case "UpdatePost":
                    response += "in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().";
                    break;
                case "DeletePre":
                    response += "in DataPortal_Delete, after setting query parameters and before the delete operation.";
                    break;
                case "DeletePost":
                    response += "in DataPortal_Delete, after the delete operation, before Commit().";
                    break;
                default:
                    response += "undescribed circumstances.";
                    break;
            }

            return response;
        }

        public string FormatFieldName(ValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatFieldName(Property prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ChildProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(UpdateValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ConvertValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(string name)
        {
            return FormatPascal(name);
        }

        public string FormatPropertyInfoName(string name)
        {
            return FormatPascal(name) + "Property";
        }

        #endregion

        #region State Field parts

        public bool StateFieldsForAllValueProperties(CslaObjectInfo info)
        {
            foreach (var prop in info.AllValueProperties)
            {
                if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.NoProperty)
                {
                    return true;
                }
            }

            return false;
        }

        public bool StateFieldsForAllChildProperties(CslaObjectInfo info)
        {
            foreach (var prop in info.AllChildProperties)
            {
                if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.NoProperty)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Declarations

        public string BusinessListBaseHelper(bool isFirstPass)
        {
            if (CurrentUnit.GenerationParams.GeneratedUIEnvironment == UIEnvironment.WinForms)
                return "BusinessBindingListBase";

            if (CurrentUnit.GenerationParams.GeneratedUIEnvironment == UIEnvironment.WPF)
                return "BusinessListBase";

            var response = string.Empty;

            if (isFirstPass)
            {
                if (CurrentUnit.GenerationParams.GeneratedUIEnvironment == UIEnvironment.WinForms_WPF)
                    response += "BusinessListBase";
                else
                    response += "BusinessBindingListBase";
            }
            else
            {
                if (CurrentUnit.GenerationParams.GeneratedUIEnvironment == UIEnvironment.WinForms_WPF)
                    response += "BusinessBindingListBase";
                else
                    response += "BusinessListBase";
            }

            return response;
        }

        // TODO: On ReadOnly objects, forbid Managed and Unmanaged with TypeConversion

        public virtual string GetInitValue(ValueProperty prop, TypeCodeEx typeCode)
        {
            if (AllowNull(prop) && typeCode != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(typeCode);
        }

        public virtual string GetDataTypeGeneric(Property prop, TypeCodeEx field)
        {
            string type = GetDataType(field);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(field))
                    type += "?";
            }
            return type;
        }

        public string FieldDeclare(ValueProperty prop)
        {
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
            {
                response = CheckNotUndoable(prop);
                response += string.Format("private {0} {1} = {2};",
                                          (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                           prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                                           prop.DeclarationMode == PropertyDeclaration.NoProperty)
                                              ? GetDataTypeGeneric(prop, prop.PropertyType)
                                              : GetDataTypeGeneric(prop, prop.BackingFieldType),
                                          FormatFieldName(prop.Name),
                                          GetFieldInitValue(prop));
            }

            return response;
        }

        private string GetFieldInitValue(ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
                return GetInitValue(prop, prop.PropertyType);

            return GetInitValue(prop, prop.BackingFieldType);
        }

        public string PropertyInfoDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                 // "private static PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
                response =
                    string.Format(
                        "{0} static PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3}, \"{4}\"{5});",
                        Access.Convert(prop.PropertyInfoAccess),
                        (prop.DeclarationMode == PropertyDeclaration.Managed ||
                         prop.DeclarationMode == PropertyDeclaration.Unmanaged)
                            ? GetDataTypeGeneric(prop, prop.PropertyType)
                            : GetDataTypeGeneric(prop, prop.BackingFieldType),
                        FormatPropertyInfoName(prop.Name),
                        prop.Name,
                        prop.FriendlyName,
                        GetRelationhipType(info, prop));
            }

            return response;
        }

        private string GetRelationhipType(CslaObjectInfo info, ValueProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
                return "";

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response = ", RelationshipTypes.PrivateField";
            }

            return response;
        }

        // TODO: check child properties are PropertyDeclaration.Managed

        public string PropertyInfoChildDeclare(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                 // "private static PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
                response =
                    string.Format(
                        "{0} static PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3}, \"{4}\"{5});",
                        Access.Convert(prop.PropertyInfoAccess),
                        prop.TypeName,
                        FormatPropertyInfoName(prop.Name),
                        prop.Name,
                        prop.FriendlyName,
                        GetRelationhipType(info, prop));
            }

            return response;
        }

        private string GetRelationhipType(CslaObjectInfo info, ChildProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
                return "";

            var response = string.Empty;

            if (prop.LazyLoad)
            {
                response += ", RelationshipTypes.LazyLoad";
            }
            else
            {
                response += ", RelationshipTypes.Child";
            }

            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += " | RelationshipTypes.PrivateField";
            }

            return response;
        }

        public string PropertyDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response = string.Format("{0} {1} {2}{3}",
                                         GetPropertyAccess(prop),
                                         GetDataTypeGeneric(prop, prop.PropertyType),
                                         prop.Name, Environment.NewLine);
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                var isReadOnly = (info.ObjectType == CslaObjectType.ReadOnlyObject);

                response += PropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += string.Format("{0} {1} {2} {{ get; {3} set; }}",
                                          GetPropertyAccess(prop),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          FormatPascal(prop.Name),
                                          (prop.ReadOnly || prop.PropSetAccessibility == AccessorVisibility.Private)
                                              ? "private"
                                              : "");
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += string.Format("{0} {1} {2}" + Environment.NewLine,
                                          GetPropertyAccess(prop),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          FormatPascal(prop.Name));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                var isReadOnly = (info.ObjectType == CslaObjectType.ReadOnlyObject);

                response += PropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }

            return response;
        }

        private string PropertyDeclareGetter(ValueProperty prop)
        {
            var isConversion = (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion);

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += string.Format("            get {{ return {0}{1}({2}); }}{3}",
                                          isConversion
                                              ? "GetPropertyConvert"
                                              : "GetProperty",
                                          isConversion
                                              ? "<" + prop.BackingFieldType + "," + prop.PropertyType + ">"
                                              : "",
                                          (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                           prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                                              ? FormatPropertyInfoName(prop.Name) + ", " + FormatFieldName(prop.Name)
                                              : FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else
            {
                response += string.Format("            get {{ return {0}; }}{1}",
                    FormatFieldName(prop.Name),
                    Environment.NewLine);
            }

            return response;
        }

        // TODO: check ReadOnly objects aren't trying to have write side of properties enabled
        // This must be validated by templates, not here
        // 1) ReadOnly - properties should have no setter except for unmanaged (w/ or w/o type conversion) and auto properties
        // 2) ReadOnly - porperties should have private setters unless they have NoSetter

        private string PropertyDeclareSetter(bool isReadOnly, ValueProperty prop)
        {
            if (prop.PropSetAccessibility == AccessorVisibility.NoSetter)
                return "";

            if ((prop.PropSetAccessibility == AccessorVisibility.Private || prop.ReadOnly) &&
                (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                 prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion))
                return "";

            var response = string.Empty;
            var isConversion = (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion);

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += string.Format("            {0}set {{ {1}{2}({3}, value); }}{4}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          PropertyDeclareSetterMethod(isReadOnly, isConversion),
                                          isConversion
                                              ? "<" + prop.BackingFieldType + "," + prop.PropertyType + ">"
                                              : "",
                                          (!isReadOnly && (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                                           prop.DeclarationMode ==
                                                           PropertyDeclaration.UnmanagedWithTypeConversion))
                                              ? FormatPropertyInfoName(prop.Name) + ", ref " +
                                                FormatFieldName(prop.Name)
                                              : FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else
            {
                response += string.Format("            {0}set {{ {1} = value; }}{2}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          FormatFieldName(prop.Name) + ConvertTextToSmartDate(prop),
                                          Environment.NewLine);
            }

            return response;
        }

        private string PropertyDeclareSetterVisibility(bool isReadOnly, ValueProperty prop)
        {
            if (GetPropertyAccess(prop) == "private")
                return "";

            return (prop.ReadOnly ||
                    prop.PropSetAccessibility == AccessorVisibility.Private ||
                    isReadOnly)
                       ? "private "
                       : "";
        }

        private static string PropertyDeclareSetterMethod(bool isReadOnly, bool isConversion)
        {
            if (isConversion)
                if (isReadOnly)
                    return "LoadPropertyConvert";
                else
                    return "SetPropertyConvert";

            if (isReadOnly)
                return "LoadProperty";

            return "SetProperty";
        }

        public string CheckNotUndoable(ValueProperty prop)
        {
            var response = string.Empty;
            if (!prop.Undoable)
                response = "[NotUndoable]" + Environment.NewLine + "        ";

            return response;
        }

        #endregion

        #region Field Reader

        public string GetFieldReaderStatement(ValueProperty prop)
        {
            return GetFieldReaderStatement(prop.DeclarationMode, prop.Name);
        }

        public string GetFieldReaderStatement(ChildProperty prop)
        {
            return GetFieldReaderStatement(prop.DeclarationMode, prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, UpdateValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.Name == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }
            foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }

            return FormatFieldName(prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, ConvertValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.Name == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }
            foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }

            return FormatFieldName(prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, string propName)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (propName == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }

            return FormatFieldName(propName);
        }

        public string GetFieldReaderStatement(PropertyDeclaration propDeclarationMode, string propName)
        {
            if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
                if (propDeclarationMode == PropertyDeclaration.Managed ||
                    propDeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                {
                    return String.Format("ReadProperty({0})", FormatPropertyInfoName(propName));
                }

            if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
                if (propDeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    return String.Format(FormatProperty(propName));
                }

            return FormatFieldName(propName);
        }

        public string GetSourceFieldReaderStatement(CslaObjectInfo info, ConvertValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }
            /*foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }*/

            return "";
//            return GetFieldReaderStatement(prop.SourceDeclarationMode, prop.SourcePropertyName);
        }

        #endregion

        #region Field Loader

        public virtual string GetDataLoaderStatement(ValueProperty prop)
        {
            var statement = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                statement += String.Format("{0} = {1} dr.{2}(\"{3}\"{4})",
                                           FormatProperty(prop.Name),
                                           "(" + prop.PropertyType + ")",
                                           //GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType),
                                           GetReaderMethod(GetDbType(prop.DbBindColumn), prop),
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ", true"
                                               : "");
            }
            else
            {
                statement += String.Format("LoadProperty({0}, dr.{1}(\"{2}\"{3}))",
                                           FormatPropertyInfoName(prop.Name),
                                           //GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType),
                                           GetReaderMethod(GetDbType(prop.DbBindColumn), prop),
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ", true"
                                               : "");
            }

            return statement;
        }

        public string GetFieldLoaderStatement(ValueProperty prop, string value)
        {
            return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
        }

        public string GetFieldLoaderStatement(ChildProperty prop, string value)
        {
            return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
        }

        /// <summary>
        /// Gets the field loader statement evaluating <paramref name="value"/> parameter using the GetFieldLoaderStatement.
        /// </summary>
        /// <param name="info">The info object.</param>
        /// <param name="prop">The property to assign the <paramref name="value"/>.</param>
        /// <param name="value">If it starts with "$" it is evaluated as a property reference and the GetFieldLoaderStatement is used to get the final form of value.</param>
        /// <returns>The loader statemente on the form <code>_prop = value</code> or <code>LoadProperty(PropProperty, value)</code>.</returns>
        public string GetFieldLoaderStatement(CslaObjectInfo info, ValueProperty prop, string value)
        {
//            if (CurrentUnit.GenerationParams.GeneratedUIEnvironment == UIEnvironment.WinForms_WPF)
            if (value.IndexOf("$") != 0)
                return GetFieldLoaderStatement(prop, value);

            var propSource = value.Substring(1);

            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (propSource == valueProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, GetFieldReaderStatement(valueProp));
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (propSource == childProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, GetFieldReaderStatement(childProp));
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(CslaObjectInfo info, UpdateValueProperty prop, string value)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return GetFieldLoaderStatement(valueProp.DeclarationMode, prop.Name + ConvertTextToSmartDate(valueProp), value);
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (prop.SourcePropertyName == childProp.Name)
                    return GetFieldLoaderStatement(childProp.DeclarationMode, prop.Name, value);
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(CslaObjectInfo info, ConvertValueProperty prop, string value)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (prop.SourcePropertyName == childProp.Name)
                    return GetFieldLoaderStatement(childProp.DeclarationMode, prop.Name, value);
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(PropertyDeclaration propDeclarationMode, string propName, string value)
        {
            if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
                if (propDeclarationMode == PropertyDeclaration.Managed ||
                    propDeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                {
                    return String.Format("LoadProperty({0}, {1})", FormatPropertyInfoName(propName), value);
                }

            if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
                if (propDeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    return String.Format("{0} = {1}", FormatProperty(propName), value);
                }

            return String.Format("{0} = {1}", FormatFieldName(propName), value);
        }

        #endregion

        #region Child handling

        public virtual string GetNewChildLoadStatement(ChildProperty prop, bool isDataPortalCreate)
        {
            var value = prop.TypeName + ".New" + prop.TypeName + "()";

            if (isDataPortalCreate && prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return "";

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            return GetFieldLoaderStatement(prop, value);
        }

        public virtual string GetExistingChildLoadStatement(ChildProperty prop)
        {
            var value = prop.TypeName + ".Get" + prop.TypeName + "()";

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            return GetFieldLoaderStatement(prop, value);
        }

        public string PropertyDeclare(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += string.Format("{0} {1} {2}{3}",
                                          GetPropertyAccess(prop),
                                          prop.TypeName,
                                          prop.Name, Environment.NewLine);
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += string.Format("{0} {1} {2}" + Environment.NewLine,
                                          GetPropertyAccess(prop),
                                          prop.TypeName,
                                          FormatPascal(prop.Name));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                var isReadOnly = (info.ObjectType == CslaObjectType.ReadOnlyObject);

                response += PropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                var isReadOnly = (info.ObjectType == CslaObjectType.ReadOnlyObject || prop.ReadOnly);

                response += string.Format("{0} {1} {2} {{ get; {3}set; }}",
                                          GetPropertyAccess(prop),
                                          prop.TypeName,
                                          FormatPascal(prop.Name),
                                          isReadOnly ? "private " : "");
            }

            return response;
        }

        private string ChildPropertyDeclareGetter(CslaObjectInfo info, ChildProperty prop)
        {
            if (prop.LazyLoad || prop.LoadingScheme == LoadingScheme.SelfLoad)
            {
                return ChildPropertyDeclareGetterSpecial(info, prop);
            }

            // this is LoadingScheme.ParentLoad or LoadingScheme.None
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += string.Format("            get {{ return GetProperty({0}); }}{1}",
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else
            {
                // prop.DeclarationMode == PropertyDeclaration.ClassicProperty

                response += string.Format("            get {{ return {0}; }}{1}",
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string ChildPropertyDeclareGetterSpecial(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += "            get" + Environment.NewLine;
                response += "            {" + Environment.NewLine;
                response += ChildPropertyDeclareGetLazyLoad(info, prop);
                response += ChildPropertyDeclareGetLoadingScheme(prop);
                response += ChildPropertyDeclareGetReturner(prop);
                response += "            }" + Environment.NewLine;
            }
            else
            {
                // prop.DeclarationMode == PropertyDeclaration.ClassicProperty

                response += string.Format("            get {{ return {0}; }}{1}",
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string ChildPropertyDeclareGetLazyLoad(CslaObjectInfo info, ChildProperty prop)
        {
            if (!prop.LazyLoad)
                return "";

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                /*if (!FieldManager.FieldExists(ChildProperty))
                    if (this.IsNew)
                        LoadProperty(ChildProperty, ChildType.NewChild());
                    else
                        LoadProperty(ChildProperty, ChildType.GetChild(this));*/
                response += string.Format("                if (!FieldManager.FieldExists({0})){1}",
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += string.Format("                        LoadProperty({0}, {1}.New{1}());{2}",
                                          FormatPropertyInfoName(prop.Name),
                                          prop.TypeName,
                                          Environment.NewLine);
                response += "                    else" + Environment.NewLine;
                response += string.Format("                        LoadProperty({0}, {1}.Get{1}({2}));{3}",
                                          FormatPropertyInfoName(prop.Name),
                                          prop.TypeName,
                                          GetFieldReaderStatementList(info, prop),
                                          Environment.NewLine);
                response += Environment.NewLine;

            }
            else
            {
                // prop.DeclarationMode == PropertyDeclaration.ClassicProperty

                response += string.Format("                return {0};{1}",
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string GetFieldReaderStatementList(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            for (var loadParameter = 0; loadParameter < prop.LoadParameters.Count; loadParameter++)
            {
                response += FormatFieldForPropertyName(info, prop.LoadParameters[loadParameter].Property.Name);
                if (loadParameter + 1 != prop.LoadParameters.Count)
                    response += ", ";
            }

            return response;
        }

        private string ChildPropertyDeclareGetLoadingScheme(ChildProperty prop)
        {
            if (prop.LazyLoad || prop.LoadingScheme != LoadingScheme.SelfLoad)
                return "";

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += string.Format("                if (!FieldManager.FieldExists({0})){1}",
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
                response += string.Format("                    LoadProperty({0}, {1}.New{1}());{2}",
                                          FormatPropertyInfoName(prop.Name),
                                          prop.TypeName,
                                          Environment.NewLine);
                response += Environment.NewLine;
            }
            else
            {
                // prop.DeclarationMode == PropertyDeclaration.ClassicProperty

                response += string.Format("                return {0};{1}",
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string ChildPropertyDeclareGetReturner(ChildProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += string.Format("                return GetProperty({0});{1}",
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else
            {
                // prop.DeclarationMode == PropertyDeclaration.ClassicProperty

                response += string.Format("                return {0};{1}",
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string PropertyDeclareSetter(bool isReadOnly, ChildProperty prop)
        {
            if ((prop.ReadOnly) &&
                (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                 prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion))
                return "";

            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                return "";
            }
            else
            {
                response += string.Format("            {0}set {{ {1} = value; }}{2}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string PropertyDeclareSetterVisibility(bool isReadOnly, ChildProperty prop)
        {
            if (GetPropertyAccess(prop) == "private")
                return "";

            return (prop.ReadOnly || isReadOnly)
                       ? "private "
                       : "";
        }

        #endregion

        public bool GetValuePropertyByName(CslaObjectInfo info, string propertyName, ref ValueProperty prop)
        {
            //foreach (var valueProperty in info.GetAllValueProperties())
            foreach (var valueProperty in info.ValueProperties)
            {
                if (valueProperty.Name == propertyName)
                {
                    prop = valueProperty;
                    return true;
                }
            }
            return false;
        }

        #region SimpleAudit

        public bool UseSimpleAuditTrail(CslaObjectInfo info)
        {
            if (!String.IsNullOrEmpty(info.Parent.Params.CreationDateColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.CreationUserColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.ChangedDateColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.ChangedUserColumn))
            {

                foreach (var valueProperty in info.GetAllValueProperties())
                {
                    if (valueProperty.Name == info.Parent.Params.CreationDateColumn ||
                        valueProperty.Name == info.Parent.Params.CreationUserColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedDateColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                        return true;
                }
            }
            return false;
        }

        public static bool IsCreationDateColumnPresent(CslaObjectInfo info)
        {
            //foreach (var valueProperty in info.GetAllValueProperties())
            foreach (var valueProperty in info.ValueProperties)
            {
                if (valueProperty.Name == info.Parent.Params.CreationDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsCreationUserColumnPresent(CslaObjectInfo info)
        {
            //foreach (var valueProperty in info.GetAllValueProperties())
            foreach (var valueProperty in info.ValueProperties)
            {
                if (valueProperty.Name == info.Parent.Params.CreationUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedDateColumnPresent(CslaObjectInfo info)
        {
            //foreach (var valueProperty in info.GetAllValueProperties())
            foreach (var valueProperty in info.ValueProperties)
            {
                if (valueProperty.Name == info.Parent.Params.ChangedDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedUserColumnPresent(CslaObjectInfo info)
        {
            //foreach (var valueProperty in info.GetAllValueProperties())
            foreach (var valueProperty in info.ValueProperties)
            {
                if (valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Context Connection Manager

        public string GetConnection(CslaObjectInfo info, bool isFetch)
        {
            var response = "using (var ctx = ";

            if (info.PersistenceType == PersistenceType.LinqContext)
            {
                response += "ContextManager<" + info.DbContextObject + ">.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else if (info.PersistenceType == PersistenceType.EFContext)
            {
                response += "ObjectContextManager<" + info.DbContextObject + ">.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                response = "using (var cn = new SqlConnection(Database." + info.DbName + "Connection))";
            }
            else if (info.TransactionType == TransactionType.ADO && !isFetch)
            {
                response += "TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else
            {
                response += "ConnectionManager<SqlConnection>.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            return response;
        }

        public string GetCommand(CslaObjectInfo info, string commandText)
        {
            return "using (var cmd = new SqlCommand(\"" + commandText + "\", " + LocalContextConnection(info) + "))";
        }

        public string LocalContextConnection(CslaObjectInfo info)
        {
            if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                return "cn";

            return "ctx.Connection";
        }

        #endregion

        public string[] CslaObjectPrimaryKeys(string infoName)
        {
            return CslaObjectPrimaryKeys(CurrentUnit.CslaObjects.Find(infoName));
        }

        public string[] CslaObjectPrimaryKeys(CslaObjectInfo info)
        {
            var pkList = new List<string>();
            foreach (var prop in info.AllValueProperties)
            {
                if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    pkList.Add(prop.Name);
            }
            pkList.Sort();

            return pkList.ToArray();
        }

        private string ConvertTextToSmartDate(ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                if (prop.PropertyType == TypeCodeEx.String && prop.BackingFieldType == TypeCodeEx.SmartDate)
                    return ".Text";
            }

            return String.Empty;
        }

        public virtual string GetInitValue(Property prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(ConvertValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(UpdateValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetAccessorVisibility(ValueProperty prop)
        {
            switch (prop.PropSetAccessibility)
            {
                case AccessorVisibility.Private:
                    return "private";
                case AccessorVisibility.Public:
                    return "public";
                case AccessorVisibility.Protected:
                    return "Protected";
                case AccessorVisibility.ProtectedInternal:
                    return "protected internal";
                case AccessorVisibility.Internal:
                    return "internal";
                default:
                    return "public";
            }
        }

        public virtual string GetConstructorVisibility(CslaObjectInfo info)
        {
            switch (info.ConstructorVisibility)
            {
                case ConstructorVisibility.Private:
                    return "private";
                case ConstructorVisibility.Protected:
                    return "protected";
                case ConstructorVisibility.ProtectedInternal:
                    return "protected internal";
                case ConstructorVisibility.Internal:
                    return "internal";
                default:
                    return "private";
            }
        }

        public virtual string GetPropertyAccess(ValueProperty prop)
        {
            return Access.Convert(prop.Access);
        }

        public virtual string GetPropertyAccess(ChildProperty prop)
        {
            return Access.Convert(prop.Access);
        }        

        #region <remarks> helpers

        public static string Ordinal(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                default:
                    return "plus then ten";
            }
        }

        public static string CslaStereotype(CslaObjectType cslaGenObjectType)
        {
            switch (cslaGenObjectType)
            {
                case CslaObjectType.EditableRoot:
                    return "editable root object";
                case CslaObjectType.EditableChild:
                    return "editable child object";
                case CslaObjectType.EditableSwitchable:
                    return "editable wwitchable object";
                case CslaObjectType.DynamicEditableRoot:
                    return "dynamic editable root object";
                case CslaObjectType.EditableRootCollection:
                    return "editable root collection";
                case CslaObjectType.DynamicEditableRootCollection:
                    return "dynamic editable root collection";
                case CslaObjectType.EditableChildCollection:
                    return "editable child collection";
                case CslaObjectType.ReadOnlyObject:
                    return "read only object";
                case CslaObjectType.ReadOnlyCollection:
                    return "read only collection";
                case CslaObjectType.NameValueList:
                    return "name value list";
                default:
                    return "new CSLA stereotype";
            }
        }

        public CslaObjectInfo FindAssociated(CslaObjectInfo info, CslaObjectInfo originalChild)
        {
            // presume only one primary key on Associated entities
            // presume only one pair of Associated entities an a "N to N" relation

            List<string> allCslaObjects = CurrentUnit.CslaObjects.GetAllObjectNames();

            var primaryKeys = PrimaryKeys.GetPrimaryKeys(allCslaObjects, info);
            var originalChildCollectionItem = originalChild.Parent.CslaObjects.Find(originalChild.ItemType);
            var originalChildCollectionItemPK = PrimaryKeys.FindPrimaryKey(originalChildCollectionItem);
            var infoPK = PrimaryKeys.FindPrimaryKey(info);

            foreach (PrimaryKeys.ObjectPK trialPK in PrimaryKeys.Cache)
            {
                // reject self matching (false positives)
                if (trialPK.Info != info && trialPK.Info != originalChildCollectionItem)
                {
                    if (MatchingProperties(originalChildCollectionItemPK, trialPK.Property))
                    {
                        if (FindMatchingChildCollectionItems(infoPK, trialPK))
                            return trialPK.Info;
                    }
                }
            }

            return null;
        }

        private bool FindMatchingChildCollectionItems(ValueProperty originalInfoPK, PrimaryKeys.ObjectPK trialPK)
        {
            if (trialPK.Info.ChildCollectionProperties.Count > 0)
            {
                for (int collection = 0; collection < trialPK.Info.ChildCollectionProperties.Count; collection++)
                {
                    var trialChildCollection = FindChildInfo(trialPK.Info, trialPK.Info.ChildCollectionProperties[collection].TypeName);
                    var trialChildCollectionItem = trialChildCollection.Parent.CslaObjects.Find(trialChildCollection.ItemType);
                    foreach (var trialChildCollectionItemProp in trialChildCollectionItem.ValueProperties)
                    {
                        if (MatchingProperties(originalInfoPK, trialChildCollectionItemProp))
                            return true;
                    }
                }
            }
            return false;
        }

        private static bool MatchingProperties(ValueProperty original, ValueProperty trial)
        {
            if (trial.Name == original.Name &&
                (trial.ParameterName == original.ParameterName ||
                 trial.DbBindColumn == original.DbBindColumn))
                return true;

            return false;
        }

        #region Singleton primary keyes

        public class PrimaryKeys
        {
            public class ObjectPK
            {
                public CslaObjectInfo Info { get; set; }

                public ValueProperty Property { get; set; }
            }

            private static PrimaryKeys _instance;
            private static CslaObjectInfo _cslaObjectInfo;
            private static List<string> _allCslaObjects;

            public static ArrayList Cache { get; private set; }

            /* force to use Factory methods */
            private PrimaryKeys()
            {
                foreach (var cslaObject in _allCslaObjects)
                {
                    var info = _cslaObjectInfo.Parent.CslaObjects.Find(cslaObject);
                    ValueProperty prop = FindPrimaryKey(info);
                    if (prop != null)
                    {
                        Cache.Add(new ObjectPK {Info = info, Property = prop});
                    }
                }
            }

            static PrimaryKeys()
            {
                Cache = new ArrayList();
            }

            public static ValueProperty FindPrimaryKey(CslaObjectInfo info)
            {
                foreach (var prop in info.ValueProperties)
                {
                    // accept DBProvidedPK and also UserProvidedPK
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        return prop;
                    }
                }
                return null;
            }

            public static PrimaryKeys GetPrimaryKeys(List<string> allCslaObjects, CslaObjectInfo cslaObjectInfo)
            {
                // Use 'Lazy initialization'
                if (_instance == null)
                {
                    _allCslaObjects = allCslaObjects;
                    _cslaObjectInfo = cslaObjectInfo;
                    _instance = new PrimaryKeys();
                }
                return _instance;
            }

            public static void ClearCache()
            {
                Cache.Clear();
                _instance = null;
            }

        }

        #endregion

        #endregion

    }
}
