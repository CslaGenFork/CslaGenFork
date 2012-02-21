using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_CityColl type
    /// </summary>
    public partial interface IC09_CityCollDal
    {

        /// <summary>
        /// Loads a C09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        /// <returns>A data reader to the C09_CityColl.</returns>
        IDataReader Fetch(int parent_Region_ID);
    }
}
