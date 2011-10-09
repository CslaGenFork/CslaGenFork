
        private void CreateRelations(DataSet ds)
        {
            <%
<script runat="template">
public string GetDSRelations(CslaObjectInfo info)
{
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    foreach (CslaObjectInfo item in GetChildItems(info))
    {
        if (item.ParentProperties.Count > 0)
        {
            sb.Append("            ds.Relations.Add(\"");
            sb.Append(info.ObjectName);
            sb.Append(item.ObjectName);
            sb.Append("\", new DataColumn[] {");
            int i = 0;
            foreach (CslaGenerator.Metadata.Property prop in item.ParentProperties)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append("ds.Tables[\"");
                sb.Append(info.ObjectName);
                sb.Append("\"].Columns[\"");
                sb.Append(prop.Name);
                sb.Append("\"]");
                i++;
            }
            i = 0;
            sb.Append("}, new DataColumn[] {");
            foreach (CslaGenerator.Metadata.Property prop in item.ParentProperties)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append("ds.Tables[\"");
                sb.Append(item.ObjectName);
                sb.Append("\"].Columns[\"");
                sb.Append(prop.Name);
                sb.Append("\"]");
                i++;
            }
            sb.Append("}, false);");
            sb.AppendLine();
            sb.Append(GetDSRelations(item));
        }
    }
    return sb.ToString();
}
</script>
%>
            <%
            CslaObjectInfo obj;
            if (IsCollectionType(Info.ObjectType))
                obj = FindChildInfo(Info, Info.ItemType);
            else
                obj = Info;
            if (obj != null)
            {
                string[] objectNames = GetAllChildItemsInHierarchy(obj);
                %>
            ds.Tables[0].TableName = "<%=obj.ObjectName%>";
            <%
                for (int i = 0; i < objectNames.Length; i++)
                {
                    %>
            ds.Tables[<%=(i+1).ToString()%>].TableName = "<%=objectNames[i]%>";
            <%
                }
                %>
<%=GetDSRelations(obj)%><%
            }
            %>
        }
