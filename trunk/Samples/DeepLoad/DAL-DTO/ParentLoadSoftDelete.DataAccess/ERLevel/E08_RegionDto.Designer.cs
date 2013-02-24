using System;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E08_Region type
    /// </summary>
    public partial class E08_RegionDto
    {
        /// <summary>
        /// Gets or sets the parent Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Parent_Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the Regions ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the Regions Name.
        /// </summary>
        /// <value>The Region Name.</value>
        public string Region_Name { get; set; }
    }
}
