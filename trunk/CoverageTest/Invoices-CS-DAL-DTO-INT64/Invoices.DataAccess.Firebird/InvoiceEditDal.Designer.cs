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
    /// DAL SQL Server implementation of <see cref="IInvoiceEditDal"/>
    /// </summary>
    public partial class InvoiceEditDal : IInvoiceEditDal
    {

        #region DAL methods

        private List<InvoiceLineItemDto> _invoiceLineCollection = new List<InvoiceLineItemDto>();

        /// <summary>
        /// Gets the Invoice Lines.
        /// </summary>
        /// <value>A list of <see cref="InvoiceLineItemDto"/>.</value>
        public List<InvoiceLineItemDto> InvoiceLineCollection
        {
            get { return _invoiceLineCollection; }
        }

        /// <summary>
        /// Loads a InvoiceEdit object from the database.
        /// </summary>
        /// <param name="invoiceId">The fetch criteria.</param>
        /// <returns>A InvoiceEditDto object.</returns>
        public InvoiceEditDto Fetch(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.GetInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private InvoiceEditDto Fetch(IDataReader data)
        {
            var invoiceEdit = new InvoiceEditDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    invoiceEdit.InvoiceId = dr.GetGuid("InvoiceId");
                    invoiceEdit.InvoiceNumber = dr.GetString("InvoiceNumber");
                    invoiceEdit.CustomerId = dr.GetString("CustomerId");
                    invoiceEdit.InvoiceDate = dr.GetSmartDate("InvoiceDate", true);
                    invoiceEdit.CreateDate = dr.GetSmartDate("CreateDate", true);
                    invoiceEdit.CreateUser = dr.GetInt32("CreateUser");
                    invoiceEdit.ChangeDate = dr.GetSmartDate("ChangeDate", true);
                    invoiceEdit.ChangeUser = dr.GetInt32("ChangeUser");
                    invoiceEdit.RowVersion = BitConverter.GetBytes(dr.GetDateTime("RowVersion").Ticks);
                }
                FetchChildren(dr);
            }
            return invoiceEdit;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                _invoiceLineCollection.Add(FetchInvoiceLineItem(dr));
            }
        }

        private InvoiceLineItemDto FetchInvoiceLineItem(SafeDataReader dr)
        {
            var invoiceLineItem = new InvoiceLineItemDto();
            // Value properties
            invoiceLineItem.InvoiceLineId = dr.GetGuid("InvoiceLineId");
            invoiceLineItem.ProductId = dr.GetGuid("ProductId");
            invoiceLineItem.Cost = dr.GetDecimal("Cost");
            invoiceLineItem.PercentDiscount = dr.GetByte("PercentDiscount");

            return invoiceLineItem;
        }

        /// <summary>
        /// Inserts a new InvoiceEdit object in the database.
        /// </summary>
        /// <param name="invoiceEdit">The Invoice Edit DTO.</param>
        /// <returns>The new <see cref="InvoiceEditDto"/>.</returns>
        public InvoiceEditDto Insert(InvoiceEditDto invoiceEdit)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.AddInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceEdit.InvoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceEdit.InvoiceNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", invoiceEdit.CustomerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceEdit.InvoiceDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@CreateDate", invoiceEdit.CreateDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUser", invoiceEdit.CreateUser).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", invoiceEdit.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", invoiceEdit.ChangeUser).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", FbDbType.TimeStamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    invoiceEdit.RowVersion = BitConverter.GetBytes(((DateTime)cmd.Parameters["@NewRowVersion"].Value).Ticks);
                }
            }
            return invoiceEdit;
        }

        /// <summary>
        /// Updates in the database all changes made to the InvoiceEdit object.
        /// </summary>
        /// <param name="invoiceEdit">The Invoice Edit DTO.</param>
        /// <returns>The updated <see cref="InvoiceEditDto"/>.</returns>
        public InvoiceEditDto Update(InvoiceEditDto invoiceEdit)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.UpdateInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceEdit.InvoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceEdit.InvoiceNumber).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", invoiceEdit.CustomerId).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceEdit.InvoiceDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@ChangeDate", invoiceEdit.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", invoiceEdit.ChangeUser).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", invoiceEdit.RowVersion).DbType = DbType.DateTime2;
                    cmd.Parameters.Add("@NewRowVersion", FbDbType.TimeStamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("InvoiceEdit");

                    invoiceEdit.RowVersion = BitConverter.GetBytes(((DateTime)cmd.Parameters["@NewRowVersion"].Value).Ticks);
                }
            }
            return invoiceEdit;
        }

        /// <summary>
        /// Deletes the InvoiceEdit object from database.
        /// </summary>
        /// <param name="invoiceId">The delete criteria.</param>
        public void Delete(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.DeleteInvoiceEdit", ctx.Connection))
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
