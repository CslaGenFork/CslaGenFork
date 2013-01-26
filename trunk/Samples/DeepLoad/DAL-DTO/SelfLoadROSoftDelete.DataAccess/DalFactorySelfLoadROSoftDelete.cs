//-----------------------------------------------------------------------
// <copyright file="DalFactorySelfLoadROSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace SelfLoadROSoftDelete.DataAccess
{
    /// <summary>
    /// Creates a SelfLoadROSoftDelete DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly SelfLoadROSoftDelete.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoadROSoftDelete.DalManagerType" value="SelfLoadROSoftDelete.DataAccess.Sql.DalManagerSelfLoadROSoftDelete, SelfLoadROSoftDelete.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactorySelfLoadROSoftDelete
    {
        private static Type _dalType;

        /// <summary>Gets the SelfLoadROSoftDelete DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerSelfLoadROSoftDelete"/> instance</returns>
        public static IDalManagerSelfLoadROSoftDelete GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["SelfLoadROSoftDelete.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("SelfLoadROSoftDelete.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerSelfLoadROSoftDelete) Activator.CreateInstance(_dalType);
        }
    }
}
