//-----------------------------------------------------------------------
// <copyright file="IDalManagerSelfLoadROSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace SelfLoadROSoftDelete.DataAccess
{
    /// <summary>
    /// Defines the SelfLoadROSoftDelete DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerSelfLoadROSoftDelete : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoadROSoftDelete DAL provider.</typeparam>
        /// <returns>A new SelfLoadROSoftDelete DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
