//-----------------------------------------------------------------------
// <copyright file="DalFactorySelfLoadRO.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace SelfLoadRO.DataAccess
{
    /// <summary>
    /// Creates a SelfLoadRO DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly SelfLoadRO.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoadRO.DalManagerType" value="SelfLoadRO.DataAccess.Sql.DalManagerSelfLoadRO, SelfLoadRO.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactorySelfLoadRO
    {
        private static Type _dalType;

        /// <summary>Gets the SelfLoadRO DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerSelfLoadRO"/> instance</returns>
        public static IDalManagerSelfLoadRO GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["SelfLoadRO.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("SelfLoadRO.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerSelfLoadRO) Activator.CreateInstance(_dalType);
        }
    }
}
