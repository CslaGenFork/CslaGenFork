using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_CityColl type
    /// </summary>
    public partial interface IG09_CityCollDal
    {
        /// <summary>
        /// Loads a G09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        /// <returns>A data reader to the G09_CityColl.</returns>
        IDataReader Fetch(int parent_Region_ID);
    }
}
