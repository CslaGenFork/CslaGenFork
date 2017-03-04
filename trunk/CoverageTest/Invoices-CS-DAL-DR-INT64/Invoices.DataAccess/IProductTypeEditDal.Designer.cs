using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeEdit type
    /// </summary>
    public partial interface IProductTypeEditDal
    {
        /// <summary>
        /// Loads a ProductTypeEdit object from the database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <returns>A data reader to the ProductTypeEdit.</returns>
        IDataReader Fetch(int productTypeId);

        /// <summary>
        /// Inserts a new ProductTypeEdit object in the database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Insert(out int productTypeId, string name);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeEdit object.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        void Update(int productTypeId, string name);

        /// <summary>
        /// Deletes the ProductTypeEdit object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        void Delete(int productTypeId);
    }
}
