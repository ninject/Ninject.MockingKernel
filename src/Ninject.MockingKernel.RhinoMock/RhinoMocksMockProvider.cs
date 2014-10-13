// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RhinoMocksMockProvider.cs" company="bbv Software Services AG">
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

namespace Ninject.MockingKernel.RhinoMock
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Ninject.Activation;
    using Ninject.Components;
    using Ninject.MockingKernel;
    using Rhino.Mocks;

    /// <summary>
    /// Creates mocked instances via RhinoMocks.
    /// </summary>
    public class RhinoMocksMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
        /// <summary>
        /// Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        public Type Type
        {
            get
            {
                return typeof(RhinoMocks);
            }
        }

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
        public object Create(IContext context)
        {
            var additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null)).ToArray();

            return MockRepository.GenerateMock(context.Request.Service, additionalInterfaces, new object[0]);
        }

        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="IProvider"/> that creates the mock.
        /// </summary>
        /// <returns>The created callback.</returns>
        public Func<IContext, IProvider> GetCreationCallback()
        {
            return ctx => this;
        }
    }
}
