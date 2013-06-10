using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_Child type
    /// </summary>
    public partial interface ID05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the D05_SubContinent_Child.</returns>
        IDataReader Fetch(int subContinent_ID1);

        /// <summary>
        /// Inserts a new D05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Insert(int subContinent_ID1, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the D05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Update(int subContinent_ID1, string subContinent_Child_Name);

        /// <summary>
        /// Deletes the D05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
