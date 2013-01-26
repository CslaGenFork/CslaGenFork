//-----------------------------------------------------------------------
// <copyright file="IDalManagerSelfLoadSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace SelfLoadSoftDelete.DataAccess
{
    /// <summary>
    /// Defines the SelfLoadSoftDelete DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerSelfLoadSoftDelete : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoadSoftDelete DAL provider.</typeparam>
        /// <returns>A new SelfLoadSoftDelete DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
