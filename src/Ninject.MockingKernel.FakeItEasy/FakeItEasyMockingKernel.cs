// -------------------------------------------------------------------------------------------------
// <copyright file="FakeItEasyMockingKernel.cs" company="Ninject Project Contributors">
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
    using Modules;

    /// <summary>
    /// Mocking kernel for NSubstitute
    /// </summary>
    public class FakeItEasyMockingKernel : MockingKernel
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "FakeItEasyMockingKernel" /> class.
        /// </summary>
        public FakeItEasyMockingKernel()
        {
            this.Load(new FakeItEasyModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeItEasyMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">
        /// The configuration to use.
        /// </param>
        /// <param name="modules">
        /// The modules to load into the kernel.
        /// </param>
        public FakeItEasyMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new FakeItEasyModule());
        }
    }
}