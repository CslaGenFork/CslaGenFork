using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03Level11Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="F03Level11Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F02Level1"/> editable child object.<br/>
    /// The items of the collection are <see cref="F04Level11"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F03Level11Coll : BusinessListBase<F03Level11Coll, F04Level11>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="F04Level11"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_ID)
        {
            foreach (var f04Level11 in this)
            {
                if (f04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    Remove(f04Level11);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="F04Level11"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F04Level11 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_ID)
        {
            foreach (var f04Level11 in this)
            {
                if (f04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="F04Level11"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F04Level11 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_ID)
        {
            foreach (var f04Level11 in this.DeletedList)
            {
                if (f04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F04Level11"/> item of the <see cref="F03Level11Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID.</param>
        /// <returns>A <see cref="F04Level11"/> object.</returns>
        public F04Level11 FindF04Level11ByParentProperties(int level_1_1_ID)
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
        /// Factory method. Creates a new <see cref="F03Level11Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="F03Level11Coll"/> collection.</returns>
        internal static F03Level11Coll NewF03Level11Coll()
        {
            return DataPortal.CreateChild<F03Level11Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F03Level11Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F03Level11Coll"/> object.</returns>
        internal static F03Level11Coll GetF03Level11Coll(SafeDataReader dr)
        {
            F03Level11Coll obj = new F03Level11Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03Level11Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F03Level11Coll()
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
        /// Loads all <see cref="F03Level11Coll"/> collection items from the given SafeDataReader.
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
                Add(F04Level11.GetF04Level11(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="F04Level11"/> items on the F03Level11Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F01Level1Coll"/> collection.</param>
        internal void LoadItems(F01Level1Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF02Level1ByParentProperties(item.parentID1);
                var rlce = obj.F03Level11Objects.RaiseListChangedEvents;
                obj.F03Level11Objects.RaiseListChangedEvents = false;
                obj.F03Level11Objects.Add(item);
                obj.F03Level11Objects.RaiseListChangedEvents = rlce;
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
