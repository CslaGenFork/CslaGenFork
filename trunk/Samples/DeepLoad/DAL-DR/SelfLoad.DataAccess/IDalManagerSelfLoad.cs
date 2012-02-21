//-----------------------------------------------------------------------
// <copyright file="IDalManagerSelfLoad.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace SelfLoad.DataAccess
{
    /// <summary>
    /// Defines the SelfLoad DAL manager interface for DAL providers.
    /// </summary>
    public interface IDalManagerSelfLoad : IDisposable
    {
        /// <summary>
        /// Gets the DAL provider for a given object Type.
        /// </summary>
        /// <typeparam name="T">Object Type that requires a SelfLoad DAL provider.</typeparam>
        /// <returns>A new SelfLoad DAL instance for the given Type.</returns>
        T GetProvider<T>() where T : class;
    }
}
