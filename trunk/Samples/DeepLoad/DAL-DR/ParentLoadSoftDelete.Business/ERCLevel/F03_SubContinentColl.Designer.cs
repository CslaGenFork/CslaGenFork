using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03_SubContinentColl (editable child list).<br/>
    /// This is a generated base class of <see cref="F03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F02_Continent"/> editable child object.<br/>
    /// The items of the collection are <see cref="F04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F03_SubContinentColl : BusinessListBase<F03_SubContinentColl, F04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="F04_SubContinent"/> item from the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to be removed.</param>
        public void Remove(int subContinent_ID)
        {
            foreach (var f04_SubContinent in this)
            {
                if (f04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    Remove(f04_SubContinent);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="F04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var f04_SubContinent in this)
            {
                if (f04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="F04_SubContinent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F04_SubContinent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int subContinent_ID)
        {
            foreach (var f04_SubContinent in DeletedList)
            {
                if (f04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F04_SubContinent"/> item of the <see cref="F03_SubContinentColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID.</param>
        /// <returns>A <see cref="F04_SubContinent"/> object.</returns>
        public F04_SubContinent FindF04_SubContinentByParentProperties(int subContinent_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].SubContinent_ID.Equals(subContinent_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="F03_SubContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="F03_SubContinentColl"/> collection.</returns>
        internal static F03_SubContinentColl NewF03_SubContinentColl()
        {
            return DataPortal.CreateChild<F03_SubContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F03_SubContinentColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F03_SubContinentColl"/> object.</returns>
        internal static F03_SubContinentColl GetF03_SubContinentColl(SafeDataReader dr)
        {
            F03_SubContinentColl obj = new F03_SubContinentColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F03_SubContinentColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads all <see cref="F03_SubContinentColl"/> collection items from the given SafeDataReader.
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
                Add(F04_SubContinent.GetF04_SubContinent(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="F04_SubContinent"/> items on the F03_SubContinentObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F01_ContinentColl"/> collection.</param>
        internal void LoadItems(F01_ContinentColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF02_ContinentByParentProperties(item.parent_Continent_ID);
                var rlce = obj.F03_SubContinentObjects.RaiseListChangedEvents;
                obj.F03_SubContinentObjects.RaiseListChangedEvents = false;
                obj.F03_SubContinentObjects.Add(item);
                obj.F03_SubContinentObjects.RaiseListChangedEvents = rlce;
            }
        }

        #endregion

        #region DataPortal Hooks

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
