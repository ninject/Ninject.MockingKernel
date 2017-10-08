// -------------------------------------------------------------------------------------------------
// <copyright file="MockingKernel.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel
{
    using Ninject.Activation.Caching;
    using Ninject.Modules;
    using Ninject.Planning.Bindings.Resolvers;

    /// <summary>
    /// A kernel that will create mocked instances (via Moq) for any service that is
    /// requested for which no binding is registered.
    /// </summary>
    public class MockingKernel : StandardKernel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        public MockingKernel()
        {
            this.AddComponents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        /// <param name="modules">The modules to load into the kernel.</param>
        public MockingKernel(params INinjectModule[] modules)
            : base(modules)
        {
            this.AddComponents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        /// <param name="settings">The configuration to use.</param>
        /// <param name="modules">The modules to load into the kernel.</param>
        public MockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.AddComponents();
        }

        /// <summary>
        /// Clears the kernel's cache, immediately deactivating all activated instances regardless of scope.
        /// This does not remove any modules, extensions, or bindings.
        /// </summary>
        public void Reset()
        {
            this.Components.Get<ICache>().Clear();
        }

        /// <summary>
        /// Adds components to the kernel during startup.
        /// </summary>
        private new void AddComponents()
        {
            this.Components.RemoveAll<IMissingBindingResolver>();
            this.Components.Add<IMissingBindingResolver, MockMissingBindingResolver>();
            this.Components.Add<IMissingBindingResolver, SingletonSelfBindingResolver>();
        }
    }
}