using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Rules.CommonRules;
using UsingClass;

namespace TestProject.Business
{

    /// <summary>
    /// Collection of folders where this document is archived (editable child list).<br/>
    /// This is a generated base class of <see cref="DocFolderColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="Doc"/> editable root object.<br/>
    /// The items of the collection are <see cref="DocFolder"/> objects.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocFolderColl : GenericListBase<DocFolderColl, DocFolder>, IHaveInterface
    {

        #region Collection Business Methods

        /// <summary>
        /// Adds a new <see cref="DocFolder"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        /// <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        public new void Add(DocFolder item)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to create a DocFolder.");

            if (Contains(item.FolderID))
                throw new ArgumentException("DocFolder already exists.");

            base.Add(item);
        }

        /// <summary>
        /// Removes a <see cref="DocFolder"/> item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><c>true</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        public new bool Remove(DocFolder item)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DocFolder.");

            return base.Remove(item);
        }

        /// <summary>
        /// Adds a new <see cref="DocFolder"/> item to the collection.
        /// </summary>
        /// <param name="folderID">The FolderID of the object to be added.</param>
        /// <returns>The new DocFolder item added to the collection.</returns>
        public DocFolder Add(int folderID)
        {
            var item = DataPortal.Create<DocFolder>(folderID);
            Add(item);
            return item;
        }

        /// <summary>
        /// Removes a <see cref="DocFolder"/> item from the collection.
        /// </summary>
        /// <param name="folderID">The FolderID of the item to be removed.</param>
        public void Remove(int folderID)
        {
            foreach (var docFolder in this)
            {
                if (docFolder.FolderID == folderID)
                {
                    Remove(docFolder);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="DocFolder"/> item is in the collection.
        /// </summary>
        /// <param name="folderID">The FolderID of the item to search for.</param>
        /// <returns><c>true</c> if the DocFolder is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int folderID)
        {
            foreach (var docFolder in this)
            {
                if (docFolder.FolderID == folderID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="DocFolder"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="folderID">The FolderID of the item to search for.</param>
        /// <returns><c>true</c> if the DocFolder is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int folderID)
        {
            foreach (var docFolder in DeletedList)
            {
                if (docFolder.FolderID == folderID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="DocFolder"/> item of the <see cref="DocFolderColl"/> collection, based on a given FolderID.
        /// </summary>
        /// <param name="folderID">The FolderID.</param>
        /// <returns>A <see cref="DocFolder"/> object.</returns>
        public DocFolder FindDocFolderByFolderID(int folderID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].FolderID.Equals(folderID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocFolderColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocFolderColl()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = DocFolderColl.CanAddObject();
            AllowEdit = DocFolderColl.CanEditObject();
            AllowRemove = DocFolderColl.CanDeleteObject();
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (DocFolderColl), new IsInRole(AuthorizationActions.CreateObject, "Archivist"));
            BusinessRules.AddRule(typeof (DocFolderColl), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (DocFolderColl), new IsInRole(AuthorizationActions.EditObject, "Author"));
            BusinessRules.AddRule(typeof (DocFolderColl), new IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new DocFolderColl object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(DocFolderColl));
        }

        /// <summary>
        /// Checks if the current user can retrieve DocFolderColl's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocFolderColl));
        }

        /// <summary>
        /// Checks if the current user can change DocFolderColl's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(DocFolderColl));
        }

        /// <summary>
        /// Checks if the current user can delete a DocFolderColl object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(DocFolderColl));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="DocFolderColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<DocFolder>(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
