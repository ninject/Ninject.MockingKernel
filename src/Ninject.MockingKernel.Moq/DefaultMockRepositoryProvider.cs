//-------------------------------------------------------------------------------
// <copyright file="DefaultMockRepositoryProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
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
//-------------------------------------------------------------------------------

#if !SILVERLIGHT_30 && !SILVERLIGHT_20 && !NETCF
namespace Ninject.MockingKernel.Moq
{
    using System;
    using System.Reflection;
    using global::Moq;
    using Ninject.Components;

    /// <summary>
    /// Providers a MockRepository that is configured as Loose by default.
    /// The MockBehavior can be overridden by setting a different one on the NinjectSettings 
    /// using SetMockBehavior.
    /// </summary>
    public class DefaultMockRepositoryProvider : NinjectComponent, IMockRepositoryProvider
    {
        /// <summary>
        /// the instance of the mock repository.
        /// </summary>
        private MockRepository instance;

        /// <summary>
        /// Gets the method info of the create method.
        /// </summary>
        private MethodInfo createMethod;

        /// <summary>
        /// Gets the method info of the add additional interface method.
        /// </summary>
        private MethodInfo addAdditionalInterfaceMethod;

        /// <summary>
        /// Gets the instance of the mock repository.
        /// </summary>
        /// <value>The instance of the mock repository.</value>
        public MockRepository Instance
        {
            get
            {
                if (this.instance == null)
                {
                    this.instance = new MockRepository(this.Settings.GetMockBehavior());                                    
                    this.instance.CallBase = this.Settings.GetMockCallBase();
                    this.instance.DefaultValue = this.Settings.GetMockDefaultValue();
                }

                return this.instance;
            }
        }

        /// <summary>
        /// Gets the method info of the create method.
        /// </summary>
        /// <value>The method info of the create method.</value>
        public MethodInfo CreateMethod
        {
            get
            {
                if (this.createMethod == null)
                {
                    this.createMethod = this.Instance.GetType().GetMethod("Create", new Type[0]);
                }

                return this.createMethod;
            }
        }

        /// <summary>
        /// Gets the method info of the add additional interface method.
        /// </summary>
        /// <value>The method info of the add additional interface method.</value>
        public MethodInfo AddAdditionalInterfaceMethod
        {
            get
            {
                if (this.addAdditionalInterfaceMethod == null)
                {
                    this.addAdditionalInterfaceMethod = typeof(Mock).GetMethod("As");
                }

                return this.addAdditionalInterfaceMethod;
            }
        }
    }
}
#endif