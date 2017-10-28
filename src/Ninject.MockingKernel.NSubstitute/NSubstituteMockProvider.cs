// -------------------------------------------------------------------------------------------------
// <copyright file="NSubstituteMockProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2011 Andre Loker IT Services. All rights reserved.
//   Copyright (c) 2011-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.NSubstitute
{
    using System;
    using System.Linq;

    using Activation;
    using Components;
    using global::NSubstitute;

    /// <summary>
    /// Creates mocked instances via <c>NSubstitute</c>.
    /// </summary>
    public class NSubstituteMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
        /// <summary>
        ///   Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        public Type Type
        {
            get { return typeof(Substitute); }
        }

        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="NSubstituteMockProvider"/>.
        /// </summary>
        /// <returns>
        /// The created callback.
        /// </returns>
        public Func<IContext, IProvider> GetCreationCallback()
        {
            return ctx => this;
        }

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The created instance.
        /// </returns>
        public object Create(IContext context)
        {
            var additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null));

            return Substitute.For(new[] { context.Request.Service }.Concat(additionalInterfaces).ToArray(), null);
        }
    }
}