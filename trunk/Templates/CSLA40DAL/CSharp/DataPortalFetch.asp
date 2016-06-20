<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
            string strGetInvokeParams = string.Empty;
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            if (usesDTO)
            {
                if (c.Properties.Count == 1)
                    strGetComment = "/// <param name=\"" + FormatCamel(c.Properties[0].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[0].Name) + ".</param>";
                if (c.Properties.Count > 1)
                    strGetInvokeParams = SendMultipleCriteria(c, "crit");
            }
            else
            {
                foreach (CriteriaProperty p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

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
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch()<%
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
            using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
            {
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                var data = dal.Fetch(<%= strGetInvokeParams %>);
                Fetch(data);
                <%
            if (ParentLoadsChildren(Info) && usesDTO)
            {
                %>
                FetchChildren(dal);
            <%
            }
                %>
            }
            OnFetchPost(args);
            <%
            if (SelfLoadsChildren(Info))
            {
                %>
            FetchChildren();
        <%
            }
            if (Info.CheckRulesOnFetch && !Info.EditOnDemand && !IsCollectionType(Info.ObjectType))
            {
                %>
            // check all object rules and property rules
            BusinessRules.CheckRules();
            <%
            }
            %>
        }
        <%
        }
    }
    if (Info.HasGetCriteria && !usesDTO)
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
            }
        }
        <%
    }
    %>
<!-- #include file="InternalDataPortalFetch.asp" -->
<%
}
%>
