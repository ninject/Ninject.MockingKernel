// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionsForBindingSyntax.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>

namespace Ninject.MockingKernel
{
    using System;
    using Ninject.Syntax;

    /// <summary>
    /// Extensions for the fluent binding syntax API.
    /// </summary>
    public static class ExtensionsForBindingSyntax
    {
        /// <summary>
        /// Indicates that the service should be bound to a mocked instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The service that is being mocked.</typeparam>
        /// <param name="builder">The builder that is building the binding.</param>
        /// <param name="additionalInterfaces">The additional interfaces for the mock.</param>
        /// <returns>The syntax for adding more information to the binding.</returns>
        public static IBindingWhenInNamedWithOrOnSyntax<T> ToMock<T>(this IBindingToSyntax<T> builder, params Type[] additionalInterfaces)
        {
            var result = builder.To<T>();

            var bindingConfiguration = builder.BindingConfiguration;

            foreach (var additionalInterface in additionalInterfaces)
            {
                bindingConfiguration.Parameters.Add(new AdditionalInterfaceParameter(additionalInterface));
            }

            bindingConfiguration.ProviderCallback = builder.Kernel.Components.Get<IMockProviderCallbackProvider>().GetCreationCallback();

            return result;
        }
    }
}