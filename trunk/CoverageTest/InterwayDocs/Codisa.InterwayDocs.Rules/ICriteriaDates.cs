using Csla;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Interface that defines search criteria.
    /// </summary>
    public interface ICriteriaDates
    {
        /// <summary>
        /// Gets or sets the criteria start date of the search.
        /// </summary>
        /// <value>
        /// The criteria start date of the search.
        /// </value>
        SmartDate CriteriaStartDate { get; set; }

        /// <summary>
        /// Gets or sets the criteria end date of the search.
        /// </summary>
        /// <value>
        /// The criteria end date of the search.
        /// </value>
        SmartDate CriteriaEndDate { get; set; }

        /// <summary>
        /// Gets or sets the full text.
        /// </summary>
        /// <value>
        /// The full text.
        /// </value>
        string FullText { get; set; }

        /// <summary>
        /// Gets or sets the index of the selected fast date.
        /// </summary>
        /// <value>
        /// The index of the selected fast date.
        /// </value>
        int SelectedFastDateIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the selected date type.
        /// </summary>
        /// <value>
        /// The index of the selected date type.
        /// </value>
        int SelectedDateTypeIndex { get; set; }
    }
}