// -------------------------------------------------------------------------------------------------
// <copyright file="DefaultMockRepositoryProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
namespace Ninject.MockingKernel.Moq
{
    using System;
    using System.Reflection;
    using global::Moq;
    using Ninject.Components;

    /// <summary>
    /// Providers a MockRepository that is configured as Loose by default.
    /// The MockBehavior can be overridden by setting a different one on the NinjectSettings
    /// using SetMockBehavior.
    /// </summary>
    public class DefaultMockRepositoryProvider : NinjectComponent, IMockRepositoryProvider
    {
        /// <summary>
        /// the instance of the mock repository.
        /// </summary>
        private MockRepository instance;

        /// <summary>
        /// Gets the method info of the create method.
        /// </summary>
        private MethodInfo createMethod;

        /// <summary>
        /// Gets the method info of the add additional interface method.
        /// </summary>
        private MethodInfo addAdditionalInterfaceMethod;

        /// <summary>
        /// Gets the instance of the mock repository.
        /// </summary>
        /// <value>The instance of the mock repository.</value>
        public MockRepository Instance
        {
            get
            {
                if (this.instance == null)
                {
                    this.instance = new MockRepository(this.Settings.GetMockBehavior())
                    {
                        CallBase = this.Settings.GetMockCallBase(),
                        DefaultValue = this.Settings.GetMockDefaultValue(),
                    };
                }

                return this.instance;
            }
        }

        /// <summary>
        /// Gets the method info of the create method.
        /// </summary>
        /// <value>The method info of the create method.</value>
        public MethodInfo CreateMethod
        {
            get
            {
                if (this.createMethod == null)
                {
                    this.createMethod = this.Instance.GetType().GetMethod("Create", new Type[0]);
                }

                return this.createMethod;
            }
        }

        /// <summary>
        /// Gets the method info of the add additional interface method.
        /// </summary>
        /// <value>The method info of the add additional interface method.</value>
        public MethodInfo AddAdditionalInterfaceMethod
        {
            get
            {
                if (this.addAdditionalInterfaceMethod == null)
                {
                    this.addAdditionalInterfaceMethod = typeof(Mock).GetMethod("As");
                }

                return this.addAdditionalInterfaceMethod;
            }
        }
    }
}
#endif