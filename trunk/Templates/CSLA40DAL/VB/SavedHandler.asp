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

        Infos.Append("To do list: edit \"" + Info.ObjectName + ".cs\", uncomment the \"OnDeserialized\" method and add the following line:" + Environment.NewLine);
        Infos.Append("      " + Info.UpdaterType + "." + Info.UpdaterType + "Saved += " + Info.UpdaterType + "SavedHandler;" + Environment.NewLine);
        %>
        #region Saved Event Handler
<%
        if (CurrentUnit.GenerationParams.WriteTodo)
        {
            %>

        // TODO: edit "<%= Info.ObjectName %>.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved += <%= Info.UpdaterType %>SavedHandler;
<%
        }
        %>

        /// <summary>
        /// Handle Saved events of <see cref="<%= Info.UpdaterType %>"/> to update the list of <see cref="<%= Info.ItemType %>"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        private void <%= Info.UpdaterType %>SavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (<%= Info.UpdaterType %>)e.NewObject;
            if (((<%= Info.UpdaterType %>)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(<%= Info.ItemType %>.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((<%= Info.UpdaterType %>)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.<%= identityName %> == obj.<%= identitySourceName %>)
                    {
                        IsReadOnly = false;
                        var rlce = RaiseListChangedEvents;
                        RaiseListChangedEvents = true;
                        this.RemoveItem(index);
                        RaiseListChangedEvents = rlce;
                        IsReadOnly = true;
                        break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.<%= identityName %> == obj.<%= identitySourceName %>)
                    {
                        child.UpdatePropertiesOnSaved(obj);
                        <%
if (CurrentUnit.GenerationParams.GenerateWPF)
{
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#if !WINFORMS
<%
    }
    %>
                        var notifyCollectionChangedEventArgs =
                            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index);
                        OnCollectionChanged(notifyCollectionChangedEventArgs);
                        <%
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#else
<%
    }
}
if (CurrentUnit.GenerationParams.GenerateWinForms)
{
    %>
                        var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index);
                        OnListChanged(listChangedEventArgs);
                        <%
    if (CurrentUnit.GenerationParams.DualListInheritance)
    {
        %>
#endif
<%
    }
}
%>
                        break;
                    }
                }
            }
        }

        #endregion

    <%
    }
}
%>
