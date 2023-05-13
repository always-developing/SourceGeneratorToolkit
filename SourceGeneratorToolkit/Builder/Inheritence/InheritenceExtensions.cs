using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for inheritence
    /// </summary>
    public static class InheritenceExtensions
    {
        /// <summary>
        /// Adds inheritence to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="baseClassName">The base class name to inherit from</param>
        /// <returns>The parent container</returns>
        public static TContainer WithInheritence<TContainer>(this ISupportsInheritence<TContainer> @base, string baseClassName) where TContainer : SourceContainer
        {
            @base.Inherits.AddInheritence(baseClassName);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds inheritence to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="baseClass">The base class to inherit from</param>
        /// <returns>The parent container</returns>
        public static TContainer WithInheritence<TContainer>(this ISupportsInheritence<TContainer> @base, Type baseClass) where TContainer : SourceContainer
        {
            @base.Inherits.AddInheritence(baseClass.Name);

            return (TContainer)@base;
        }
    }
}
