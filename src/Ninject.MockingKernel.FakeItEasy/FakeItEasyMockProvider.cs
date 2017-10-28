// -------------------------------------------------------------------------------------------------
// <copyright file="FakeItEasyMockProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2015-2017 Ninject Project Contributors. All rights reserved.
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

namespace Ninject.MockingKernel.FakeItEasy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using global::FakeItEasy;
    using global::FakeItEasy.Creation;
    using Ninject.Activation;
    using Ninject.Components;

    /// <summary>
    /// Creates mocked instances via <c>FakeItEasy</c>.
    /// </summary>
    public class FakeItEasyMockProvider : NinjectComponent, IProvider, IMockProviderCallbackProvider
    {
        /// <summary>
        /// Additional interfaces the proxy to implement.
        /// </summary>
        private IEnumerable<Type> additionalInterfaces;

        /// <summary>
        /// Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        public Type Type
        {
            get { return typeof(A); }
        }

        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="FakeItEasyMockProvider"/>.
        /// </summary>
        /// <returns>The created callback.</returns>
        public Func<IContext, IProvider> GetCreationCallback()
        {
            return ctx => this;
        }

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
        public object Create(IContext context)
        {
            this.additionalInterfaces = context.Parameters.OfType<AdditionalInterfaceParameter>().Select(ai => (Type)ai.GetValue(context, null));
            var fakeMethod = typeof(A).GetMethods(BindingFlags.Public | BindingFlags.Static).Last(m => m.Name == "Fake").MakeGenericMethod(context.Request.Service);
            var buildAction = typeof(Action<>).MakeGenericType(typeof(IFakeOptions<>).MakeGenericType(context.Request.Service));

            var d = Delegate.CreateDelegate(buildAction, this, typeof(FakeItEasyMockProvider).GetMethod("Build", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(context.Request.Service));

            return fakeMethod.Invoke(null, new object[] { d });
        }

        /// <summary>
        /// Add additional interfaces to the builder.
        /// </summary>
        /// <typeparam name="T">The proxy type.</typeparam>
        /// <param name="builder">The <see cref="IFakeOptions{T}"/>.</param>
        protected virtual void Build<T>(IFakeOptions<T> builder)
        {
            foreach (var i in this.additionalInterfaces)
            {
                builder.Implements(i);
            }
        }
    }
}