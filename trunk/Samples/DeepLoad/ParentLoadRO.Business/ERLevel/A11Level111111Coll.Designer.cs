using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A11Level111111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="A11Level111111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A10Level11111"/> read only object.<br/>
    /// The items of the collection are <see cref="A12Level111111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A11Level111111Coll : ReadOnlyListBase<A11Level111111Coll, A12Level111111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="A12Level111111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_1_ID">The Level_1_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A12Level111111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_1_1_ID)
        {
            foreach (var a12Level111111 in this)
            {
                if (a12Level111111.Level_1_1_1_1_1_1_ID == level_1_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A11Level111111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A11Level111111Coll"/> object.</returns>
        internal static A11Level111111Coll GetA11Level111111Coll(SafeDataReader dr)
        {
            A11Level111111Coll obj = new A11Level111111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A11Level111111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal A11Level111111Coll()
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
        /// Loads all <see cref="A11Level111111Coll"/> collection items from the given SafeDataReader.
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
                Add(A12Level111111.GetA12Level111111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="A12Level111111"/> items on the A11Level111111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A09Level11111Coll"/> collection.</param>
        internal void LoadItems(A09Level11111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA10Level11111ByParentProperties(item.qarentID1);
                obj.A11Level111111Objects.IsReadOnly = false;
                var rlce = obj.A11Level111111Objects.RaiseListChangedEvents;
                obj.A11Level111111Objects.RaiseListChangedEvents = false;
                obj.A11Level111111Objects.Add(item);
                obj.A11Level111111Objects.RaiseListChangedEvents = rlce;
                obj.A11Level111111Objects.IsReadOnly = true;
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
