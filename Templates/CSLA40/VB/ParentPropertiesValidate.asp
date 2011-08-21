<%
// Only check objects with a ParentType
if (!Info.ParentType.Equals(String.Empty))
{
    List<string> propNames = new List<string>();
    CslaObjectInfo parent = Info.FindParent(Info);
    foreach (ValueProperty valProp in Info.ValueProperties)
    {
        if (!string.IsNullOrEmpty(valProp.DbBindColumn.ColumnName))
        {
            string nameTypeMatch = PropertyNameMatchesParentProperty(parent, Info, valProp);
            string fkMatch = PropertyFKMatchesParentProperty(parent, Info, valProp);

            if (string.IsNullOrEmpty(nameTypeMatch) && string.IsNullOrEmpty(fkMatch))
                continue;
            else
            {
                if (!string.IsNullOrEmpty(nameTypeMatch))
                {
                    propNames.Add(valProp.Name);// make sure there is at least one item
                    propNames[0] = valProp.Name;// make sure this is the first item
                }
                else if (CslaTemplateHelperCS.MultiplePropertyFKMatchesParent(parent, Info, valProp))
                    continue;
                else
                    propNames.Add(valProp.Name);// make sure there is at least one item
            }
        }
    }

    if (propNames.Count > 0)
        Warnings.AppendFormat("{0}.{1} matches a Parent Property and should be excluded from {0} Value Properties.\r\n", Info.ObjectName, propNames[0]);
}
%>