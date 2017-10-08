// -------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInterfaceParameter.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010 bbv Software Services AG
//   Copyright (c) 2011-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.MockingKernel
{
    using System;
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;

    /// <summary>
    /// Additional interface to implement for the mock.
    /// </summary>
    public class AdditionalInterfaceParameter : IParameter
    {
        /// <summary>
        /// The type of additional interface.
        /// </summary>
        private Type additionalInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalInterfaceParameter"/> class.
        /// </summary>
        /// <param name="additionalInterface">The type of additional interface.</param>
        public AdditionalInterfaceParameter(Type additionalInterface)
        {
            this.additionalInterface = additionalInterface;
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the parameter should be inherited into child requests.
        /// </summary>
        public bool ShouldInherit
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Get the interface array.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">The target</param>
        /// <returns>The interface type.</returns>
        public object GetValue(IContext context, ITarget target)
        {
            return this.additionalInterface;
        }

        /// <summary>
        /// Determines whether the object equals the specified object.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>True</c> if the objects are equal; otherwise <c>false</c>.</returns>
        public bool Equals(IParameter other)
        {
            throw new NotImplementedException();
        }
    }
}