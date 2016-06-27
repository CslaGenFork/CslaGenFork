<%
if ((firstComment == null && string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)) ||
    (firstComment == true && !string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)))
{
    firstComment = true;
    %>
    /// <summary>
    /// <%= string.IsNullOrEmpty(Info.ClassSummary) ? Info.ObjectName : Info.ClassSummary %> (<%= CslaStereotype(Info) %>).<br/>
    /// This is a generated base class of <see cref="<%= Info.ObjectName %>"/> business object.
<%
    if (string.IsNullOrEmpty(Info.ParentType))
    {
        if (Info.IsReadOnlyObject())
        {
            %>
    /// This class is a root object.
<%
        }
        else if (Info.IsReadOnlyCollection())
        {
            %>
    /// This class is a root collection.
<%
        }
        else if (Info.IsUnitOfWork())
        {
            %>
    /// This class is a root object that implements the Unit of Work pattern.
<%
        }
    }
%>
    /// </summary>
    <%
    int indentLevel = (CurrentUnit.GenerationParams.UtilitiesNamespace.Length > 0) ? 1 : 0;
    string localIndent = new string(' ', indentLevel * 4);
    string xmlRemark = "/// ";
    // contained child collections
    if (Info.ChildCollectionProperties.Count > 0)
    {
        string collectionName;
        firstComment = false;
        xmlRemark += "This class contains " + Ordinal(Info.ChildCollectionProperties.Count) + " child collection" +
            (Info.ChildCollectionProperties.Count > 1 ? "s" : "") + ":<br/>\r\n";
        for (int collection = 0; collection < Info.ChildCollectionProperties.Count; collection++)
        {
            collectionName = string.IsNullOrEmpty(Info.ChildCollectionProperties[collection].Interfaces) ? Info.ChildCollectionProperties[collection].Name : Info.ChildCollectionProperties[collection].Interfaces;
            CslaObjectInfo childColl = FindChildInfo(Info, Info.ChildCollectionProperties[collection].TypeName);
            CslaObjectInfo associated = FindAssociated(Info, childColl);
            xmlRemark += "- <see cref=\"" + collectionName + "\"/> of type <see cref=\"" + childColl.ObjectName +
                "\"/> (" + (associated == null ? "1" : "M") + ":M relation to <see cref=\"" + (associated == null ? childColl.ItemType : associated.ObjectName) + "\"/>)" + (collection != Info.ChildCollectionProperties.Count - 1 ? "<br/>\r\n" : "");
        }
    }
    // collection items
    if (!string.IsNullOrEmpty(Info.ParentType))
    {
        if (Info.IsEditableChild() ||
            Info.IsEditableSwitchable() ||
            Info.IsDynamicEditableRoot() ||
            Info.IsReadOnlyObject())
        {
            if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
            xmlRemark += "This class is an item of <see cref=\"" + Info.ParentType + "\"/> collection.";
        }
        else
        {
            if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
            CslaObjectInfo parent = Info.FindMyParent(Info);
            xmlRemark += "This class is child of <see cref=\"" + Info.ParentType + "\"/> " + CslaStereotype(parent) + ".";
        }
    }
    // collections
    if (!string.IsNullOrEmpty(Info.ItemType) &&
        (Info.IsEditableRootCollection() ||
        Info.IsDynamicEditableRootCollection() ||
        Info.IsEditableChildCollection() ||
        Info.IsReadOnlyCollection()))
    {
        if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
        xmlRemark += "The items of the collection are <see cref=\"" + Info.ItemType + "\"/> objects.";
    }
    if (firstComment == false)
    {
        xmlRemark = System.Text.RegularExpressions.Regex.Replace(xmlRemark, "\r\n", "\r\n" + localIndent + "/// ", System.Text.RegularExpressions.RegexOptions.Multiline);
        %>
    /// <remarks>
    <%= xmlRemark %>
    <%
        if (Info.ClassRemarks != string.Empty)
        {
            %>
    /// <%= Info.ClassRemarks %>
    <%
        }
        %>
    /// </remarks>
    <%
    }
}
    %>
