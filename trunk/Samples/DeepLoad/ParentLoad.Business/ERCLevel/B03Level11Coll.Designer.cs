using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B03Level11Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="B03Level11Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B02Level1"/> editable child object.<br/>
    /// The items of the collection are <see cref="B04Level11"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B03Level11Coll : BusinessListBase<B03Level11Coll, B04Level11>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="B04Level11"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_ID)
        {
            foreach (var b04Level11 in this)
            {
                if (b04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    Remove(b04Level11);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="B04Level11"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B04Level11 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_ID)
        {
            foreach (var b04Level11 in this)
            {
                if (b04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="B04Level11"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B04Level11 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_ID)
        {
            foreach (var b04Level11 in this.DeletedList)
            {
                if (b04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B04Level11"/> item of the <see cref="B03Level11Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID.</param>
        /// <returns>A <see cref="B04Level11"/> object.</returns>
        public B04Level11 FindB04Level11ByParentProperties(int level_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_ID.Equals(level_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B03Level11Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="B03Level11Coll"/> collection.</returns>
        internal static B03Level11Coll NewB03Level11Coll()
        {
            return DataPortal.CreateChild<B03Level11Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B03Level11Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B03Level11Coll"/> object.</returns>
        internal static B03Level11Coll GetB03Level11Coll(SafeDataReader dr)
        {
            B03Level11Coll obj = new B03Level11Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B03Level11Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B03Level11Coll()
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
        /// Loads all <see cref="B03Level11Coll"/> collection items from the given SafeDataReader.
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
                Add(B04Level11.GetB04Level11(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="B04Level11"/> items on the B03Level11Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B01Level1Coll"/> collection.</param>
        internal void LoadItems(B01Level1Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB02Level1ByParentProperties(item.parentID1);
                var rlce = obj.B03Level11Objects.RaiseListChangedEvents;
                obj.B03Level11Objects.RaiseListChangedEvents = false;
                obj.B03Level11Objects.Add(item);
                obj.B03Level11Objects.RaiseListChangedEvents = rlce;
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
