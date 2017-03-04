using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierListDal"/>
    /// </summary>
    public partial class SupplierListDal : ISupplierListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="SupplierInfoDto"/>.</returns>
        public List<SupplierInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryGetSupplierList();
                using (var cmd = new FbCommand(getSupplierListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        /// <summary>
        /// Loads a SupplierList collection from the database.
        /// </summary>
        /// <param name="name">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierInfoDto"/>.</returns>
        public List<SupplierInfoDto> Fetch(string name)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryGetSupplierListByName(name);
                using (var cmd = new FbCommand(getSupplierListByNameInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<SupplierInfoDto> LoadCollection(IDataReader data)
        {
            var supplierList = new List<SupplierInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    supplierList.Add(Fetch(dr));
                }
            }
            return supplierList;
        }

        private SupplierInfoDto Fetch(SafeDataReader dr)
        {
            var supplierInfo = new SupplierInfoDto();
            // Value properties
            supplierInfo.SupplierId = dr.GetInt32("SupplierId");
            supplierInfo.Name = dr.GetString("Name");

            return supplierInfo;
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getSupplierListInlineQuery;

        [NotUndoable, NonSerialized]
        private string getSupplierListByNameInlineQuery;

        partial void GetQueryGetSupplierList();

        partial void GetQueryGetSupplierListByName(string name);

        #endregion

    }
}
