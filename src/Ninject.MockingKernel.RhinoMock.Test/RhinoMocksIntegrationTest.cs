// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RhinoMocksIntegrationTest.cs" company="bbv Software Services AG">
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
// --------------------------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel.RhinoMock
{
#if !NO_RHINOMOCKS_SILVERLIGHT_TESTS
    using Rhino.Mocks;

    /// <summary>
    /// Tests the rhino mocks mocking kernel.
    /// </summary>
    public class RhinoMocksIntegrationTest : IntegrationTest
    {
        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>The newly created kernel.</returns>
        protected override MockingKernel CreateKernel()
        {
            return new MockingKernel(new NinjectSettings(), new RhinoMocksModule());
        }

        /// <summary>
        /// Asserts that do was called.
        /// </summary>
        /// <param name="dummyService">The dummy service.</param>
        protected override void AssertDoWasCalled(IDummyService dummyService)
        {
            dummyService.AssertWasCalled(s => s.Do());
        }
    }
#endif
}