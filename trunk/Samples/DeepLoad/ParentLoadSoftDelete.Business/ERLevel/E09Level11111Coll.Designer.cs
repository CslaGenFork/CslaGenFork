using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E09Level11111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="E09Level11111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E08Level1111"/> editable child object.<br/>
    /// The items of the collection are <see cref="E10Level11111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E09Level11111Coll : BusinessListBase<E09Level11111Coll, E10Level11111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="E10Level11111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_ID)
        {
            foreach (var e10Level11111 in this)
            {
                if (e10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    Remove(e10Level11111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="E10Level11111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E10Level11111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_1_ID)
        {
            foreach (var e10Level11111 in this)
            {
                if (e10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="E10Level11111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E10Level11111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_1_ID)
        {
            foreach (var e10Level11111 in this.DeletedList)
            {
                if (e10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E10Level11111"/> item of the <see cref="E09Level11111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID.</param>
        /// <returns>A <see cref="E10Level11111"/> object.</returns>
        public E10Level11111 FindE10Level11111ByParentProperties(int level_1_1_1_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_1_1_1_ID.Equals(level_1_1_1_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E09Level11111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="E09Level11111Coll"/> collection.</returns>
        internal static E09Level11111Coll NewE09Level11111Coll()
        {
            return DataPortal.CreateChild<E09Level11111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E09Level11111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E09Level11111Coll"/> object.</returns>
        internal static E09Level11111Coll GetE09Level11111Coll(SafeDataReader dr)
        {
            E09Level11111Coll obj = new E09Level11111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E09Level11111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E09Level11111Coll()
        {
            // Prevent direct creation

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

        #region Data Access

        /// <summary>
        /// Loads all <see cref="E09Level11111Coll"/> collection items from the given SafeDataReader.
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
                Add(E10Level11111.GetE10Level11111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="E10Level11111"/> items on the E09Level11111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E07Level1111Coll"/> collection.</param>
        internal void LoadItems(E07Level1111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE08Level1111ByParentProperties(item.narentID1);
                var rlce = obj.E09Level11111Objects.RaiseListChangedEvents;
                obj.E09Level11111Objects.RaiseListChangedEvents = false;
                obj.E09Level11111Objects.Add(item);
                obj.E09Level11111Objects.RaiseListChangedEvents = rlce;
            }
        }

        #endregion

        #region Pseudo Events

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
