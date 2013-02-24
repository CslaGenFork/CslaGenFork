using System;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for C11_City_Child type
    /// </summary>
    public partial class C11_City_ChildDto
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
