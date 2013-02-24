using System;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for D02_Continent type
    /// </summary>
    public partial class D02_ContinentDto
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
