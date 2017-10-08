// -------------------------------------------------------------------------------------------------
// <copyright file="IMockProviderCallbackProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel
{
    using System;
    using Ninject.Activation;
    using Ninject.Components;

    /// <summary>
    /// Provides a callback that creates a provider which creates the mock.
    /// </summary>
    public interface IMockProviderCallbackProvider : INinjectComponent
    {
        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="IProvider"/> that creates the mock.
        /// </summary>
        /// <returns> The created callback.</returns>
        Func<IContext, IProvider> GetCreationCallback();
    }
}