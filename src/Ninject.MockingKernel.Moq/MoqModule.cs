// -------------------------------------------------------------------------------------------------
// <copyright file="MoqModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.Moq
{
    using Ninject.Modules;

    /// <summary>
    /// The module for moq
    /// </summary>
    public class MoqModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Components.Add<IMockProviderCallbackProvider, MoqMockProvider>();
#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
            this.Kernel.Components.Add<IMockRepositoryProvider, DefaultMockRepositoryProvider>();
#endif
        }
    }
}