<%
foreach (Criteria c in Info.CriteriaObjects) {
    if (c.DeleteOptions.Factory) { %>

        /// <summary>
        /// Marks the <see cref="<%=Info.ObjectName%>" /> Object for deletion. The Object will be deleted as part of the next save operation.
        /// </summary><%
                string strDelParams = string.Empty;
                string strDelCritParams = string.Empty;
                string UpdateEventString_Delete = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++) {
                    if (i > 0) {
                        strDelParams += ", ";
                        strDelCritParams += ", ";
                    }
                    strDelParams += string.Concat(GetDataType(c.Properties[i]), " ", FormatCamel(c.Properties[i].Name));
                    strDelCritParams += FormatCamel(c.Properties[i].Name);
                }
                if (c.Properties.Count > 1)
                    UpdateEventString_Delete = "new object() {" + strDelCritParams + "}";
                else
                    UpdateEventString_Delete = strDelCritParams;
    %>
        public static void Delete<%=Info.ObjectName%><%=c.DeleteOptions.FactorySuffix.Trim()%>(<%=strDelParams %>)
        {
        <% if(Info.DeleteRoles != String.Empty) { %>
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a <%= Info.ObjectName %>");
        <% } %>
            <%     if (Info.ObjectType == CslaObjectType.EditableSwitchable) {
                        if (!strDelCritParams.Equals(String.Empty)) {
                            strDelCritParams = ", " + strDelCritParams;
                        }
                        strDelCritParams = "false" + strDelCritParams;
                    }
                %>
            <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Delete(new <%=c.Name %>(<%=strDelCritParams %>));
            <% if (ActiveObjects) {
                if (Info.PublishToChannel.Length > 0) { %>
            Observer.EventChannels.Publish("<%= Info.PublishToChannel %>", null, BusinessEvents.Deleted, <%= UpdateEventString_Delete %>);
            <%     }
               } %>
        }
<%    }
} %>
