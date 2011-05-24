<%
if (CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>

        /// <summary>
        /// Factory method. Loads an existing <see cref="<%= Info.ObjectName %>"/> object from the database.
        /// </summary>
        <%
                    //string strGetParams = string.Empty;
                    //string strGetCritParams = string.Empty;
                    string critSilverlight = string.Empty;
                    for (int i = 0; i < c.Properties.Count; i++)
                    {
                        if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                        {
                            Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Ignored." + Environment.NewLine);
                            return;
                        }
                        else
                        {
                            c.Properties[i].ReadOnly = true;
                        }
                        if (i > 0)
                        {
                            //strGetParams += ", ";
                            //strGetCritParams += ", ";
                        }
                        //strGetParams += string.Concat(GetDataType(c.Properties[i]), " ", FormatCamel(c.Properties[i].Name));
                        //strGetCritParams += FormatCamel(c.Properties[i].Name);
                    }
                    if (c.Properties.Count > 1)
                        critSilverlight = "new " + c.Name + "()";
                    else if (c.Properties.Count > 0)
                        critSilverlight = SendSingleCriteria(c, c.Properties[0].ParameterValue);
        %>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        public static <%= Info.ObjectName %> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>()
        {
            <%
                    if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
                        CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
                        Info.GetRoles.Trim() != String.Empty)
                    {
                        %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
                    }
                    if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                    {
                        %>if (_list == null)
                return _list;

            return new <%= Info.ObjectName %>();
            <%
                    }
                    else
                    {
                        %>
            return DataPortal.Fetch<<%= Info.ObjectName %>>(<%= critSilverlight %>);
            <%
                    }
                    %>
        }
<%
}
%>
