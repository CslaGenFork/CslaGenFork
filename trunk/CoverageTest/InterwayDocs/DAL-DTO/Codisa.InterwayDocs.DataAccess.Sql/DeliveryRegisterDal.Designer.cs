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
    /// DAL SQL Server implementation of <see cref="IDeliveryRegisterDal"/>
    /// </summary>
    public partial class DeliveryRegisterDal : IDeliveryRegisterDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a DeliveryRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A DeliveryRegisterDto object.</returns>
        public DeliveryRegisterDto Fetch(int registerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.GetDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private DeliveryRegisterDto Fetch(IDataReader data)
        {
            var deliveryRegister = new DeliveryRegisterDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    deliveryRegister.RegisterId = dr.GetInt32("RegisterId");
                    deliveryRegister.RegisterDate = dr.GetSmartDate("RegisterDate", true);
                    deliveryRegister.DocumentType = dr.GetString("DocumentType");
                    deliveryRegister.DocumentReference = dr.GetString("DocumentReference");
                    deliveryRegister.DocumentEntity = dr.GetString("DocumentEntity");
                    deliveryRegister.DocumentDept = dr.GetString("DocumentDept");
                    deliveryRegister.DocumentClass = dr.GetString("DocumentClass");
                    deliveryRegister.DocumentDate = dr.GetSmartDate("DocumentDate", true);
                    deliveryRegister.RecipientName = dr.GetString("RecipientName");
                    deliveryRegister.ExpeditorName = dr.GetString("ExpeditorName");
                    deliveryRegister.ReceptionName = dr.GetString("ReceptionName");
                    deliveryRegister.ReceptionDate = dr.GetSmartDate("ReceptionDate", true);
                    deliveryRegister.CreateDate = dr.GetSmartDate("CreateDate", true);
                    deliveryRegister.ChangeDate = dr.GetSmartDate("ChangeDate", true);
                }
            }
            return deliveryRegister;
        }

        /// <summary>
        /// Inserts a new DeliveryRegister object in the database.
        /// </summary>
        /// <param name="deliveryRegister">The Delivery Register DTO.</param>
        /// <returns>The new <see cref="DeliveryRegisterDto"/>.</returns>
        public DeliveryRegisterDto Insert(DeliveryRegisterDto deliveryRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.AddDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", deliveryRegister.RegisterId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RegisterDate", deliveryRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", deliveryRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", deliveryRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", deliveryRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", deliveryRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", deliveryRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", deliveryRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", deliveryRegister.RecipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ExpeditorName", deliveryRegister.ExpeditorName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionName", deliveryRegister.ReceptionName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", deliveryRegister.ReceptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@CreateDate", deliveryRegister.CreateDate.DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", deliveryRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    cmd.ExecuteNonQuery();
                    deliveryRegister.RegisterId = (int)cmd.Parameters["@RegisterId"].Value;
                }
            }
            return deliveryRegister;
        }

        /// <summary>
        /// Updates in the database all changes made to the DeliveryRegister object.
        /// </summary>
        /// <param name="deliveryRegister">The Delivery Register DTO.</param>
        /// <returns>The updated <see cref="DeliveryRegisterDto"/>.</returns>
        public DeliveryRegisterDto Update(DeliveryRegisterDto deliveryRegister)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InterwayDocs"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateDeliveryRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", deliveryRegister.RegisterId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RegisterDate", deliveryRegister.RegisterDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", deliveryRegister.DocumentType).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", deliveryRegister.DocumentReference).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", deliveryRegister.DocumentEntity).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", deliveryRegister.DocumentDept).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", deliveryRegister.DocumentClass).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", deliveryRegister.DocumentDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RecipientName", deliveryRegister.RecipientName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ExpeditorName", deliveryRegister.ExpeditorName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionName", deliveryRegister.ReceptionName).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", deliveryRegister.ReceptionDate.DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@ChangeDate", deliveryRegister.ChangeDate.DBValue).DbType = DbType.DateTime2;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("DeliveryRegister");
                }
            }
            return deliveryRegister;
        }

        #endregion

    }
}
