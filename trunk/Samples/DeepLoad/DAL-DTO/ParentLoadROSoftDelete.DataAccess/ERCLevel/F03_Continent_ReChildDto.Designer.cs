using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for F03_Continent_ReChild type
    /// </summary>
    public partial class F03_Continent_ReChildDto
    {
        /// <summary>
        /// Gets or sets the parent Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Parent_Continent_ID { get; set; }

        /// <summary>
        /// Gets or sets the SubContinents Child Name.
        /// </summary>
        /// <value>The Continent Child Name.</value>
        public string Continent_Child_Name { get; set; }
    }
}
