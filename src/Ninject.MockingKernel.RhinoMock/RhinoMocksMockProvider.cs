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
#if SILVERLIGHT
        /// <summary>
        /// The method info for creation mocks.
        /// </summary>
        private readonly MethodInfo generateMockMethodInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RhinoMocksMockProvider"/> class.
        /// </summary>
        public RhinoMocksMockProvider()
        {
            this.generateMockMethodInfo = typeof(MockRepository).GetMethod("GenerateMock");
        }
#endif

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
#if !SILVERLIGHT
            return MockRepository.GenerateMock(context.Request.Service, new Type[0], new object[0]);
#else
            return this.generateMockMethodInfo.MakeGenericMethod(context.Request.Service).Invoke(null, new[] { new object[0] });
#endif
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
