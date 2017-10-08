// -------------------------------------------------------------------------------------------------
// <copyright file="FakeItEasyModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2015-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.FakeItEasy
{
    using Modules;

    /// <summary>
    /// The module for FakeItEasy.
    /// </summary>
    public class FakeItEasyModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Components.Add<IMockProviderCallbackProvider, FakeItEasyMockProvider>();
        }
    }
}