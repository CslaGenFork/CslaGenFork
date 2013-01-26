using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E06_Country type
    /// </summary>
    public partial class E06_CountryDto
    {
        /// <summary>
        /// Gets or sets the parent Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int Parent_SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the 3_Countries ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the 3_Countries Name.
        /// </summary>
        /// <value>The Country Name.</value>
        public string Country_Name { get; set; }

        /// <summary>
        /// Gets or sets the ParentSubContinentID.
        /// </summary>
        /// <value>The Parent Sub Continent ID.</value>
        public int ParentSubContinentID { get; set; }

        /// <summary>
        /// Gets or sets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion { get; set; }
    }
}
