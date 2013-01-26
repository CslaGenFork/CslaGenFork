using System;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for B10_City type
    /// </summary>
    public partial class B10_CityDto
    {
        /// <summary>
        /// Gets or sets the parent Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Parent_Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int City_ID { get; set; }

        /// <summary>
        /// Gets or sets the City Name.
        /// </summary>
        /// <value>The City Name.</value>
        public string City_Name { get; set; }
    }
}
