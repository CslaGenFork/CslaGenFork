//-----------------------------------------------------------------------
// <copyright file="DalManagerSelfLoad.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using Csla.Data;

namespace SelfLoad.DataAccess.Sql
{
    /// <summary>
    /// Implements <see cref="IDalManagerSelfLoad"/> interface.
    /// </summary>
    /// <remarks>
    /// To use this DAL:<br/>
    /// 1) name this assembly SelfLoad.DataAccess.Sql<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoad.DalManagerType" value="SelfLoad.DataAccess.Sql.DalManagerSelfLoad, SelfLoad.DataAccess.Sql" /&gt;
    /// </remarks>
    public class DalManagerSelfLoad : IDalManagerSelfLoad
    {
        private static readonly string TypeMask = typeof (DalManagerSelfLoad).FullName.Replace("DalManagerSelfLoad", @"{0}");
        private const string BaseNamespace = "SelfLoad.DataAccess";

        /// <summary>
        /// Initializes a new instance of the <see cref="DalManagerSelfLoad"/> class.
        /// </summary>
        public DalManagerSelfLoad()
        {
            ConnectionManager = ConnectionManager<SqlConnection>.GetManager("DeepLoad");
        }

        /// <summary>
        /// Gets the ADO ConnectionManager object.
        /// </summary>
        /// <value>The ConnectionManager object</value>
        public ConnectionManager<SqlConnection> ConnectionManager { get; private set; }

        #region IDalManagerSelfLoad Members

        /// <summary>
        /// Gets the SelfLoad DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoad DAL provider.</typeparam>
        /// <returns>A new SelfLoad DAL instance for the given Type.</returns>
        public T GetProvider<T>() where T : class
        {
            string typeName;
            var namespaceDiff = typeof(T).Namespace.Length - BaseNamespace.Length;
            if (namespaceDiff > 0)
                typeName = string.Format(TypeMask, typeof(T).Namespace.Substring(BaseNamespace.Length + 1,
                    namespaceDiff - 1)) + "." + typeof(T).Name.Substring(1);
            else
                typeName = string.Format(TypeMask, typeof(T).Name.Substring(1));

            var type = Type.GetType(typeName);
            if (type != null)
                return Activator.CreateInstance(type) as T;

            throw new NotImplementedException(typeName);
        }

        /// <summary>
        /// Disposes the ConnectionManager.
        /// </summary>
        public void Dispose()
        {
            ConnectionManager.Dispose();
            ConnectionManager = null;
        }

        #endregion

    }
}
