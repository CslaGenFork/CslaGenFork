using System;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for C07_Country_ReChild type
    /// </summary>
    public partial class C07_Country_ReChildDto
    {
        /// <summary>
        /// Gets or sets the parent Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Parent_Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the Regions Child Name.
        /// </summary>
        /// <value>The Country Child Name.</value>
        public string Country_Child_Name { get; set; }
    }
}
