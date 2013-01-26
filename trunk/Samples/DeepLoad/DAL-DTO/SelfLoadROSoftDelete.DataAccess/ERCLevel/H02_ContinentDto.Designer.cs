using System;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for H02_Continent type
    /// </summary>
    public partial class H02_ContinentDto
    {
        /// <summary>
        /// Gets or sets the 1_Continents ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID { get; set; }

        /// <summary>
        /// Gets or sets the 1_Continents Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name { get; set; }
    }
}
