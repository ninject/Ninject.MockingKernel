// -------------------------------------------------------------------------------------------------
// <copyright file="IMockRepositoryProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
namespace Ninject.MockingKernel.Moq
{
    using System.Reflection;
    using global::Moq;
    using Ninject.Components;

    /// <summary>
    /// Provider for the MockRepository used to create new mock instances.
    /// </summary>
    public interface IMockRepositoryProvider : INinjectComponent
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        MockRepository Instance { get; }

        /// <summary>
        /// Gets the method info of the create method.
        /// </summary>
        /// <value>The method info of the create method.</value>
        MethodInfo CreateMethod { get; }

        /// <summary>
        /// Gets the method info of the add additional interface method.
        /// </summary>
        /// <value>the method info of the add additional interface method.</value>
        MethodInfo AddAdditionalInterfaceMethod { get; }
    }
}
#endif