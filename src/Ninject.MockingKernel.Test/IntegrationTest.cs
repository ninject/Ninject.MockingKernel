// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationTest.cs" company="bbv Software Services AG">
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

namespace Ninject.MockingKernel
{
    using FluentAssertions;

    using Xunit;
    
    /// <summary>
    /// Abstract test base for testing mocking kernel implementations
    /// </summary>
    public abstract class IntegrationTest
    {
        /// <summary>
        /// A dummy interface
        /// </summary>
        public interface IDummyService
        {
            /// <summary>
            /// A dummy method.
            /// </summary>
            void Do();
        }

        /// <summary>
        /// Mocks are singletons.
        /// </summary>
        [Fact]
        public void MocksAreSingletons()
        {
            using (var kernel = this.CreateKernel())
            {
                var firstReference = kernel.Get<IDummyService>();
                var secondReference = kernel.Get<IDummyService>();

                firstReference.Should().BeSameAs(secondReference);
            }
        }

        /// <summary>
        /// Reals the objects are created for auto bindable types.
        /// </summary>
        [Fact]
        public void RealObjectsAreCreatedForAutoBindableTypes()
        {
            using (var kernel = this.CreateKernel())
            {
                var instance = kernel.Get<DummyClass>();

                instance.Should().NotBeNull();
            }
        }

        /// <summary>
        /// Reals objects are singletons.
        /// </summary>
        [Fact]
        public void RealObjectsAreSingletons()
        {
            using (var kernel = this.CreateKernel())
            {
                var instance1 = kernel.Get<DummyClass>();
                var instance2 = kernel.Get<DummyClass>();

                instance1.Should().BeSameAs(instance2);
            }
        }

        /// <summary>
        /// The injected dependencies are actually mocks.
        /// </summary>
        [Fact]
        public void TheInjectedDependenciesAreMocks()
        {
            using (var kernel = this.CreateKernel())
            {
                var instance = kernel.Get<DummyClass>();
                instance.DummyService.Do();

                this.AssertDoWasCalled(instance.DummyService);
            }
        }

        /// <summary>
        /// Asserts that do was called.
        /// </summary>
        /// <param name="dummyService">The dummy service.</param>
        protected abstract void AssertDoWasCalled(IDummyService dummyService);

        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>The newly created kernel.</returns>
        protected abstract MockingKernel CreateKernel();

        /// <summary>
        /// A dummy test class.
        /// </summary>
        public class DummyClass
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DummyClass"/> class.
            /// </summary>
            /// <param name="dummyService">The dummy service.</param>
            public DummyClass(IDummyService dummyService)
            {
                this.DummyService = dummyService;
            }

            /// <summary>
            /// Gets or sets the dummy service.
            /// </summary>
            /// <value>The dummy service.</value>
            public IDummyService DummyService { get; set; }
        }
    }
}