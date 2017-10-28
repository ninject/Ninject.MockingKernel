// -------------------------------------------------------------------------------------------------
// <copyright file="IMockProviderCallbackProvider.cs" company="Ninject Project Contributors">
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

    using Ninject.Activation;
    using Ninject.Components;

    /// <summary>
    /// Provides a callback that creates a provider which creates the mock.
    /// </summary>
    public interface IMockProviderCallbackProvider : INinjectComponent
    {
        /// <summary>
        /// Gets a callback that creates an instance of the <see cref="IProvider"/> that creates the mock.
        /// </summary>
        /// <returns> The created callback.</returns>
        Func<IContext, IProvider> GetCreationCallback();
    }
}