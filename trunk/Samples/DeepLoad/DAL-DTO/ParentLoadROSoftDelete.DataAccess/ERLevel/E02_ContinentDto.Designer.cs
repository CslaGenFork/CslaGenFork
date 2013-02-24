using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E02_Continent type
    /// </summary>
    public partial class E02_ContinentDto
    {
        /// <summary>
        /// Gets or sets the Continents ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID { get; set; }

        /// <summary>
        /// Gets or sets the Continents Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name { get; set; }
    }
}
