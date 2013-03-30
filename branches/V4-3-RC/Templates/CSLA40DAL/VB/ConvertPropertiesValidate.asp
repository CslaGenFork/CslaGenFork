<%
int counter = 0;
foreach (ConvertValueProperty convertValueProperty in Info.ConvertValueProperties)
{
    counter ++;
    if (convertValueProperty.Name == string.Empty)
    {
        Errors.Append(Info.ObjectName + " converted property #" + counter + ": must specify property name." + Environment.NewLine);
        return;
    }
    if (convertValueProperty.SourcePropertyName == string.Empty)
    {
        Errors.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + ": must specify source property." + Environment.NewLine);
        return;
    }
    if (convertValueProperty.NVLConverter == string.Empty)
    {
        Errors.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + ": must specify NVL converter class." + Environment.NewLine);
        return;
    }

    ValueProperty sourceProperty = Info.ValueProperties.Find(convertValueProperty.SourcePropertyName);
    if (sourceProperty == null)
    {
        Errors.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + ": source property " + sourceProperty.Name + " was not found." + Environment.NewLine);
        return;
    }

    if (sourceProperty.DeclarationMode == PropertyDeclaration.AutoProperty)
    {
        Errors.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + ": source property " + sourceProperty.Name + " Declaration Mode can not be \"AutoProperty\"." + Environment.NewLine);
        return;
    }

    if (sourceProperty.Access < convertValueProperty.Access)
    {
        Warnings.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + " is less accessible than source property " + sourceProperty.Name + "." + Environment.NewLine);
    }
    if (!sourceProperty.ReadOnly && !convertValueProperty.ReadOnly &&
        ((sourceProperty.PropSetAccessibility != AccessorVisibility.Default && convertValueProperty.PropSetAccessibility != AccessorVisibility.Default) &&
        (sourceProperty.PropSetAccessibility < convertValueProperty.PropSetAccessibility)))
    {
        Warnings.Append(Info.ObjectName + " converted property " + convertValueProperty.Name + " setter is less accessible than source property " + sourceProperty.Name + " setter." + Environment.NewLine);
    }
}
%>