//-------------------------------------------------------------------------------
// <copyright file="RhinoMocksMockingKernel.cs" company="bbv Software Services AG">
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

namespace Ninject.MockingKernel.RhinoMock
{
    using Ninject.Modules;

    /// <summary>
    /// The mocking kernel for RhinoMocks
    /// </summary>
    public class RhinoMocksMockingKernel : MockingKernel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RhinoMocksMockingKernel"/> class.
        /// </summary>
        public RhinoMocksMockingKernel()
        {
            this.Load(new RhinoMocksModule());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RhinoMocksMockingKernel"/> class.
        /// </summary>
        /// <param name="settings">The configuration to use.</param>
        /// <param name="modules">The modules to load into the kernel.</param>
        public RhinoMocksMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
            : base(settings, modules)
        {
            this.Load(new RhinoMocksModule());
        }
    }
}