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
        /// The key used to store the mock call base behavior in the ninject settings.
        /// </summary>
        private const string MockCallBase = "MockCallBase";

        /// <summary>
        /// The key used to store the mock default return value in the ninject settings.
        /// </summary>
        private const string MockDefaultValue = "MockDefaultValue";

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

        /// <summary>
        /// Sets the mock call base behavior.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <param name="mockCallBase">The mock call base behavior.</param>
        public static void SetMockCallBase(this INinjectSettings settings, bool mockCallBase)
        {
            settings.Set(MockCallBase, mockCallBase);
        }

        /// <summary>
        /// Gets the mock call base behavior.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <returns>The configured mock call base behavior.</returns>
        public static bool GetMockCallBase(this INinjectSettings settings)
        {
            return settings.Get(MockCallBase, false);
        }

        /// <summary>
        /// Sets the mock default return value.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <param name="mockDefaultValue">The mock default return value.</param>
        public static void SetMockDefaultValue(this INinjectSettings settings, DefaultValue mockDefaultValue)
        {
            settings.Set(MockDefaultValue, mockDefaultValue);
        }

        /// <summary>
        /// Gets the mock default return value.
        /// </summary>
        /// <param name="settings">The ninject settings.</param>
        /// <returns>The configured mock default return value.</returns>
        public static DefaultValue GetMockDefaultValue(this INinjectSettings settings)
        {
            return settings.Get(MockDefaultValue, DefaultValue.Empty);
        }
    }
}