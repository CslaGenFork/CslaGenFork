using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E11_City_ReChild type
    /// </summary>
    public partial interface IE11_City_ReChildDal
    {

        /// <summary>
        /// Inserts a new E11_City_ReChild object in the database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        
        void Insert(int city_ID, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the E11_City_ReChild object.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        
        void Update(int city_ID, string city_Child_Name);

        /// <summary>
        /// Deletes the E11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
