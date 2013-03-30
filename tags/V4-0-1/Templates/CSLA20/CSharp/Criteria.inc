<% if (Info.CriteriaObjects.Count > 0) { %>

        #region Criteria

         <%
         foreach (Criteria crit in Info.CriteriaObjects) {
            String strParams = String.Empty;
            String strFieldAssignments = String.Empty;
            // Temporary until Rocky provides a Fetch that can take no criteria
            // if (crit.Properties.Count > 0 ) { %>
        [Serializable()]
        protected class <%=crit.Name%>
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable) {
                strParams = "bool isChild";
                strFieldAssignments = "  _isChild = isChild;";
            %>
            private bool _isChild;

            public bool IsChild
            {
                get
                {
                    return _isChild;
                }
            }
            <%
            }
            foreach (CslaGenerator.Metadata.Property prop in crit.Properties) { %>
            private <%=GetDataType(prop)%> <%=FormatFieldName(prop.Name)%>;

            public <%=GetDataType(prop)%> <%=FormatPascal(prop.Name)%>
            {
                get
                {
                    return <%=FormatFieldName(prop.Name)%>;
                }
            }

            <%

            // Just creating strings for later use in the constructors in order to avoid another loop
            if (strParams.Length > 0) {
                strParams += ", ";
            }
            strParams += string.Concat(GetDataType(prop), " ", FormatCamel(prop.Name));
            strFieldAssignments += string.Concat("\r\n                ", FormatFieldName(prop.Name), " = ", FormatCamel(prop.Name), ";");
            %>
            <% } %>
            public <%=crit.Name%>(<%= strParams %>)
            {
                <% if (strFieldAssignments.Length > 1) { %>
<%=strFieldAssignments.Substring(2)%>
                <% } %>
            }

            public override bool Equals(object obj)
            {
                if (obj is <%=crit.Name%>)
                {
                    <%=crit.Name%> c = (<%=crit.Name%>) obj;
                    <% foreach (CriteriaProperty p in crit.Properties) { %>
                    if (!<%=FormatFieldName(p.Name)%>.Equals(c.<%=FormatFieldName(p.Name)%>))
                        return false;
                    <% } %>
                    return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return string.Concat("<%=crit.Name%>"<% foreach (CriteriaProperty p in crit.Properties) { %>, <%=FormatFieldName(p.Name)%>.ToString()<% } %>).GetHashCode();
            }
        }

         <%
        } %>
        #endregion
<% } %>
