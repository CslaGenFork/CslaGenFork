<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    List<string> createPartialMethods = new List<string>();
    List<string> createPartialParams = new List<string>();
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.CreateOptions.DataPortal)
        {
            %>

        /// <summary>
        /// Loads default values for the <see cref="<%= Info.ObjectName %>"/> object properties<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                createPartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The create criteria.</param>");
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The create criteria.</param>
        <%
            }
            else
            {
                createPartialParams.Add("");
            }
            %>
        [Csla.RunLocal]
        <%
            if (c.Properties.Count > 1)
            {
                createPartialMethods.Add("partial void Service_Create(" + c.Name + " crit)");
                %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Create(<%= c.Name %> crit)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                createPartialMethods.Add("partial void Service_Create(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Create(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
            }
            else
            {
                createPartialMethods.Add("partial void Service_Create()");
                %>
        protected <%= isChildNotLazyLoaded ? "override void Child_" : "override void DataPortal_" %>Create()
        <%
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
            foreach (ValueProperty prop in Info.ValueProperties)
            {
                if (prop.DefaultValue != String.Empty)
                {
                    if (prop.DefaultValue.ToUpper() == "_lastID".ToUpper() &&
                        prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK &&
                        (prop.PropertyType == TypeCodeEx.Int16 ||
                        prop.PropertyType == TypeCodeEx.Int32 ||
                        prop.PropertyType == TypeCodeEx.Int64))
                    {
                        %>
            <%= GetFieldLoaderStatement(prop, "System.Threading.Interlocked.Decrement(ref " + prop.DefaultValue.Trim() + ")") %>;
            <%
                    }
                    else
                    {
                        %>
            <%= GetFieldLoaderStatement(Info, prop, prop.DefaultValue) %>;
            <%
                    }
                }
                else if (prop.Nullable && prop.PropertyType == TypeCodeEx.String)
                {
                    %>
            <%= GetFieldLoaderStatement(Info, prop, "null") %>;
            <%
                }
            }
            ValuePropertyCollection valProps = Info.GetAllValueProperties();
            foreach (CriteriaProperty p in c.Properties)
            {
                if (valProps.Contains(p.Name))
                {
                    ValueProperty prop = valProps.Find(p.Name);
                    if (c.Properties.Count > 1)
                    {
                        %>
            <%= GetFieldLoaderStatement(prop, "crit." + FormatProperty(p.Name)) %>;
            <%
                    }
                    else
                    {
                        %>
            <%= GetFieldLoaderStatement(prop, AssignSingleCriteria(c, "crit")) %>;
            <%
                    }
                }
            }
            foreach (ChildProperty childProp in Info.GetAllChildProperties())
            {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null)
                {
                    if (IsEditableType(_child.ObjectType) &&
                        (childProp.LoadingScheme == LoadingScheme.ParentLoad || !childProp.LazyLoad))
                    {
                        %>
            <%= GetNewChildLoadStatement(childProp, true) %>;
            <%
                    }
                }
            }
            if (c.Properties.Count > 1)
            {
                %>
            Service_Create(crit);
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            Service_Create(<%= HookSingleCriteria(c, "crit") %>);
            <%
            }
            else
            {
                %>
            Service_Create();
            <%
            }
            %>
            base.<%= isChildNotLazyLoaded ? "Child_Create()" : "DataPortal_Create()" %>;
        }
<%
        }
    }
    for (int index = 0; index < createPartialMethods.Count ; index++)
    {
        string header = createPartialParams[index] + (string.IsNullOrEmpty(createPartialParams[index]) ? "" : "\r\n        ");
        header += createPartialMethods[index];
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Create" : "DataPortal_Create", header));
    %>

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Create" : "DataPortal_Create" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>;
<%
    }
}
%>
