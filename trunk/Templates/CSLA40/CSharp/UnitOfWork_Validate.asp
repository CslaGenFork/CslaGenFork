<%
// check UnitOfWorkType compatibility
// check there is at least one appropriate criteria per element type
if (Info.IsDeleter)
{
    int editableTypeCounter = 0;
    foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkProperties)
    {
        CslaObjectInfo targetInfo = Info.Parent.CslaObjects.Find(uowProp.TypeName);
        if (IsEditableType(targetInfo.ObjectType))
        {
            editableTypeCounter++;
            int deleteCriteriaCounter = 0;
            foreach (Criteria crit in targetInfo.CriteriaObjects)
            {
                if (crit.IsDeleter)
                    deleteCriteriaCounter++;
            }
            if (deleteCriteriaCounter < 1)
            {
                Errors.Append(Info.ObjectName + " (" + Info.UnitOfWorkType + " unit of work): editable target " +  targetInfo.ObjectName + " must have a delete criteria." + Environment.NewLine);
                return;
            }
        }
    }
    if (editableTypeCounter < 1)
    {
        Errors.Append(Info.ObjectName + ": no editable target object found. \"Unit of Work Type\" must be \"Getter\"." + Environment.NewLine);
        return;
    }
}
else if (!Info.IsUpdater)
{
    int editableTypeCounter = 0;
    foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkProperties)
    {
        CslaObjectInfo targetInfo = Info.Parent.CslaObjects.Find(uowProp.TypeName);
        if (IsEditableType(targetInfo.ObjectType))
        {
            editableTypeCounter++;
            int createCriteriaCounter = 0;
            foreach (Criteria crit in targetInfo.CriteriaObjects)
            {
                if (crit.IsCreator)
                    createCriteriaCounter++;
            }
            if (createCriteriaCounter < 1)
            {
                Errors.Append(Info.ObjectName + " (" + Info.UnitOfWorkType + " unit of work): editable target " +  targetInfo.ObjectName + " must have a create criteria." + Environment.NewLine);
                return;
            }
        }
        else
        {
            int getCriteriaCounter = 0;
            foreach (Criteria crit in targetInfo.CriteriaObjects)
            {
                if (crit.IsGetter)
                    getCriteriaCounter++;
            }
            if (getCriteriaCounter < 1)
            {
                Errors.Append(Info.ObjectName + ": read only target " +  targetInfo.ObjectName + " must have a get criteria." + Environment.NewLine);
                return;
            }
        }
    }
    if (editableTypeCounter < 1 && !Info.IsGetter)
    {
        Errors.Append(Info.ObjectName + ": no editable target object found. \"Unit of Work Type\" must be \"Getter\"." + Environment.NewLine);
        return;
    }
}

// get combined criteria
if (!Info.IsUpdater)
{
    Info.UnitOfWorkCriteriaObjects = UnitOfWorkCriteriaManager.GetAllCriteria(Info);
    /*if (allUnitOfWorkCriteria != null)
    {
        List<CriteriaCollection> allUnitOfWorkCriteria = Info.UnitOfWorkCriteriaObjects
        foreach (CriteriaCollection criteriaCollection in Info.UnitOfWorkCriteriaObjects)
        {
            foreach (Criteria crit in criteriaCollection)
            {
                Warnings.Append(crit.ParentObject.ObjectName + "_" + crit.Name + ".");
            }
            Warnings.Append(Environment.NewLine);
        }
    }*/
}
List<UnitOfWorkCriteriaManager.UoWCriteria> listUoWCriteriaCreator = null;
List<UnitOfWorkCriteriaManager.UoWCriteria> listUoWCriteriaGetter = null;
List<UnitOfWorkCriteriaManager.UoWCriteria> listUoWCriteriaDeleter = null;
if (Info.IsCreator || Info.IsCreatorGetter)
    listUoWCriteriaCreator = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Creator);
if (Info.IsGetter || Info.IsCreatorGetter)
    listUoWCriteriaGetter = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Getter);
if (Info.IsDeleter)
    listUoWCriteriaDeleter = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Deleter);
%>
