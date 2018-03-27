<%
if (Info.GenerateConstructor)
{
    bool dependentAllowNew2 = false;
    bool dependentAllowEdit2 = false;
    bool dependentAllowRemove2 = false;
    if (!TypeHelper.IsReadOnlyType(Info.ObjectType) && TypeHelper.IsCollectionType(Info.ObjectType))
    {
        if ((CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel) &&
            ((itemInfo.NewRoles.Trim() != String.Empty) ||
            (itemInfo.UpdateRoles.Trim() != String.Empty) ||
            (itemInfo.DeleteRoles.Trim() != String.Empty)))
        {
            if (Info.AllowNew && itemInfo.NewRoles.Trim() != String.Empty)
                dependentAllowNew2 = true;
            if (Info.AllowEdit && itemInfo.UpdateRoles.Trim() != String.Empty)
                dependentAllowEdit2 = true;
            if (Info.AllowRemove && itemInfo.DeleteRoles.Trim() != String.Empty)
                dependentAllowRemove2 = true;
        }
    }
    %>
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="<%= Info.GenericNameXml %>"/> class.
        /// </summary>
        /// <remarks> Do not use to create a <%= Info.IsUnitOfWork() ? "Unit of Work" : "Csla object" %>. Use factory methods instead.</remarks>
<%
    if (UseBoth())
    {
        %>
#if SILVERLIGHT
<%
    }
    if (UseSilverlight())
    {
        %>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public <%= Info.ObjectName %>()
<%
    }
    if (UseBoth()) // check there is a fetch
    {
        %>
#else
<%
    }
    if (UseNoSilverlight())
    {
        string ctorVisibility = GetConstructorVisibility(Info);

        if (ctorVisibility == "public")
        {
            %>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
<%
        }
        %>
        <%= ctorVisibility %> <%= Info.ObjectName %>()
<%
    }
    if (UseBoth())
    {
        %>
#endif
<%
    }
    %>
        {
            // Use factory methods and do not use direct creation.
            <%
    if (Info.SupportUpdateProperties || hasFactoryCache || hasDataPortalCache)
    {
        %>
            Saved += On<%= Info.ObjectName %>Saved;
            <%
    }
    if (Info.SupportUpdateProperties && (hasFactoryCache || hasDataPortalCache))
    {
        %>
            <%= Info.ObjectName %>Saved += <%= Info.ObjectName %>SavedHandler;
<%
    }
    if (Info.IsReadOnlyCollection())
    {
        if (Info.UpdaterType != string.Empty)
        {
            CslaObjectInfo childInfo4 = FindChildInfo(Info, Info.ItemType);
            if (childInfo4.UpdateValueProperties.Count > 0)
            {
                %>
            <%= Info.UpdaterType %>Saved.Register(this);
            <%
            }
        }
    }
    if (Info.IsEditableChild() ||
        Info.IsEditableChildCollection())
    {
        %>

            // show the framework that this is a child object
            MarkAsChild();
            <%
    }
    //if (Info.IsEditableChildCollection() ||
    //    Info.IsEditableRootCollection() ||
    //    Info.IsDynamicEditableRootCollection() ||
    //    Info.IsReadOnlyCollection())
    if (TypeHelper.IsCollectionType(Info.ObjectType))
    {
        %>

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = <%= dependentAllowNew2 ? Info + ".CanAddObject()" : Info.AllowNew.ToString().ToLower() %>;
            AllowEdit = <%= dependentAllowEdit2 ? Info + ".CanEditObject()" : Info.AllowEdit.ToString().ToLower() %>;
            AllowRemove = <%= dependentAllowRemove2 ? Info + ".CanDeleteObject()" : Info.AllowRemove.ToString().ToLower() %>;
            RaiseListChangedEvents = rlce;
        <%
    }
    foreach (ChildProperty prop in Info.GetMyChildProperties())
    {
        CslaObjectInfo _child = FindChildInfo(Info, prop.TypeName);
        if (_child == null)
        {
            Warnings.Append("TypeName '" + prop.TypeName + "' doesn't exist in this project." + Environment.NewLine);
        }
    }
    %>
        }

        #endregion
<%
}
%>
