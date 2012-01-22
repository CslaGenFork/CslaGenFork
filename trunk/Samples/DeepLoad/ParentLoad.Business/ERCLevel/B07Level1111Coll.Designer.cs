using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B07Level1111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="B07Level1111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B06Level111"/> editable child object.<br/>
    /// The items of the collection are <see cref="B08Level1111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B07Level1111Coll : BusinessListBase<B07Level1111Coll, B08Level1111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="B08Level1111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_ID)
        {
            foreach (var b08Level1111 in this)
            {
                if (b08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    Remove(b08Level1111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="B08Level1111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B08Level1111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_ID)
        {
            foreach (var b08Level1111 in this)
            {
                if (b08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="B08Level1111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B08Level1111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_ID)
        {
            foreach (var b08Level1111 in this.DeletedList)
            {
                if (b08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B08Level1111"/> item of the <see cref="B07Level1111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID.</param>
        /// <returns>A <see cref="B08Level1111"/> object.</returns>
        public B08Level1111 FindB08Level1111ByParentProperties(int level_1_1_1_1_ID)
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
        /// Factory method. Creates a new <see cref="B07Level1111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="B07Level1111Coll"/> collection.</returns>
        internal static B07Level1111Coll NewB07Level1111Coll()
        {
            return DataPortal.CreateChild<B07Level1111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B07Level1111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B07Level1111Coll"/> object.</returns>
        internal static B07Level1111Coll GetB07Level1111Coll(SafeDataReader dr)
        {
            B07Level1111Coll obj = new B07Level1111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B07Level1111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B07Level1111Coll()
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
        /// Loads all <see cref="B07Level1111Coll"/> collection items from the given SafeDataReader.
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
                Add(B08Level1111.GetB08Level1111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="B08Level1111"/> items on the B07Level1111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B05Level111Coll"/> collection.</param>
        internal void LoadItems(B05Level111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB06Level111ByParentProperties(item.larentID1);
                var rlce = obj.B07Level1111Objects.RaiseListChangedEvents;
                obj.B07Level1111Objects.RaiseListChangedEvents = false;
                obj.B07Level1111Objects.Add(item);
                obj.B07Level1111Objects.RaiseListChangedEvents = rlce;
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
