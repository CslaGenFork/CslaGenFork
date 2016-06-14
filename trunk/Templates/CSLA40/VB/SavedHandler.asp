<%
// Check if we are supposed to use the Updater or else skip over
if (Info.UpdaterType != string.Empty)
{
    string identityName = string.Empty;
    string identitySourceName = string.Empty;
    // Check if there is an item on this collection
    if (Info.ItemType == string.Empty)
    {
        Errors.Append(Info.ObjectType + " is missing ItemType property." + Environment.NewLine);
    }
    else
    {
        if (itemInfo == null)
        {
            Errors.Append("ItemType " + Info.ItemType + " doesn't exist." + Environment.NewLine);
        }
        else
        {
            identityName = string.Empty;
            // Is there something to update
            if (itemInfo.UpdateValueProperties.Count == 0)
            {
                Errors.Append("No UpdateValueProperties defined on " + itemInfo.ObjectName + "." + Environment.NewLine);
            }
        }
    }
    // Find the updater (we checked earlier that the property exists)
    CslaObjectInfo parentType2 = FindChildInfo(Info, Info.UpdaterType);
    if (parentType2 == null)
    {
        Errors.Append("UpdaterType " + Info.UpdaterType + " doesn't exist." + Environment.NewLine);
    }
    else
    {
        // Check the updater willing to update
        if (!parentType2.SupportUpdateProperties)
        {
            Errors.Append("SupportUpdateProperties is turned off in " + parentType2.ObjectName + "." + Environment.NewLine);
        }
    }
    // If all went well, find the Identity property
    if (Errors.Length == 0)
    {
        foreach (UpdateValueProperty vp in itemInfo.UpdateValueProperties)
        {
            if (vp.IsIdentity)
            {
                if (identityName != string.Empty)
                {
                    Errors.Append("IsIdentity is defined twice on UpdateValueProperties of " + itemInfo.ObjectName + "." + Environment.NewLine);
                }
                else
                {
                    identityName = vp.Name;
                    identitySourceName = vp.SourcePropertyName;
                }
            }
        }
        if (identityName == string.Empty)
        {
            Errors.Append("IsIdentity is not defined on UpdateValueProperties of " + itemInfo.ObjectName + "." + Environment.NewLine);
        }
    }
    if (Errors.Length == 0)
    {
        if (!genOptional)
        {
            Response.Write(Environment.NewLine);
        }
        genOptional = true;
        %>
        #Region " Saved Event Handler "

        ''' <summary>
        ''' Handle Saved events of <see cref="<%= Info.UpdaterType %>"/> to update the list of <see cref="<%= Info.ItemType %>"/> objects.
        ''' </summary>
        ''' <param name="sender">The sender of the event.</param>
        ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        Private Sub <%= Info.UpdaterType %>SavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            Dim obj = DirecCast(e.NewObject, <%= Info.UpdaterType %>)
            If DirecCast(sender, <%= Info.UpdaterType %>).IsNew Then
                IsReadOnly = False
                Dim rlce = RaiseListChangedEvents
                RaiseListChangedEvents = True
                Add(<%= Info.ItemType %>.LoadInfo(obj))
                RaiseListChangedEvents = rlce
                IsReadOnly = True
            ElseIf DirecCast(sender, <%= Info.UpdaterType %>).IsDeleted Then
                For index As Int = 0 To Me.Count - 1
                    Dim child = Me(index)
                    If child.<%= identityName %> = obj.<%= identitySourceName %> Then
                        IsReadOnly = False
                        Dim rlce = RaiseListChangedEvents
                        RaiseListChangedEvents = True
                        Me.RemoveItem(index)
                        RaiseListChangedEvents = rlce
                        IsReadOnly = True
                        Exit For
                    End If
                Next
            Else
                For index As Int = 0 To Me.Count - 1
                    Dim child = Me(index)
                    If child.<%= identityName %> = obj.<%= identitySourceName %> Then
                        child.UpdatePropertiesOnSaved(obj)
                        <%
if (CurrentUnit.GenerationParams.GenerateWPF)
{
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#If Not WINFORMS Then
<%
    }
    %>
                        Dim notifyCollectionChangedEventArgs As New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index)
                        OnCollectionChanged(notifyCollectionChangedEventArgs)
                        <%
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#Else
<%
    }
}
if (CurrentUnit.GenerationParams.GenerateWinForms)
{
    %>
                        Dim listChangedEventArgs As New ListChangedEventArgs(ListChangedType.ItemChanged, index)
                        OnListChanged(listChangedEventArgs)
                        <%
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#End If
<%
    }
}
%>
                        Exit For
                    End If
                Next
            End If
        End Sub

        #End Region

    <%
    }
}
%>
