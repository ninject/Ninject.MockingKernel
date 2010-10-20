//-------------------------------------------------------------------------------
// <copyright file="SingletonSelfBindingResolver.cs" company="bbv Software Services AG">
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
//-------------------------------------------------------------------------------

namespace Ninject.MockingKernel
{
    using System;
    using System.Collections.Generic;

    using Ninject.Activation;
    using Ninject.Components;
    using Ninject.Infrastructure;
    using Ninject.Planning.Bindings;
    using Ninject.Planning.Bindings.Resolvers;

    /// <summary>
    /// Resolver for self bindable types. Binds them as singleton to self.
    /// </summary>
    public class SingletonSelfBindingResolver : NinjectComponent, IMissingBindingResolver
    {
        /// <summary>
        /// The SelfBindingResolver that is used to create bindings for self bindable types.
        /// </summary>
        private readonly SelfBindingResolver selfBindingResolver = new SelfBindingResolver();

        /// <summary>
        /// Returns any bindings from the specified collection that match the specified request.
        /// </summary>
        /// <param name="bindings">The multimap of all registered bindings.</param>
        /// <param name="request">The request in question.</param>
        /// <returns>The series of matching bindings.</returns>
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            var newBindings = this.selfBindingResolver.Resolve(bindings, request);
            foreach (var binding in newBindings)
            {
                binding.ScopeCallback = StandardScopeCallbacks.Singleton;
            }

            return newBindings;
        }
    }
}