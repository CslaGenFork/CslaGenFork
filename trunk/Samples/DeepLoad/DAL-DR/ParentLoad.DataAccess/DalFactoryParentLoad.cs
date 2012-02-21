//-----------------------------------------------------------------------
// <copyright file="DalFactoryParentLoad.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace ParentLoad.DataAccess
{
    /// <summary>
    /// Creates a ParentLoad DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly ParentLoad.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="ParentLoad.DalManagerType" value="ParentLoad.DataAccess.Sql.DalManagerParentLoad, ParentLoad.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryParentLoad
    {
        private static Type _dalType;

        /// <summary>Gets the ParentLoad DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerParentLoad"/> instance</returns>
        public static IDalManagerParentLoad GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["ParentLoad.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("ParentLoad.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerParentLoad) Activator.CreateInstance(_dalType);
        }
    }
}
