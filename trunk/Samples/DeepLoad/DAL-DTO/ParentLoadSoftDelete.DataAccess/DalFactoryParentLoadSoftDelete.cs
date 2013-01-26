//-----------------------------------------------------------------------
// <copyright file="DalFactoryParentLoadSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace ParentLoadSoftDelete.DataAccess
{
    /// <summary>
    /// Creates a ParentLoadSoftDelete DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly ParentLoadSoftDelete.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="ParentLoadSoftDelete.DalManagerType" value="ParentLoadSoftDelete.DataAccess.Sql.DalManagerParentLoadSoftDelete, ParentLoadSoftDelete.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryParentLoadSoftDelete
    {
        private static Type _dalType;

        /// <summary>Gets the ParentLoadSoftDelete DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerParentLoadSoftDelete"/> instance</returns>
        public static IDalManagerParentLoadSoftDelete GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["ParentLoadSoftDelete.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("ParentLoadSoftDelete.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerParentLoadSoftDelete) Activator.CreateInstance(_dalType);
        }
    }
}
