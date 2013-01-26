//-----------------------------------------------------------------------
// <copyright file="DalFactorySelfLoadSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace SelfLoadSoftDelete.DataAccess
{
    /// <summary>
    /// Creates a SelfLoadSoftDelete DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly SelfLoadSoftDelete.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoadSoftDelete.DalManagerType" value="SelfLoadSoftDelete.DataAccess.Sql.DalManagerSelfLoadSoftDelete, SelfLoadSoftDelete.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactorySelfLoadSoftDelete
    {
        private static Type _dalType;

        /// <summary>Gets the SelfLoadSoftDelete DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerSelfLoadSoftDelete"/> instance</returns>
        public static IDalManagerSelfLoadSoftDelete GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["SelfLoadSoftDelete.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("SelfLoadSoftDelete.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerSelfLoadSoftDelete) Activator.CreateInstance(_dalType);
        }
    }
}
