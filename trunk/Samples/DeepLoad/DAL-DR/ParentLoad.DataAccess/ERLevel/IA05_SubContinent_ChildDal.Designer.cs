using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A05_SubContinent_Child type
    /// </summary>
    public partial interface IA05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new A05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <returns>The Row Version of the new A05_SubContinent_Child.</returns>
        byte[] Insert(int subContinent_ID1, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the A05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(int subContinent_ID1, string subContinent_Child_Name, byte[] rowVersion);

        /// <summary>
        /// Deletes the A05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
