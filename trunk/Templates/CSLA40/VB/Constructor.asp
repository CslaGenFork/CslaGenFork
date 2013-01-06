<%
bool dependentAllowNew2 = false;
bool dependentAllowEdit2 = false;
bool dependentAllowRemove2 = false;
if (!IsReadOnlyType(Info.ObjectType) && IsCollectionType(Info.ObjectType))
{
    CslaObjectInfo itemInfo2 = FindChildInfo(Info, Info.ItemType);
    if ((CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel) &&
        ((itemInfo2.NewRoles.Trim() != String.Empty) ||
        (itemInfo2.UpdateRoles.Trim() != String.Empty) ||
        (itemInfo2.DeleteRoles.Trim() != String.Empty)))
    {
        if (Info.AllowNew && itemInfo2.NewRoles.Trim() != String.Empty)
            dependentAllowNew2 = true;
        if (Info.AllowEdit && itemInfo2.UpdateRoles.Trim() != String.Empty)
            dependentAllowEdit2 = true;
        if (Info.AllowRemove && itemInfo2.DeleteRoles.Trim() != String.Empty)
            dependentAllowRemove2 = true;
    }
}
%>
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="<%= Info.ObjectName %>"/> class.
        /// </summary>
        /// <remarks> Do not use to create a <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "Unit of Work" : "Csla object" %>. Use factory methods instead.</remarks>
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
    string ctorVisibility = string.Empty;
    if (Info.ConstructorVisibility == ConstructorVisibility.Default &&
        Info.ObjectType == CslaObjectType.ReadOnlyCollection &&
        Info.ParentType != string.Empty &&
        ancestorLoaderLevel > 1)
        ctorVisibility = "internal";
    else
        ctorVisibility = GetConstructorVisibility(Info);

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
            // Prevent direct creation
            <%
if (hasFactoryCache || hasDataPortalCache)
{
    %>
            this.Saved += <%= Info.ObjectName %>_Saved;
            <%
}
if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
{
    if (Info.UpdaterType != string.Empty)
    {
        CslaObjectInfo childInfo4 = FindChildInfo(Info, Info.ItemType);
        if (childInfo4.UpdateValueProperties.Count > 0)
        {
            %>
            <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved += <%= Info.UpdaterType %>SavedHandler;
                    <%
        }
    }
}
if (Info.ObjectType == CslaObjectType.EditableChild ||
    Info.ObjectType == CslaObjectType.EditableChildCollection)
{
    %>

            // show the framework that this is a child object
            MarkAsChild();
            <%
}
//if (Info.ObjectType == CslaObjectType.EditableChildCollection ||
//    Info.ObjectType == CslaObjectType.EditableRootCollection ||
//    Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
//    Info.ObjectType == CslaObjectType.ReadOnlyCollection)
if (IsCollectionType(Info.ObjectType))
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
