namespace Codisa.InterwayDocs.Business.SearchObjects
{
    /// <summary>
    /// Describe common search criteria for use by implementations of <see cref="Rules.ICriteriaDates"/>
    /// </summary>
    public class CommonBookCriteria
    {
        #region Business Properties

        /// <summary>
        /// Gets or sets the start dateof the search.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the search.
        /// </summary>
        /// <value>The end date.</value>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Full Text to search for.
        /// </summary>
        /// <value>The Full Text.</value>
        public string FullText { get; set; }

        /// <summary>
        /// Gets or sets the index fast date to use (combo box).
        /// </summary>
        /// <value>The fast date index.</value>
        public int SelectedFastDateIndex { get; set; }

        /// <summary>
        /// Gets or sets the index on the date type to use (combo box).
        /// </summary>
        /// <value>The date type index.</value>
        public int SelectedDateTypeIndex { get; set; }

        /// <summary>
        /// Gets or sets the Archive Location where to search.
        /// </summary>
        /// <value>The Archive Location.</value>
        public string ArchiveLocation { get; set; }

        #endregion
    }
}