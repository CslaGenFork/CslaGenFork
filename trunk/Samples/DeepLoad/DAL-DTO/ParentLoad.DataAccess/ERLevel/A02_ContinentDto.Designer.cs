using System;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for A02_Continent type
    /// </summary>
    public partial class A02_ContinentDto
    {
        /// <summary>
        /// Gets or sets the Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID { get; set; }

        /// <summary>
        /// Gets or sets the Continent Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name { get; set; }
    }
}
