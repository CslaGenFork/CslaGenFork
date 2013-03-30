
        #region Contains (Evaluate if the Object exists in Collection)

        /// <summary>
        /// Determines whether an <see cref="<%=Info.ItemType%>" /> object is in the <see cref="<%=Info.ObjectName%>" /> collection.
        /// </summary>
        public bool Contains(<%=Info.ItemType %> item)
        {
            foreach(<%=Info.ItemType %> obj in List)
            {
                if(obj.Equals(item))
                {
                    return(true);
                }
            }
            return(false);
        }
        <% if (Info.ObjectType != CslaObjectType.ReadOnlyCollection) { %>

        /// <summary>
        /// Determines whether an <see cref="<%=Info.ItemType%>" /> object is in the <see cref="<%=Info.ObjectName%>" /> collection, but it's been deleted.
        /// </summary>
        public bool ContainsDeleted(<%=Info.ItemType %> item)
        {
            foreach(<%=Info.ItemType %> obj in deletedList)
            {
                if(obj.Equals(item))
                {
                    return(true);
                }
            }
            return(false);
        }
        <% } %>

        #endregion
