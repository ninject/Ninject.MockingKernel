// -------------------------------------------------------------------------------------------------
// <copyright file="MoqMockingKernel.cs" company="Ninject Project Contributors">
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

namespace Ninject.MockingKernel.Moq
{
    using global::Moq;
    using Ninject.Modules;

    /// <summary>
    /// Mocking kernel for moq
    /// </summary>
    public class MoqMockingKernel : MockingKernel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoqMockingKernel"/> class.
        /// </summary>
        public MoqMockingKernel()
        {
            this.Load(new MoqModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoqMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">The configuration to use.</param>
        /// <param name="modules">The modules to load into the kernel.</param>
        public MoqMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new MoqModule());
        }

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
        /// <summary>
        /// Gets the mock repository.
        /// </summary>
        /// <value>The mock repository.</value>
        public MockRepository MockRepository
        {
            get
            {
                return this.Components.Get<IMockRepositoryProvider>().Instance;
            }
        }
#endif

        /// <summary>
        /// Gets the mock.
        /// </summary>
        /// <typeparam name="T">The type of the mock to be returned.</typeparam>
        /// <returns>The mock for the given type.</returns>
        public Mock<T> GetMock<T>()
            where T : class
        {
            return Mock.Get(this.Get<T>());
        }
    }
}