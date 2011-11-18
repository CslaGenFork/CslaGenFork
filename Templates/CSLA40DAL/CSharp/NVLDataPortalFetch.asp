<%
if (!Info.UseCustomLoading && (UseNoSilverlight() ||
    CurrentUnit.GenerationParams.GenerateSilverlight4))
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal)
        {
            %>

        /// <summary>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void DataPortal_Fetch(<%= c.Name %> crit)
        {
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        protected void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
            }
            else
            {
                %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= Info.SimpleCacheOptions == SimpleCacheResults.DataPortal ? " or from the cache" : "" %>.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            <%
                if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal)
                {
                    %>
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            <%
                }
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
                var data = dal.Fetch(<%= hookArgs %>);
                LoadCollection(data);
            }
            OnFetchPost(args);
        }
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
        <%
        }
    }
    %>

        private void LoadCollection(IDataReader data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    Add(new NameValuePair(
                        <%= String.Format(GetDataReaderStatement(valueProp)) %>,
                        <%= String.Format(GetDataReaderStatement(nameProp)) %>));
                }
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }
    <%
}
%>
