using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D04_SubContinent type
    /// </summary>
    public partial interface ID04_SubContinentDal
    {

        /// <summary>
        /// Inserts a new D04_SubContinent object in the database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        
        void Insert(int continent_ID, out int subContinent_ID, string subContinent_Name);

        /// <summary>
        /// Updates in the database all changes made to the D04_SubContinent object.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        
        void Update(int subContinent_ID, string subContinent_Name);

        /// <summary>
        /// Deletes the D04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
