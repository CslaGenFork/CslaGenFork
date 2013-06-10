using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F05_SubContinent_Child type
    /// </summary>
    public partial interface IF05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new F05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Insert(int subContinent_ID1, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the F05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Update(int subContinent_ID1, string subContinent_Child_Name);

        /// <summary>
        /// Deletes the F05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
