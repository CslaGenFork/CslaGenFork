        private <%= Info.ObjectName %>Dto Fetch(IDataReader data)
        {
            var <%= FormatCamel(Info.ObjectName) %> = new <%= Info.ObjectName %>Dto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
            <%
foreach (ValueProperty prop in Info.GetAllValueProperties())
{
    if (prop.IsDatabaseBound &&
        prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
        prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
    {
        try
        {
            %>
                    <%= FormatCamel(Info.ObjectName) %>.<%= FormatProperty(prop) %> = <%= GetDataReaderStatement(prop) %>;
                    <%
        }
        catch (Exception ex)
        {
            Errors.Append(ex.Message + Environment.NewLine);
        }
    }
}
%>
                }
                <%
if (ParentLoadsChildren(Info))
{
    %>
                FetchChildren(dr);
                <%
}
%>
            }
            return <%= FormatCamel(Info.ObjectName) %>;
        }
