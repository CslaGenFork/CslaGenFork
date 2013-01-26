//-----------------------------------------------------------------------
// <copyright file="DalFactoryParentLoadROSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace ParentLoadROSoftDelete.DataAccess
{
    /// <summary>
    /// Creates a ParentLoadROSoftDelete DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly ParentLoadROSoftDelete.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="ParentLoadROSoftDelete.DalManagerType" value="ParentLoadROSoftDelete.DataAccess.Sql.DalManagerParentLoadROSoftDelete, ParentLoadROSoftDelete.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryParentLoadROSoftDelete
    {
        private static Type _dalType;

        /// <summary>Gets the ParentLoadROSoftDelete DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerParentLoadROSoftDelete"/> instance</returns>
        public static IDalManagerParentLoadROSoftDelete GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["ParentLoadROSoftDelete.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("ParentLoadROSoftDelete.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerParentLoadROSoftDelete) Activator.CreateInstance(_dalType);
        }
    }
}
