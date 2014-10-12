// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoqIntegrationTest.cs" company="bbv Software Services AG">
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

namespace Ninject.MockingKernel.Moq
{
    using System;
    using System.Reflection;

    using FluentAssertions;
    using global::Moq;

    using Ninject.Components;

    using Xunit;

    /// <summary>
    /// Integration test for the moq mocking kernel.
    /// </summary>
    public class MoqIntegrationTest : IntegrationTest
    {
        /// <summary>
        /// Mocks are loose by default
        /// </summary>
        [Fact]
        public void MocksAreLooseByDefault()
        {
            using (var kernel = this.CreateKernel())
            {
                var mock = kernel.Get<IDummyService>();

                Assert.DoesNotThrow(mock.Do);
             }
        }
    
        /// <summary>
        /// Mocks are loose by default
        /// </summary>
        [Fact]
        public void MocksAreStrictIfConfigured()
        {
            var settings = new NinjectSettings();
            settings.SetMockBehavior(MockBehavior.Strict);

            using (var kernel = new MoqMockingKernel(settings))
            {
                var mock = kernel.Get<IDummyService>();

                Assert.Throws<MockException>(() => mock.Do());
            }
        }

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
        /// <summary>
        /// Mocks are loose by default
        /// </summary>
        [Fact]
        public void MockRepositoryCanBeAccessed()
        {
            using (var kernel = new MoqMockingKernel())
            {
                kernel.Components.RemoveAll<IMockRepositoryProvider>();
                kernel.Components.Add<IMockRepositoryProvider, TestMockRepositoryProvider>();
                var repository = new MockRepository(MockBehavior.Default);
                TestMockRepositoryProvider.Repository = repository;

                kernel.MockRepository.Should().BeSameAs(repository);
            }
        }
#endif
       
        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>The newly created kernel.</returns>
        protected override MockingKernel CreateKernel()
        {
            return new MoqMockingKernel();
        }
        
        /// <summary>
        /// Asserts that do was called.
        /// </summary>
        /// <param name="dummyService">The dummy service.</param>
        protected override void AssertDoWasCalled(IDummyService dummyService)
        {
            Mock.Get(dummyService).Verify(service => service.Do());
        }

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
        public class TestMockRepositoryProvider : NinjectComponent, IMockRepositoryProvider
        {
            public static MockRepository Repository { get; set; }

            public MockRepository Instance
            {
                get
                {
                    return Repository;
                }
            }

            public MethodInfo CreateMethod
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public MethodInfo AddAdditionalInterfaceMethod
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
#endif
    }
}