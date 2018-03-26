using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.DataAccess.Sql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IDeliveryRegisterDal"/>
    /// </summary>
    public partial class DeliveryRegisterDal : IDeliveryRegisterDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a DeliveryRegister object from the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <returns>A data reader to the DeliveryRegister.</returns>
        public IDataReader Fetch(int registerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.GetDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new DeliveryRegister object in the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="recipientName">The Recipient Name.</param>
        /// <param name="expeditorName">The Expeditor Name.</param>
        /// <param name="receptionName">The Reception Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="createDate">The Create Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        public void Insert(out int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string recipientName, string expeditorName, string receptionName, SmartDate receptionDate, SmartDate createDate, SmartDate changeDate)
        {
            registerId = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.AddDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RegisterDate", registerDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", documentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", documentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", documentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", documentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", documentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", documentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", recipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ExpeditorName", expeditorName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionName", receptionName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", receptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@CreateDate", createDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", changeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.ExecuteNonQuery();
                    registerId = (int)cmd.Parameters["@RegisterId"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the DeliveryRegister object.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="recipientName">The Recipient Name.</param>
        /// <param name="expeditorName">The Expeditor Name.</param>
        /// <param name="receptionName">The Reception Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        public void Update(int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string recipientName, string expeditorName, string receptionName, SmartDate receptionDate, SmartDate changeDate)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RegisterDate", registerDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", documentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", documentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", documentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", documentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", documentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", documentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", recipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ExpeditorName", expeditorName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionName", receptionName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", receptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@ChangeDate", changeDate.DBValue).DbType = DbType.DateTime2;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("DeliveryRegister");
                }
            }
        }

        #endregion

    }
}
