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
    /// DAL SQL Server implementation of <see cref="ICustomerEditDal"/>
    /// </summary>
    public partial class CustomerEditDal : ICustomerEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a CustomerEdit object from the database.
        /// </summary>
        /// <param name="customerId">The fetch criteria.</param>
        /// <returns>A CustomerEditDto object.</returns>
        public CustomerEditDto Fetch(string customerId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerEdit(customerId);
                using (var cmd = new OracleCommand(getCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private CustomerEditDto Fetch(IDataReader data)
        {
            var customerEdit = new CustomerEditDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    customerEdit.CustomerId = dr.GetString("CustomerId");
                    customerEdit.Name = dr.GetString("Name");
                    customerEdit.FiscalNumber = dr.IsDBNull("FiscalNumber") ? null : dr.GetString("FiscalNumber");
                    customerEdit.AddressLine1 = dr.IsDBNull("AddressLine1") ? null : dr.GetString("AddressLine1");
                    customerEdit.AddressLine2 = dr.IsDBNull("AddressLine2") ? null : dr.GetString("AddressLine2");
                    customerEdit.ZipCode = dr.IsDBNull("ZipCode") ? null : dr.GetString("ZipCode");
                    customerEdit.State = dr.IsDBNull("State") ? null : dr.GetString("State");
                    customerEdit.Country = (byte?)dr.GetValue("Country");
                }
            }
            return customerEdit;
        }

        /// <summary>
        /// Inserts a new CustomerEdit object in the database.
        /// </summary>
        /// <param name="customerEdit">The Customer Edit DTO.</param>
        /// <returns>The new <see cref="CustomerEditDto"/>.</returns>
        public CustomerEditDto Insert(CustomerEditDto customerEdit)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryAddCustomerEdit(customerEdit);
                using (var cmd = new OracleCommand(addCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@CustomerId", customerEdit.CustomerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.Add("@Name", customerEdit.Name).DbType = DbType.String;
                    cmd.Parameters.Add("@FiscalNumber", customerEdit.FiscalNumber == null ? (object)DBNull.Value : customerEdit.FiscalNumber).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine1", customerEdit.AddressLine1 == null ? (object)DBNull.Value : customerEdit.AddressLine1).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine2", customerEdit.AddressLine2 == null ? (object)DBNull.Value : customerEdit.AddressLine2).DbType = DbType.String;
                    cmd.Parameters.Add("@ZipCode", customerEdit.ZipCode == null ? (object)DBNull.Value : customerEdit.ZipCode).DbType = DbType.String;
                    cmd.Parameters.Add("@State", customerEdit.State == null ? (object)DBNull.Value : customerEdit.State).DbType = DbType.String;
                    cmd.Parameters.Add("@Country", customerEdit.Country == null ? (object)DBNull.Value : customerEdit.Country.Value).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
            return customerEdit;
        }

        /// <summary>
        /// Updates in the database all changes made to the CustomerEdit object.
        /// </summary>
        /// <param name="customerEdit">The Customer Edit DTO.</param>
        /// <returns>The updated <see cref="CustomerEditDto"/>.</returns>
        public CustomerEditDto Update(CustomerEditDto customerEdit)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryUpdateCustomerEdit(customerEdit);
                using (var cmd = new OracleCommand(updateCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@CustomerId", customerEdit.CustomerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.Add("@Name", customerEdit.Name).DbType = DbType.String;
                    cmd.Parameters.Add("@FiscalNumber", customerEdit.FiscalNumber == null ? (object)DBNull.Value : customerEdit.FiscalNumber).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine1", customerEdit.AddressLine1 == null ? (object)DBNull.Value : customerEdit.AddressLine1).DbType = DbType.String;
                    cmd.Parameters.Add("@AddressLine2", customerEdit.AddressLine2 == null ? (object)DBNull.Value : customerEdit.AddressLine2).DbType = DbType.String;
                    cmd.Parameters.Add("@ZipCode", customerEdit.ZipCode == null ? (object)DBNull.Value : customerEdit.ZipCode).DbType = DbType.String;
                    cmd.Parameters.Add("@State", customerEdit.State == null ? (object)DBNull.Value : customerEdit.State).DbType = DbType.String;
                    cmd.Parameters.Add("@Country", customerEdit.Country == null ? (object)DBNull.Value : customerEdit.Country.Value).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("CustomerEdit");
                }
            }
            return customerEdit;
        }

        /// <summary>
        /// Deletes the CustomerEdit object from database.
        /// </summary>
        /// <param name="customerId">The delete criteria.</param>
        public void Delete(string customerId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                GetQueryDeleteCustomerEdit(customerId);
                using (var cmd = new OracleCommand(deleteCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("CustomerEdit");
                }
            }
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string addCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string updateCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string deleteCustomerEditInlineQuery;

        partial void GetQueryGetCustomerEdit(string customerId);

        partial void GetQueryAddCustomerEdit(CustomerEditDto customerEdit);

        partial void GetQueryUpdateCustomerEdit(CustomerEditDto customerEdit);

        partial void GetQueryDeleteCustomerEdit(string customerId);

        #endregion

    }
}
