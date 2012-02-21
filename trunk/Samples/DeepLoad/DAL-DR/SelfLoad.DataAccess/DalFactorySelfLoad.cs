//-----------------------------------------------------------------------
// <copyright file="DalFactorySelfLoad.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace SelfLoad.DataAccess
{
    /// <summary>
    /// Creates a SelfLoad DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly SelfLoad.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="SelfLoad.DalManagerType" value="SelfLoad.DataAccess.Sql.DalManagerSelfLoad, SelfLoad.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactorySelfLoad
    {
        private static Type _dalType;

        /// <summary>Gets the SelfLoad DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerSelfLoad"/> instance</returns>
        public static IDalManagerSelfLoad GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["SelfLoad.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("SelfLoad.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerSelfLoad) Activator.CreateInstance(_dalType);
        }
    }
}
