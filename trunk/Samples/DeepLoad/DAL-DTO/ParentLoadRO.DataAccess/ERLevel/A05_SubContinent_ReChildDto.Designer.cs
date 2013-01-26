using System;
using Csla;

namespace ParentLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for A05_SubContinent_ReChild type
    /// </summary>
    public partial class A05_SubContinent_ReChildDto
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

        /// <summary>
        /// Gets or sets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion { get; set; }
    }
}
