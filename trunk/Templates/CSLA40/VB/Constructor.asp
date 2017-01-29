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
        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="<%= Info.ObjectName %>"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a <%= Info.IsUnitOfWork() ? "Unit of Work" : "Csla object" %>. Use factory methods instead.</remarks>
<%
    if (UseBoth())
    {
        %>
#If SILVERLIGHT Then
<%
    }
    if (UseSilverlight())
    {
        %>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
<%
    }
    if (UseBoth()) // check there is a fetch
    {
        %>
#Else
<%
    }
    if (UseNoSilverlight())
    {
        string ctorVisibility = GetConstructorVisibility(Info);

        if (ctorVisibility == "Public")
        {
            %>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
<%
        }
        %>
        <%= ctorVisibility %> Sub New()
<%
    }
    if (UseBoth())
    {
        %>
#End If
<%
    }
    %>
            ' Use factory methods and do not use direct creation.
            <%
    if (Info.SupportUpdateProperties || hasFactoryCache || hasDataPortalCache)
    {
        %>
            AddHandler Saved, AddressOf On<%= Info.ObjectName %>Saved
            <%
    }
    if (Info.SupportUpdateProperties && (hasFactoryCache || hasDataPortalCache))
    {
        %>
            AddHandler <%= Info.ObjectName %>Saved, AddressOf <%= Info.ObjectName %>SavedHandler
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
            AddHandler <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved, AddressOf <%= Info.UpdaterType %>SavedHandler
            <%
            }
        }
    }
    if (Info.IsEditableChild() ||
        Info.IsEditableChildCollection())
    {
        %>

            ' show the framework that this is a child object
            MarkAsChild()
            <%
    }
    //if (Info.IsEditableChildCollection() ||
    //    Info.IsEditableRootCollection() ||
    //    Info.IsDynamicEditableRootCollection() ||
    //    Info.IsReadOnlyCollection())
    if (TypeHelper.IsCollectionType(Info.ObjectType))
    {
        %>

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = <%= dependentAllowNew2 ? Info + ".CanAddObject()" : Info.AllowNew.ToString() %>
            AllowEdit = <%= dependentAllowEdit2 ? Info + ".CanEditObject()" : Info.AllowEdit.ToString() %>
            AllowRemove = <%= dependentAllowRemove2 ? Info + ".CanDeleteObject()" : Info.AllowRemove.ToString() %>
            RaiseListChangedEvents = rlce
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
        End Sub

        #End Region
<%
}
%>
