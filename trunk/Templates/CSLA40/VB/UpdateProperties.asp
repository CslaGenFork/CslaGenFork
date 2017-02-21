<%
// Check there is something to update or else skip over
if (Info.UpdateValueProperties.Count > 0)
{
    string parentType = Info.ParentType;
    if (parentType != string.Empty)
    {
        if (parentInfo.UpdaterType == string.Empty)
        {
            Errors.Append("No UpdaterType defined on " + parentInfo.ObjectName + "." + Environment.NewLine);
        }
        else
        {
            if (!genOptional)
            {
                Response.Write(Environment.NewLine);
            }
            genOptional = true;
            %>
        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="<%= Info.ObjectName %>"/> object is updated by <see cref="<%= parentInfo.UpdaterType %>"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(<%= FormatCamel(parentInfo.UpdaterType) %> As <%= parentInfo.UpdaterType %>) As <%= Info.ObjectName %>
            Dim info As New <%= Info.ObjectName %>()
            info.UpdatePropertiesOnSaved(<%= FormatCamel(parentInfo.UpdaterType) %>)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="<%= Info.ObjectName %>"/> object are updated by <see cref="<%= parentInfo.UpdaterType %>"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(<%= FormatCamel(parentInfo.UpdaterType) %> As <%= parentInfo.UpdaterType %>)
        <%
            foreach (UpdateValueProperty prop in Info.UpdateValueProperties)
            {
                // Do update IsIdentity properties as they change when the object is created.
                // if (prop.IsIdentity)
                //     continue;
                string cast = FormatCamel(parentInfo.UpdaterType) + "." + prop.SourcePropertyName;
                foreach (ValueProperty valProp in Info.ValueProperties)
                {
                    if (valProp.Name == prop.Name)
                    {
                        if (TemplateHelper.GetBackingFieldType(valProp) == TypeCodeEx.SmartDate && valProp.PropertyType == TypeCodeEx.String)
                            cast = String.Format("CType({0}, SmartDate)", cast);
                        break;
                    }
                }
                %>
            <%= GetFieldLoaderStatement(Info, prop, cast) %>
        <%
            }
            %>
        End Sub

        #End Region

        <%
        }
    }
}
%>
