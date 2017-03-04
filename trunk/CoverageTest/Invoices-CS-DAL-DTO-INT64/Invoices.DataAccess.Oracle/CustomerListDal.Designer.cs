using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ICustomerListDal"/>
    /// </summary>
    public partial class CustomerListDal : ICustomerListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="CustomerInfoDto"/>.</returns>
        public List<CustomerInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList();
                using (var cmd = new OracleCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <param name="name">The fetch criteria.</param>
        /// <returns>A list of <see cref="CustomerInfoDto"/>.</returns>
        public List<CustomerInfoDto> Fetch(string name)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList(name);
                using (var cmd = new OracleCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Name", name).DbType = DbType.String;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<CustomerInfoDto> LoadCollection(IDataReader data)
        {
            var customerList = new List<CustomerInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    customerList.Add(Fetch(dr));
                }
            }
            return customerList;
        }

        private CustomerInfoDto Fetch(SafeDataReader dr)
        {
            var customerInfo = new CustomerInfoDto();
            // Value properties
            customerInfo.CustomerId = dr.GetString("CustomerId");
            customerInfo.Name = dr.GetString("Name");
            customerInfo.FiscalNumber = dr.IsDBNull("FiscalNumber") ? null : dr.GetString("FiscalNumber");

            return customerInfo;
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getCustomerListInlineQuery;

        partial void GetQueryGetCustomerList();

        partial void GetQueryGetCustomerList(string name);

        #endregion

    }
}
