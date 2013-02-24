using System;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for C03_Continent_Child type
    /// </summary>
    public partial class C03_Continent_ChildDto
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
