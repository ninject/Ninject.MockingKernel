//-------------------------------------------------------------------------------
// <copyright file="NinjectSettingsExtensions.cs" company="Ninject Project Contributors">
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

namespace Ninject.MockingKernel.Moq
{
    using global::Moq;

    /// <summary>
    /// Extends the ninject settings with a getter and setter method for the default mock behavior.
    /// </summary>
    public static class NinjectSettingsExtensions
    {
        /// <summary>
        /// The key used to store the mock behavior in the ninject settings. 
        /// </summary>
        private const string MockBehaviorSettingsKey = "MockBehavior";

        /// <summary>
        /// Sets the mock behavior.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <param name="mockBehavior">The mock behavior.</param>
        public static void SetMockBehavior(this INinjectSettings settings, MockBehavior mockBehavior)
        {
            settings.Set(MockBehaviorSettingsKey, mockBehavior);
        }

        /// <summary>
        /// Gets the mock behavior.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <returns>The configured mock behavior.</returns>
        public static MockBehavior GetMockBehavior(this INinjectSettings settings)
        {
            return settings.Get(MockBehaviorSettingsKey, MockBehavior.Default);
        }
    }
}