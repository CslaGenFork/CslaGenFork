using System;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for H06_Country type
    /// </summary>
    public partial class H06_CountryDto
    {
        /// <summary>
        /// Gets or sets the parent Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int Parent_SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the Countries ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the Countries Name.
        /// </summary>
        /// <value>The Country Name.</value>
        public string Country_Name { get; set; }
    }
}
