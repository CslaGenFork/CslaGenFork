<%
// COnly check objects with a ParentType
if (!Info.ParentType.Equals(String.Empty))
{
    foreach (Property prop in Info.ParentProperties)
    {
        foreach (ValueProperty valProp in Info.GetAllValueProperties())
        {
            if (valProp.Name == prop.Name && valProp.PropertyType == prop.PropertyType)
            {
                Warnings.AppendFormat("{0}.{1} matches a Parent Property and should be excluded from {0} Value Properties.\r\n", Info.ObjectName, prop.Name);
                break;
            }
        }
    }
}
%>