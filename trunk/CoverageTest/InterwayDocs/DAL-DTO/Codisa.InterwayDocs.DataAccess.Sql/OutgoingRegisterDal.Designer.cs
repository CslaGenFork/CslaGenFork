using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.DataAccess.Sql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IOutgoingRegisterDal"/>
    /// </summary>
    public partial class OutgoingRegisterDal : IOutgoingRegisterDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a OutgoingRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A OutgoingRegisterDto object.</returns>
        public OutgoingRegisterDto Fetch(int registerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.GetOutgoingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private OutgoingRegisterDto Fetch(IDataReader data)
        {
            var outgoingRegister = new OutgoingRegisterDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    outgoingRegister.RegisterId = dr.GetInt32("RegisterId");
                    outgoingRegister.RegisterDate = dr.GetSmartDate("RegisterDate", true);
                    outgoingRegister.DocumentType = dr.GetString("DocumentType");
                    outgoingRegister.DocumentReference = dr.GetString("DocumentReference");
                    outgoingRegister.DocumentEntity = dr.GetString("DocumentEntity");
                    outgoingRegister.DocumentDept = dr.GetString("DocumentDept");
                    outgoingRegister.DocumentClass = dr.GetString("DocumentClass");
                    outgoingRegister.DocumentDate = dr.GetSmartDate("DocumentDate", true);
                    outgoingRegister.Subject = dr.GetString("Subject");
                    outgoingRegister.SendDate = dr.GetSmartDate("SendDate", true);
                    outgoingRegister.RecipientName = dr.GetString("RecipientName");
                    outgoingRegister.RecipientTown = dr.GetString("RecipientTown");
                    outgoingRegister.Notes = dr.GetString("Notes");
                    outgoingRegister.ArchiveLocation = dr.GetString("ArchiveLocation");
                    outgoingRegister.CreateDate = dr.GetSmartDate("CreateDate", true);
                    outgoingRegister.ChangeDate = dr.GetSmartDate("ChangeDate", true);
                }
            }
            return outgoingRegister;
        }

        /// <summary>
        /// Inserts a new OutgoingRegister object in the database.
        /// </summary>
        /// <param name="outgoingRegister">The Outgoing Register DTO.</param>
        /// <returns>The new <see cref="OutgoingRegisterDto"/>.</returns>
        public OutgoingRegisterDto Insert(OutgoingRegisterDto outgoingRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.AddOutgoingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", outgoingRegister.RegisterId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RegisterDate", outgoingRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", outgoingRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", outgoingRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", outgoingRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", outgoingRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", outgoingRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", outgoingRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", outgoingRegister.Subject).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SendDate", outgoingRegister.SendDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", outgoingRegister.RecipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RecipientTown", outgoingRegister.RecipientTown).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", outgoingRegister.Notes).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", outgoingRegister.ArchiveLocation).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", outgoingRegister.CreateDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", outgoingRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.ExecuteNonQuery();
                    outgoingRegister.RegisterId = (int)cmd.Parameters["@RegisterId"].Value;
                }
            }
            return outgoingRegister;
        }

        /// <summary>
        /// Updates in the database all changes made to the OutgoingRegister object.
        /// </summary>
        /// <param name="outgoingRegister">The Outgoing Register DTO.</param>
        /// <returns>The updated <see cref="OutgoingRegisterDto"/>.</returns>
        public OutgoingRegisterDto Update(OutgoingRegisterDto outgoingRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateOutgoingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", outgoingRegister.RegisterId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RegisterDate", outgoingRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", outgoingRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", outgoingRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", outgoingRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", outgoingRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", outgoingRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", outgoingRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", outgoingRegister.Subject).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SendDate", outgoingRegister.SendDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", outgoingRegister.RecipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RecipientTown", outgoingRegister.RecipientTown).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", outgoingRegister.Notes).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", outgoingRegister.ArchiveLocation).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", outgoingRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("OutgoingRegister");
                }
            }
            return outgoingRegister;
        }

        #endregion

    }
}
