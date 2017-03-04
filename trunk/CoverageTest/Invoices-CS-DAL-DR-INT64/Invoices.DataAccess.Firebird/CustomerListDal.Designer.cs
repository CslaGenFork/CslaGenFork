using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
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
        /// <returns>A data reader to the CustomerList.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList();
                using (var cmd = new FbCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <returns>A data reader to the CustomerList.</returns>
        public IDataReader Fetch(string name)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList(name);
                using (var cmd = new FbCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    return cmd.ExecuteReader();
                }
            }
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
