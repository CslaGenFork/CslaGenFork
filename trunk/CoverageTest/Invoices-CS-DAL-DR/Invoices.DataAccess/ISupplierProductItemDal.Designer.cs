using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductItem type
    /// </summary>
    public partial interface ISupplierProductItemDal
    {
        /// <summary>
        /// Inserts a new SupplierProductItem object in the database.
        /// </summary>
        /// <param name="supplierId">The parent Supplier Id.</param>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="productId">The Product Id.</param>
        void Insert(int supplierId, out int productSupplierId, Guid productId);

        /// <summary>
        /// Updates in the database all changes made to the SupplierProductItem object.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="productId">The Product Id.</param>
        void Update(int productSupplierId, Guid productId);

        /// <summary>
        /// Deletes the SupplierProductItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        void Delete(int productSupplierId);
    }
}
