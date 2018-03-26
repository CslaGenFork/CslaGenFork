using Codisa.InterwayDocs.Rules;

namespace Codisa.InterwayDocs.Business.SearchObjects
{
    /// <summary>
    /// Interface that defines common search criteria.
    /// </summary>
    /// <seealso cref="ICriteriaDates" />
    public interface IGenericCriteriaInformation : ICriteriaDates
    {
        /// <summary>
        /// Gets or sets the start date of the search.
        /// </summary>
        /// <value>
        /// The start date of the search.
        /// </value>
        string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the search.
        /// </summary>
        /// <value>
        /// The end date of the search.
        /// </value>
        string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the date type list.
        /// </summary>
        /// <value>
        /// The date type list.
        /// </value>
        CriteriaDateTypeList DateTypeList { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected date type.
        /// </summary>
        /// <value>
        /// The name of the selected date type.
        /// </value>
        string SelectedDateTypeName { get; set; }

        /// <summary>
        /// Gets the stored common search criteria.
        /// </summary>
        /// <param name="fastDateOptions">The fast date options.</param>
        /// <param name="commonBookCriteria">The common book criteria.</param>
        void GetCommonCriteria(FastDateOptions fastDateOptions, CommonBookCriteria commonBookCriteria);

        /// <summary>
        /// Stores the common search criteria.
        /// </summary>
        /// <param name="commonBookCriteria">The common search criteria.</param>
        void StoreCommonCriteria(CommonBookCriteria commonBookCriteria);
    }
}