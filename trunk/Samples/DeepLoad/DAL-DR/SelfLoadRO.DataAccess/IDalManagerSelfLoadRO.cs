//-----------------------------------------------------------------------
// <copyright file="IDalManagerSelfLoadRO.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace SelfLoadRO.DataAccess
{
    /// <summary>
    /// Defines the SelfLoadRO DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerSelfLoadRO : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoadRO DAL provider.</typeparam>
        /// <returns>A new SelfLoadRO DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
