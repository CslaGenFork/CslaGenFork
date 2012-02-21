using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_ReChild type
    /// </summary>
    public partial interface ID11_City_ReChildDal
    {

        /// <summary>
        /// Loads a D11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the D11_City_ReChild.</returns>
        IDataReader Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new D11_City_ReChild object in the database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        
        void Insert(int city_ID, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the D11_City_ReChild object.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        
        void Update(int city_ID, string city_Child_Name);

        /// <summary>
        /// Deletes the D11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
