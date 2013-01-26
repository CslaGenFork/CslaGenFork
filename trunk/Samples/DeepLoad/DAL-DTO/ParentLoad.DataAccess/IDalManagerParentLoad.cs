//-----------------------------------------------------------------------
// <copyright file="IDalManagerParentLoad.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace ParentLoad.DataAccess
{
    /// <summary>
    /// Defines the ParentLoad DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerParentLoad : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a ParentLoad DAL provider.</typeparam>
        /// <returns>A new ParentLoad DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
