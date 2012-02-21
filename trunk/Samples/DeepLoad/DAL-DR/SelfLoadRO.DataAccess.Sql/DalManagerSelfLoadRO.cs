//-----------------------------------------------------------------------
// <copyright file="DalManagerSelfLoadRO.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using Csla.Data;

namespace SelfLoadRO.DataAccess.Sql
{
    /// <summary>
    /// Implements <see cref="IDalManagerSelfLoadRO"/> interface.
    /// </summary>
    /// <remarks>
    /// To use this DAL:<br/>
    /// 1) name this assembly SelfLoadRO.DataAccess.Sql<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoadRO.DalManagerType" value="SelfLoadRO.DataAccess.Sql.DalManagerSelfLoadRO, SelfLoadRO.DataAccess.Sql" /&gt;
    /// </remarks>
    public class DalManagerSelfLoadRO : IDalManagerSelfLoadRO
    {
        private static readonly string TypeMask = typeof (DalManagerSelfLoadRO).FullName.Replace("DalManagerSelfLoadRO", @"{0}");
        private const string BaseNamespace = "SelfLoadRO.DataAccess";

        /// <summary>
        /// Initializes a new instance of the <see cref="DalManagerSelfLoadRO"/> class.
        /// </summary>
        public DalManagerSelfLoadRO()
        {
            ConnectionManager = ConnectionManager<SqlConnection>.GetManager("DeepLoad");
        }

        /// <summary>
        /// Gets the ADO ConnectionManager object.
        /// </summary>
        /// <value>The ConnectionManager object</value>
        public ConnectionManager<SqlConnection> ConnectionManager { get; private set; }

        #region IDalManagerSelfLoadRO Members

        /// <summary>
        /// Gets the SelfLoadRO DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoadRO DAL provider.</typeparam>
        /// <returns>A new SelfLoadRO DAL instance for the given Type.</returns>
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
