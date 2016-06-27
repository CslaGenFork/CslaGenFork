<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.Factory)
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
            {
                %>

        /// <summary>
        /// Factory method. Deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        /// </summary>
        /// <param name="crit">The delete criteria.</param>
        public static <%= Info.ObjectName %> Delete<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= c.Name %> crit)
        {
            DataPortal.Delete<<%= Info.ObjectName %>>(crit);
        }
        <%
            }
            %>

        /// <summary>
        /// Factory method. Deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        /// </summary>
<%
            string strDelParams = string.Empty;
            string strDelCritParams = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to delete.</param>
        <%
                if (i > 0)
                {
                    strDelParams += ", ";
                    strDelCritParams += ", ";
                }
                strDelParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                strDelCritParams += FormatCamel(c.Properties[i].Name);
            }
            %>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void Delete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
        {
            <%
            if (Info.IsEditableSwitchable())
            {
                if (!strDelCritParams.Equals(String.Empty))
                {
                    strDelCritParams = ", " + strDelCritParams;
                }
                strDelCritParams = "false" + strDelCritParams;
            }
            if (c.Properties.Count > 1)
            {
                %>DataPortal.Delete<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strDelCritParams %>));<%
            }
            else if (c.Properties.Count > 0)
            {
                %>DataPortal.Delete<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strDelCritParams) %>);<%
            }
            else
            {
                %>DataPortal.Delete(new <%= c.Name %>(<%= strDelCritParams %>));<%
            }
            %>
        }
<%
            if (isUndeletable == true)
            {
                %>

        /// <summary>
        /// Factory method. Undeletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        /// </summary>
<%
                strDelParams = string.Empty;
                strDelCritParams = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to undelete.</param>
        <%
                    if (i > 0)
                    {
                        strDelParams += ", ";
                        strDelCritParams += ", ";
                    }
                    strDelParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    strDelCritParams += FormatCamel(c.Properties[i].Name);
                }
                %>
        /// <returns>A reference to the undeleted <see cref="<%= Info.ObjectName %>"/> object.</returns>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static <%= Info.ObjectName %> Undelete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
        {
            <%
                if (Info.IsEditableSwitchable())
                {
                    if (!strDelCritParams.Equals(String.Empty))
                    {
                        strDelCritParams = ", " + strDelCritParams;
                    }
                    strDelCritParams = "false" + strDelCritParams;
                }
                if (c.Properties.Count > 1)
                {
                    %>var obj = DataPortal.Fetch<<%= Info.ObjectName %>>(<%= strDelCritParams %>);<%
                }
                else if (c.Properties.Count > 0)
                {
                    %>var obj = DataPortal.Fetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strDelCritParams) %>);<%
                }
            %>
            obj.<%= softDeleteProperty %> = true;
            return obj.Save();
        }
<%
            }
        }
    }
}
%>
