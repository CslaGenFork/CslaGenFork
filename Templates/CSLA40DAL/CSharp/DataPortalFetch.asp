<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal)
        {
            //string strGetCritParams = string.Empty;
            string strGetInvokeParams = string.Empty;
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            if (usesDalCriteria)
            {
                foreach (Property p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        //strGetCritParams += ", ";
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

                    TypeCodeEx propType = p.PropertyType;

                    //strGetCritParams += p.Name;
                    strGetInvokeParams += "crit." + FormatPascal(p.Name);
                    strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }

                /*if (c.Properties.Count > 1)
                {
                    strGetCritParams = "new " + c.Name + "(" + strGetCritParams + ")";
                }
                else if (c.Properties.Count > 0)
                {
                    strGetCritParams = SendSingleCriteria(c, strGetCritParams);
                }*/
            }
            else
            {
                foreach (Property p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        //strGetCritParams += ", ";
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

                    TypeCodeEx propType = p.PropertyType;

                    //strGetCritParams += string.Concat(GetDataTypeGeneric(p, propType), " ", FormatCamel(p.Name));
                    strGetInvokeParams += "crit." + FormatPascal(p.Name);
                    strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }
            }
            if (c.Properties.Count > 1)
                strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
            else if (c.Properties.Count == 1)
                strGetInvokeParams = FormatCamel(c.Properties[0].Name);
            %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %><%= strGetComment %>
        <%
            }
            if (c.GetOptions.RunLocal)
            {
                %>[Csla.RunLocal]
        <%
            }
            if (c.Properties.Count > 1)
            {
        %>protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
        %>protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
        %>protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch()<%
            }
        %>
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                %>
            if (crit.IsChild)
                MarkAsChild();
            <%
            }
            string hookArgs = string.Empty;
            if (c.Properties.Count > 1)
            {
                hookArgs = "crit";
            }
            else if (c.Properties.Count > 0)
            {
                hookArgs = HookSingleCriteria(c, "crit");
            }
            %>
            var args = new DataPortalHookArgs(<%= hookArgs %>);
            OnFetchPre(args);
            using (var dalManager = DalFactory<%= GetConnectionName(CurrentUnit) %>.GetManager())
            {
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                var data = dal.Fetch(<%= strGetInvokeParams %>);
                Fetch(data);
            }
            OnFetchPost(args);
            <%
            if (SelfLoadsChildren(Info))
            {
                %>
            FetchChildren();
        }
        <%
            }
            else
            {
        %>
        }
        <%
            }
        }
    }
    if (Info.HasGetCriteria)
    {
        %>

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    <%
        if (ParentLoadsChildren(Info))
        {
            %>
                    FetchChildren(dr);
                    <%
        }
        %>
                }
                <%
        if (Info.CheckRulesOnFetch)
        {
            %>
                BusinessRules.CheckRules();
                <%
        }
        %>
            }
        }
        <%
    }
    %>
<!-- #include file="InternalDataPortalFetch.asp" -->
<%
}
%>
