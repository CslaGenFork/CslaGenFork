using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F11Level111111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="F11Level111111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F10Level11111"/> read only object.<br/>
    /// The items of the collection are <see cref="F12Level111111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F11Level111111Coll : ReadOnlyListBase<F11Level111111Coll, F12Level111111>
    {

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F11Level111111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F11Level111111Coll"/> object.</returns>
        internal static F11Level111111Coll GetF11Level111111Coll(SafeDataReader dr)
        {
            F11Level111111Coll obj = new F11Level111111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F11Level111111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F11Level111111Coll()
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
        /// Loads all <see cref="F11Level111111Coll"/> collection items from the given SafeDataReader.
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
                Add(F12Level111111.GetF12Level111111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F12Level111111"/> items on the F11Level111111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F09Level11111Coll"/> collection.</param>
        internal void LoadItems(F09Level11111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF10Level11111ByParentProperties(item.qarentID1);
                obj.F11Level111111Objects.IsReadOnly = false;
                var rlce = obj.F11Level111111Objects.RaiseListChangedEvents;
                obj.F11Level111111Objects.RaiseListChangedEvents = false;
                obj.F11Level111111Objects.Add(item);
                obj.F11Level111111Objects.RaiseListChangedEvents = rlce;
                obj.F11Level111111Objects.IsReadOnly = true;
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
