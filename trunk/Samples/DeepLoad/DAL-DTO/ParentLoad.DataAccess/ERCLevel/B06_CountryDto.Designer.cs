using System;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for B06_Country type
    /// </summary>
    public partial class B06_CountryDto
    {
        /// <summary>
        /// Gets or sets the parent Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int Parent_SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the Country Name.
        /// </summary>
        /// <value>The Country Name.</value>
        public string Country_Name { get; set; }
    }
}
