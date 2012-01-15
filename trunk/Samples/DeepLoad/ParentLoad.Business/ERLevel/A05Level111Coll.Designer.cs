using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A05Level111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="A05Level111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A04Level11"/> editable child object.<br/>
    /// The items of the collection are <see cref="A06Level111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A05Level111Coll : BusinessListBase<A05Level111Coll, A06Level111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="A06Level111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_ID)
        {
            foreach (A06Level111 a06Level111 in this)
            {
                if (a06Level111.Level_1_1_1_ID == level_1_1_1_ID)
                {
                      Remove(a06Level111);
                      break;
                }
            }
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A06Level111"/> item of the <see cref="A05Level111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID.</param>
        /// <returns>A <see cref="A06Level111"/> object.</returns>
        public A06Level111 FindA06Level111ByParentProperties(int level_1_1_1_ID)
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
        /// Factory method. Creates a new <see cref="A05Level111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="A05Level111Coll"/> collection.</returns>
        internal static A05Level111Coll NewA05Level111Coll()
        {
            return DataPortal.CreateChild<A05Level111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A05Level111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A05Level111Coll"/> object.</returns>
        internal static A05Level111Coll GetA05Level111Coll(SafeDataReader dr)
        {
            A05Level111Coll obj = new A05Level111Coll();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A05Level111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A05Level111Coll()
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
        /// Loads all <see cref="A05Level111Coll"/> collection items from the given SafeDataReader.
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
                Add(A06Level111.GetA06Level111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="A06Level111"/> items on the A05Level111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A03Level11Coll"/> collection.</param>
        internal void LoadItems(A03Level11Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA04Level11ByParentProperties(item.marentID1);
                var rlce = obj.A05Level111Objects.RaiseListChangedEvents;
                obj.A05Level111Objects.RaiseListChangedEvents = false;
                obj.A05Level111Objects.Add(item);
                obj.A05Level111Objects.RaiseListChangedEvents = rlce;
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
