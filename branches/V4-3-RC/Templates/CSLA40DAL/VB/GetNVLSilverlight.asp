<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    if (!Info.UseCustomLoading)
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.GetOptions.Factory)
            {
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                    {
                        Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Add it or remove the Criteria Property." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        c.Properties[i].ReadOnly = true;
                    }
                }
                %>

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
                string critSilverlight = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                    {
                        Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Add it or remove the Criteria Property." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        c.Properties[i].ReadOnly = true;
                    }
                }
                if (c.Properties.Count > 1)
                    critSilverlight = "new " + c.Name + "()";
                else if (c.Properties.Count > 0)
                    critSilverlight = SendSingleCriteria(c, c.Properties[0].ParameterValue);
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                    critSilverlight += (critSilverlight.Length > 0 ? ", " : "") + "(o, e) =>";
                else
                    critSilverlight += (critSilverlight.Length > 0 ? ", " : "");
                %>
        /// <param name="callback">The completion callback method.</param>
        public static void Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback" %>)
        {
            <%
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                    Info.GetRoles.Trim() != String.Empty)
                {
                    %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
                }
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    %>if (_list == null)
                DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= critSilverlight %>
                    {
                        _list = e.Object;
                        callback(o, e);
                    }, DataPortal.ProxyModes.LocalOnly);
            else
                callback(null, new DataPortalResult<<%= Info.ObjectName %>>(_list, null, null));<%
                }
                else
                {
                    %>DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= critSilverlight %>callback, DataPortal.ProxyModes.LocalOnly);<%
                }
                %>
        }
<%
            }
        }
    }
}
%>
