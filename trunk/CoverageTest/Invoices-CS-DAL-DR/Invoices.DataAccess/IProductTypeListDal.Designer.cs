using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeList type
    /// </summary>
    public partial interface IProductTypeListDal
    {
        /// <summary>
        /// Loads a ProductTypeList collection from the database.
        /// </summary>
        /// <returns>A data reader to the ProductTypeList.</returns>
        IDataReader Fetch();
    }
}
