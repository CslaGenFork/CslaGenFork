        #region Factory Methods
<%
if (UseBoth()) // check there is a fetch OR Sync
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
%>

        /// <summary>Adds a new item to the end of the <see cref="<%= Info.ObjectName %>"/> collection.</summary>
        protected override <%= Info.ItemType %> AddNewCore()
        {
            <%= Info.ItemType %> item = <%= Info.ItemType %>.New<%= Info.ItemType %>();
            Add(item);
            return item;
        }
<%
}
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObject.asp" -->
<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
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
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (UseBoth())
{
    %>

#endif
<%
}
if (!CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>
<!-- #include file="Save.asp" -->

        #endregion
