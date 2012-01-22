using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05Level111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="E05Level111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E04Level11"/> read only object.<br/>
    /// The items of the collection are <see cref="E06Level111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E05Level111Coll : ReadOnlyListBase<E05Level111Coll, E06Level111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="E06Level111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E06Level111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_ID)
        {
            foreach (var e06Level111 in this)
            {
                if (e06Level111.Level_1_1_1_ID == level_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E06Level111"/> item of the <see cref="E05Level111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID.</param>
        /// <returns>A <see cref="E06Level111"/> object.</returns>
        public E06Level111 FindE06Level111ByParentProperties(int level_1_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_1_ID.Equals(level_1_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E05Level111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E05Level111Coll"/> object.</returns>
        internal static E05Level111Coll GetE05Level111Coll(SafeDataReader dr)
        {
            E05Level111Coll obj = new E05Level111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E05Level111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal E05Level111Coll()
        {
            // Prevent direct creation

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="E05Level111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(E06Level111.GetE06Level111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="E06Level111"/> items on the E05Level111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E03Level11Coll"/> collection.</param>
        internal void LoadItems(E03Level11Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE04Level11ByParentProperties(item.marentID1);
                obj.E05Level111Objects.IsReadOnly = false;
                var rlce = obj.E05Level111Objects.RaiseListChangedEvents;
                obj.E05Level111Objects.RaiseListChangedEvents = false;
                obj.E05Level111Objects.Add(item);
                obj.E05Level111Objects.RaiseListChangedEvents = rlce;
                obj.E05Level111Objects.IsReadOnly = true;
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
