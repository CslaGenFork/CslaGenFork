
<%
if (Info.CriteriaObjects.Count > 0)
{
    bool isCriteriaNestedClassNeeded = IsCriteriaNestedClassNeeded(Info);

    if (isCriteriaNestedClassNeeded)
    {
        string getterCriteria = string.Empty;
        string setterCriteria = string.Empty;
        genOptional = true;
        IndentLevel += 3;
        %>

        #region Criteria
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
        /// <%= crit.Summary == string.Empty ? crit.Name + " criteria." : crit.Summary %>
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
        [Serializable]
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
        <%
                    if (crit.CriteriaClassMode == CriteriaMode.Simple)
                    {
                        %>
        public class <%= crit.Name %>
        <%
                    }
                    else
                    {
                        %>
        public <%= crit.CriteriaClassMode == CriteriaMode.BusinessBase ? "partial " : "" %>class <%= crit.Name %> : <%= crit.CriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %><<%= crit.Name %>>
        <%
                    }
                }
                if (UseBoth())
                {
                    %>
#else
        <%
                }
                if (UseNoSilverlight())
                {
                    if (crit.CriteriaClassMode == CriteriaMode.Simple)
                    {
                        %>
        protected class <%= crit.Name %>
        <%
                    }
                    else
                    {
                        %>
        protected <%= crit.CriteriaClassMode == CriteriaMode.BusinessBase ? "partial " : "" %>class <%= crit.Name %> : <%= crit.CriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %><<%= crit.Name %>>
        <%
                    }
                }
                if (UseBoth())
                {
                    %>
#endif
        <%
                }
                %>
        {
            <%
                if (Info.IsEditableSwitchable())
                {
                    strParams = "bool isChild";
                    strFieldAssignments = "  _isChild = isChild;";
                    %>
            private bool _isChild;

            public bool IsChild
            {
                get { return _isChild; }
            }
            <%
                }
                getterCriteria = "Get";
                setterCriteria = "Set";
                if (crit.CriteriaClassMode != CriteriaMode.BusinessBase)
                {
                    getterCriteria = "Read";
                    setterCriteria = "Load";
                }
                foreach (CriteriaProperty prop in crit.Properties)
                {
                    %>

            <%
                    if (crit.CriteriaClassMode != CriteriaMode.Simple)
                    {
                        string statement = PropertyInfoCriteriaDeclare(Info, prop);
                        %>
            /// <summary>
            /// Maintains metadata about <see cref="<%= FormatProperty(prop.Name) %>"/> property.
            /// </summary>
    <%= statement %>
                    <%
                    }
                    if (prop.Summary != string.Empty)
                    {
                        IndentLevel = 3;
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
                        IndentLevel = 3;
                        %>
            /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
            /// </remarks>
            <%
                    }
                    // Just creating strings for later use in constructors generation in order to avoid another loop
                    if (string.IsNullOrEmpty(prop.ParameterValue))
                    {
                        if (strParams.Length > 0)
                        {
                            strParams += ", ";
                        }
                        strParams += string.Concat(GetDataTypeGeneric(prop, prop.PropertyType), " ", FormatCamel(prop.Name));
                        strFieldAssignments += string.Concat("\r\n                ", FormatProperty(prop.Name), " = ", FormatCamel(prop.Name), ";");
                        strComment += "\r\n            /// <param name=\"" + FormatCamel(prop.Name) + "\">The "+ FormatProperty(prop.Name) + ".</param>";
                    }
                    else
                    {
                        strFieldAssignments += string.Concat("\r\n                ", FormatProperty(prop.Name), " = ", prop.ParameterValue, ";");
                    }
                    if (crit.CriteriaClassMode == CriteriaMode.Simple)
                    {
                        %>
            public <%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatProperty(prop.Name) %> { get; <%= (prop.ReadOnly ? "private " : "") %>set; }
            <%
                    }
                    else
                    {
                        %>
            public <%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatProperty(prop.Name) %>
            {
                get { return <%= getterCriteria %>Property(<%= FormatProperty(prop.Name) %>Property); }
                <%= (prop.ReadOnly ? "private " : "") %>set { <%= setterCriteria %>Property(<%= FormatProperty(prop.Name) %>Property, value); }
            }
            <%
                    }
                }
                if (strParams.Length > 0)
                {
                    %>

            /// <summary>
            /// Initializes a new instance of the <see cref="<%= crit.Name %>"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public <%= crit.Name %>()
            {
            }
<%
                }
                %>

            /// <summary>
            /// Initializes a new instance of the <see cref="<%= crit.Name %>"/> class.
            /// </summary><%= strComment %>
            public <%= crit.Name %>(<%= strParams %>)
            {
                <%
                if (strFieldAssignments.Length > 1)
                {
                    %>
<%= strFieldAssignments.Substring(2) %>
                <%
                }
                %>
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is <%= crit.Name %>)
                {
                    var c = (<%= crit.Name %>) obj;
                    <%
                foreach (CriteriaProperty p in crit.Properties)
                {
                    %>
                    if (!<%= FormatProperty(p.Name) %>.Equals(c.<%= FormatProperty(p.Name) %>))
                        return false;
                    <%
                }
                %>
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("<%= crit.Name %>"<% foreach (CriteriaProperty p in crit.Properties) { %>, <%= FormatProperty(p.Name) %>.ToString()<% } %>).GetHashCode();
            }
        }
        <%
            }
        }
        %>

        #endregion

<%
        IndentLevel -=3;
    }
}
%>
