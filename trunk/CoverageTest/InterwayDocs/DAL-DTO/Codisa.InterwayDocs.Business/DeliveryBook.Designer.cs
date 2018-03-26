using System;
using System.Collections.Generic;
using Csla;
using Codisa.InterwayDocs.Business.SearchObjects;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// DeliveryBook (read only list).<br/>
    /// This is a generated <see cref="DeliveryBook"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DeliveryInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class DeliveryBook : ReadOnlyBindingListBase<DeliveryBook, DeliveryInfo>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DeliveryInfo"/> item is in the collection.
        /// </summary>
        /// <param name="registerId">The RegisterId of the item to search for.</param>
        /// <returns><c>true</c> if the DeliveryInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int registerId)
        {
            foreach (var deliveryInfo in this)
            {
                if (deliveryInfo.RegisterId == registerId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DeliveryBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A reference to the fetched <see cref="DeliveryBook"/> collection.</returns>
        public static DeliveryBook GetDeliveryBook(DeliveryBookCriteriaGet crit)
        {
            return DataPortal.Fetch<DeliveryBook>(crit);
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DeliveryBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="criteriaStartDate">The CriteriaStartDate parameter of the DeliveryBook to fetch.</param>
        /// <param name="criteriaEndDate">The CriteriaEndDate parameter of the DeliveryBook to fetch.</param>
        /// <param name="fullText">The FullText parameter of the DeliveryBook to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DeliveryBook"/> collection.</returns>
        public static DeliveryBook GetDeliveryBook(SmartDate criteriaStartDate, SmartDate criteriaEndDate, string fullText)
        {
            return DataPortal.Fetch<DeliveryBook>(new DeliveryBookCriteriaGet(criteriaStartDate, criteriaEndDate, fullText));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryBook"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DeliveryBook()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

    }
}
