// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoqMockProvider.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 bbv Software Services AG
//   Author: Remo Gloor remo.gloor@bbv.ch
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
//   Also licenced under Microsoft Public License (Ms-PL).
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.Moq
{
    using System;
    using System.Linq;
    using System.Reflection;

    using global::Moq;
    using Ninject.Activation;
    using Ninject.Components;
    using Ninject.MockingKernel;

    /// <summary>
    /// Creates mocked instances via <c>Moq</c>.
    /// </summary>
    public class MoqMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
        /// <summary>
        /// The mock repository provider used to create mock instances.
        /// </summary>
        private readonly MockRepository mockRepository;

        /// <summary>
        /// The method info used to create mock instances.
        /// </summary>
        private readonly MethodInfo createMethod;

        /// <summary>
        /// The method info used to add additional interface to mock.
        /// </summary>
        private readonly MethodInfo addAdditionalInterfaceMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoqMockProvider"/> class.
        /// </summary>
        /// <param name="mockRepositoryProvider">The mock repository provider used to create mock instances.</param>
        public MoqMockProvider(IMockRepositoryProvider mockRepositoryProvider)
        {
            this.mockRepository = mockRepositoryProvider.Instance;
            this.createMethod = mockRepositoryProvider.CreateMethod;
            this.addAdditionalInterfaceMethod = mockRepositoryProvider.AddAdditionalInterfaceMethod;
        }
#endif

        /// <summary>
        /// Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        public Type Type
        {
            get
            {
                return typeof(Mock<>);
            }
        }

        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="MoqMockProvider"/>.
        /// </summary>
        /// <returns> The created callback.</returns>
        public Func<IContext, IProvider> GetCreationCallback()
        {
            return ctx => this;
        }

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
        [System.Security.SecuritySafeCritical]
        public object Create(IContext context)
        {
            var methodInfo = this.createMethod.MakeGenericMethod(context.Request.Service);
            var mock = (Mock)methodInfo.Invoke(this.mockRepository, new object[0]);
            var additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null));
            foreach (var additionalInterface in additionalInterfaces)
            {
                this.addAdditionalInterfaceMethod.MakeGenericMethod(additionalInterface).Invoke(mock, null);
            }

            return mock.Object;
        }

#else
        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
#if !NETCF
        [System.Security.SecuritySafeCritical]
#endif
        public object Create(IContext context)
        {
            var mockType = typeof(Mock<>).MakeGenericType(context.Request.Service);
            var constructorInfo = mockType.GetConstructor(new[] { typeof(MockBehavior) });
            var mock = (Mock)constructorInfo.Invoke(new object[] { Settings.GetMockBehavior() });
            var additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null));
            foreach (var additionalInterface in additionalInterfaces)
            {
                typeof(Mock).GetMethod("As").MakeGenericMethod(additionalInterface).Invoke(mock, null);
            }

            return mock.Object;
        }
#endif
    }
}