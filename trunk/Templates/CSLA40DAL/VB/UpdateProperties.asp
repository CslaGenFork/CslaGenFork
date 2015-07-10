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
        #region Update properties on saved object

        /// <summary>
        /// Existing <see cref="<%= Info.ObjectName %>"/> object is updated by <see cref="<%= parentInfo.UpdaterType %>"/> Saved event.
        /// </summary>
        internal static <%= Info.ObjectName %> LoadInfo(<%= parentInfo.UpdaterType %> <%= FormatCamel(parentInfo.UpdaterType) %>)
        {
            var info = new <%= Info.ObjectName %>();
            info.UpdatePropertiesOnSaved(<%= FormatCamel(parentInfo.UpdaterType) %>);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="<%= Info.ObjectName %>"/> object are updated by <see cref="<%= parentInfo.UpdaterType %>"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(<%= parentInfo.UpdaterType %> <%= FormatCamel(parentInfo.UpdaterType) %>)
        {
        <%
            foreach (UpdateValueProperty prop in Info.UpdateValueProperties)
            {
				if (prop.IsIdentity)
					continue;
                string cast = string.Empty;
                foreach (ValueProperty valProp in Info.ValueProperties)
                {
                    if (valProp.Name == prop.Name)
                    {
                        if (TypeHelper.GetBackingFieldType(valProp) == TypeCodeEx.SmartDate && valProp.PropertyType == TypeCodeEx.String)
                            cast = "(SmartDate)";
                        break;
                    }
                }
                %>
            <%= GetFieldLoaderStatement(Info, prop, cast + FormatCamel(parentInfo.UpdaterType) + "." + prop.SourcePropertyName) %>;
        <%
            }
            %>
        }

        #endregion

        <%
        }
    }
}
%>
