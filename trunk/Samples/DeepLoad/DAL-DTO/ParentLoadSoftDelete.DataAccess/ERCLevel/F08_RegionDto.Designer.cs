using System;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for F08_Region type
    /// </summary>
    public partial class F08_RegionDto
    {
        /// <summary>
        /// Gets or sets the parent Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Parent_Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the 4_Regions ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the 4_Regions Name.
        /// </summary>
        /// <value>The Region Name.</value>
        public string Region_Name { get; set; }
    }
}
