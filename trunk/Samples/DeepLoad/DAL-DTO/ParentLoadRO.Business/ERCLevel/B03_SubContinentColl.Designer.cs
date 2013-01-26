using System;
using System.Collections.Generic;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B03_SubContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="B03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B02_Continent"/> read only object.<br/>
    /// The items of the collection are <see cref="B04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B03_SubContinentColl : ReadOnlyListBase<B03_SubContinentColl, B04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="B04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var b04_SubContinent in this)
            {
                if (b04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B04_SubContinent"/> item of the <see cref="B03_SubContinentColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID.</param>
        /// <returns>A <see cref="B04_SubContinent"/> object.</returns>
        public B04_SubContinent FindB04_SubContinentByParentProperties(int subContinent_ID)
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
        /// Factory method. Loads a <see cref="B03_SubContinentColl"/> object from the given list of B04_SubContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B03_SubContinentColl"/> object.</returns>
        internal static B03_SubContinentColl GetB03_SubContinentColl(List<B04_SubContinentDto> data)
        {
            B03_SubContinentColl obj = new B03_SubContinentColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal B03_SubContinentColl()
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
        /// Loads all <see cref="B03_SubContinentColl"/> collection items from the given list of B04_SubContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B04_SubContinentDto"/>.</param>
        private void Fetch(List<B04_SubContinentDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(B04_SubContinent.GetB04_SubContinent(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="B04_SubContinent"/> items on the B03_SubContinentObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B01_ContinentColl"/> collection.</param>
        internal void LoadItems(B01_ContinentColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB02_ContinentByParentProperties(item.parent_Continent_ID);
                obj.B03_SubContinentObjects.IsReadOnly = false;
                var rlce = obj.B03_SubContinentObjects.RaiseListChangedEvents;
                obj.B03_SubContinentObjects.RaiseListChangedEvents = false;
                obj.B03_SubContinentObjects.Add(item);
                obj.B03_SubContinentObjects.RaiseListChangedEvents = rlce;
                obj.B03_SubContinentObjects.IsReadOnly = true;
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
