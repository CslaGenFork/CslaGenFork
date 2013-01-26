using System;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for G02_Continent type
    /// </summary>
    public partial class G02_ContinentDto
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
