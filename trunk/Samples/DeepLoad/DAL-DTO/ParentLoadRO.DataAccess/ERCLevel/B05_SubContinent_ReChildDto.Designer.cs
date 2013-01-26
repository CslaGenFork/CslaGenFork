using System;
using Csla;

namespace ParentLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DTO for B05_SubContinent_ReChild type
    /// </summary>
    public partial class B05_SubContinent_ReChildDto
    {
        /// <summary>
        /// Gets or sets the parent Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int Parent_SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the Sub Continent Child Name.
        /// </summary>
        /// <value>The Sub Continent Child Name.</value>
        public string SubContinent_Child_Name { get; set; }
    }
}
