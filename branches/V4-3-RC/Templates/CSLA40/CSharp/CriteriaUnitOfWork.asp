<%
List<UnitOfWorkCriteriaManager.UoWCriteria> listUoWCriteriaCurrent = null;
if (Info.IsCreator || Info.IsCreatorGetter)
    listUoWCriteriaCurrent = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Creator, true);
else if (Info.IsGetter)
    listUoWCriteriaCurrent = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Getter, true);
else if (Info.IsDeleter)
    listUoWCriteriaCurrent = listUoWCriteriaDeleter;

int activeCriteria = 0;
foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCurrent)
{
    if (!string.IsNullOrEmpty(uowCrit.CriteriaName))
        activeCriteria ++;
}

if (activeCriteria > 0)
{
    CriteriaMode critCriteriaClassMode = CriteriaMode.CriteriaBase;
    string getterCriteria = string.Empty;
    string setterCriteria = string.Empty;
    genOptional = true;
    IndentLevel += 3;
    %>

        #region Criteria
        <%
    foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCurrent)
    {
        string strParams = string.Empty;
        string strFieldAssignments = string.Empty;
        string strComment = string.Empty;
        %>

        /// <summary>
        /// <%= uowCrit.CriteriaName + " criteria." %>
        /// </summary>
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
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
        public class <%= uowCrit.CriteriaName %>
        <%
            }
            else
            {
                %>
        public <%= critCriteriaClassMode == CriteriaMode.BusinessBase ? "partial " : "" %>class <%= uowCrit.CriteriaName %> : <%= critCriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %><<%= uowCrit.CriteriaName %>>
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
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
        protected class <%= uowCrit.CriteriaName %>
        <%
            }
            else
            {
                %>
        protected <%= critCriteriaClassMode == CriteriaMode.BusinessBase ? "partial " : "" %>class <%= uowCrit.CriteriaName %> : <%= critCriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %><<%= uowCrit.CriteriaName %>>
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
        getterCriteria = "Get";
        setterCriteria = "Set";
        if (critCriteriaClassMode != CriteriaMode.BusinessBase)
        {
            getterCriteria = "Read";
            setterCriteria = "Load";
        }
        foreach (UnitOfWorkCriteriaManager.ElementCriteria crit in uowCrit.ElementCriteriaList)
        {
            if (crit.Name == string.Empty)
                continue;
            %>

            <%
            if (critCriteriaClassMode != CriteriaMode.Simple)
            {
                string statement = PropertyInfoUoWCriteriaDeclare(Info, crit);
                %>
            /// <summary>
            /// Maintains metadata about <see cref="<%= FormatProperty(crit.Name) %>"/> property.
            /// </summary>
    <%= statement %>
            <%
            }
            %>
            /// <summary>
            /// Gets or sets the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>.
            /// </summary>
            <%
            if (crit.Type == "bool")
            {
                %>
            /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; otherwise, <c>false</c>.</value>
            <%
            }
            else if (crit.Type == "bool?")
            {
                %>
            /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; otherwise, <c>null</c>.</value>
            <%
            }
            else
            {
                %>
            /// <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>.</value>
            <%
            }
            // Just creating strings for later use in the constructors in order to avoid another loop
            if (strParams.Length > 0)
            {
                strParams += ", ";
            }
            strParams += string.Concat(crit.Type, " ", FormatCamel(crit.Name));
            strFieldAssignments += string.Concat("\r\n                ", FormatProperty(crit.Name), " = ", FormatCamel(crit.Name), ";");
            strComment += "\r\n            /// <param name=\"" + FormatCamel(crit.Name) + "\">The "+ FormatProperty(crit.Name) + ".</param>";
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
            public <%= crit.Type %> <%= FormatProperty(crit.Name) %> { get; set; }
            <%
            }
            else
            {
                %>
            public <%= crit.Type %> <%= FormatProperty(crit.Name) %>
            {
                get { return <%= getterCriteria %>Property(<%= FormatProperty(crit.Name) %>Property); }
                set { <%= setterCriteria %>Property(<%= FormatProperty(crit.Name) %>Property, value); }
            }
            <%
            }
        }
        %>

            /// <summary>
            /// Initializes a new instance of the <see cref="<%= uowCrit.CriteriaName %>"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public <%= uowCrit.CriteriaName %>()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="<%= uowCrit.CriteriaName %>"/> class.
            /// </summary><%= strComment %>
            public <%= uowCrit.CriteriaName %>(<%= strParams %>)
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
                if (obj is <%= uowCrit.CriteriaName %>)
                {
                    var c = (<%= uowCrit.CriteriaName %>) obj;
                    <%
        foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
        {
            if (c.Name == string.Empty)
                continue;

            %>
                    if (!<%= FormatProperty(c.Name) %>.Equals(c.<%= FormatProperty(c.Name) %>))
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
                return string.Concat("<%= uowCrit.CriteriaName %>"<% foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList) { if (c.Name == string.Empty) continue; %>, <%= FormatProperty(c.Name) %>.ToString()<% } %>).GetHashCode();
            }
        }
        <%
    }
    %>

        #endregion
<%
    IndentLevel -=3;
}
%>
