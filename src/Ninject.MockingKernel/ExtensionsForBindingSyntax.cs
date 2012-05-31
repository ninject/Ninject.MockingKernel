//-------------------------------------------------------------------------------
// <copyright file="ExtensionsForBindingSyntax.cs" company="bbv Software Services AG">
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
    using Ninject.Syntax;

    /// <summary>
    /// Extensions for the fluent binding syntax API.
    /// </summary>
    public static class ExtensionsForBindingSyntax
    {
        /// <summary>
        /// Indicates that the service should be bound to a mocked instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The service that is being mocked.</typeparam>
        /// <param name="builder">The builder that is building the binding.</param>
        /// <returns>The syntax for adding more information to the binding.</returns>
        public static IBindingWhenInNamedWithOrOnSyntax<T> ToMock<T>(this IBindingToSyntax<T> binding) 
        {
            return binding.ToMethod(CreateMockObject<T>);
        }

        private static T CreateMockObject<T>(IContext ctx) 
        {
            IMockProviderCallbackProvider callBackProvider =
                    ctx.Kernel.Components.Get<IMockProviderCallbackProvider>();
            IProvider factory = callBackProvider.GetCreationCallback().Invoke(ctx);
            return (T)factory.Create(ctx);
        }

        /// <summary>
        /// Convenient method for indicating mocking for the specified service type and making the mocking object singleton.
        /// </summary>
        /// <remarks>
        /// Important note: If you use this method, make sure to reset the kernel each time as objects won't be recreated otherwise.
        /// </remarks>
        /// <typeparam name="T">The service that is being mocked.</typeparam>
        /// <param name="builder">The builder that is building the binding.</param>
        /// <returns>The syntax for adding more information to the binding.</returns>
        public static IBindingNamedWithOrOnSyntax<T> ToMockSingleton<T>(this IBindingToSyntax<T> binding) 
        {
            return binding.ToMock().InSingletonScope();
        }
    }
}