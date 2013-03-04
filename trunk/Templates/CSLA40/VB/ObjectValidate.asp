<%
/*
ERRORS
1. When using DAL, no DataSetLoadingScheme
2. When using DAL, no UseCustomLoading
3. When using DAL, criteria classes (with more than one property) may or may not be nested (DTO, DTO limit)
(run on Business or on DalObject)
4. When generating Data Access Region:
4.1. When generating Insert method, check Insert Procedure name isn't empty
4.2. When generating Update method, check Update Procedure name isn't empty
4.3. When generating Delete methods:
4.3.1. For EditableChilds check DeleteProcedureName is empty
4.3.2. Check Criteria for DeleteOptions where DataPortal is set and SProc name is empty
4.3.3. Check Criteria for DeleteOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
4.4. Check Criteria for GetOptions where DataPortal is set and SProc name is empty
4.5. Check Criteria for GetOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
5. Check value properties from StoredProcedure don't co-exist with other origins
6. Warn about value properties of editable objects if delcaration mode is Classic or Auto
WARNINGS
7. When using NOT DAL, Persistence type unshared needs database class
8. When using Silverligh 4, no Auto, Classic nor 'No Property'.
9. When using Silverligh 4, criteria classes (with more than one property) must not use Simple mode.
10. Missing Foreign key constraints on DB
ALERTS
11. When using DAL, unbound properties need DTO or will be excluded from DAL interaction
12. When using NOT DAL, CustomLoading forces NOT generation of child Factory methods
*/

bool isCriteriaClassNeeded = IsCriteriaClassNeeded(Info);
CslaObjectInfo parentInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
UseChildFactoryHelper = CurrentUnit.GenerationParams.UseChildFactory;
bool isCollectionType = IsCollectionType(Info.ObjectType);
bool isItemType = IsItemType(Info);
bool isChild = parentInfo != null;
bool isParent = Info.GetAllChildProperties().Count > 0;
bool isChildSelfLoaded = IsChildSelfLoaded(Info);
bool isChildLazyLoaded = IsChildLazyLoaded(Info);
bool isChildNotLazyLoaded = isChild && !isChildLazyLoaded;
bool createAsynGenRunLocal = true;
bool objectRunLocal = true;
if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
{
    if (Info.DataSetLoadingScheme)
    {
        Errors.Append("DataSet Loading Scheme isn't supported when generating DAL." + Environment.NewLine);
    }
    if (Info.UseCustomLoading)
    {
        Errors.Append("Custom Loading isn't supported when generating DAL." + Environment.NewLine);
    }
}
if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
{
    if (isCollectionType)
    {
        if (Info.UseCustomLoading != itemInfo.UseCustomLoading)
        {
            Errors.Append(Info.ObjectName + " is " + (Info.UseCustomLoading ? "" : "not") + " using custom loading: item " + itemInfo.ObjectName + " must use the same setting.." + Environment.NewLine);
            return;
        }
    }
    if (isItemType)
    {
        if (Info.UseCustomLoading != parentInfo.UseCustomLoading)
        {
            Errors.Append(parentInfo.ObjectName + " is " + (parentInfo.UseCustomLoading ? "" : "not") + " using custom loading: item " + Info.ObjectName + " must use the same setting.." + Environment.NewLine);
            return;
        }
    }
    if (isParent)
    {
        foreach (ChildProperty prop in Info.GetAllChildProperties())
        {
            CslaObjectInfo childInfo = Info.Parent.CslaObjects.Find(prop.TypeName);
            if (Info.UseCustomLoading != childInfo.UseCustomLoading)
            {
                Errors.Append(Info.ObjectName + " is " + (Info.UseCustomLoading ? "" : "not") + " using custom loading: child " + childInfo.ObjectName + " must use the same setting.." + Environment.NewLine);
                return;
            }
        }
    }
    if (isChild)
    {
        if (Info.UseCustomLoading != parentInfo.UseCustomLoading)
        {
            Errors.Append(parentInfo.ObjectName + " is " + (parentInfo.UseCustomLoading ? "" : "not") + " using custom loading: child " + Info.ObjectName + " must use the same setting.." + Environment.NewLine);
            return;
        }
    }
    if (UseChildFactoryHelper && Info.UseCustomLoading && (isItemType || isCollectionType || isChild || isParent))
    {
        UseChildFactoryHelper = false;
        Infos.Append("Alert: " + Info.ObjectName + " is using custom loading: child Factory methods will not be generated." + Environment.NewLine);
    }
}

bool hasFactoryCache = false;
bool hasDataPortalCache = false;
CslaObjectInfo invalidatorInfo = Info;
if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
    Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
    Info.ObjectType == CslaObjectType.EditableRoot)
{
    if (Info.ObjectType == CslaObjectType.DynamicEditableRoot)
    {
        invalidatorInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
    }
    foreach (string objectName in invalidatorInfo.InvalidateCache)
    {
        CslaObjectInfo cachedInfo = invalidatorInfo.Parent.CslaObjects.Find(objectName);
        if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.None)
        {
            Errors.Append("Object " + invalidatorInfo.ObjectName + ": " + cachedInfo.ObjectName + " is on 'Invalidate Cache Types' but has 'Cache Results Options' set to 'None'." + Environment.NewLine);
            return;
        }
        else
        {
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.Factory)
                hasFactoryCache = hasFactoryCache || true;
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.DataPortal)
                hasDataPortalCache = hasFactoryCache || true;
        }
    }
}

if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
{
    if (Info.GenerateDataAccessRegion &&
        (Info.ObjectType == CslaObjectType.EditableRoot ||
        Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
        Info.ObjectType == CslaObjectType.EditableChild ||
        Info.ObjectType == CslaObjectType.EditableSwitchable))
    {
        if (Info.GenerateDataPortalInsert)
        {
            if (string.IsNullOrEmpty(Info.InsertProcedureName))
            {
                Errors.Append("Object " + Info.ObjectName + " missing Insert procedure name." + Environment.NewLine);
            }
        }
        if (Info.GenerateDataPortalUpdate)
        {
            if (string.IsNullOrEmpty(Info.UpdateProcedureName))
            {
                Errors.Append("Object " + Info.ObjectName + " missing Update procedure name." + Environment.NewLine);
            }
        }
        if (Info.GenerateDataPortalDelete)
        {
            if (Info.ObjectType == CslaObjectType.EditableChild)
            {
                if (string.IsNullOrEmpty(Info.DeleteProcedureName))
                {
                    Errors.Append("Object " + Info.ObjectName + " missing Delete procedure name." + Environment.NewLine);
                }
            }
            else
            {
                foreach (Criteria c in Info.CriteriaObjects)
                {
                    if (c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName == string.Empty)
                    {
                        Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is enable but is missing Delete procedure name." + Environment.NewLine);
                    }
                    if (!c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName != string.Empty)
                    {
                        Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is disable but has Delete procedure name." + Environment.NewLine);
                    }
                }
            }
        }
    }
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (Info.ObjectType == CslaObjectType.UnitOfWork)
            continue;
        if (c.GetOptions.DataPortal && c.GetOptions.ProcedureName == string.Empty)
        {
            Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is enable but is missing Get procedure name." + Environment.NewLine);
        }
        if (!c.GetOptions.DataPortal && c.GetOptions.ProcedureName != string.Empty)
        {
            Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is disable but has Get procedure name." + Environment.NewLine);
        }
    }
}
if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared &&
    !CurrentUnit.GenerationParams.GenerateDatabaseClass &&
    CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
{
    Warnings.Append("Generation settings: 'Generate Database class' is un-checked. Persistence Type.SqlConnectionUnshared needs the database class." + Environment.NewLine);
}
bool originIsStoredProcedure = false;
foreach (ValueProperty prop in Info.GetDatabaseBoundValueProperties())
{
    originIsStoredProcedure = originIsStoredProcedure || prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure;
}
foreach (ValueProperty prop in Info.GetDatabaseBoundValueProperties())
{
    bool reportMixedOrigins = false;
    if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure)
    {
        reportMixedOrigins = reportMixedOrigins || !originIsStoredProcedure;
    }
    else if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None)
    {
        reportMixedOrigins = reportMixedOrigins || originIsStoredProcedure;
    }
    if (reportMixedOrigins)
    {
        Warnings.Append(Info.ObjectName + " has Value Properties with Stored Procedure origin: " + prop.Name + " origin's must be Stored Procedure also." + Environment.NewLine);
    }
    if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL && !CurrentUnit.GenerationParams.GenerateDTO)
    {
        if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
            Infos.Append("Alert: " + Info.ObjectName + "Property " + prop.Name + " isn't database bound; must use DTO or property will be excluded from DAL interaction." + Environment.NewLine);
    }
    if (prop.DeclarationMode != PropertyDeclaration.Unmanaged &&
        prop.DeclarationMode != PropertyDeclaration.UnmanagedWithTypeConversion &&
        prop.DeclarationMode != PropertyDeclaration.Managed &&
        prop.DeclarationMode != PropertyDeclaration.ManagedWithTypeConversion)
    {
        if (UseSilverlight())
            Warnings.Append(Info.ObjectName + " property " + prop.Name + ": must use Declaration Mode 'Managed', 'ManagedWithTypeConversion', 'Unmanaged' or 'UnmanagedWithTypeConversion' under Silverlight." + Environment.NewLine);
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject)
            Warnings.Append(Info.ObjectName + " is editable: property " + prop.Name + ": must use Declaration Mode 'Managed', 'ManagedWithTypeConversion', 'Unmanaged' or 'UnmanagedWithTypeConversion' as changes to the property won't raise any event." + Environment.NewLine);
    }
}
if (CurrentUnit.GenerationParams.GenerateSilverlight4 ||
    CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
{
    foreach (Criteria criteria in Info.CriteriaObjects)
    {
        if (criteria.Properties.Count > 1)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4 && criteria.CriteriaClassMode == CriteriaMode.Simple)
                Warnings.Append("Criteria " + criteria.Name + ": must use Mode 'CriteriaBase' or 'BusinessBase' under Silverlight." + Environment.NewLine);
        }
    }
}
%>
