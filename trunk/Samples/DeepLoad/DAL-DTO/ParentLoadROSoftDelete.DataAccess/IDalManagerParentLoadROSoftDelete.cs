//-----------------------------------------------------------------------
// <copyright file="IDalManagerParentLoadROSoftDelete.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace ParentLoadROSoftDelete.DataAccess
{
    /// <summary>
    /// Defines the ParentLoadROSoftDelete DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerParentLoadROSoftDelete : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a ParentLoadROSoftDelete DAL provider.</typeparam>
        /// <returns>A new ParentLoadROSoftDelete DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
