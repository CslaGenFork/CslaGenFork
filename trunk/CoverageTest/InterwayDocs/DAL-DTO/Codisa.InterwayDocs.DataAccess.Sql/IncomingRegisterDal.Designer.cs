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
    /// DAL SQL Server implementation of <see cref="IIncomingRegisterDal"/>
    /// </summary>
    public partial class IncomingRegisterDal : IIncomingRegisterDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a IncomingRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A IncomingRegisterDto object.</returns>
        public IncomingRegisterDto Fetch(int registerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.GetIncomingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private IncomingRegisterDto Fetch(IDataReader data)
        {
            var incomingRegister = new IncomingRegisterDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    incomingRegister.RegisterId = dr.GetInt32("RegisterId");
                    incomingRegister.RegisterDate = dr.GetSmartDate("RegisterDate", true);
                    incomingRegister.DocumentType = dr.GetString("DocumentType");
                    incomingRegister.DocumentReference = dr.GetString("DocumentReference");
                    incomingRegister.DocumentEntity = dr.GetString("DocumentEntity");
                    incomingRegister.DocumentDept = dr.GetString("DocumentDept");
                    incomingRegister.DocumentClass = dr.GetString("DocumentClass");
                    incomingRegister.DocumentDate = dr.GetSmartDate("DocumentDate", true);
                    incomingRegister.Subject = dr.GetString("Subject");
                    incomingRegister.SenderName = dr.GetString("SenderName");
                    incomingRegister.ReceptionDate = dr.GetSmartDate("ReceptionDate", true);
                    incomingRegister.RoutedTo = dr.GetString("RoutedTo");
                    incomingRegister.Notes = dr.GetString("Notes");
                    incomingRegister.ArchiveLocation = dr.GetString("ArchiveLocation");
                    incomingRegister.CreateDate = dr.GetSmartDate("CreateDate", true);
                    incomingRegister.ChangeDate = dr.GetSmartDate("ChangeDate", true);
                }
            }
            return incomingRegister;
        }

        /// <summary>
        /// Inserts a new IncomingRegister object in the database.
        /// </summary>
        /// <param name="incomingRegister">The Incoming Register DTO.</param>
        /// <returns>The new <see cref="IncomingRegisterDto"/>.</returns>
        public IncomingRegisterDto Insert(IncomingRegisterDto incomingRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.AddIncomingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", incomingRegister.RegisterId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RegisterDate", incomingRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", incomingRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", incomingRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", incomingRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", incomingRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", incomingRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", incomingRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", incomingRegister.Subject).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderName", incomingRegister.SenderName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", incomingRegister.ReceptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RoutedTo", incomingRegister.RoutedTo).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", incomingRegister.Notes).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", incomingRegister.ArchiveLocation).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", incomingRegister.CreateDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", incomingRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.ExecuteNonQuery();
                    incomingRegister.RegisterId = (int)cmd.Parameters["@RegisterId"].Value;
                }
            }
            return incomingRegister;
        }

        /// <summary>
        /// Updates in the database all changes made to the IncomingRegister object.
        /// </summary>
        /// <param name="incomingRegister">The Incoming Register DTO.</param>
        /// <returns>The updated <see cref="IncomingRegisterDto"/>.</returns>
        public IncomingRegisterDto Update(IncomingRegisterDto incomingRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateIncomingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", incomingRegister.RegisterId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RegisterDate", incomingRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", incomingRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", incomingRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", incomingRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", incomingRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", incomingRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", incomingRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", incomingRegister.Subject).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderName", incomingRegister.SenderName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", incomingRegister.ReceptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RoutedTo", incomingRegister.RoutedTo).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", incomingRegister.Notes).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", incomingRegister.ArchiveLocation).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", incomingRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("IncomingRegister");
                }
            }
            return incomingRegister;
        }

        #endregion

    }
}
