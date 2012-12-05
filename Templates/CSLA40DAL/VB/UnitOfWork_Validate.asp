<%
if (!Info.IsUpdater)
{
    if (Info.CriteriaObjects.Count == 0)
    {
        Criteria addedCrit = new Criteria();
        addedCrit.Name = "Criteria";
        Info.CriteriaObjects.Add(addedCrit);
        Warnings.Append(Info.ObjectName + ": Criteria added." + Environment.NewLine);
    }

    Info.MyCriteriaObjects = FilterAndMergeUnitOfWorkCriteriaCollection(Info);
    Criteria tempCrit = GetCriteriaObjects(Info)[0];

    if (Info.IsCreator && !(tempCrit.CreateOptions.Factory && tempCrit.CreateOptions.DataPortal))
    {
        tempCrit.CreateOptions.Factory = true;
        tempCrit.CreateOptions.DataPortal = true;
        Warnings.Append(Info.ObjectName + ": CreateOptions set." + Environment.NewLine);
    }
    if (Info.IsGetter && !(tempCrit.GetOptions.Factory && tempCrit.GetOptions.DataPortal))
    {
        tempCrit.GetOptions.Factory = true;
        tempCrit.GetOptions.DataPortal = true;
        Warnings.Append(Info.ObjectName + ": GetOptions set." + Environment.NewLine);
    }
    if (Info.IsDeleter && !(tempCrit.DeleteOptions.Factory && tempCrit.DeleteOptions.DataPortal))
    {
        tempCrit.DeleteOptions.Factory = true;
        tempCrit.DeleteOptions.DataPortal = true;
        Warnings.Append(Info.ObjectName + ": DeleteOptions set." + Environment.NewLine);
    }

    string typeOfCriteria = string.Empty;
    string objectFunctions = string.Empty;
    bool reportCreatorError = Info.IsCreatorGetter || Info.IsCreator;
    foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkProperties)
    {
        CslaObjectInfo targetInfo = Info.Parent.CslaObjects.Find(uowProp.TypeName);

        // check UnitOfWorkType compatibility
        if (reportCreatorError && IsEditableType(targetInfo.ObjectType))
                reportCreatorError = false;

        // check criteria compatibility
        if (uowProp.TargetCriteria == string.Empty)
            continue;

        Criteria targetCrit = targetInfo.CriteriaObjects.Find(uowProp.TargetCriteria);
        bool isGetter = ForceIsGetter(Info, uowProp);

        Criteria crit = GetCriteriaObjects(Info)[0];
        bool foundMatchingCriteria = false;
        if ((crit.IsCreator && !isGetter) ||
            (crit.IsGetter && isGetter) ||
            (crit.IsDeleter && Info.IsDeleter))
        {
            typeOfCriteria += crit.IsCreator ? "Create" : "";
            typeOfCriteria += crit.IsGetter ? "Get" : "";
            typeOfCriteria += crit.IsDeleter ? "Delete" : "";
            if (targetCrit.Properties.Count > crit.Properties.Count)
                foundMatchingCriteria = false;
            //if (crit.Properties.Count == 0)
            //    continue;
            if (CheckTargetPropertiesFound(Info, uowProp, crit))
                foundMatchingCriteria = true;
            if (!foundMatchingCriteria)
            {
                Warnings.Append(Info.ObjectName + "." + uowProp.Name + ": " + typeOfCriteria + " criteria " + crit.Name +
                    " doesn't match target criteria " + uowProp.TargetCriteria + "." + Environment.NewLine);
            }
        }
    }
    
    if (reportCreatorError)
    {
        Errors.Append(Info.ObjectName + ": no editable target object found. \"Unit of Work Type\" must be \"Getter\"." + Environment.NewLine);
        return;
    }
}
%>
