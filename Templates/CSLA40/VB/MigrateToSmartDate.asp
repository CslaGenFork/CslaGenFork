<%
int counter = 0;

foreach (ValueProperty prop in Info.ValueProperties)
{
    if (prop.PropertyType == TypeCodeEx.DateTime)
    {
        prop.PropertyType = TypeCodeEx.SmartDate;
        counter++;
    }
}
    
if (counter >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counter + " \"DateTime\" properties." + Environment.NewLine);
%>