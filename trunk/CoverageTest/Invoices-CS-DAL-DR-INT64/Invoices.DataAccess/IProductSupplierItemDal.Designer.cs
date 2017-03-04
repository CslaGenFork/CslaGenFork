using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductSupplierItem type
    /// </summary>
    public partial interface IProductSupplierItemDal
    {
        /// <summary>
        /// Inserts a new ProductSupplierItem object in the database.
        /// </summary>
        /// <param name="productId">The parent Product Id.</param>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="supplierId">The Supplier Id.</param>
        void Insert(Guid productId, out int productSupplierId, int supplierId);

        /// <summary>
        /// Updates in the database all changes made to the ProductSupplierItem object.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="supplierId">The Supplier Id.</param>
        void Update(int productSupplierId, int supplierId);

        /// <summary>
        /// Deletes the ProductSupplierItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        void Delete(int productSupplierId);
    }
}
