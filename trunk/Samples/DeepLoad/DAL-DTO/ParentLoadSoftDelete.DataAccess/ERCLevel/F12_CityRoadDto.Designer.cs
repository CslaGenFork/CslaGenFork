using System;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for F12_CityRoad type
    /// </summary>
    public partial class F12_CityRoadDto
    {
        /// <summary>
        /// Gets or sets the parent City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int Parent_City_ID { get; set; }

        /// <summary>
        /// Gets or sets the 6_CityRoads ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID { get; set; }

        /// <summary>
        /// Gets or sets the 6_CityRoads Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name { get; set; }
    }
}
