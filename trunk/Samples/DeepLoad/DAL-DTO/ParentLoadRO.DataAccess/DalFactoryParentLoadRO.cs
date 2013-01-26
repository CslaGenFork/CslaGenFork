//-----------------------------------------------------------------------
// <copyright file="DalFactoryParentLoadRO.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace ParentLoadRO.DataAccess
{
    /// <summary>
    /// Creates a ParentLoadRO DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly ParentLoadRO.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="ParentLoadRO.DalManagerType" value="ParentLoadRO.DataAccess.Sql.DalManagerParentLoadRO, ParentLoadRO.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryParentLoadRO
    {
        private static Type _dalType;

        /// <summary>Gets the ParentLoadRO DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerParentLoadRO"/> instance</returns>
        public static IDalManagerParentLoadRO GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["ParentLoadRO.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("ParentLoadRO.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerParentLoadRO) Activator.CreateInstance(_dalType);
        }
    }
}
