// -------------------------------------------------------------------------------------------------
// <copyright file="NSubstituteModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011 Andre Loker IT Services
//   Copyright (c) 2012-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.NSubstitute
{
    using Modules;

    /// <summary>
    /// The module for moq
    /// </summary>
    public class NSubstituteModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Components.Add<IMockProviderCallbackProvider, NSubstituteMockProvider>();
        }
    }
}