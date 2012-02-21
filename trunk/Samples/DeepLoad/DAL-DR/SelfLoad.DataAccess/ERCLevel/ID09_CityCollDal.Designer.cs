using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_CityColl type
    /// </summary>
    public partial interface ID09_CityCollDal
    {

        /// <summary>
        /// Loads a D09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        /// <returns>A data reader to the D09_CityColl.</returns>
        IDataReader Fetch(int parent_Region_ID);
    }
}
