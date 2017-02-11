<%
/*
ERRORS
1. When using DAL, no DataSetLoadingScheme
2. When using DAL, no UseCustomLoading
>>> missing 3. When using DAL, criteria classes (with more than one property) may or may not be nested (DTO, DTO limit)
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
4.6. Check Criteria for GetOptions for DynamicEditableRoot
5. Check value properties from StoredProcedure don't co-exist with other origins
6. Warn about value properties of editable objects if declaration mode is Classic or Auto
7. Warning when using NOT DAL, Persistence type unshared needs database class
8. Warning when using Silverligh 4, no Auto, Classic nor 'No Property'.
9. Warning when using Silverligh 4, criteria classes (with more than one property) must not use Simple mode.
>>> missing 10. Warn about missing Foreign key constraints on DB
11. Alert when using DAL, unbound properties need DTO or will be excluded from DAL interaction
12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
13. Alert about useless Unit Of Work.
14. The matching object for a cache invalidator has no CacheResultsOptions set.
15. Warn about InheritedType with no InheritedTypeWinForms (and VV) when DualListInheritance.
16. BaseClass needs InheritedType.
17. InheritedType number of arguments doesn't match what is needed by ObjectType, except for BaseClass.
18. InheritedTypeWinForms number of arguments doesn't match what is needed by ObjectType, except for BaseClass.
19. On BaseClass, InheritedType number of arguments must match number of arguments specified on the object.
*/

// General interest variables start

bool isCriteriaClassNeeded = IsCriteriaClassNeeded(Info);
CslaObjectInfo parentInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
UseChildFactoryHelper = CurrentUnit.GenerationParams.UseChildFactory;
bool isCollectionType = TypeHelper.IsCollectionType(Info.ObjectType);
bool isItemType = TypeHelper.IsItemType(Info);
bool isChild = parentInfo != null;
bool isParent = Info.GetAllChildProperties().Count > 0;
bool isChildSelfLoaded = IsChildSelfLoaded(Info);
bool isChildLazyLoaded = IsChildLazyLoaded(Info);
bool isChildNotLazyLoaded = isChild && !isChildLazyLoaded;
bool? forceGeneration = null;
bool createGenerateLocal = true;
bool generateLocal = false;
bool useUnitOfWorkCreator = false;
bool useUnitOfWorkGetter = false;
bool isObjectAutz = false;
if (Info.UseUnitOfWorkType != string.Empty)
{
    CslaObjectInfo uowInfo = Info.Parent.CslaObjects.Find(Info.UseUnitOfWorkType);
    if (uowInfo != null)
    {
        useUnitOfWorkCreator = uowInfo.IsCreator || uowInfo.IsCreatorGetter;
        useUnitOfWorkGetter = uowInfo.IsGetter || uowInfo.IsCreatorGetter;
    }
}

// General interest variables end

if (CurrentUnit.GenerationParams.TargetIsCsla4DAL)
{
    if (Info.DataSetLoadingScheme)
    {
        // 1. When using DAL, no DataSetLoadingScheme
        Errors.Append("DataSet Loading Scheme isn't supported when generating DAL." + Environment.NewLine);
    }
    /*
    retain for eventual use on dummy proof checks
    if (Info.UseCustomLoading)
    {
        // 2. When using DAL, no UseCustomLoading
        Errors.Append("Custom Loading isn't supported when generating DAL." + Environment.NewLine);
    }*/
}

/*
makes sure custom loading isn't used by accident
retain for eventual use on dummy proof checks
if (CurrentUnit.GenerationParams.TargetIsCsla4)
{
    if (isCollectionType)
    {
        if (Info.UseCustomLoading != itemInfo.UseCustomLoading)
        {
            // 12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
            Errors.Append(Info.ObjectName + " is " + (Info.UseCustomLoading ? "" : "not") + " using custom loading: item " + itemInfo.ObjectName + " must use the same setting.." + Environment.NewLine);
            return;
        }
    }
    if (isItemType)
    {
        if (Info.UseCustomLoading != parentInfo.UseCustomLoading)
        {
            // 12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
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
                // 12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
                Errors.Append(Info.ObjectName + " is " + (Info.UseCustomLoading ? "" : "not") + " using custom loading: child " + childInfo.ObjectName + " must use the same setting.." + Environment.NewLine);
                return;
            }
        }
    }
    if (isChild)
    {
        if (Info.UseCustomLoading != parentInfo.UseCustomLoading)
        {
            // 12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
            Errors.Append(parentInfo.ObjectName + " is " + (parentInfo.UseCustomLoading ? "" : "not") + " using custom loading: child " + Info.ObjectName + " must use the same setting.." + Environment.NewLine);
            return;
        }
    }
    if (UseChildFactoryHelper && Info.UseCustomLoading && (isItemType || isCollectionType || isChild || isParent))
    {
        UseChildFactoryHelper = false;
        // 12. Alert when using NOT DAL, CustomLoading forces NO generation of child Factory methods
        Infos.Append("Alert: " + Info.ObjectName + " is using custom loading: child Factory methods will not be generated." + Environment.NewLine);
    }
}*/

bool hasFactoryCache = false;
bool hasDataPortalCache = false;
CslaObjectInfo invalidatorInfo = Info;
if (Info.IsEditableRootCollection() ||
    Info.IsDynamicEditableRoot() ||
    Info.IsEditableRoot())
{
    if (Info.IsDynamicEditableRoot())
    {
        invalidatorInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
    }
    foreach (string objectName in invalidatorInfo.InvalidateCache)
    {
        CslaObjectInfo cachedInfo = invalidatorInfo.Parent.CslaObjects.Find(objectName);
        if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.None)
        {
            // 14. The matching object for a cache invalidator has no CacheResultsOptions set.
            Errors.Append("Object " + invalidatorInfo.ObjectName + ": " + cachedInfo.ObjectName + " is on 'Invalidate Cache Types' but has 'Cache Results Options' set to 'None'." + Environment.NewLine);
            return;
        }
        else
        {
            // Set up variables for InvalidateCachedList.asp
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.Factory)
                hasFactoryCache = hasFactoryCache || true;
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.DataPortal)
                hasDataPortalCache = hasFactoryCache || true;
        }
    }
}

if (CurrentUnit.GenerationParams.TargetIsCsla4)
{
    // 4. When generating Data Access Region:
    if (Info.GenerateDataAccessRegion &&
        (Info.IsEditableRoot() ||
        Info.IsDynamicEditableRoot() ||
        Info.IsEditableChild() ||
        Info.IsEditableSwitchable()))
    {
        if (Info.GenerateDataPortalInsert)
        {
            if (string.IsNullOrEmpty(Info.InsertProcedureName))
            {
                // 4.1. When generating Insert method, check Insert Procedure name isn't empty
                Errors.Append("Object " + Info.ObjectName + " missing Insert procedure name." + Environment.NewLine);
            }
        }
        if (Info.GenerateDataPortalUpdate)
        {
            if (string.IsNullOrEmpty(Info.UpdateProcedureName))
            {
                // 4.2. When generating Update method, check Update Procedure name isn't empty
                Errors.Append("Object " + Info.ObjectName + " missing Update procedure name." + Environment.NewLine);
            }
        }
        // 4.3. When generating Delete methods:
        if (Info.GenerateDataPortalDelete)
        {
            if (Info.IsEditableChild())
            {
                if (string.IsNullOrEmpty(Info.DeleteProcedureName))
                {
                    // 4.3.1. For EditableChilds check DeleteProcedureName is empty
                    Errors.Append("Object " + Info.ObjectName + " missing Delete procedure name." + Environment.NewLine);
                }
            }
            else
            {
                foreach (Criteria c in Info.CriteriaObjects)
                {
                    if (c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName == string.Empty)
                    {
                        // 4.3.2. Check Criteria for DeleteOptions where DataPortal is set and SProc name is empty
                        Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is enable but is missing Delete procedure name." + Environment.NewLine);
                    }
                    if (!c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName != string.Empty)
                    {
                        // 4.3.3. Check Criteria for DeleteOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
                        Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is disable but has Delete procedure name." + Environment.NewLine);
                    }
                }
            }
        }
    }
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (Info.IsUnitOfWork())
            continue;
        if (Info.IsDynamicEditableRoot())
        {
            if (c.GetOptions.Factory || c.GetOptions.DataPortal || c.GetOptions.Procedure || c.GetOptions.ProcedureName != string.Empty)
            {
                // 4.6. Check Criteria for GetOptions for DynamicEditableRoot
                Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": must disable all Get options and remove procedure name." + Environment.NewLine);
            }
        }
        if (c.GetOptions.DataPortal && c.GetOptions.ProcedureName == string.Empty)
        {
            // 4.4. Check Criteria for GetOptions where DataPortal is set and SProc name is empty
            Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is enable but is missing Get procedure name." + Environment.NewLine);
        }
        if (!c.GetOptions.DataPortal && c.GetOptions.ProcedureName != string.Empty)
        {
            // 4.5. Check Criteria for GetOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
            Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is disable but has Get procedure name." + Environment.NewLine);
        }
    }
}

if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared &&
    !CurrentUnit.GenerationParams.GenerateDatabaseClass &&
    CurrentUnit.GenerationParams.TargetIsCsla4)
{
    // 7. Warning when using NOT DAL, Persistence type unshared needs database class
    Warnings.Append("Generation settings: 'Generate Database class' is un-checked. Persistence Type.SqlConnectionUnshared needs the database class." + Environment.NewLine);
}

bool originIsStoredProcedure = false;
foreach (ValueProperty prop in Info.GetDatabaseBoundValueProperties())
{
    if (!prop.IsDatabaseBound)
        continue;
    originIsStoredProcedure = originIsStoredProcedure || prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure;
}
foreach (ValueProperty prop in Info.GetDatabaseBoundValueProperties())
{
    if (!prop.IsDatabaseBound)
        continue;
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
        // 5. Check value properties from StoredProcedure don't co-exist with other origins
        Warnings.Append(Info.ObjectName + " has Value Properties with Stored Procedure origin: " + prop.Name + " origin's must be Stored Procedure also." + Environment.NewLine);
    }
    if (CurrentUnit.GenerationParams.TargetIsCsla4DAL && !CurrentUnit.GenerationParams.GenerateDTO)
    {
        if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
        {
            // 11. Alert when using DAL, unbound properties need DTO or will be excluded from DAL interaction
            Infos.Append("Alert: " + Info.ObjectName + "Property " + prop.Name + " isn't database bound; must use DTO or property will be excluded from DAL interaction." + Environment.NewLine);
        }
    }
    if (prop.DeclarationMode != PropertyDeclaration.Unmanaged &&
        prop.DeclarationMode != PropertyDeclaration.UnmanagedWithTypeConversion &&
        prop.DeclarationMode != PropertyDeclaration.Managed &&
        prop.DeclarationMode != PropertyDeclaration.ManagedWithTypeConversion)
    {
        if (UseSilverlight())
        {
            // 8. Warning when using Silverligh 4, no Auto, Classic nor 'No Property'.
            Warnings.Append(Info.ObjectName + " property " + prop.Name + ": must use Declaration Mode 'Managed', 'ManagedWithTypeConversion', 'Unmanaged' or 'UnmanagedWithTypeConversion' under Silverlight." + Environment.NewLine);
        }
        if (!prop.ReadOnly && Info.IsNotReadOnlyObject())
        {
            // 6. Warn about value properties of editable objects if declaration mode is Classic or Auto
            Warnings.Append(Info.ObjectName + " is editable: property " + prop.Name + ": must use Declaration Mode 'Managed', 'ManagedWithTypeConversion', 'Unmanaged' or 'UnmanagedWithTypeConversion' as changes to the property won't raise any event." + Environment.NewLine);
        }
    }
}
if (CurrentUnit.GenerationParams.GenerateSilverlight4 ||
    CurrentUnit.GenerationParams.TargetIsCsla4DAL)
{
    foreach (Criteria criteria in Info.CriteriaObjects)
    {
        if (criteria.Properties.Count > 1)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4 && criteria.CriteriaClassMode == CriteriaMode.Simple)
            {
                // 9. Warning when using Silverligh 4, criteria classes (with more than one property) must not use Simple mode.
                Warnings.Append("Criteria " + criteria.Name + ": must use Mode 'CriteriaBase' or 'BusinessBase' under Silverlight." + Environment.NewLine);
            }
        }
    }
}
/*if (!CurrentUnit.GenerationParams.GenerateAsynchronous && ! UseSilverlight() && Info.UseUnitOfWorkType != string.Empty)
{
    // 13. Alert about useless Unit Of Work.
    Infos.Append(Info.ObjectName + " uses Unit of Work Type " + Info.UseUnitOfWorkType + ": usage is useful only when Asynchronous or Silverlight is generated." + Environment.NewLine);
}*/

if (Info.IsDualInheritor() && CurrentUnit.GenerationParams.DualListInheritance)
{
    if (Info.InheritedType.FinalName != String.Empty && Info.InheritedTypeWinForms.FinalName == String.Empty)
    {
        // 15. Warn about InheritedType with no InheritedTypeWinForms (and VV) when DualListInheritance.
        Warnings.Append(Info.ObjectName + " Inherited Type is specified but no Inherited Type WinForms was specified." + Environment.NewLine);
    }
    if (Info.InheritedTypeWinForms.FinalName != String.Empty && Info.InheritedType.FinalName == String.Empty)
    {
        // 15. Warn about InheritedType with no InheritedTypeWinForms (and VV) when DualListInheritance.
        Warnings.Append(Info.ObjectName + " Inherited Type WinForms is specified  but no Inherited Type was specified." + Environment.NewLine);
    }
    if (Info.IsNotBaseClass() && Info.InheritedTypeWinForms.FinalName != String.Empty && Info.InheritedTypeWinForms.GetParameters().Length != Info.NumberOfGenericArguments())
    {
        // 18. InheritedTypeWinForms number of arguments doesn't match what is needed by ObjectType, except for BaseClass.
        Errors.Append(Info.ObjectName + " must have " + Info.NumberOfGenericArguments() + " generic arguments and Inherited Type WinForms has " + Info.InheritedTypeWinForms.GetParameters().Length + " generic arguments." + Environment.NewLine);
    } 
}
if (Info.IsBaseClass() && Info.CslaBaseClass == CslaBaseClasses.None)
{
    // 16. BaseClass needs InheritedType.
    Errors.Append(Info.ObjectName + " is a BaseClass and an Csla Base Class must be specified." + Environment.NewLine);
}
if (Info.IsNotBaseClass() && Info.InheritedType.FinalName != String.Empty && Info.InheritedType.GetParameters().Length != Info.NumberOfGenericArguments())
{
    // 17. InheritedType number of arguments doesn't match what is needed by ObjectType, except for BaseClass.
    Errors.Append(Info.ObjectName + " must have " + Info.NumberOfGenericArguments() + " generic arguments and Inherited Type has " + Info.InheritedType.GetParameters().Length + " generic arguments." + Environment.NewLine);
}
if (Info.IsBaseClass() && Info.InheritedType.FinalName != String.Empty && Info.InheritedType.GetParameters().Length != Info.GetGenericArguments().Length)
{
    // 19. On BaseClass, InheritedType number of arguments must match number of arguments specified on the object.
    Errors.Append(Info.ObjectName + " is a BaseClass with " + Info.GetGenericArguments().Length + " generic arguments and Inherited Type has " + Info.InheritedType.GetParameters().Length + " generic arguments." + Environment.NewLine);
}
%>
