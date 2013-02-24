using System;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for H12_CityRoad type
    /// </summary>
    public partial class H12_CityRoadDto
    {
        /// <summary>
        /// Gets or sets the parent City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int Parent_City_ID { get; set; }

        /// <summary>
        /// Gets or sets the CityRoads ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID { get; set; }

        /// <summary>
        /// Gets or sets the CityRoads Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name { get; set; }
    }
}
