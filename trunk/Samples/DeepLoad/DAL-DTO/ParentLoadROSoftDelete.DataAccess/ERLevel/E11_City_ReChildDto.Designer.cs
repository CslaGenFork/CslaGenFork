using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E11_City_ReChild type
    /// </summary>
    public partial class E11_City_ReChildDto
    {
        /// <summary>
        /// Gets or sets the parent City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int Parent_City_ID { get; set; }

        /// <summary>
        /// Gets or sets the CityRoads Child Name.
        /// </summary>
        /// <value>The City Child Name.</value>
        public string City_Child_Name { get; set; }
    }
}
