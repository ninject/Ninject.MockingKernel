//-------------------------------------------------------------------------------
// <copyright file="MockingKernel.cs" company="bbv Software Services AG">
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
    using Ninject.Activation.Caching;
    using Ninject.Modules;
    using Ninject.Planning.Bindings.Resolvers;

    /// <summary>
    /// A kernel that will create mocked instances (via Moq) for any service that is
    /// requested for which no binding is registered.
    /// </summary>
    public class MockingKernel : StandardKernel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        public MockingKernel()
        {
            this.AddComponents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        /// <param name="modules">The modules to load into the kernel.</param>
        public MockingKernel(params INinjectModule[] modules)
            : base(modules)
        {
            this.AddComponents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockingKernel"/> class.
        /// </summary>
        /// <param name="settings">The configuration to use.</param>
        /// <param name="modules">The modules to load into the kernel.</param>
        public MockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.AddComponents();
        }

        /// <summary>
        /// Clears the kernel's cache, immediately deactivating all activated instances regardless of scope.
        /// This does not remove any modules, extensions, or bindings.
        /// </summary>
        public void Reset()
        {
            this.Components.Get<ICache>().Clear();
        }

        /// <summary>
        /// Adds components to the kernel during startup.
        /// </summary>
        private new void AddComponents()
        {
            this.Components.RemoveAll<IMissingBindingResolver>();
            this.Components.Add<IMissingBindingResolver, MockMissingBindingResolver>();
            this.Components.Add<IMissingBindingResolver, SingletonSelfBindingResolver>();
        }
    }
}