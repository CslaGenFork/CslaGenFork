using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F07Level1111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="F07Level1111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F06Level111"/> editable child object.<br/>
    /// The items of the collection are <see cref="F08Level1111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F07Level1111Coll : BusinessListBase<F07Level1111Coll, F08Level1111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="F08Level1111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_ID)
        {
            foreach (var f08Level1111 in this)
            {
                if (f08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    Remove(f08Level1111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="F08Level1111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F08Level1111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_ID)
        {
            foreach (var f08Level1111 in this)
            {
                if (f08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="F08Level1111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F08Level1111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_ID)
        {
            foreach (var f08Level1111 in this.DeletedList)
            {
                if (f08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F08Level1111"/> item of the <see cref="F07Level1111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID.</param>
        /// <returns>A <see cref="F08Level1111"/> object.</returns>
        public F08Level1111 FindF08Level1111ByParentProperties(int level_1_1_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_1_1_ID.Equals(level_1_1_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="F07Level1111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="F07Level1111Coll"/> collection.</returns>
        internal static F07Level1111Coll NewF07Level1111Coll()
        {
            return DataPortal.CreateChild<F07Level1111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F07Level1111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F07Level1111Coll"/> object.</returns>
        internal static F07Level1111Coll GetF07Level1111Coll(SafeDataReader dr)
        {
            F07Level1111Coll obj = new F07Level1111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F07Level1111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F07Level1111Coll()
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
        /// Loads all <see cref="F07Level1111Coll"/> collection items from the given SafeDataReader.
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
                Add(F08Level1111.GetF08Level1111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="F08Level1111"/> items on the F07Level1111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F05Level111Coll"/> collection.</param>
        internal void LoadItems(F05Level111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF06Level111ByParentProperties(item.larentID1);
                var rlce = obj.F07Level1111Objects.RaiseListChangedEvents;
                obj.F07Level1111Objects.RaiseListChangedEvents = false;
                obj.F07Level1111Objects.Add(item);
                obj.F07Level1111Objects.RaiseListChangedEvents = rlce;
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
