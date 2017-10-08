// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectSettingsExtensions.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

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