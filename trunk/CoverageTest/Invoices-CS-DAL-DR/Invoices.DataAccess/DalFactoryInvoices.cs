//-----------------------------------------------------------------------
// <copyright file="DalFactoryInvoices.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace Invoices.DataAccess
{
    /// <summary>
    /// Creates a Invoices DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly Invoices.DataAccess<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="Invoices.DalManagerType" value="Invoices.DataAccess.Sql.DalManagerInvoices, Invoices.DataAccess.Sql" /&gt;
    /// </remarks>
    public static class DalFactoryInvoices
    {
        private static Type _dalType;

        /// <summary>Gets the Invoices DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerInvoices"/> instance</returns>
        public static IDalManagerInvoices GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["Invoices.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("Invoices.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerInvoices) Activator.CreateInstance(_dalType);
        }
    }
}
