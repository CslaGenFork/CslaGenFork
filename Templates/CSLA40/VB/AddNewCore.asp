        #region AddNewCore
<%

if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
if (CurrentUnit.GenerationParams.GenerateWinForms && CurrentUnit.GenerationParams.GenerateWPF)
{
    %>

#if WINFORMS
<%
}
if (CurrentUnit.GenerationParams.GenerateWinForms)
{
    %>

        /// <summary>Adds a new item to the end of the <see cref="<%= Info.ObjectName %>"/> collection.</summary>
        /// <returns>The added object.</returns>
        protected override object AddNewCore()
        {
            <%= Info.ItemType %> item = <%= Info.ItemType %>.New<%= Info.ItemType %>();
            Add(item);
            return item;
        }
<%
}
if (CurrentUnit.GenerationParams.GenerateWinForms && CurrentUnit.GenerationParams.GenerateWPF)
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.GenerateWPF)
{
    %>

        /// <summary>Adds a new item to the end of the <see cref="<%= Info.ObjectName %>"/> collection.</summary>
        /// <returns>The added object.</returns>
        protected override <%= Info.ItemType %> AddNewCore()
        {
            <%= Info.ItemType %> item = <%= Info.ItemType %>.New<%= Info.ItemType %>();
            Add(item);
            return item;
        }
<%
}
if (CurrentUnit.GenerationParams.GenerateWinForms && CurrentUnit.GenerationParams.GenerateWPF)
{
    %>

#endif
<%
}
if (UseBoth()) // check there is a fetch
{
    %>

#else
<%
}
if (UseSilverlight())
{
%>

        /// <summary>Asynchronously adds a new item to the end of the <see cref="<%= Info.ObjectName %>"/> collection.</summary>
        protected override void AddNewCore()
        {
            <%= Info.ItemType %>.New<%= Info.ItemType %>((o, e) =>
                {
                    if (e.Error != null)
                    {
                        throw e.Error;
                    }
                    else
                    {
                        Add(e.Object);
                        OnAddedNew(e.Object);
                    }
                });
        }
<%
}
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
<% %>