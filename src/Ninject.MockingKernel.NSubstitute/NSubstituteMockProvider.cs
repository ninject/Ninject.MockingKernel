// -------------------------------------------------------------------------------------------------
// <copyright file="NSubstituteMockProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011 Andre Loker IT Services
//   Copyright (c) 2012-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.NSubstitute
{
    using System;
    using System.Linq;
    using Activation;
    using Components;
    using global::NSubstitute;

    /// <summary>
    /// Creates mocked instances via <c>NSubstitute</c>.
    /// </summary>
    public class NSubstituteMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
        /// <summary>
        ///   Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        public Type Type
        {
            get { return typeof(Substitute); }
        }

        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="NSubstituteMockProvider"/>.
        /// </summary>
        /// <returns>
        /// The created callback.
        /// </returns>
        public Func<IContext, IProvider> GetCreationCallback()
        {
            return ctx => this;
        }

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The created instance.
        /// </returns>
        public object Create(IContext context)
        {
            var additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null));

            return Substitute.For(new[] { context.Request.Service }.Concat(additionalInterfaces).ToArray(), null);
        }
    }
}