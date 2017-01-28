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
        #region Find Methods
        <%

    if (Info.FindMethodsParameters.Count > 0)
    {
        foreach (Property prop in Info.FindMethodsParameters)
        {
            %>

        /// <summary>
        /// Finds a <see cref="<%= Info.ItemType %>"/> item of the <see cref="<%= Info.ObjectName %>"/> collection, based on a given <%= prop.Name %>.
        /// </summary>
        /// <param name="<%= FormatCamel(prop.Name) %>">The <%= FormatProperty(prop.Name) %>.</param>
        /// <returns>A <see cref="<%= Info.ItemType %>"/> object.</returns>
        public <%= Info.ItemType %> Find<%= Info.ItemType %>By<%= prop.Name %>(<%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatCamel(prop.Name) %>)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].<%= prop.Name %>.Equals(<%= FormatCamel(prop.Name) %>))
                {
                    return this[i];
                }
            }

            return null;
        }
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
                if (prop.IsDatabaseBound &&
                    prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                    (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
                    (prop.DbBindColumn.NativeType == "timestamp" && Info.DeleteUseTimestamp)))
                {
                    if (firstFind)
                        firstFind = false;
                    else
                    {
                        findByComments += Environment.NewLine + new string(' ', 8);
                        findByParams += ", ";
                        findByStat += " &&" + Environment.NewLine + new string(' ', 8);
                    }

                    findByComments += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + FormatProperty(prop.Name) + ".</param>";
                    findByParams += GetDataTypeGeneric(prop, prop.PropertyType) + " " + FormatCamel(prop.Name);
                    findByStat += "this[i]." + prop.Name + ".Equals(" + FormatCamel(prop.Name) + ")";
                }
            }
            %>

        /// <summary>
        /// Finds a <see cref="<%= Info.ItemType %>"/> item of the <see cref="<%= Info.ObjectName %>"/> collection, based on item key properties.
        /// </summary>
        <%= findByComments %>
        /// <returns>A <see cref="<%= Info.ItemType %>"/> object.</returns>
        public <%= Info.ItemType %> Find<%= Info.ItemType %>ByParentProperties(<%= findByParams %>)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (<%= findByStat %>)
                {
                    return this[i];
                }
            }

            return null;
        }
        <%
        }
    }
%>

        #endregion

<%
}
%>
