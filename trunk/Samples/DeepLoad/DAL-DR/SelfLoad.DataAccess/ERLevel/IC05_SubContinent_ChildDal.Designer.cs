using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_Child type
    /// </summary>
    public partial interface IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the C05_SubContinent_Child.</returns>
        IDataReader Fetch(int subContinent_ID1);

        /// <summary>
        /// Inserts a new C05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <returns>The Row Version of the new C05_SubContinent_Child.</returns>
        byte[] Insert(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the C05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(int subContinent_ID, string subContinent_Child_Name, int subContinent_ID1, byte[] rowVersion);

        /// <summary>
        /// Deletes the C05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
