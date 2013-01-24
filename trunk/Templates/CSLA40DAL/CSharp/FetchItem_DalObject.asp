        private <%= Info.ItemType %>Dto Fetch(SafeDataReader dr)
        {
            var <%= FormatCamel(Info.ItemType) %> = new <%= Info.ItemType %>Dto();
            // Value properties
            <%
foreach (ValueProperty prop in itemInfo.GetAllValueProperties())
{
    if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
        prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
    {
        try
        {
            %>
            <%= FormatCamel(Info.ItemType) %>.<%= FormatProperty(prop) %> = <%= GetDataReaderStatement(prop) %>;
            <%
        }
        catch (Exception ex)
        {
            Errors.Append(ex.Message + Environment.NewLine);
        }
    }
}

// parent loading field
bool useFieldForParentLoading = (((ancestorLoaderLevel > 2 && !ancestorIsCollection) ||
    (ancestorLoaderLevel > 1 && ancestorIsCollection)) && Info.ParentProperties.Count > 0);
if (useFieldForParentLoading)
{
    %>
            // parent properties
            <%
    foreach(Property prop in Info.ParentProperties)
    {
        %>
            <%= FormatCamel(Info.ItemType) %>.<%= FormatCamel(GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop)) %> = dr.<%= GetReaderMethod(prop.PropertyType) %>("<%= GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop) %>");
            <%
    }
}
%>

            return <%= FormatCamel(Info.ItemType) %>;
        }
