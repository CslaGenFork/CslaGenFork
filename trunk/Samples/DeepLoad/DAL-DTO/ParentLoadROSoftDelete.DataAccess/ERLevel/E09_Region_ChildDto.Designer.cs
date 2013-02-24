using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E09_Region_Child type
    /// </summary>
    public partial class E09_Region_ChildDto
    {
        /// <summary>
        /// Gets or sets the parent Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Parent_Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the Cities Child Name.
        /// </summary>
        /// <value>The Region Child Name.</value>
        public string Region_Child_Name { get; set; }
    }
}
