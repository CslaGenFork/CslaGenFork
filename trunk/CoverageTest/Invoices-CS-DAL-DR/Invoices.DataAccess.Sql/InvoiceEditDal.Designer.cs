using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Sql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IInvoiceEditDal"/>
    /// </summary>
    public partial class InvoiceEditDal : IInvoiceEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a InvoiceEdit object from the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <returns>A data reader to the InvoiceEdit.</returns>
        public IDataReader Fetch(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new InvoiceEdit object in the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <param name="invoiceNumber">The Invoice Number.</param>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="invoiceDate">The Invoice Date.</param>
        /// <param name="createDate">The Create Date.</param>
        /// <param name="createUser">The Create User.</param>
        /// <param name="changeDate">The Change Date.</param>
        /// <param name="changeUser">The Change User.</param>
        /// <returns>The Row Version of the new InvoiceEdit.</returns>
        public byte[] Insert(Guid invoiceId, string invoiceNumber, string customerId, SmartDate invoiceDate, SmartDate createDate, int createUser, SmartDate changeDate, int changeUser)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.AddInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@CreateDate", createDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUser", createUser).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", changeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", changeUser).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the InvoiceEdit object.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <param name="invoiceNumber">The Invoice Number.</param>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="invoiceDate">The Invoice Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        /// <param name="changeUser">The Change User.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        public byte[] Update(Guid invoiceId, string invoiceNumber, string customerId, SmartDate invoiceDate, SmartDate changeDate, int changeUser, byte[] rowVersion)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@ChangeDate", changeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", changeUser).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", rowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("InvoiceEdit");

                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Deletes the InvoiceEdit object from database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        public void Delete(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.DeleteInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("InvoiceEdit");
                }
            }
        }

        #endregion

    }
}
