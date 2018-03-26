//-----------------------------------------------------------------------
// <copyright file="IDalManagerInterwayDocs.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// Defines the InterwayDocs DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerInterwayDocs : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a InterwayDocs DAL provider.</typeparam>
        /// <returns>A new InterwayDocs DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
