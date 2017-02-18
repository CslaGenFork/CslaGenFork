using System;
using System.Collections.Generic;
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
        /// <param name="productTypeDynaItem">The Product Type Dyna Item DTO.</param>
        /// <returns>The new <see cref="ProductTypeDynaItemDto"/>.</returns>
        ProductTypeDynaItemDto Insert(ProductTypeDynaItemDto productTypeDynaItem);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeDynaItem object.
        /// </summary>
        /// <param name="productTypeDynaItem">The Product Type Dyna Item DTO.</param>
        /// <returns>The updated <see cref="ProductTypeDynaItemDto"/>.</returns>
        ProductTypeDynaItemDto Update(ProductTypeDynaItemDto productTypeDynaItem);

        /// <summary>
        /// Deletes the ProductTypeDynaItem object from database.
        /// </summary>
        /// <param name="productTypeId">The delete criteria.</param>
        void Delete(int productTypeId);
    }
}
