<%
if (usesDTO)
{
    if (Info.CriteriaObjects.Count > 0)
    {
        bool isCriteriaObjectNeeded = IsCriteriaObjectNeeded(Info);

        if (isCriteriaObjectNeeded)
        {
            IndentLevel += 2;
            %>

    #region Criteria Interface
        <%
            foreach (Criteria crit in Info.CriteriaObjects)
            {
                string strParams = string.Empty;
                string strFieldAssignments = string.Empty;
                string strComment = string.Empty;
                if (crit.Properties.Count > 1)
                {
                    %>

    /// <summary>
    /// <%= crit.Summary  == string.Empty ? "Interface for " + (crit.Name + " criteria (used by " + Info.ObjectName + " object)") : crit.Summary %>
    /// </summary>
        <%
                    if (crit.Remarks != string.Empty)
                    {
                        %>
    /// <remarks>
    /// <%= crit.Remarks %>
    /// </remarks>
        <%
                    }
                    %>
    public partial interface I<%= crit.Name %>
    {
        <%
                    bool isFirstCI = true;
                    foreach (CriteriaProperty prop in crit.Properties)
                    {
                        if (isFirstCI)
                            isFirstCI = false;
                        else
                            Response.Write(Environment.NewLine);

                        if (prop.Summary != string.Empty)
                        {
                            IndentLevel = 2;
                            %>
        /// <summary>
<%= GetXmlCommentString(prop.Summary) %>
        /// </summary>
        <%
                        }
                        else
                        {
                            %>
        /// <summary>
        /// Gets <%= (prop.ReadOnly ? "" : "or sets ") %>the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        /// </summary>
        <%
                        }
                        if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
                        {
                            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
                        }
                        else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
                        {
                            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
                        }
                        else
                        {
                            %>
        /// <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
                        }
                        if (prop.Remarks != string.Empty)
                        {
                            IndentLevel = 2;
                            %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
        <%
                        }
                        // Just creating strings for later use in the constructors in order to avoid another loop
                        if (string.IsNullOrEmpty(prop.ParameterValue))
                        {
                            if (strParams.Length > 0)
                                strParams += ", ";

                            strParams += string.Concat(GetDataTypeGeneric(prop, prop.PropertyType), " ", FormatCamel(prop.Name));
                            strFieldAssignments += string.Concat("\r\n            ", FormatProperty(prop.Name), " = ", FormatCamel(prop.Name), ";");
                            strComment += "\r\n        /// <param name=\"" + FormatCamel(prop.Name) + "\">The "+ FormatProperty(prop.Name) + ".</param>";
                        }
                        else
                            strFieldAssignments += string.Concat("\r\n            ", FormatProperty(prop.Name), " = ", prop.ParameterValue, ";");

                        %>
        <%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatProperty(prop.Name) %> { get;<%= (prop.ReadOnly ? "" : " set;") %> }
        <%
                    }
                    %>
    }
    <%
                }
            }
            %>

    #endregion

<%
        }
    }
}
%>
