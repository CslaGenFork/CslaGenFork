//-----------------------------------------------------------------------
// <copyright file="IDalManagerParentLoadRO.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace ParentLoadRO.DataAccess
{
    /// <summary>
    /// Defines the ParentLoadRO DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerParentLoadRO : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a ParentLoadRO DAL provider.</typeparam>
        /// <returns>A new ParentLoadRO DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
