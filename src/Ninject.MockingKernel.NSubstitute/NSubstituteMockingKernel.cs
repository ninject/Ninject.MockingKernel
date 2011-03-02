//-------------------------------------------------------------------------------
// <copyright file="NSubstituteMockingKernel.cs" company="Andre Loker IT Services">
//   Copyright (c) 2011 Andre Loker IT Services
//   Author: Andre Loker (mail@loker-it.de)
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

namespace Ninject.MockingKernel.NSubstitute
{
    using Modules;

    /// <summary>
    /// Mocking kernel for NSubstitute
    /// </summary>
    public class NSubstituteMockingKernel : MockingKernel
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "NSubstituteMockingKernel" /> class.
        /// </summary>
        public NSubstituteMockingKernel()
        {
            this.Load(new NSubstituteModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSubstituteMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">
        /// The configuration to use.
        /// </param>
        /// <param name="modules">
        /// The modules to load into the kernel.
        /// </param>
        public NSubstituteMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new NSubstituteModule());
        }
    }
}