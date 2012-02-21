using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_ReChild type
    /// </summary>
    public partial interface IH05_SubContinent_ReChildDal
    {

        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the H05_SubContinent_ReChild.</returns>
        IDataReader Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new H05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        
        void Insert(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        
        void Update(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Deletes the H05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
