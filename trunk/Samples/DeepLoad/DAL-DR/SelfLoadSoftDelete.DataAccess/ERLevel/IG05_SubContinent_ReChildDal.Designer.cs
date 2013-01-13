using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_ReChild type
    /// </summary>
    public partial interface IG05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the G05_SubContinent_ReChild.</returns>
        IDataReader Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new G05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <returns>The Row Version of the new G05_SubContinent_ReChild.</returns>
        byte[] Insert(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(int subContinent_ID, string subContinent_Child_Name, byte[] rowVersion);

        /// <summary>
        /// Deletes the G05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
