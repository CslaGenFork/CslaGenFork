
        /// <summary>
        /// Determines whether a <see cref="<%= Info.ItemType %>" /> item is in the collection.
        /// </summary>
        public bool Contains(<%= Info.ItemType %> item)
        {
            foreach(<%= Info.ItemType %> obj in List)
            {
                if (obj.Equals(item))
                {
                    return(true);
                }
            }
            return(false);
        }
        <%
if (Info.ObjectType != CslaObjectType.ReadOnlyCollection)
{
    %>

        /// <summary>
        /// Determines whether a <see cref="<%= Info.ItemType %>" /> object is in the collection, but it's been deleted.
        /// </summary>
        public bool ContainsDeleted(<%= Info.ItemType %> item)
        {
            foreach(<%= Info.ItemType %> obj in deletedList)
            {
                if (obj.Equals(item))
                {
                    return(true);
                }
            }
            return(false);
        }
        <%
}
%>
