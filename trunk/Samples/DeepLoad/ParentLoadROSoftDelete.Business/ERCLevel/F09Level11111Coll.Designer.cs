using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F09Level11111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="F09Level11111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F08Level1111"/> read only object.<br/>
    /// The items of the collection are <see cref="F10Level11111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F09Level11111Coll : ReadOnlyListBase<F09Level11111Coll, F10Level11111>
    {

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F10Level11111"/> item of the <see cref="F09Level11111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID.</param>
        /// <returns>A <see cref="F10Level11111"/> object.</returns>
        public F10Level11111 FindF10Level11111ByParentProperties(int level_1_1_1_1_1_ID)
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
        /// Factory method. Loads a <see cref="F09Level11111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F09Level11111Coll"/> object.</returns>
        internal static F09Level11111Coll GetF09Level11111Coll(SafeDataReader dr)
        {
            F09Level11111Coll obj = new F09Level11111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F09Level11111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F09Level11111Coll()
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
        /// Loads all <see cref="F09Level11111Coll"/> collection items from the given SafeDataReader.
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
                Add(F10Level11111.GetF10Level11111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F10Level11111"/> items on the F09Level11111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F07Level1111Coll"/> collection.</param>
        internal void LoadItems(F07Level1111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF08Level1111ByParentProperties(item.narentID1);
                obj.F09Level11111Objects.IsReadOnly = false;
                var rlce = obj.F09Level11111Objects.RaiseListChangedEvents;
                obj.F09Level11111Objects.RaiseListChangedEvents = false;
                obj.F09Level11111Objects.Add(item);
                obj.F09Level11111Objects.RaiseListChangedEvents = rlce;
                obj.F09Level11111Objects.IsReadOnly = true;
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
