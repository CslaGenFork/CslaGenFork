using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeItem type
    /// </summary>
    public partial interface IProductTypeItemDal
    {
        /// <summary>
        /// Inserts a new ProductTypeItem object in the database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Insert(out int productTypeId, string name);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeItem object.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Update(int productTypeId, string name);

        /// <summary>
        /// Deletes the ProductTypeItem object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        void Delete(int productTypeId);
    }
}
