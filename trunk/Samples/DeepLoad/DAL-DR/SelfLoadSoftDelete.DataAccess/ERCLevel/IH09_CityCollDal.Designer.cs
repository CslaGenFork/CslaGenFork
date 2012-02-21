using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_CityColl type
    /// </summary>
    public partial interface IH09_CityCollDal
    {

        /// <summary>
        /// Loads a H09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        /// <returns>A data reader to the H09_CityColl.</returns>
        IDataReader Fetch(int parent_Region_ID);
    }
}
