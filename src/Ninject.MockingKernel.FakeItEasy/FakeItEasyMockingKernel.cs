// -------------------------------------------------------------------------------------------------
// <copyright file="FakeItEasyMockingKernel.cs" company="Ninject Project Contributors">
//   Copyright (c) 2015-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.FakeItEasy
{
    using Modules;

    /// <summary>
    /// Mocking kernel for NSubstitute
    /// </summary>
    public class FakeItEasyMockingKernel : MockingKernel
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "FakeItEasyMockingKernel" /> class.
        /// </summary>
        public FakeItEasyMockingKernel()
        {
            this.Load(new FakeItEasyModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeItEasyMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">
        /// The configuration to use.
        /// </param>
        /// <param name="modules">
        /// The modules to load into the kernel.
        /// </param>
        public FakeItEasyMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new FakeItEasyModule());
        }
    }
}