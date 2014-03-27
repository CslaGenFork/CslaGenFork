<%
bool isParentLoaded = false;
if (Info.ItemType != string.Empty)
{
    CslaObjectInfo findItem = Info.Parent.CslaObjects.Find(Info.ItemType);
    foreach (var child in findItem.GetAllChildProperties())
    {
        if (child.LoadingScheme == LoadingScheme.ParentLoad)
        {
            isParentLoaded = true;
            break;
        }
    }
}

if (Info.FindMethodsParameters.Count > 0 || isParentLoaded)
{
    %>
        #Region " Find Methods "
        <%

    if (Info.FindMethodsParameters.Count > 0)
    {
        foreach (Property prop in Info.FindMethodsParameters)
        {
            %>

        ''' <summary>
        ''' Finds a <see cref="<%= Info.ItemType %>"/> item of the <see cref="<%= Info.ObjectName %>"/> collection, based on a given <%= prop.Name %>.
        ''' </summary>
        ''' <param name="<%= FormatCamel(prop.Name) %>">The <%= FormatProperty(prop.Name) %>.</param>
        ''' <returns>A <see cref="<%= Info.ItemType %>"/> object.</returns>
        Public Function Find<%= Info.ItemType %>By<%= prop.Name %>(<%= FormatCamel(prop.Name) %> As <%= GetDataTypeGeneric(prop, prop.PropertyType) %>) As <%= Info.ItemType %> 
            For i As Integer = 0 To Me.Count - 1
                If Me(i).<%= prop.Name %>.Equals(<%= FormatCamel(prop.Name) %>) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function
        <%
        }
    }

    if (isParentLoaded)
    {
        CslaObjectInfo item = Info.Parent.CslaObjects.Find(Info.ItemType);
        if (item.ValueProperties.Count > 0)
        {
            string findByComments = string.Empty;
            string findByParams = string.Empty;
            string findByStat = string.Empty;
            bool firstFind = true;
            foreach (ValueProperty prop in item.ValueProperties)
            {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                    (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
                    (prop.DbBindColumn.NativeType == "timestamp" && Info.DeleteUseTimestamp)))
                {
                    if (firstFind)
                        firstFind = false;
                    else
                    {
                        findByComments += Environment.NewLine + new string(' ', 8);
                        findByParams += ", ";
                        findByStat += " AndAlso " + Environment.NewLine + new string(' ', 8);
                    }

                    findByComments += "''' <param name=\"" + FormatCamel(prop.Name) + "\">The " + FormatProperty(prop.Name) + ".</param>";
                    findByParams += FormatCamel(prop.Name) + " As " + GetDataTypeGeneric(prop, prop.PropertyType);
                    findByStat += "Me(i)." + prop.Name + ".Equals(" + FormatCamel(prop.Name) + ")";
                }
            }
            %>

        ''' <summary>
        ''' Finds a <see cref="<%= Info.ItemType %>"/> item of the <see cref="<%= Info.ObjectName %>"/> collection, based on item key properties.
        ''' </summary>
        <%= findByComments %>
        ''' <returns>A <see cref="<%= Info.ItemType %>"/> object.</returns>
        Public Function Find<%= Info.ItemType %>ByParentProperties(<%= findByParams %>) As <%= Info.ItemType %> 
            For i As Integer = 0 To Me.Count - 1
                If <%= findByStat %> Then
                    Return Me(i)
                End If
            Next

            Return Nothing
        End Function
        <%
        }
    }
%>

        #End Region

<%
}
%>
