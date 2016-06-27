<%
/*
ERRORS
1. Transaction type ADO is invalid
2. Persistence type SqlConnectionUnshared is invalid
(run on Business or on DalObject)
5. When generating Data Access Region:
5.1. When generating Insert method, check Insert Procedure name isn't empty
5.2. When generating Update method, check Update Procedure name isn't empty
5.3. When generating Delete methods:
5.3.1. For EditableChilds check DeleteProcedureName is empty
5.3.2. Check Criteria for DeleteOptions where DataPortal is set and SProc name is empty
5.3.3. Check Criteria for DeleteOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
5.4. Check Criteria for GetOptions where DataPortal is set and SProc name is empty
5.5. Check Criteria for GetOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
*/

CslaObjectInfo parentInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
//UseChildFactoryHelper = CurrentUnit.GenerationParams.UseChildFactory;
if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
{
    Errors.Append("Persistence Type SqlConnectionUnshared isn't supported when running DAL." + Environment.NewLine);
}

if (Info.TransactionType == TransactionType.ADO)
{
    Errors.Append("Transaction Type ADO isn't supported when running DAL." + Environment.NewLine);
}

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
        if (Info.IsEditableChild())
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
    if (c.GetOptions.DataPortal && c.GetOptions.ProcedureName == string.Empty)
    {
        Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is enable but is missing Get procedure name." + Environment.NewLine);
    }
    if (!c.GetOptions.DataPortal && c.GetOptions.ProcedureName != string.Empty)
    {
        Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is disable but has Get procedure name." + Environment.NewLine);
    }
}
%>
