using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.Business.SearchObjects;
using Codisa.InterwayDocs.Rules;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// OutgoingBook (read only list).<br/>
    /// This is a generated <see cref="OutgoingBook"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="OutgoingInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class OutgoingBook : ReadOnlyBindingListBase<OutgoingBook, OutgoingInfo>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="OutgoingInfo"/> item is in the collection.
        /// </summary>
        /// <param name="registerId">The RegisterId of the item to search for.</param>
        /// <returns><c>true</c> if the OutgoingInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int registerId)
        {
            foreach (var outgoingInfo in this)
            {
                if (outgoingInfo.RegisterId == registerId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="OutgoingBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A reference to the fetched <see cref="OutgoingBook"/> collection.</returns>
        public static OutgoingBook GetOutgoingBook(OutgoingBookCriteriaGet crit)
        {
            return DataPortal.Fetch<OutgoingBook>(crit);
        }

        /// <summary>
        /// Factory method. Loads a <see cref="OutgoingBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="criteriaStartDate">The CriteriaStartDate parameter of the OutgoingBook to fetch.</param>
        /// <param name="criteriaEndDate">The CriteriaEndDate parameter of the OutgoingBook to fetch.</param>
        /// <param name="archiveLocation">The ArchiveLocation parameter of the OutgoingBook to fetch.</param>
        /// <param name="fullText">The FullText parameter of the OutgoingBook to fetch.</param>
        /// <returns>A reference to the fetched <see cref="OutgoingBook"/> collection.</returns>
        public static OutgoingBook GetOutgoingBook(SmartDate criteriaStartDate, SmartDate criteriaEndDate, string archiveLocation, string fullText)
        {
            return DataPortal.Fetch<OutgoingBook>(new OutgoingBookCriteriaGet(criteriaStartDate, criteriaEndDate, archiveLocation, fullText));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingBook"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OutgoingBook()
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
