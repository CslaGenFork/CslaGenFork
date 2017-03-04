//-----------------------------------------------------------------------
// <copyright file="IDalManager.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Invoices.DataAccess
{
    /// <summary>
    /// Defines the  DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManager : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a  DAL provider.</typeparam>
        /// <returns>A new  DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
