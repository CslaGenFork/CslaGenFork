using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E11Level111111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="E11Level111111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E10Level11111"/> editable child object.<br/>
    /// The items of the collection are <see cref="E12Level111111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E11Level111111Coll : BusinessListBase<E11Level111111Coll, E12Level111111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="E12Level111111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_1_ID">The Level_1_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_1_ID)
        {
            foreach (var e12Level111111 in this)
            {
                if (e12Level111111.Level_1_1_1_1_1_1_ID == level_1_1_1_1_1_1_ID)
                {
                    Remove(e12Level111111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="E12Level111111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_1_ID">The Level_1_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E12Level111111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_1_1_ID)
        {
            foreach (var e12Level111111 in this)
            {
                if (e12Level111111.Level_1_1_1_1_1_1_ID == level_1_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="E12Level111111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_1_1_ID">The Level_1_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E12Level111111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_1_1_ID)
        {
            foreach (var e12Level111111 in this.DeletedList)
            {
                if (e12Level111111.Level_1_1_1_1_1_1_ID == level_1_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E11Level111111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="E11Level111111Coll"/> collection.</returns>
        internal static E11Level111111Coll NewE11Level111111Coll()
        {
            return DataPortal.CreateChild<E11Level111111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E11Level111111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E11Level111111Coll"/> object.</returns>
        internal static E11Level111111Coll GetE11Level111111Coll(SafeDataReader dr)
        {
            E11Level111111Coll obj = new E11Level111111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E11Level111111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E11Level111111Coll()
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
        /// Loads all <see cref="E11Level111111Coll"/> collection items from the given SafeDataReader.
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
                Add(E12Level111111.GetE12Level111111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="E12Level111111"/> items on the E11Level111111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E09Level11111Coll"/> collection.</param>
        internal void LoadItems(E09Level11111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE10Level11111ByParentProperties(item.qarentID1);
                var rlce = obj.E11Level111111Objects.RaiseListChangedEvents;
                obj.E11Level111111Objects.RaiseListChangedEvents = false;
                obj.E11Level111111Objects.Add(item);
                obj.E11Level111111Objects.RaiseListChangedEvents = rlce;
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
