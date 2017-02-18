using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeDynaItem type
    /// </summary>
    public partial interface IProductTypeDynaItemDal
    {
        /// <summary>
        /// Inserts a new ProductTypeDynaItem object in the database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Insert(out int productTypeId, string name);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeDynaItem object.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Update(int productTypeId, string name);

        /// <summary>
        /// Deletes the ProductTypeDynaItem object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        void Delete(int productTypeId);
    }
}
