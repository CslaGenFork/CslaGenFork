using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F05Level111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="F05Level111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F04Level11"/> read only object.<br/>
    /// The items of the collection are <see cref="F06Level111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F05Level111Coll : ReadOnlyListBase<F05Level111Coll, F06Level111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="F06Level111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F06Level111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_ID)
        {
            foreach (var f06Level111 in this)
            {
                if (f06Level111.Level_1_1_1_ID == level_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F06Level111"/> item of the <see cref="F05Level111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID.</param>
        /// <returns>A <see cref="F06Level111"/> object.</returns>
        public F06Level111 FindF06Level111ByParentProperties(int level_1_1_1_ID)
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
        /// Factory method. Loads a <see cref="F05Level111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F05Level111Coll"/> object.</returns>
        internal static F05Level111Coll GetF05Level111Coll(SafeDataReader dr)
        {
            F05Level111Coll obj = new F05Level111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F05Level111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F05Level111Coll()
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
        /// Loads all <see cref="F05Level111Coll"/> collection items from the given SafeDataReader.
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
                Add(F06Level111.GetF06Level111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F06Level111"/> items on the F05Level111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F03Level11Coll"/> collection.</param>
        internal void LoadItems(F03Level11Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF04Level11ByParentProperties(item.marentID1);
                obj.F05Level111Objects.IsReadOnly = false;
                var rlce = obj.F05Level111Objects.RaiseListChangedEvents;
                obj.F05Level111Objects.RaiseListChangedEvents = false;
                obj.F05Level111Objects.Add(item);
                obj.F05Level111Objects.RaiseListChangedEvents = rlce;
                obj.F05Level111Objects.IsReadOnly = true;
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
