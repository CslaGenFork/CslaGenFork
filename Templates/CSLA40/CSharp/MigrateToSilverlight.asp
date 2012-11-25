<%
int counterAutoProperty = 0;
int counterClassicProperty = 0;
int counterClassicPropertyWithTypeConversion = 0;
int counterNoProperty = 0;
int counterCriteria = 0;

foreach (ValueProperty prop in Info.ValueProperties)
{
    if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
    {
        prop.DeclarationMode = PropertyDeclaration.Managed;
        counterAutoProperty++;
    }
    else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
    {
        prop.DeclarationMode = PropertyDeclaration.Managed;
        counterClassicProperty++;
    }
    else if (prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
    {
        prop.DeclarationMode = PropertyDeclaration.ManagedWithTypeConversion;
        counterClassicPropertyWithTypeConversion++;
    }
    else if (prop.DeclarationMode == PropertyDeclaration.NoProperty)
    {
        prop.DeclarationMode = PropertyDeclaration.Managed;
        counterNoProperty++;
    }
}

foreach (Criteria criteria in Info.CriteriaObjects)
{
    if (criteria.Properties.Count > 1)
    {
        if (criteria.CriteriaClassMode == CriteriaMode.Simple)
        {
            bool nested = criteria.NestedClass;
            criteria.CriteriaClassMode = CriteriaMode.CriteriaBase;
            criteria.NestedClass = nested;
            counterCriteria++;
        }
    }
}
    
if (counterAutoProperty >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counterAutoProperty + " \"PropertyDeclaration.AutoProperty\" properties." + Environment.NewLine);
if (counterClassicProperty >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counterClassicProperty + " \"PropertyDeclaration.ClassicProperty\" properties." + Environment.NewLine);
if (counterClassicPropertyWithTypeConversion >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counterClassicPropertyWithTypeConversion + " \"PropertyDeclaration.ClassicPropertyWithTypeConversion\" properties." + Environment.NewLine);
if (counterNoProperty >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counterNoProperty + " \"PropertyDeclaration.NoProperty\" properties." + Environment.NewLine);
if (counterCriteria >0)
    Warnings.Append(Info.ObjectName + ": migrated " + counterCriteria + " \"CriteriaMode.Simple\" criteria." + Environment.NewLine);
%>