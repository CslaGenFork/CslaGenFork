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
    /// IncomingBook (read only list).<br/>
    /// This is a generated <see cref="IncomingBook"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="IncomingInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class IncomingBook : ReadOnlyBindingListBase<IncomingBook, IncomingInfo>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="IncomingInfo"/> item is in the collection.
        /// </summary>
        /// <param name="registerId">The RegisterId of the item to search for.</param>
        /// <returns><c>true</c> if the IncomingInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int registerId)
        {
            foreach (var incomingInfo in this)
            {
                if (incomingInfo.RegisterId == registerId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="IncomingBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A reference to the fetched <see cref="IncomingBook"/> collection.</returns>
        public static IncomingBook GetIncomingBook(IncomingBookCriteriaGet crit)
        {
            return DataPortal.Fetch<IncomingBook>(crit);
        }

        /// <summary>
        /// Factory method. Loads a <see cref="IncomingBook"/> collection, based on given parameters.
        /// </summary>
        /// <param name="criteriaStartDate">The CriteriaStartDate parameter of the IncomingBook to fetch.</param>
        /// <param name="criteriaEndDate">The CriteriaEndDate parameter of the IncomingBook to fetch.</param>
        /// <param name="archiveLocation">The ArchiveLocation parameter of the IncomingBook to fetch.</param>
        /// <param name="fullText">The FullText parameter of the IncomingBook to fetch.</param>
        /// <returns>A reference to the fetched <see cref="IncomingBook"/> collection.</returns>
        public static IncomingBook GetIncomingBook(SmartDate criteriaStartDate, SmartDate criteriaEndDate, string archiveLocation, string fullText)
        {
            return DataPortal.Fetch<IncomingBook>(new IncomingBookCriteriaGet(criteriaStartDate, criteriaEndDate, archiveLocation, fullText));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingBook"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public IncomingBook()
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
