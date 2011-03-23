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
    using global::Moq;
    using Ninject.Activation;
    using Ninject.Components;
    using Ninject.MockingKernel;

    /// <summary>
    /// Creates mocked instances via <c>Moq</c>.
    /// </summary>
    public class MoqMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
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

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
        [System.Security.SecuritySafeCritical]
        public object Create(IContext context)
        {
            Type mockType = typeof(Mock<>).MakeGenericType(context.Request.Service);
            var constructorInfo = mockType.GetConstructor(new Type[0]);
            var mock = (Mock)constructorInfo.Invoke(new object[0]);
            return mock.Object;
        }
    }
}