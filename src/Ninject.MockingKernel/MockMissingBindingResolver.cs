// -------------------------------------------------------------------------------------------------
// <copyright file="MockMissingBindingResolver.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG. All rights reserved.
//   Copyright (c) 2010-2017 Ninject Project Contributors. All rights reserved.
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

namespace Ninject.MockingKernel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Activation;
    using Ninject.Components;
    using Ninject.Infrastructure;
    using Ninject.Planning.Bindings;
    using Ninject.Planning.Bindings.Resolvers;

    /// <summary>
    /// Missing binding resolver that creates a mock for every none self bindable type.
    /// </summary>
    public class MockMissingBindingResolver : NinjectComponent, IMissingBindingResolver
    {
        /// <summary>
        /// The call back provider for creating the mock provider.
        /// </summary>
        private readonly IMockProviderCallbackProvider mockProviderCallbackProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockMissingBindingResolver"/> class.
        /// </summary>
        /// <param name="mockProviderCallbackProvider">The mock provider callback provider.</param>
        public MockMissingBindingResolver(IMockProviderCallbackProvider mockProviderCallbackProvider)
        {
            this.mockProviderCallbackProvider = mockProviderCallbackProvider;
        }

        /// <summary>
        /// Returns any bindings from the specified collection that match the specified request.
        /// </summary>
        /// <param name="bindings">The multimap of all registered bindings.</param>
        /// <param name="request">The request in question.</param>
        /// <returns>The series of matching bindings.</returns>
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            var service = request.Service;
            IList<IBinding> bindingList = new List<IBinding>();
            if (this.TypeIsInterfaceOrAbstract(service))
            {
                var binding = new Binding(service)
                {
                    ProviderCallback = this.mockProviderCallbackProvider.GetCreationCallback(),
                    ScopeCallback = ctx => StandardScopeCallbacks.Singleton,
                    IsImplicit = true,
                };

                if (request.Target != null &&
                    request.Target.GetCustomAttributes(typeof(NamedAttribute), false).FirstOrDefault() is NamedAttribute namedAttribute)
                {
                    binding.Metadata.Name = namedAttribute.Name;
                }

                bindingList.Add(binding);
            }

            return bindingList;
        }

        /// <summary>
        /// Returns a value indicating whether the specified service is self-bindable.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns><see langword="True"/> if the type is self-bindable; otherwise <see langword="false"/>.</returns>
        protected virtual bool TypeIsInterfaceOrAbstract(Type service)
        {
            return service.IsInterface || service.IsAbstract || typeof(MulticastDelegate).IsAssignableFrom(service);
        }
    }
}