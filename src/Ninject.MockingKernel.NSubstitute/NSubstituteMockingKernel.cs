// -------------------------------------------------------------------------------------------------
// <copyright file="NSubstituteMockingKernel.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011 Andre Loker IT Services
//   Copyright (c) 2012-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.NSubstitute
{
    using Modules;

    /// <summary>
    /// Mocking kernel for NSubstitute
    /// </summary>
    public class NSubstituteMockingKernel : MockingKernel
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "NSubstituteMockingKernel" /> class.
        /// </summary>
        public NSubstituteMockingKernel()
        {
            this.Load(new NSubstituteModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSubstituteMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">
        /// The configuration to use.
        /// </param>
        /// <param name="modules">
        /// The modules to load into the kernel.
        /// </param>
        public NSubstituteMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new NSubstituteModule());
        }
    }
}