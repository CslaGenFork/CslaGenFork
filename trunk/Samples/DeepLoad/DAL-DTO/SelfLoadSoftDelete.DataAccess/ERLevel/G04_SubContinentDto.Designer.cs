using System;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for G04_SubContinent type
    /// </summary>
    public partial class G04_SubContinentDto
    {
        /// <summary>
        /// Gets or sets the parent Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Parent_Continent_ID { get; set; }

        /// <summary>
        /// Gets or sets the SubContinents ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the SubContinents Name.
        /// </summary>
        /// <value>The Sub Continent Name.</value>
        public string SubContinent_Name { get; set; }
    }
}
