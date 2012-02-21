using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03_SubContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="F03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F02_Continent"/> read only object.<br/>
    /// The items of the collection are <see cref="F04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F03_SubContinentColl : ReadOnlyListBase<F03_SubContinentColl, F04_SubContinent>
    {

        #region Collection Business Methods

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
        /// Factory method. Loads a <see cref="F03_SubContinentColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F03_SubContinentColl"/> object.</returns>
        internal static F03_SubContinentColl GetF03_SubContinentColl(SafeDataReader dr)
        {
            F03_SubContinentColl obj = new F03_SubContinentColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F03_SubContinentColl()
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
        /// Loads all <see cref="F03_SubContinentColl"/> collection items from the given SafeDataReader.
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
                Add(F04_SubContinent.GetF04_SubContinent(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
                obj.F03_SubContinentObjects.IsReadOnly = false;
                var rlce = obj.F03_SubContinentObjects.RaiseListChangedEvents;
                obj.F03_SubContinentObjects.RaiseListChangedEvents = false;
                obj.F03_SubContinentObjects.Add(item);
                obj.F03_SubContinentObjects.RaiseListChangedEvents = rlce;
                obj.F03_SubContinentObjects.IsReadOnly = true;
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
