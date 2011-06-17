<%
if (GetCriteriaObjects(Info).Count > 0)
{
    bool isCriteriaClassNeeded = IsCriteriaClassNeeded(Info);

    if (isCriteriaClassNeeded)
    {
        genOptional = true;
        IndentLevel += 3;
        %>

        #region Criteria

        <%
        foreach (Criteria crit in GetCriteriaObjects(Info))
        {
            string strParams = string.Empty;
            string strFieldAssignments = string.Empty;
            string strSummaryParams = string.Empty;
            if (crit.Properties.Count > 1)
            {
                %>
        /// <summary>
        /// <%= crit.Summary  == string.Empty ? crit.Name + " criteria." : crit.Summary %>
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
        if (UseSilverlight())
        {
            bool usePublicCriteria = false;
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
                foreach (Criteria c in GetCriteriaObjects(Info))
                {
                    if (c.CreateOptions.DataPortal && c.Properties.Count > 1 && c.CreateOptions.RunLocal)
                    {
                        usePublicCriteria = true;
                    }
                }
            }
            else
            {
                usePublicCriteria = true;
            }
            if (usePublicCriteria)
            {
            /*if (usePublicCriteria &&
                (Info.ObjectType == CslaObjectType.EditableRoot ||
                Info.ObjectType == CslaObjectType.EditableRootCollection ||
                Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                (Info.ObjectType == CslaObjectType.ReadOnlyObject && Info.ParentType == string.Empty) ||
                (Info.ObjectType == CslaObjectType.ReadOnlyCollection && Info.ParentType == string.Empty)))
            {*/
                %>
#if SILVERLIGHT
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public class <%= crit.Name %>
#else
        protected class <%= crit.Name %>
#endif
        <%
            }
            else
            {
                %>
        protected class <%= crit.Name %>
        <%
            }
        }
        else
        {
            %>
        protected class <%= crit.Name %>
        <%
        }
            %>
        {
            <%
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
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
                foreach (CriteriaProperty prop in crit.Properties)
                {
                    %>

            <%
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
            /// Gets <%= (prop.ReadOnly ? "" : "or sets ") %>the <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.
            /// </summary>
            <%
                    }
                    if(prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
                    {
                        %>
            /// <value><c>true</c> if <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
            <%
                    }
                    else if(prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
                    {
                        %>
            /// <value><c>true</c> if <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
            <%
                    }
                    else
                    {
                        %>
            /// <value>The <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.</value>
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
                    %>
            public <%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatProperty(prop.Name) %> { get; <%= (prop.ReadOnly ? "private " : "") %>set; }
            <%
                    // Just creating strings for later use in the constructors in order to avoid another loop
                    if (string.IsNullOrEmpty(prop.ParameterValue))
                    {
                        if (strParams.Length > 0)
                        {
                            strParams += ", ";
                        }
                        strParams += string.Concat(GetDataTypeGeneric(prop, prop.PropertyType), " ", FormatCamel(prop.Name));
                        strFieldAssignments += string.Concat("\r\n                ", FormatProperty(prop.Name), " = ", FormatCamel(prop.Name), ";");
                        strSummaryParams += "\r\n            /// <param name=\"" + FormatCamel(prop.Name) + "\">The "+ FormatProperty(prop.Name) + ".</param>";
                    }
                    else
                    {
                        strFieldAssignments += string.Concat("\r\n                ", FormatProperty(prop.Name), " = ", prop.ParameterValue, ";");
                    }
                }
                %>

            /// <summary>
            /// Initializes a new instance of the <see cref="<%= crit.Name %>"/> class.
            /// </summary><%= strSummaryParams %>
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
