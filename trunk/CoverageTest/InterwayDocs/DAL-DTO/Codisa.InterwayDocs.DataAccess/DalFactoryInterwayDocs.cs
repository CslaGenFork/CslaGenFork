//-----------------------------------------------------------------------
// <copyright file="DalFactoryInterwayDocs.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// Creates a InterwayDocs DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly Codisa.InterwayDocs.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="InterwayDocs.DalManagerType" value="Codisa.InterwayDocs.DataAccess.Sql.DalManagerInterwayDocs, Codisa.InterwayDocs.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryInterwayDocs
    {
        private static Type _dalType;

        /// <summary>Gets the InterwayDocs DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerInterwayDocs"/> instance</returns>
        public static IDalManagerInterwayDocs GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["InterwayDocs.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("InterwayDocs.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerInterwayDocs) Activator.CreateInstance(_dalType);
        }
    }
}
