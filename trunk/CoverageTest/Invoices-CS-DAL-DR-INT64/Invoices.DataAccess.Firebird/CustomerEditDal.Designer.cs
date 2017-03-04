using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
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
        /// <param name="customerId">The Customer Id.</param>
        /// <returns>A data reader to the CustomerEdit.</returns>
        public IDataReader Fetch(string customerId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerEdit(customerId);
                using (var cmd = new FbCommand(getCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new CustomerEdit object in the database.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="fiscalNumber">The Fiscal Number.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        public void Insert(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryAddCustomerEdit(customerId, name, fiscalNumber, addressLine1, addressLine2, zipCode, state, country);
                using (var cmd = new FbCommand(addCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FiscalNumber", fiscalNumber == null ? (object)DBNull.Value : fiscalNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", addressLine1 == null ? (object)DBNull.Value : addressLine1).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", addressLine2 == null ? (object)DBNull.Value : addressLine2).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", zipCode == null ? (object)DBNull.Value : zipCode).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", state == null ? (object)DBNull.Value : state).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", country == null ? (object)DBNull.Value : country.Value).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the CustomerEdit object.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="fiscalNumber">The Fiscal Number.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        public void Update(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryUpdateCustomerEdit(customerId, name, fiscalNumber, addressLine1, addressLine2, zipCode, state, country);
                using (var cmd = new FbCommand(updateCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FiscalNumber", fiscalNumber == null ? (object)DBNull.Value : fiscalNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", addressLine1 == null ? (object)DBNull.Value : addressLine1).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", addressLine2 == null ? (object)DBNull.Value : addressLine2).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", zipCode == null ? (object)DBNull.Value : zipCode).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", state == null ? (object)DBNull.Value : state).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", country == null ? (object)DBNull.Value : country.Value).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("CustomerEdit");
                }
            }
        }

        /// <summary>
        /// Deletes the CustomerEdit object from database.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        public void Delete(string customerId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryDeleteCustomerEdit(customerId);
                using (var cmd = new FbCommand(deleteCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
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

        partial void GetQueryAddCustomerEdit(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country);

        partial void GetQueryUpdateCustomerEdit(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country);

        partial void GetQueryDeleteCustomerEdit(string customerId);

        #endregion

    }
}
