//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocCircColl
// ObjectType:  DocCircColl
// CSLAType:    EditableChildCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using UsingClass;

namespace DocStore.Business.Circulations
{

    /// <summary>
    /// Collection of circulations of this document (editable child list).<br/>
    /// This is a generated base class of <see cref="DocCircColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="Doc"/> editable root object.<br/>
    /// The items of the collection are <see cref="DocCirc"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class DocCircColl : BusinessBindingListBase<DocCircColl, DocCirc>, IHaveInterface, IHaveGenericInterface<DocCircColl>
#else
    public partial class DocCircColl : BusinessListBase<DocCircColl, DocCirc>, IHaveInterface, IHaveGenericInterface<DocCircColl>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Adds a new <see cref="DocCirc"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        public new void Add(DocCirc item)
        {
            if (Contains(item.CircID))
                throw new ArgumentException("DocCirc already exists.");

            base.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="DocCirc"/> item to the collection.
        /// </summary>
        /// <returns>The new DocCirc item added to the collection.</returns>
        public DocCirc Add()
        {
            var item = DocCirc.NewDocCirc();
            Add(item);
            return item;
        }

        /// <summary>
        /// Asynchronously adds a new <see cref="DocCirc"/> item to the collection.
        /// </summary>
        public void BeginAdd()
        {
            DocCirc docCirc = null;
            DocCirc.NewDocCirc((o, e) =>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        docCirc = e.Object;
                });
            Add(docCirc);
        }

        /// <summary>
        /// Removes a <see cref="DocCirc"/> item from the collection.
        /// </summary>
        /// <param name="circID">The CircID of the item to be removed.</param>
        public void Remove(int circID)
        {
            foreach (var docCirc in this)
            {
                if (docCirc.CircID == circID)
                {
                    Remove(docCirc);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="DocCirc"/> item is in the collection.
        /// </summary>
        /// <param name="circID">The CircID of the item to search for.</param>
        /// <returns><c>true</c> if the DocCirc is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int circID)
        {
            foreach (var docCirc in this)
            {
                if (docCirc.CircID == circID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="DocCirc"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="circID">The CircID of the item to search for.</param>
        /// <returns><c>true</c> if the DocCirc is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int circID)
        {
            foreach (var docCirc in DeletedList)
            {
                if (docCirc.CircID == circID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocCircColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocCircColl"/> collection.</returns>
        internal static DocCircColl NewDocCircColl()
        {
            return DataPortal.CreateChild<DocCircColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocCircColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocCircColl"/> object.</returns>
        internal static DocCircColl GetDocCircColl(SafeDataReader dr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a DocCircColl.");

            DocCircColl obj = new DocCircColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocCircColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void NewDocCircColl(EventHandler<DataPortalResult<DocCircColl>> callback)
        {
            DataPortal.BeginCreate<DocCircColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocCircColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocCircColl()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (DocCircColl), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new DocCircColl object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(DocCircColl));
        }

        /// <summary>
        /// Checks if the current user can retrieve DocCircColl's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocCircColl));
        }

        /// <summary>
        /// Checks if the current user can change DocCircColl's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(DocCircColl));
        }

        /// <summary>
        /// Checks if the current user can delete a DocCircColl object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(DocCircColl));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="DocCircColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DocCirc.GetDocCirc(dr));
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
