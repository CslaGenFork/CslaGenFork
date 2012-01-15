using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B11Level111111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="B11Level111111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B10Level11111"/> editable child object.<br/>
    /// The items of the collection are <see cref="B12Level111111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B11Level111111Coll : BusinessListBase<B11Level111111Coll, B12Level111111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="B12Level111111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_1_ID">The Level_1_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_1_ID)
        {
            foreach (B12Level111111 b12Level111111 in this)
            {
                if (b12Level111111.Level_1_1_1_1_1_1_ID == level_1_1_1_1_1_1_ID)
                {
                      Remove(b12Level111111);
                      break;
                }
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B11Level111111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="B11Level111111Coll"/> collection.</returns>
        internal static B11Level111111Coll NewB11Level111111Coll()
        {
            return DataPortal.CreateChild<B11Level111111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B11Level111111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B11Level111111Coll"/> object.</returns>
        internal static B11Level111111Coll GetB11Level111111Coll(SafeDataReader dr)
        {
            B11Level111111Coll obj = new B11Level111111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11Level111111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B11Level111111Coll()
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
        /// Loads all <see cref="B11Level111111Coll"/> collection items from the given SafeDataReader.
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
                Add(B12Level111111.GetB12Level111111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="B12Level111111"/> items on the B11Level111111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B09Level11111Coll"/> collection.</param>
        internal void LoadItems(B09Level11111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB10Level11111ByParentProperties(item.qarentID1);
                var rlce = obj.B11Level111111Objects.RaiseListChangedEvents;
                obj.B11Level111111Objects.RaiseListChangedEvents = false;
                obj.B11Level111111Objects.Add(item);
                obj.B11Level111111Objects.RaiseListChangedEvents = rlce;
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
